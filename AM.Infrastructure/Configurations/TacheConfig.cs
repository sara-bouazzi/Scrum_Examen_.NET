using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    internal class TacheConfig : IEntityTypeConfiguration<Tache>
    {

        public void Configure(EntityTypeBuilder<Tache> builder)
        {
             builder.HasOne(h => h.MyMembre)
                .WithMany(h => h.Taches)
                .HasForeignKey(h => h.MembreKey);

            builder.HasOne(h => h.MySprint)
                .WithMany(h => h.Taches)
                .HasForeignKey(h => h.SprintKey);

            builder.HasKey(h => new
            {
                h.SprintKey,
                h.MembreKey,
                h.Titre
            });


        }
    
    
    }
}
