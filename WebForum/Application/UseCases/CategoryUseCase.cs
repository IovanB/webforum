using Domain.Entities;
using Infrastructure.PostgresData.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CategoryUseCase : ICommonUseCase<Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteEntity(int id)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.Categories.Delete(id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Domain.Entities.Category>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAll();
            if (categories == null)
                return new List<Category>(){ };

            return categories.ToList();

        }

        public async Task<Category> GetById(int id)
        {
            var category = await _unitOfWork.Categories.GetById(id);
            if (category is null)
            {
                return null;
            }
            return category;
        }

        public async Task Insert(Category entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.Categories.Add(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateEntity(Category entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                _unitOfWork.Categories.Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
