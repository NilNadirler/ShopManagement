using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Abstract;
using Core.Aspects.Autofac.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostImageManager : IPostImageService
    {
        IPostImageRepository _postImageRepository;
        ICloudinaryService _cloudinaryService;

        public PostImageManager(IPostImageRepository postImageRepository, ICloudinaryService cloudinaryService)
        {
            _postImageRepository = postImageRepository;
            _cloudinaryService = cloudinaryService;
        }

        [ValidationAspect(typeof(PostImageValidator))]
        public IResult Add(PostImageDto dto)
        {
            string imagePath= _cloudinaryService.Upload("Shop", dto.Image.OpenReadStream());
            PostImage postImage = new PostImage();
            postImage.Id = dto.Id;
            postImage.PostId = dto.PostId;
            postImage.Image = imagePath;
            postImage.CretedAt = dto.CretedAt;
            postImage.CreatedUser = dto.CreatedUser;
            _postImageRepository.Add(postImage);
            return new SuccessResult();
        }

        public IResult Delete(PostImage entity)
        {
            entity=_postImageRepository.Get(p => p.Id == entity.Id);
            entity.DeletedAt = DateTime.Now;
            entity.DeletedUser = 1;
            _postImageRepository.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<PostImage> GetByID(int id)
        {
            return new SuccessDataResult<PostImage>(_postImageRepository.Get(m => m.Id == id));
        }

        public IDataResult<List<PostImage>> GetAll()
        {
            return new SuccessDataResult<List<PostImage>>(_postImageRepository.GetAll());
        }

        public IResult Update(PostImageDto dto)
        {
            string imagePath = _cloudinaryService.Upload("Shop", dto.Image.OpenReadStream());
            PostImage postImage = new PostImage();
            postImage.Id = dto.Id;
            postImage.PostId = dto.PostId;
            postImage.Image = imagePath;
            postImage.UpdatedAt = dto.UpdatedAt;
            postImage.UpdatedUser = dto.UpdatedUser;
            _postImageRepository.Update(postImage);
            return new SuccessResult();
        }

        public IDataResult<List<PostImage>> GetAllDeleted()
        {
            return new SuccessDataResult<List<PostImage>>(_postImageRepository.GetAll(c => c.DeletedAt != null));
        }

        public IResult RecoverByID(int Id)
        {
            PostImage postImage = _postImageRepository.Get(c => c.Id == Id);
            postImage.DeletedAt = null;
            postImage.DeletedUser = null;
            _postImageRepository.Update(postImage);
            return new SuccessResult();
        }
    }
}
