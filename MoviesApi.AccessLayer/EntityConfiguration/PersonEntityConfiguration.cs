using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model;

namespace MoviesApi.AccessLayer
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasOne<Country>(c => c.CountryConfiguration)
                .WithOne(p => p.Person)
                .HasForeignKey<Country>(c => c.Id);

            
        }
    }
}