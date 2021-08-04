using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post : BaseModel, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
