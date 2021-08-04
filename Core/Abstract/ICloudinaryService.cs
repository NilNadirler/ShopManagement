using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface ICloudinaryService
    {
        string Upload(string name, Stream stream);
    }
}
