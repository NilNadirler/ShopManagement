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
    public class LikeOfCommentManager : ILikeOfCommentService
    {
        ILikeOfCommentRepository _likeOfCommentRepository;

        public LikeOfCommentManager(ILikeOfCommentRepository LikeOfCommentRepository)
        {
            _likeOfCommentRepository = LikeOfCommentRepository;
        }

        public IResult Add(LikeOfComment entity)
        {
            _likeOfCommentRepository.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(LikeOfComment entity)
        {
            _likeOfCommentRepository.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<LikeOfComment> GetByID(int id)
        {
            return new SuccessDataResult<LikeOfComment>(_likeOfCommentRepository.Get(m => m.Id == id));
        }

        public IDataResult<List<LikeOfComment>> GetAll()
        {
            return new SuccessDataResult<List<LikeOfComment>>(_likeOfCommentRepository.GetAll());
        }

        public IResult Update(LikeOfComment entity)
        {
            _likeOfCommentRepository.Update(entity);
            return new SuccessResult();
        }
    }
}
