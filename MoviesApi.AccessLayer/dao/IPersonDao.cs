using MoviesApi.Model;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao
{
    public interface IPersonDao
    {
        Task<Person> GetPerson(int id);
    }
}
