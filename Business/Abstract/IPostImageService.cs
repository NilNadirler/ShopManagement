
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPostImageService
    {
        IDataResult<List<PostImage>> GetAll();
        IDataResult<PostImage> GetByID(int Id);
        IDataResult<List<PostImage>> GetAllDeleted();
        IResult RecoverByID(int Id);
        IResult Add(PostImageDto dto);
        IResult Update(PostImageDto dto);
        IResult Delete(PostImage entity);
    }
}
