using Microsoft.EntityFrameworkCore;
using EsameParadigmiAPIBadiali.Modello.Configurazioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsameParadigmiAPIBadiali.Modello
    .Entities;

namespace EsameParadigmiAPIBadiali.Modello.Contesto
{
    public class MyDbContext : DbContext
    {

        public DbSet<Libro> Libri { get; set; }
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<LibroCategoria> CategorieLibro { get; set; } 


        public MyDbContext(DbContextOptions<MyDbContext> config) : base(config)
        {

        }

        //TODO serve
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server = localhost; Database = Paradigmi; User Id = Paradigmi; Password = password; ");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.ApplyConfiguration(new LibroConfiguration());
            modelBuilder.ApplyConfiguration(new UtenteConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration(new LibroCategoriaConfiguration());


            //    modelBuilder.Entity<Libro>()
            //.HasMany(e => e.categorie)
            //.WithMany(e => e.LibriDelGenere)
            //.UsingEntity(
            //    j =>
            //    {
            //        j.Property("PostsId").HasColumnName("PostForeignKey");
            //        j.Property("TagsId").HasColumnName("TagForeignKey");
            //    });
            //}
        }


    }
}
