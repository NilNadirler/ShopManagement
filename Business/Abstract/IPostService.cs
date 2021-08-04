
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPostService
    {
        IDataResult<List<Post>> GetAll();
        IDataResult<Post> GetByID(int Id);
        IResult Add(Post entity);
        IResult Update(Post entity);
        IResult Delete(Post entity);
    }
}
