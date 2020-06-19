using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Infrastructure.Repository
{
    public class PostRepository : IPostWriteOnlyUseCase, IPostReadOnlyUseCase
    {
        public int Add(Post post)
        {
            using (var applicationContext = new Context.ApplicationContext())
            {
                applicationContext.Topic.Attach(post.Topic);
                applicationContext.User.Attach(post.Author);
                applicationContext.Add(post);
                return applicationContext.SaveChanges();
            }
        }

        public List<Post> GetAll()
        {
            using(var context = new Context.ApplicationContext())
            {
                return context.Post.Include(x => x.Topic).Include(x => x.Topic.Category).Include(y => y.Author).ToList();
            }
        }

        public Post GetById(Guid id)
        {
            using(var context = new Context.ApplicationContext())
            {
                return context.Post.Find(id);
            }
        }

        public int Remove(Post post)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Remove(post);
                return context.SaveChanges();
            }
        }

        public int Update(Post post)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Topic.Attach(post.Topic);
                context.Update(post);
                return context.SaveChanges();
            }
        }
    }
}
