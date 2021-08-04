using Core.Abstract;
using Entegrations.CloudinaryManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters
{
    public class CloudinaryAdapter : ICloudinaryService
    {
        public string Upload(string name, Stream stream)
        {
            ImageManagement imageManagement = new ImageManagement();
            return imageManagement.ImageUpload(name,stream);
        }
    }
}
