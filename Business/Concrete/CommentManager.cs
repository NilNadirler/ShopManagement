using Business.Abstract;
using Business.Constants;
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
    public class CommentManager : ICommentService

    {
        ICommentRepository _commentRepository;

        public CommentManager(ICommentRepository CommentRepository)
        {
            _commentRepository = CommentRepository;
        }

        public IResult Add(Comment entity)
        {
            _commentRepository.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Comment entity)
        {
            _commentRepository.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Comment> GetByID(int id)
        {
            return new SuccessDataResult<Comment>(_commentRepository.Get(m => m.Id == id));
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentRepository.GetAll());
        }

        public IResult Update(Comment entity)
        {
            _commentRepository.Update(entity);
            return new SuccessResult();
        }
    }
}
