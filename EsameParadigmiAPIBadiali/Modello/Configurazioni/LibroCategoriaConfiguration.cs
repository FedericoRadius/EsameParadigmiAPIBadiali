using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Modello.Configurazioni
{
    public class LibroCategoriaConfiguration : IEntityTypeConfiguration<LibroCategoria>
    {
        public void Configure(EntityTypeBuilder<LibroCategoria> builder)
        {
            builder.ToTable("CategorieLibro");
            builder.HasKey(x => new { x.IdCategoria, x.IdLibro });


        }
    }





}
