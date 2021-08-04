using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}

//users ,

// 1  nil
// 2  ali

//OperationClaim
// 1  twmiZlik
// 2  güvenlik
// 3  mutfak
// 4  yazzılım

//UserOperationClaim
// 1 1 1
// 2 1 4
// 3 2 3
