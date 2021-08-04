using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category:BaseModel,IEntity
    {
        public string Name { get; set; }
        public string Keywords { get; set; }
    }
}
