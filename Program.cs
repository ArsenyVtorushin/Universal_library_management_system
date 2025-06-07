namespace Universal_library_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book {Title = "Мастер и Маргарита", Author = "Михаил Булгаков",
                    YearPublished = 1967, IsAvailable = true, PagesCount = 480, Genre = "Роман"},

                new Book {Title = "Война и мир", Author = "Лев Толстой",
                    YearPublished = 1869, IsAvailable = false, PagesCount = 1225, Genre = "Эпопея"},

                new Book {Title = "Преступление и наказание", Author = "Фёдор Достоевский",
                    YearPublished = 1866, IsAvailable = true, PagesCount = 544, Genre = "Психологический роман"},

                new Book {Title = "Идиот", Author = "Фёдор Достоевский",
                    YearPublished = 1869, IsAvailable = true, PagesCount = 608, Genre = "Социальная драма"},

                new Book {Title = "Анна Каренина", Author = "Лев Толстой",
                    YearPublished = 1878, IsAvailable = true, PagesCount = 864, Genre = "Роман"},

                new Book {Title = "Евгений Онегин", Author = "Александр Пушкин",
                    YearPublished = 1831, IsAvailable = true, PagesCount = 256, Genre = "Поэма"},

                new Book {Title = "Мёртвые души", Author = "Николай Гоголь",
                    YearPublished = 1842, IsAvailable = false, PagesCount = 384, Genre = "Поэма в прозе"},

                new Book {Title = "Отцы и дети", Author = "Иван Тургенев",
                    YearPublished = 1862, IsAvailable = true, PagesCount = 352, Genre = "Роман"},

                new Book {Title = "Герой нашего времени", Author = "Михаил Лермонтов",
                    YearPublished = 1840, IsAvailable = true, PagesCount = 288, Genre = "Роман"},

                new Book {Title = "Обломов", Author = "Иван Гончаров",
                    YearPublished = 1859, IsAvailable = false, PagesCount = 576, Genre = "Роман"},

                new Book {Title = "Двенадцать стульев", Author = "Илья Ильф, Евгений Петров",
                    YearPublished = 1928, IsAvailable = true, PagesCount = 352, Genre = "Комедия"}
            };

            var library = new Library<Book>(books);
            library.Show();
            

            library.Add(new Book
            {
                Title = "451 градус по Фаренгейту",
                Author = "Рэй Брэдбери",
                YearPublished = 1953,
                IsAvailable = true,
                PagesCount = 240,
                Genre = "Научная фантастика"
            });

            foreach (var item in library.FilterByYear(1953))
                Console.WriteLine(item.Title);

            library.Remove("451 градус по Фаренгейту");





        }
    }
}
