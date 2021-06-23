using Application.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserReadOnlyUseCase, IUserWriteOnlyUseCase
    {
        private readonly IMapper mapper;

        public UserRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(User user)
        {
            var model = mapper.Map<List<Data.Entity.Entities.User>>(user);
            using (var context = new Context.ApplicationContext())
            {
                context.Add(model);
                context.SaveChanges();
            }
            return 1;
        }

        public User FindByLogin(string name)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.User.SingleOrDefault(x => x.Name.Equals(name));
                return FindByLogin(name);
            }
        }

        public IList<User> GetAll()
        {
            var list = new List<User>();
            using (var context = new Context.ApplicationContext())
            {
                list = mapper.Map<List<User>>(context.User.ToList());
            }
            return list;
        }

        public User GetById(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {
                return mapper.Map<User>(context.User.FirstOrDefault(x => x.Id == id));
            }
        }

        public User GetByName(string name, string password)
        {
            using (var context = new Context.ApplicationContext())
            {
                return mapper.Map<User>(context.User.SingleOrDefault( x => x.Name.Equals(name) && x.Password.Equals(password)));
            }
        }

        public int Remove(Guid id)
        {
            using(var context = new Context.ApplicationContext())
            {
                var model = context.User.FirstOrDefault(x => x.Id == id);
                return context.SaveChanges();
            }
        }

        public int Save(User user)
        {
            if (GetById(user.Id) == null)
                return Add(user);
            else
                return Update(user);
        }

        public int Update(User user)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.Entry(mapper.Map<Data.Entity.Entities.User>(user)).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}
