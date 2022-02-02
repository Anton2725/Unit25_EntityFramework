using System;

namespace Task2
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

                var userRep = new UserRepository(db);
                userRep.AddUser(user1);
                userRep.AddUser(user2);


                var bookRep = new BookRepository(db);
                bookRep.AddBook(book1);
                bookRep.AddBook(book2);

                db.SaveChanges();


                userRep.UpdateUserName(2, "Uran");
                bookRep.UpdateBookYearOfRelease(1, 1869);

            }
        }
    }
}
