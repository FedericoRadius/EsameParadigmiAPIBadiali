using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi
{
    public interface IServizioUtenti
    {

        public void addUtente( string nome, string Cognome, string email, string password);

        public Utente getUtente(int idUtente);

        public List<Utente> getUtenti();

    }
}
