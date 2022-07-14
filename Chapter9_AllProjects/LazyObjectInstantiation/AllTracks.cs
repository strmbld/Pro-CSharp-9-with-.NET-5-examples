using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    class AllTracks
    {
        private Song[] allSongs = new Song[10000];
        public AllTracks()
        {
            Console.WriteLine("Fill allSongs");
        }
    }
}
