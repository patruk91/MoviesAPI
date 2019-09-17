using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApi.Model
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }
    }
}
