using System;
using System.Collections.Generic;
using System.Linq;
using Application.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class CommentRepository : ICommentWriteOnlyUseCase, ICommentReadOnlyUseCase
    {
        private readonly IMapper mapper;

        public CommentRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public int Add(Comment comment)
        {
            var model = mapper.Map<List<Data.Entity.Entities.Comment>>(comment);
            using (var applicationContext = new Context.ApplicationContext())
            {
                applicationContext.Post.Attach(comment.Post);
                applicationContext.User.Attach(comment.Author);
                applicationContext.Add(model);
                applicationContext.SaveChanges();
            }
            return 1;
        }
        public IList<Comment> GetAll()
        {
            var list = new List<Comment>();
            using (var context = new Context.ApplicationContext())
            {
                list = mapper.Map<List<Comment>>(context.Comment.Include(x => x.Author).Include(x => x.Post)).ToList();
            }
            return list;
        }

        public Comment GetById(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                return mapper.Map<Comment>(context.Post.FirstOrDefault(x => x.Id == id));
            }
        }

        public int Remove(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                var model = context.Comment.FirstOrDefault(x => x.Id == id);
                context.Remove(model);
                return context.SaveChanges();
            }
        }

        public int Save(Comment comment)
        {
            if (GetById(comment.Id) == null)
                return Add(comment);
            else
                return Update(comment);
        }

        public int Update(Comment comment)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Post.Attach(comment.Post);
                context.User.Attach(comment.Author);
                context.Entry(mapper.Map<Data.Entity.Entities.Comment>(comment)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
