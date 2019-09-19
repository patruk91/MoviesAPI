using MoviesApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesApi
{
    public interface IMovieProducerDao
    {
        void RemoveProducersFromMovie(int id);
    }
}