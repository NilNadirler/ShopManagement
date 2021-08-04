using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        ICategoryRepository _categoryRepository;
        public CategoryValidator()
        {
            _categoryRepository = new CategoryRepository();
            RuleFor(c => c.Name).Must(IsNameUnique).WithMessage("The name of the category must be unique.");
            RuleFor(c => c.Keywords).NotEmpty();
        }
        public bool IsNameUnique(string newValue)
        {
            return _categoryRepository.GetAll(c => c.Name == newValue).Count()<1;
        }
    }
}
