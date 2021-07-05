using Application.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class TopicRepository : ITopicWriteOnlyUseCase, ITopicReadOnlyUseCase
    {
        private readonly IMapper mapper;

        public TopicRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public int Add(Topic topic)
        {
            var model = mapper.Map<Data.Entity.Entities.Topic>(topic);
            using (var context = new Context.ApplicationContext())
            {
                context.Topic.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public IList<Topic> GetAll()
        {
            var list = new List<Topic>();
            using (var context = new Context.ApplicationContext())
            {
                list = mapper.Map<List<Topic>>(context.Topic.Include(x => x.Category).ToList());
            }
            return list;
            
        }

        public Topic GetById(Guid id)
        {

            using (var context = new Context.ApplicationContext())
            {
                return mapper.Map<Topic>(context.Topic.FirstOrDefault(x => x.Id == id));
            }
        }

        public int Remove(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                var model = context.Topic.FirstOrDefault(x => x.Id == id);
                context.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Save(Topic topic)
        {
            if (GetById(topic.Id) == null)
                return Add(topic);
            else
                return Update(topic);
        }

        public int Update(Topic topic)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Entry(mapper.Map<Data.Entity.Entities.Topic>(topic)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
