using Microsoft.AspNetCore.Mvc;
using ShopASP.Features;
using ShopASP.Features.Models;
using System.Net.Mail;

namespace ShopASP.Controllers
{
    public class SendMailController : Controller
    {
        //Injec dịch vụ Email
        private readonly IEmail Email;
        public SendMailController(IEmail Email)
        {
            this.Email = Email;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMail(string mailTo,string message)
        {
            MailMessage mailMessage = new MailMessage(
                from: "vuvietquyacn@gmail.com",
                to: mailTo,
                subject: "Test send Mail",
                body: ""
            );

            MailFile[] mailFiles = new MailFile[]
            {
                new MailFile
                {
                    pathFile= "wwwroot/images/products/ok_2022113055025.jpg",
                    isAttachment= false,
                    cid = "logo"
                },
                new MailFile{ 
                    pathFile= "wwwroot/images/products/ok_2022113061737.jpg",
                }
            };

            object viewData = new
            {
                message
            };

            try
            {
                Email.SendMail(
                    this,
                    "~/Features/Views/Mails/Thanks.cshtml",
                    mailMessage,
                    viewData,
                    mailFiles
                );
                TempData["Message"] = "Gửi mail thành công";
            }
            catch( Exception ex )
            {
                TempData["Message"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
