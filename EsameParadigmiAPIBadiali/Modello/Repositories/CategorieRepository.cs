using EsameParadigmiAPIBadiali.Modelli.Repositories;
using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;
using Microsoft.EntityFrameworkCore;

namespace EsameParadigmiAPIBadiali.Modello.Repositories
{
    public class CategorieRepository : GenericRepository<Categoria>
    {

        public CategorieRepository(MyDbContext context) : base(context)
        { }


        public Categoria getCategoria(int id)
        {
            var cat = ctx.Categorie.AsNoTracking().Include(x=> x.LibriDelGenere).ThenInclude(y=> y.LibroCollegato).Where(x => x.IdCategoria == id).FirstOrDefault(); 
            if (cat == null)
                throw new Exception("Non è stata trovata una categoria con l'ID indicato");
            return cat;
        }

        public List<Categoria> getNomiCategorie()
        {
            return ctx.Categorie.ToList();
        }



    }
}
