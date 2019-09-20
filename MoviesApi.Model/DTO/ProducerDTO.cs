using System;

namespace MoviesApi.Model.DTO
{
    public class ProducerDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime YearEstablished { get; set; }
        public long EstimatedCompanyValue { get; set; }
        public int CountryId { get; set; }

    }
}
