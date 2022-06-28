using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMovieApp.Model
{
    class Movie
    {
        private int _id;
        private int _year;
        private string _name;
        private string _genre;
        public Movie(int id, int year, string name, string genre)
        {
            _id = id;
            _genre = genre;
            _name = name;
            _year = year;
        }
    }
}
