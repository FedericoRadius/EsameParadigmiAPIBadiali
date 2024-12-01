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
    internal class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(x => x.IdCategoria);
            builder.HasIndex(x => x.NomeCategoria).IsUnique();
            builder.Property(x => x.NomeCategoria).HasMaxLength(20);
            builder.HasMany(x => x.LibriDelGenere).WithOne(x => x.CategoriaCollegata).HasForeignKey(x => x.IdCategoria);

        }
    }
}
