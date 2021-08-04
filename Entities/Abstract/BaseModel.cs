using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CretedAt { get; set; }
        public int CreatedUser { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedUser { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<int> DeletedUser { get; set; }
    }
}
