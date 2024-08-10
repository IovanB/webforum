using Application.UseCases;
using Application.UseCases.Topic.Get;
using Infrastructure.PostgresData.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebForum.Application.UseCases.Topic
{
    public class TopicUseCase : ICommonUseCase<Domain.Entities.Topic>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TopicUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteEntity(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var topic = await _unitOfWork.Topics.GetById(id);
                _unitOfWork.Categories.Delete(topic);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Execute(TopicGetRequest request)
        {
            try
            {
                var req = topicReadOnlyUseCase.GetById(request.Id);
                if (req == null)
                    throw new ArgumentException("There is no topic");

                output.Standard(req);
            }
            catch (Exception ex)
            {
                output.Error($"Error while processing Topic {ex.Message}");
            }
        }

       

        public Task Insert(Domain.Entities.Topic entity)
        {
            throw new NotImplementedException();
        }


        public Task UpdateEntity(Domain.Entities.Topic entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Domain.Entities.Topic>> ICommonUseCase<Domain.Entities.Topic>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Domain.Entities.Topic> ICommonUseCase<Domain.Entities.Topic>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
