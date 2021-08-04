using Business.Abstract;
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
    public class LikeOfPostManager : ILikeOfPostService
    {
        ILikeOfPostRepository _likeOfPostRepository;

        public LikeOfPostManager(ILikeOfPostRepository LikeOfPostRepository)
        {
            _likeOfPostRepository = LikeOfPostRepository;
        }

        public IResult Add(LikeOfPost entity)
        {
            _likeOfPostRepository.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(LikeOfPost entity)
        {
            _likeOfPostRepository.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<LikeOfPost> GetByID(int id)
        {
            return new SuccessDataResult<LikeOfPost>(_likeOfPostRepository.Get(m => m.Id == id));
        }

        public IDataResult<List<LikeOfPost>> GetAll()
        {
            return new SuccessDataResult<List<LikeOfPost>>(_likeOfPostRepository.GetAll());
        }

        public IResult Update(LikeOfPost entity)
        {
            _likeOfPostRepository.Update(entity);
            return new SuccessResult();
        }
    }
}
