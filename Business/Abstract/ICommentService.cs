
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<Comment> GetByID(int Id);
        IResult Add(Comment entity);
        IResult Update(Comment entity);
        IResult Delete(Comment entity);
    }
}
