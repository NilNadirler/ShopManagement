using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entegrations.CloudinaryManagement
{
    public class ImageManagement
    {
        Cloudinary _cloudinary;
        public ImageManagement()
        {
            Account account = new Account(
                "dbzscmgzj",
                "465219415676227",
                "UH3UJOUuJdMAKgkwAKJ9xRxutkU");
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }
        public string  ImageUpload(string imageName,Stream imageStream)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imageName, imageStream)
            };
            var uploadResult = _cloudinary.Upload(uploadParams);
            return uploadResult.SecureUrl.AbsoluteUri;
        }
    }
}
