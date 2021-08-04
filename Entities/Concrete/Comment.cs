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
    public class Comment:BaseModel,IEntity
    {
        public int PostId { get; set; } 
        public Nullable<int> CommentId { get; set; } 
        public string Text { get; set; } 
    }
}
