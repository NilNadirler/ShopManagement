
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ILikeOfCommentService
    {
        IDataResult<List<LikeOfComment>> GetAll();
        IDataResult<LikeOfComment> GetByID(int Id);
        IResult Add(LikeOfComment entity);
        IResult Update(LikeOfComment entity);
        IResult Delete(LikeOfComment entity);
    }
}
