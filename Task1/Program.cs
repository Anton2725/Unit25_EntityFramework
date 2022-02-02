using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext(true))
            {
                var user1 = new User { Name = "Ivan", Email = "ivan@mail.ru" };
                var user2 = new User { Name = "Petr", Email = "petr@mail.ru" };

                var book1 = new Book { Name = "Война и мир", Author = "Толстой Л.Н.", YearOfRelease = 1873 };
                var book2 = new Book { Name = "TRANSHUMANISM INC.", Author = "Пелевин В.О.", YearOfRelease = 2021 };

                db.Users.AddRange(user1, user2);
                db.Books.AddRange(book1, book2);

                db.SaveChanges();
            }
        }
    }
}
