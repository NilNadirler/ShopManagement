using Business.Abstract;
using Business.ValidationRules.FluentValidation;
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
    public class PostManager : IPostService
    {
        IPostRepository _postRepository;

        public PostManager(IPostRepository PostRepository)
        {
            _postRepository = PostRepository;
        }

        public IResult Add(Post entity)
        {
            _postRepository.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Post entity)
        {
            _postRepository.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Post> GetByID(int id)
        {
            return new SuccessDataResult<Post>(_postRepository.Get(m => m.Id == id));
        }

        public IDataResult<List<Post>> GetAll()
        {
            return new SuccessDataResult<List<Post>>(_postRepository.GetAll());
        }

        public IResult Update(Post entity)
        {
            _postRepository.Update(entity);
            return new SuccessResult();
        }
    }
}
