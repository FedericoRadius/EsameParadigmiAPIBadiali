using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Modello.Configurazioni
{
    class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(x => x.IdUtente);
            builder.Property(x => x.Nome ).HasMaxLength(20);
            builder.Property(x => x.Cognome).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Password).HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
