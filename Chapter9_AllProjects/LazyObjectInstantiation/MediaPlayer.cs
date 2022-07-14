using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyObjectInstantiation
{
    class MediaPlayer
    {
        private Lazy<AllTracks> allSongs =
            new(() => // Lazy<AllTracks> constructor
            {
                Console.WriteLine("Creating AllTracks object");
                return new(); // AllTracks constructor but could be anything else returning AllTracks obj
                // call default constructor but could provide any other logic just have to return AllTracks type
            });

        public void Play() { /* Play a song */ }
        public void Pause() { /* Pause the song */ }
        public void Stop() { /* Stop playback */ }

        public AllTracks GetAllTracks()
        {
            return allSongs.Value;
        }
    }
}
