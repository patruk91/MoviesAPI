using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Model;
using MoviesApi.Model.DbModels;

namespace MoviesApi.AccessLayer
{
    public class MovieProducerEntityConfiguration : IEntityTypeConfiguration<MovieProducer>
    {
        public void Configure(EntityTypeBuilder<MovieProducer> builder)
        {
            builder
                .HasKey(k => new { k.ProducerId, k.MovieId });

            builder
                .HasOne(m => m.Movie)
                .WithMany(mp => mp.MovieProducers)
                .HasForeignKey(m => m.MovieId);

            builder
                .HasOne(p => p.Producer)
                .WithMany(mp => mp.MovieProducers)
                .HasForeignKey(p => p.ProducerId);
        }
    }
}