using Infrastructure.PostgresData.Repository.UnitOfWork;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace Application.UseCases
{
    public class PostGetAllUseCase : ICommonUseCase<Domain.Entities.Post>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostGetAllUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteEntity(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var post = await _unitOfWork.Posts.GetById(id);
                _unitOfWork.Posts.Delete(post);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Domain.Entities.Post>> GetAll()
        {
            var posts = await _unitOfWork.Posts.GetAll();
            if (posts == null)
                return [];

            return posts.ToList();
        }

        public async Task<Domain.Entities.Post> GetById(int id)
        {
            var post = await _unitOfWork.Posts.GetById(id);
            if (post is null)
            {
                return null;
            }
            return post;
        }

        public async Task Insert(Domain.Entities.Post entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var topic = await _unitOfWork.Topics.GetById(entity.TopicId) ?? throw new ApplicationException("Topic not found");
                await _unitOfWork.Posts.Add(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateEntity(Domain.Entities.Post entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var topic = await _unitOfWork.Topics.GetById(entity.TopicId) ?? throw new ApplicationException("Topic not found");
                _unitOfWork.Posts.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
