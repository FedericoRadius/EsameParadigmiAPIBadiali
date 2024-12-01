using EsameParadigmiAPIBadiali.Modello.Contesto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsameParadigmiAPIBadiali.Modelli.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {

        protected MyDbContext ctx;

        public GenericRepository(MyDbContext ctx)
        {
            this.ctx = ctx;
        }


        public void Aggiunta<T>(T entity)
        {
            ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public void Rimozione<T>(T entity)
        {
            ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Save()
        {
            ctx.SaveChanges();
        }






    }
}
