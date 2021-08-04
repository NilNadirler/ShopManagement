using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class CommentRepository : EfEntityRepositoryBase<Comment, ShopManagementContext>, ICommentRepository
    {
        //Merhaba dünya
    }
}
