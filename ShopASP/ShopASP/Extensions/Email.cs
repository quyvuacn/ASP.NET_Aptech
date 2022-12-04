using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ShopASP.Features.Models;
using System.Net;
using System.Net.Mail;

namespace ShopASP.Features
{
    public interface IEmail
    {
        void SendMail(Controller controller, string viewPath, MailMessage mailMessage, object model, MailFile[]? mailFiles);
        Task<string> ToHtml(Controller Controller, string viewName, object model);
    }
    public class Email : IEmail
    {
        private const string MY_EMAIL = "vuvietquyacn@gmail.com";
        private const string MY_PASSWORD = "gnxplvksjwiewfdw";
        private SmtpClient SmtpClient
        {
            get
            {
                var SmtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(MY_EMAIL, MY_PASSWORD),
                    EnableSsl = true
                };
                return SmtpClient;
            }
        }


        private readonly IViewRenderService _viewRender;
        private readonly ICompositeViewEngine _viewEngine;
        

        public Email(IViewRenderService viewRender, ICompositeViewEngine viewEngine)
        {
            _viewRender=viewRender;
            _viewEngine=viewEngine;
        }

        public async void SendMail(Controller controller,string viewPath, MailMessage mailMessage,object model, MailFile[]? mailFiles)
        {
            var html = await _viewRender.RenderPartialViewToString(controller,viewPath, model);
            mailMessage.Body= html;
            mailMessage.IsBodyHtml= true;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            if(mailFiles != null)
            {
                foreach (MailFile mailFile in mailFiles)
                {
                    var file = new Attachment(mailFile.pathFile);
                    if (!mailFile.isAttachment)
                    {
                        file.ContentDisposition.Inline = true;
                        file.ContentId = mailFile.cid;
                    }
                    mailMessage.Attachments.Add(file);

                }
            };
            SmtpClient.Send(mailMessage);
        }

        public async Task<string> ToHtml(Controller Controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = Controller.ControllerContext.ActionDescriptor.ActionName;

            Controller.ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult =
                    _viewEngine.GetView(null, viewName, false);

                ViewContext viewContext = new ViewContext(
                    Controller.ControllerContext,
                    viewResult.View,
                    Controller.ViewData,
                    Controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }

        

    }

}
