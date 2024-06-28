using Microsoft.EntityFrameworkCore;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<Time> Times { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Jogador>()
                .HasOne(j => j.Time)
                .WithMany()
                .HasForeignKey(j => j.TimeId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
