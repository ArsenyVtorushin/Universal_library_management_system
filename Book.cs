using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_library_management_system
{
    public class Book : Media
    {
        public int PagesCount { get; set; }
        public string Genre { get; set; }
    }
}
