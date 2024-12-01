using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Modelli.Repositories;
using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Applicazione.Servizi
{
    public class ServizioUtenti : IServizioUtenti
    {

        private readonly UtenteRepository _UtenteRepository;

        public ServizioUtenti(UtenteRepository ur) 
        {
            _UtenteRepository = ur;
        }

        public void addUtente(string nome, string Cognome, string email, string password)
        {
            var utente = new Utente();
            utente.Nome = nome;
            utente.Cognome = Cognome;
            utente.Email = email;
            utente.Password = password;

            _UtenteRepository.Aggiunta(utente);
        }

        public Utente getUtente(int idUtente)
        {
            return _UtenteRepository.getUtente(idUtente);
        }

        public List<Utente> getUtenti()
        {
            return _UtenteRepository.getUtenti();
        }
    }
}
