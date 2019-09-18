using System;
using System.Collections.Generic;
using MoviesApi.Model;

namespace MoviesApi.Model.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public TypesOfGenre Genre { get; set; }
        public long Length { get; set; }
        public DateTime Year { get; set; }
        public string CountryName { get; set; }
        public List<int> MovieProducersId { get; set; }
        public List<int> MovieActorsId { get; set; }
    }
}