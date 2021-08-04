using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        //[yetkikontrol("Category.Add,admin")]
        [SecuredOperation("Category.Add")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category entity)
        {
            _categoryRepository.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Category entity)
        {
            entity=_categoryRepository.Get(c=>c.Id==entity.Id);
            entity.DeletedAt = DateTime.Now;
            entity.DeletedUser = 1;//default
            _categoryRepository.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Category> GetByID(int id)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(c => c.Id == id));
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll(c=> c.DeletedAt==null));
        }

        public IResult Update(Category entity)
        {
            _categoryRepository.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll(c => c.DeletedAt != null));
        }

        public IResult RecoverByID(int Id)
        {
            Category category= _categoryRepository.Get(c => c.Id == Id);
            category.DeletedAt = null;
            category.DeletedUser = null;
            _categoryRepository.Update(category);
            return new SuccessResult();
        }
    }
}
