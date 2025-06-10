using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Newtonsoft.Json;

namespace Universal_library_management_system
{
    public class Library<T> : IMediaManager<T> where T : Media
    {
        private List<T> _media;
        private Dictionary<string, T> _dictionary;




        public Library(List<T> media)
        {
            _media = media;
            _dictionary = new Dictionary<string, T>();

            for (int i = 0; i < _media.Count; i++)
                _dictionary.Add(_media[i].Title, _media[i]);
        }


        public void PrintAll()
        {
            foreach (var item in _media)
                Console.WriteLine($"Название: {item.Title}\nАвтор: {item.Author}\n" +
                    $"Год публикации: {item.YearPublished}\nДоступность: {item.IsAvailable}\n");
        }


        public T this[int index]
        {
            get { return _media[index]; }
            set { _media[index] = value; }
        }
        




        public IEnumerable<Book> FindBooksAfterYear(int year)
        {
            return (IEnumerable<Book>)_media.Where(el => el.YearPublished > year);
        }


        public IEnumerable<Movie> GetSortedMovies()
        {
            return (_media as List<Movie>).OrderByDescending(el => el.Duration);
        }


        public IEnumerable<T> FindUnavailable()
        {
            return _media.Where(el => el.IsAvailable == false);
        }




        public void Add(T item)
        {
            try
            {
                if (_dictionary.ContainsKey(item.Title))
                    throw new Exception("Попытка добавить элемент с уже существующим названием");
                else
                {
                    _media.Add(item);
                    _dictionary.Add(item.Title, item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void Remove(string title)
        {
            try
            {                
                if (!_dictionary.ContainsKey(title))
                    throw new Exception("Попытка удалить или найти элемент, которого нет в коллекции");
                else
                {
                    _media.Remove(_dictionary[title]);
                    _dictionary.Remove(title);
                }
                    
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public T FindByTitle(string title)
        {
            return _dictionary[title];
        }


        public IEnumerable<T> FilterByYear(int year)
        {
            return _media.Where(el => el.YearPublished == year);
        }


        public IEnumerable<T> GetAllAvailable()
        {
            return _media.Where(el => el.IsAvailable);
        }




        public void ExportToJSON(string filePath)
        {
            string json = JsonConvert.SerializeObject(_media, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }


        public void ExportToCSV(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine("Title,Author,YearPublished,IsAvailable");
                foreach (var item in _media)
                {
                    sw.WriteLine(item.Title + ',' + item.Author + ',' + item.YearPublished + ',' + item.IsAvailable);
                }
            }
        }
    }

}
