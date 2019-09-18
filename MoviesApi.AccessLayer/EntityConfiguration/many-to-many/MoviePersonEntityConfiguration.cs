using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model.DbModels;

namespace MoviesApi.AccessLayer
{
    internal class MoviePersonEntityConfiguration : IEntityTypeConfiguration<MoviePerson>
    {
        public void Configure(EntityTypeBuilder<MoviePerson> builder)
        {
            builder
                .HasKey(k => new { k.MovieId, k.PersonId });
        }
    }
}