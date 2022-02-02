using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext(true))
            {
                var author1 = new Author { Name = "Лев Толстой" };
                var author2 = new Author { Name = "Виктор Пелевин" };
                var author3 = new Author { Name = "Агата Кристи" };

                var genre1 = new Genre { Name = "Роман эпопея" };
                var genre2 = new Genre { Name = "Роман в рассказах" };
                var genre3 = new Genre { Name = "Детектив" };

                var book1 = new Book { Name = "Война и мир", Author = author1, YearOfRelease = 1873, Genre = genre1 };
                var book2 = new Book { Name = "TRANSHUMANISM INC.", Author = author2, YearOfRelease = 2021, Genre = genre2 };
                var book3 = new Book { Name = "Убийство в Восточном экспрессе", Author = author3, YearOfRelease = 1934, Genre = genre3 };

                var bookRep = new BookRepository(db);
                bookRep.AddBook(book1);
                bookRep.AddBook(book2);
                bookRep.AddBook(book3);


                var user1 = new User { Name = "Ivan", Email = "ivan@mail.ru" };
                var user2 = new User { Name = "Petr", Email = "petr@mail.ru" };

                var userRep = new UserRepository(db);
                userRep.AddUser(user1);
                userRep.AddUser(user2);

                db.SaveChanges();


                userRep.UpdateUserName(2, "Uran");
                bookRep.UpdateBookYearOfRelease(1, 1869);
                Console.WriteLine();


                //Получаем список книг определенного жанра и вышедших между определенными годами.
                var books = bookRep.GetBooksByGenre(genre3.Id, 1900);
                foreach (var book in books)
                {
                    Console.WriteLine($"Жанр: {genre3.Name}\tКнига: {book.Name}\tГод издания: {book.YearOfRelease.ToString()}");
                }
                Console.WriteLine();

                //Получаем количество книг определенного автора в библиотеке
                var countBooks = bookRep.GetBooksCountByAuthorId(author2.Id);
                Console.WriteLine($"Автор: {author2.Name}\tКоличество книг в библиотеке: {countBooks.ToString()}");
                Console.WriteLine();

                //Получаем количество книг определенного жанра в библиотеке
                countBooks = bookRep.GetBooksCountByGenreId(genre3.Id);
                Console.WriteLine($"Жанр: {genre3.Name}\tКоличество книг в библиотеке: {countBooks.ToString()}");
                Console.WriteLine();

                //Получаем булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
                var nameBook = "Война и мир";
                var existBook = bookRep.BookExistByBookNameAndAuthorId(nameBook, author1.Id);
                Console.WriteLine($"Книга: {nameBook} в библиотеке {(existBook ? "есть" : "нет")}");
                Console.WriteLine();

                //Получаем булевый флаг о том, есть ли определенная книга на руках у пользователя
                var userHasBook = userRep.UserHasBook(book2.Id);
                Console.WriteLine($"Книга: {book2.Name} {(userHasBook ? "взята" : "в наличии")}");
                Console.WriteLine();

                //Получаем количество книг на руках у пользователя
                countBooks = userRep.UserBooksCount(user2.Id);
                Console.WriteLine($"Количество книг на руках у пользователя: {user2.Name}\t{countBooks.ToString()} шт.");
                Console.WriteLine();

                //Получение последней вышедшей книги
                var lastBooks = bookRep.GetLastBook();
                Console.WriteLine($"Последняя изданная книга: {lastBooks.Name}\tГод издания: {lastBooks.YearOfRelease.ToString()}");
                Console.WriteLine();

                //Получение списка всех книг, отсортированного в алфавитном порядке по названию
                books = bookRep.GetBooksOrderByName();
                foreach (var book in books)
                {
                    Console.WriteLine($"Книга: {book.Name}\tАвтор:{book.Author.Name}\tГод издания: {book.YearOfRelease.ToString()}\tЖанр: {book.Genre.Name}");
                }
                Console.WriteLine();

                //Получение списка всех книг, отсортированного в порядке убывания года их выхода
                books = bookRep.GetBooksOrderByDescendingByYearOfRelease();
                foreach (var book in books)
                {
                    Console.WriteLine($"Книга: {book.Name}\tАвтор:{book.Author.Name}\tГод издания: {book.YearOfRelease.ToString()}\tЖанр: {book.Genre.Name}");
                }
                Console.WriteLine();
            }
        }
    }
}
