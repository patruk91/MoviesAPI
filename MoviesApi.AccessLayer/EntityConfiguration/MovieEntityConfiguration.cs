using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model;

namespace MoviesApi.AccessLayer
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .HasOne<Country>(c => c.CountryName)
                .WithOne(p => p.Movie)
                .HasForeignKey<Country>(c => c.Id);

            //builder
            //    .HasOne<Person>(p => p.Director)
            //    .WithMany(d => d.Movie)
            //    .HasForeignKey(m => m.DirectorId);

        }


    }
}