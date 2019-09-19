using Microsoft.AspNetCore.Mvc;
using MoviesApi.Model;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao
{
    public interface ICountryDao
    {
        Task<Country> GetCountry(int countryId);
    }
}
