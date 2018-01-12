using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmalgamaParser
{
    class AmalgamaSetings : IParserSettings
    {
        string artist;
        string song;

        public AmalgamaSetings(string song, string artist)
        {
            Artist = artist;
            Song = song;
        }

        public string BaseUrl { get; set; } = "https://www.amalgama-lab.com/songs/";

        public string Song {
            get
            {
                return song;
            }
            set
            {
                string[] words = value.Split(' ');
                string songs = String.Join("_", words).ToLower();
                song = songs + ".html";
            }

        }

        public string Artist {
            get
            {
                return artist;
            }
            set
            {
                char firstWord = value.ToLower()[0];
                string[] words = value.Split(' ');
                string art = String.Join("_", words).ToLower();
                artist = firstWord + "/" + art + "/"; 
            }
        }

    }
}
