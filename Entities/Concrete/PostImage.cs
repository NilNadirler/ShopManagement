using Core.Entities;
using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PostImage:BaseModel,IEntity
    {
        public int PostId { get; set; }
        public string Image { get; set; }
    }
}
