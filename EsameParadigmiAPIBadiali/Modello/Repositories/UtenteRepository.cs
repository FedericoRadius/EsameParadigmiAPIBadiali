using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsameParadigmiAPIBadiali.Modelli.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {

        public UtenteRepository(MyDbContext context) : base(context)
        {
        }

        public Utente Autenticazione(string username, string password)
        {
            var utente = new Utente();
            utente = ctx.Utenti.Where(x=> x.Email.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            return utente;
        }


        public Utente getUtente(int id)
        {
            var utente = ctx.Utenti.Where(x => x.IdUtente == id).FirstOrDefault();
            if(utente == null)
                utente = new Utente();
            return utente;
        }

        public List<Utente> getUtenti()
        {
            return ctx.Utenti.ToList();
        }


    }
}
