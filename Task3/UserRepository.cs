using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class UserRepository
    {
        private AppContext context = new AppContext();

        public UserRepository(AppContext context)
        {
            this.context = context;
        }

        public User GetUser(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public void RemoveUser(User user)
        {
            context.Users.Remove(user);
        }

        public void UpdateUserName(int id, string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.Name = name;
                context.SaveChanges();
            }
        }
    }
}
