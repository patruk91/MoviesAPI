using Microsoft.AspNetCore.Mvc;
using MoviesApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApi.AccessLayer.dao
{
    public interface IPersonDao
    {
        Task<Person> GetPerson(int id);
    }
}
