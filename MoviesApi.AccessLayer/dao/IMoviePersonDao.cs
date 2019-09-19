using MoviesApi.Model.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao
{
    public interface IMoviePersonDao
    {
        void RemoveActorsFromMovie(int id);
    }
}
