using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Навигационное свойство
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
