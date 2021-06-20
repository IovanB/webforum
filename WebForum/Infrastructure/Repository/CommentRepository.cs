using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebForum.Domain.Entities;

namespace WebForum.Infrastructure.Repository
{
    public class CommentRepository : ICommentWriteOnlyUseCase, ICommentReadOnlyUseCase
    {
        public int Add(Comment comment)
        {
            using (var applicationContext = new Context.ApplicationContext())
            {
                applicationContext.Post.Attach(comment.Post);
                applicationContext.User.Attach(comment.Author);
                applicationContext.Add(comment);
                return applicationContext.SaveChanges();
            }
        }
        public List<Comment> GetAll()
        {
            using (var context = new Context.ApplicationContext())
            {
                return context.Comment.Include(x => x.Author).Include(x => x.Post).ToList();
            }
        }

        public Comment GetById(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                return context.Comment.Find(id);
            }
        }

        public int Remove(Comment comment)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Remove(comment);
                return context.SaveChanges();
            }
        }
        public int Update(Comment comment)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Post.Attach(comment.Post);
                context.User.Attach(comment.Author);
                context.Update(comment);
                return context.SaveChanges();
            }
        }
    }
}
