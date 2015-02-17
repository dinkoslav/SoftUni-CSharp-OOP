using System;
using System.Collections.Generic;

namespace MyTunesShop
{
    public class Album : Media, IAlbum
    {
        private IPerformer performer;
        private string genre;
        private int year;
        private IList<ISong> songs = new List<ISong>();

        public Album(string title, decimal price, IPerformer performer, string genre, int year) 
            : base(title, price)
        {
            this.performer = performer;
            this.Genre = genre;
            this.Year = year;
        }

        public IPerformer Performer
        {
            get { return this.performer; }
        }

        public string Genre
        {
            get { return this.genre; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The genre is required.");
                }

                this.genre = value;
            }
        }

        public int Year
        {
            get { return this.year; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The year must be positive.");
                }

                this.year = value;
            }
        }

        public IList<ISong> Songs
        {
            get { return new List<ISong>(songs); }
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }
    }
}
