using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model;

namespace MoviesApi.AccessLayer
{
    public class ProducerEntityConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder
                .HasOne<Country>(c => c.CountryName)
                .WithOne(p => p.Producer)
                .HasForeignKey<Country>(c => c.Id);
        }
    }
}