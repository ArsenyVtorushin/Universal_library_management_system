using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_library_management_system
{
    public interface IMediaManager<T>
    {
        void Add(T item);
        void Remove(string title);
        T FindByTitle(string title);
        IEnumerable<T> FilterByYear(int year);
        IEnumerable<T> GetAllAvailable();
    }

}
