using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        // 👇 Propriété DbSet ajoutée pour Tache
        public DbSet<Tache> Tache { get; set; }

        public AMContext() { }

        public AMContext(DbContextOptions<AMContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=ScrumSarraBouazzi;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appliquer les configurations personnalisées
            modelBuilder.ApplyConfiguration(new TacheConfig());

            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Appliquer des conventions globales sur les propriétés string
            configurationBuilder.Properties<string>().HaveMaxLength(200);
        }
    }
}
