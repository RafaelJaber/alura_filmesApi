using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> opts)
            : base(opts) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Session>()
                .HasKey(session => new { session.MovieId, session.MovieTheaterId });

            builder.Entity<Session>()
                .HasOne(session => session.MovieTheater)
                .WithMany(movieT => movieT.Sessions)
                .HasForeignKey(session => session.MovieTheaterId);
            
            builder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            builder.Entity<Address>()
                .HasOne(address => address.MovieTheater)
                .WithOne(movieT => movieT.Address)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
