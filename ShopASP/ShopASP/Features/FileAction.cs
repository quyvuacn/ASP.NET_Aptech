using ShopASP.Features.Models;
using System.Xml.Linq;

namespace ShopASP.Features
{
    public class FileAction 
    {
        //private long SizeMax;
        //private string[] Extensions;
        public FileAction()
        {
            //SizeMax = 10*1024*1024 ;//10mb
        }

        

        public static ActionInfo Upload(FileModel file,string uploadDirecotroy)
        {
            try
            {
                if (!Directory.Exists(uploadDirecotroy))
                    Directory.CreateDirectory(uploadDirecotroy);

                var fileExtension = Path.GetExtension(file.FileData.FileName);
                var fileName = file.FileName + "_" + DateTime.Now.ToString("yyyyMMddhmmss") + fileExtension;
                var filePath = Path.Combine(uploadDirecotroy, fileName);
                using (var strem = File.Create(filePath))
                {
                    file.FileData.CopyTo(strem);
                }
                return new ActionInfo {
                    Completed = true,
                    Result = fileName
                };
            }
            catch(Exception ex)
            {
                return new ActionInfo
                {
                    Completed = false,
                    Result = ex.Message
                };
            }
            
            
        }

        public static ActionInfo Remove(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new ActionInfo { 
                    Completed= true,
                    Result = filePath
                };
            }
            return new ActionInfo { 
                Completed= false,
                Result = filePath
            };
        }

    }
}
