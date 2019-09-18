using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model;
using System;

namespace MoviesApi.AccessLayer
{
    public class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder
               .Property(e => e.Genre)
               .HasConversion(
                   v => v.ToString(),
                   v => (TypesOfGenre)Enum.Parse(typeof(TypesOfGenre), v));
        }


    }
}