using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class PostImageDto:IDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public IFormFile Image { get; set; }
        public DateTime CretedAt { get; set; }
        public int CreatedUser { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public Nullable<int> UpdatedUser { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<int> DeletedUser { get; set; }
    }
}
