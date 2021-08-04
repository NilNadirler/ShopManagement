
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetByID(int Id);
        IDataResult<List<Category>> GetAllDeleted();
        IResult RecoverByID(int Id);
        IResult Add(Category entity);
        IResult Update(Category entity);
        IResult Delete(Category entity);
    }
}
