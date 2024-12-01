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
    class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(p => p.IdLibro);
            builder.Property(p => p.Nome).HasMaxLength(50);
            builder.Property(p => p.Autore).HasMaxLength(50);
            builder.Property(p => p.Editore).HasMaxLength(50);
            builder.HasMany(x => x.Categorie).WithOne(x => x.LibroCollegato).HasForeignKey(x => x.IdLibro);
        }
    }
}
