using Application.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.PostgresData.Repository
{
    public class CategoryRepository : ICategoryWriteOnlyUseCase, ICategoryReadOnlyUseCase
    {
        private readonly IMapper mapper;

        public CategoryRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public int Add(Category category)
        {
            var model = mapper.Map<Data.Entity.Entities.Category>(category);
            using (var context = new Context.ApplicationContext())
            {
                context.Category.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public IList<Category> GetAll()
        {
            var list = new List<Category>();
            using(var context = new Context.ApplicationContext())
            {
                list = mapper.Map<List<Category>>(context.Category.ToList());
            }
            return list;
        }

        public Category GetById(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                return mapper.Map<Category>(context.Category.FirstOrDefault(x => x.Id == id));
            }
        }

        public int Remove(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                var model = context.Category.FirstOrDefault(x => x.Id == id);
                context.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Save(Category category)
        {
            if (GetById(category.Id) == null)
                return Add(category);
            else
                return Update(category);
        }

        public int Update(Category category)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Entry(mapper.Map<Data.Entity.Entities.Category>(category)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
