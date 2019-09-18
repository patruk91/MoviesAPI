using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model;
using System;

namespace MoviesApi.AccessLayer
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();

            builder
               .Property(e => e.Type)
               .HasConversion(
                   v => v.ToString(),
                   v => (TypeOfPeople)Enum.Parse(typeof(TypeOfPeople), v));

            builder
               .Property(e => e.Sex)
               .HasConversion(
                   v => v.ToString(),
                   v => (TypeOfSex)Enum.Parse(typeof(TypeOfSex), v));
        }
    }
}