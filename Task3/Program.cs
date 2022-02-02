using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext(true))
            {
                var user1 = new User { Name = "Ivan", Email = "ivan@mail.ru" };
                var user2 = new User { Name = "Petr", Email = "petr@mail.ru" };

                var author1 = new Author { Name = "Толстой Л.Н." };
                var author2 = new Author { Name = "Пелевин В.О." };

                var genre1 = new Genre { Name = "Роман эпопея" };
                var genre2 = new Genre { Name = "Роман в рассказах" };

                var book1 = new Book { Name = "Война и мир", Author = author1, YearOfRelease = 1873, Genre = genre1 };
                var book2 = new Book { Name = "TRANSHUMANISM INC.", Author = author2, YearOfRelease = 2021, Genre = genre2 };

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
