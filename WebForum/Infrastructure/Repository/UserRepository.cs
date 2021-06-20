using System;
using System.Collections.Generic;
using System.Linq;
using WebForum.Application.Repositories;
using WebForum.Domain.Entities;

namespace WebForum.Infrastructure.Repository
{
    public class UserRepository : IWriteOnlyUseCase<User>, IReadOnlyUseCase<User>
    {

        public int Add(User user)
        {
            using(var context = new Context.ApplicationContext())
            {
                context.User.Add(user);
                return context.SaveChanges();
            }
        }

        public User FindByLogin(string name)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.User.SingleOrDefault(x => x.Name.Equals(name));
                return FindByLogin(name);
            }
        }

        public List<User> GetAll()
        {
            using (var context = new Context.ApplicationContext())
            {
                return context.User.ToList();
            }
        }

        public User GetById(Guid id)
        {
            using (var context = new Context.ApplicationContext())
            {   
                return context.User.Find(id);
            }
        }

        public User GetByName(string name, string password)
        {
            using (var context = new Context.ApplicationContext())
            {
                return context.User.SingleOrDefault( x => x.Name.Equals(name) && x.Password.Equals(password));
            }
        }

        public int Remove(User user)
        {
            using(var context = new Context.ApplicationContext())
            {
                context.User.Remove(user);
                return context.SaveChanges();
            }
        }

        public int Update(User user)
        {
            using (var context = new Context.ApplicationContext())
            {
                context.User.Update(user);
                return context.SaveChanges();
            }
        }
    }
}
