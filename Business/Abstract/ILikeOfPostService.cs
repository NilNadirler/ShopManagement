
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ILikeOfPostService
    {
        IDataResult<List<LikeOfPost>> GetAll();
        IDataResult<LikeOfPost> GetByID(int Id);
        IResult Add(LikeOfPost entity);
        IResult Update(LikeOfPost entity);
        IResult Delete(LikeOfPost entity);
    }
}
