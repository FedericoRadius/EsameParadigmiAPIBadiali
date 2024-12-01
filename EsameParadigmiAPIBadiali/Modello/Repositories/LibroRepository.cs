using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsameParadigmiAPIBadiali.Modelli.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {

        public LibroRepository(MyDbContext context) : base(context)
        { }

        public Libro getLibro(int id)
        {
            var lib = ctx.Libri.Include(x=> x.Categorie).ThenInclude(y=>y.CategoriaCollegata).Where(x => x.IdLibro == id).FirstOrDefault();
            if(lib == null)
                lib = new Libro();
            return lib;
        }

        public IQueryable<Libro> getLibri()
        {
            return ctx.Libri.Include(x => x.Categorie).ThenInclude(y => y.CategoriaCollegata);
        }


        public int getIdUltimoLibro()
        {
            return ctx.Libri.Max(x => x.IdLibro);
        }

        public void RimuoviLibro(Libro libro)
        {
            var libro2 = ctx.Libri.Where(x => x.IdLibro == libro.IdLibro).Include(x=>x.Categorie).FirstOrDefault();
            if (libro2 == null)
                throw new Exception("L'ID non è collegato a nessun libro");

            foreach (var categoria in libro2.Categorie)
            {
                ctx.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }

            Save();

            ctx.Entry(libro2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            

            

        }

        internal void ModificaLibro(int idLibro, string? nuovoNome, string? nuovoAutore, DateTime? nuovaData, string? nuovoEditore)
        {
            var editLibro = new Libro();

            bool flagNome = false;
            bool flagAutore = false;
            bool flagData = false;
            bool flagEditore = false;

            editLibro.IdLibro = idLibro;
            if (nuovoNome != null)
            {
                editLibro.Nome = nuovoNome;
                flagNome = true;
            }
            if (nuovoAutore != null)
            {
                editLibro.Autore = nuovoAutore;
                flagAutore = true;
            }
            if (nuovaData != null)
            {
                editLibro.DataDiPubblicazione = nuovaData.Value;
                flagData = true;
            }
            if (nuovoEditore != null)
            {
                editLibro.Editore = nuovoEditore;
                flagEditore = true;
            }
            
            var entry = ctx.Entry(editLibro);

            if(flagNome)
                entry.Property(x => x.Nome).IsModified = true;
            if(flagAutore)
                entry.Property(x => x.Autore).IsModified = true;
            if(flagData)
                entry.Property(x => x.DataDiPubblicazione).IsModified = true;
            if(flagEditore)
                entry.Property(x => x.Editore).IsModified = true;
        }
    }

}
