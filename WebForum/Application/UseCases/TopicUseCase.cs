using Infrastructure.PostgresData.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
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
                await _unitOfWork.Topics.Delete(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Insert(Domain.Entities.Topic entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var category = await _unitOfWork.Categories.GetById(entity.CategoryId) ?? throw new ApplicationException("Category not found");
                await _unitOfWork.Topics.Add(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task UpdateEntity(Domain.Entities.Topic entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var category = await _unitOfWork.Categories.GetById(entity.CategoryId) ?? throw new ApplicationException("Category not found");
                _unitOfWork.Topics.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Domain.Entities.Topic>> GetAll()
        {
            var topics = await _unitOfWork.Topics.GetAll();
            if (topics == null)
                return [];

            return topics.ToList();
        }

        public async Task<Domain.Entities.Topic> GetById(int id)
        {
            var topics = await _unitOfWork.Topics.GetById(id);
            if (topics is null)
            {
                return null;
            }
            return topics;
        }
    }
}
