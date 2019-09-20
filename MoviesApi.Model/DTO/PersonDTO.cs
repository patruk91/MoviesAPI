using System;

namespace MoviesApi.Model.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfPeople Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public TypeOfSex Sex { get; set; }
        public int CountryId { get; set; }
    }
}
