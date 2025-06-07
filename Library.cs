using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public void Show()
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


        public void Add(T item)
        {
            _media.Add(item);
        }


        public IEnumerable<T> FilterByYear(int year)
        {
            return _media.Where(e => e.YearPublished == year);
        }


        public T FindByTitle(string title)
        {
            return _dictionary[title];
        }


        public IEnumerable<T> GetAllAvailable()
        {
            return _media.Where(e => e.IsAvailable);
        }


        public bool Remove(string title)
        {
            if (_dictionary.ContainsKey(title))
            {
                _media.Remove(_dictionary[title]);
                _dictionary.Remove(title);
                return true;
            }
            return false;
        }
    }

}
