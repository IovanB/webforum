using Application.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class PostRepository : IPostWriteOnlyUseCase, IPostReadOnlyUseCase
    {
        private readonly IMapper mapper;

        public PostRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public int Add(Post post)
        {
            var model = mapper.Map<List<Data.Entity.Entities.Post>>(post);
            using (var applicationContext = new Context.ApplicationContext())
            {
                applicationContext.Topic.Attach(post.Topic);
                applicationContext.User.Attach(post.Author);
                applicationContext.Add(model);
                applicationContext.SaveChanges();
            }
            return 1;
        }

        public IList<Post> GetAll()
        {
            var list = new List<Post>();
            using (var context = new Context.ApplicationContext())
            {
                list = mapper.Map<List<Post>>(context.Post.Include(x => x.Topic).Include(x => x.Topic.Category).Include(y => y.Author)).ToList();
            }
            return list;
        }

        public Post GetById(Guid id)
        {
            using(var context = new Context.ApplicationContext())
            {
                return mapper.Map<Post>(context.Post.FirstOrDefault(x => x.Id == id));
            }
        }

        public int Remove(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                var model = context.Post.FirstOrDefault(x => x.Id == id);
                context.Remove(model);
                return context.SaveChanges();
            }
        }
        public int Save(Post post)
        {
            if (GetById(post.Id) == null)
                return Add(post);
            else
                return Update(post);
        }
        public int Update(Post post)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Topic.Attach(post.Topic);
                context.Entry(mapper.Map<Data.Entity.Entities.Post>(post)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
