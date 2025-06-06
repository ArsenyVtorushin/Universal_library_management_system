using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_library_management_system
{
    public class MusicAlbum : Media
    {
        public string Performer { get; set; }
        public int TracksCount { get; set; }
    }
}
