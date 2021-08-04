using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PostImageValidator: AbstractValidator<PostImageDto>
    {
        IPostImageRepository _postImageRepository;
        public PostImageValidator()
        {
            _postImageRepository = new PostImageRepository();
            RuleFor(p => p.Image).NotEmpty();
            RuleFor(p => p.PostId).Must(LessMoreThan).WithMessage("There should be max 8 images");
            
        }
        public bool LessMoreThan(int postId)
        {
            return _postImageRepository.GetAll(p => p.PostId == postId).Count < 8;
        }
    }
}
