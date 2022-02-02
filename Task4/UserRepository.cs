using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
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
        
        //Получаем булевый флаг о том, есть ли определенная книга на руках у пользователя
        public bool UserHasBook(int bookId)
        {
            return context.Users.Any(u => u.Books.Any(b => b.Id == bookId));
        }

        //Получаем количество книг на руках у пользователя
        public int UserBooksCount(int userId)
        {
            return context.Books.Where(b => b.User.Id == userId).Count();
        }

    }
}
