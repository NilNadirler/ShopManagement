using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class LikeOfCommentRepository : EfEntityRepositoryBase<LikeOfComment, ShopManagementContext>, ILikeOfCommentRepository
    {
    }
}
