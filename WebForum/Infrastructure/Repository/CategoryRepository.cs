using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryWriteOnlyUseCase, ICategoryReadOnlyUseCase
    {
        public int Add(Category category)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Add(category);
                return context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            using(var context = new Context.ApplicationContext())
            {
                return context.Category.ToList();
            }
        }

        public Category GetById(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                return context.Category.Find(id);
            }
        }

        public int Remove(Category category)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Remove(category);
                return context.SaveChanges();
            }
        }

        public int Update(Category category)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Update(category);
                return context.SaveChanges();
            }
        }
    }
}
