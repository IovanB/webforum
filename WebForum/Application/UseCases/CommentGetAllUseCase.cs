using Infrastructure.PostgresData.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CommentGetAllUseCase : ICommonUseCase<Domain.Entities.Comment>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentGetAllUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteEntity(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var comment = await _unitOfWork.Comments.GetById(id);
                _unitOfWork.Comments.Delete(comment);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Domain.Entities.Comment>> GetAll()
        {
            var comments = await _unitOfWork.Comments.GetAll();
            if (comments == null)
                return [];

            return comments.ToList();
        }

        public async Task<Domain.Entities.Comment> GetById(int id)
        {
            var comment = await _unitOfWork.Comments.GetById(id);
            if (comment is null)
            {
                return null;
            }
            return comment;
        }

        public async Task Insert(Domain.Entities.Comment entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var post = await _unitOfWork.Posts.GetById(entity.PostId) ?? throw new ApplicationException("Post not found");
                await _unitOfWork.Comments.Add(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateEntity(Domain.Entities.Comment entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var post = await _unitOfWork.Posts.GetById(entity.PostId) ?? throw new ApplicationException("Post not found");
                _unitOfWork.Comments.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
