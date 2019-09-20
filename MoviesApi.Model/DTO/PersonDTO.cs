using System;

namespace MoviesApi.Model.DTO
{
    class PersonDTO
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfPeople Type { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public TypeOfSex Sex { get; set; }
        public Country Country { get; set; }
    }
}
