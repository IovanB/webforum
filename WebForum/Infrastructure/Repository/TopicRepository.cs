using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebForum.Domain.Entities;

namespace WebForum.Infrastructure.Repository
{
    public class TopicRepository : ITopicWriteOnlyUseCase, ITopicReadOnlyUseCase
    {
        public int Add(Topic topic)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Category.Attach(topic.Category);

                context.Add(topic);
                return context.SaveChanges();
            }
        }

        public List<Topic> GetAll()
        {
            using (var context = new Context.ApplicationContext())
            {
                return context.Topic.Include(x => x.Category).ToList();
            }
        }

        public Topic GetById(Guid id)
        {

            using (var context = new Context.ApplicationContext())
            {
                return context.Topic.Find(id);
            }
        }

        public int Remove(Topic topic)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Remove(topic);
                return context.SaveChanges();
            }
        }

        public int Update(Topic topic)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Update(topic);
                return context.SaveChanges();
            }
        }
    }
}
