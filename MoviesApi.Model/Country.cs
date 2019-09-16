using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApi.Model
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; set; }

        public Producer Producer { get; set; }
        public Movie Movie { get; set; }
        public Person Person { get; set; }

    }
}
