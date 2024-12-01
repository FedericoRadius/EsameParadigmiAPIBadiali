using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Applicazione.Modelli;
using EsameParadigmiAPIBadiali.Modello.DTOs;
using EsameParadigmiAPIBadiali.Modello.Entities;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Factories;

namespace EsameParadigmiAPIBadiali.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtentiController : ControllerBase
    {
        private readonly IServizioUtenti _serizioUtenti;

        public UtentiController(IServizioUtenti su)
        {
            _serizioUtenti = su;
        }



        [HttpPost]
        [Route("/AggiungiUtente")]
        public ActionResult addUtente(string nome, string cognome, string email, string password)
        {
            try
            {
                _serizioUtenti.addUtente(nome, cognome, email, password);
            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            return Ok();
        }


        [HttpGet]
        [Route("/PrendiUtente")]
        public ActionResult<BaseResponse<UtenteDTO>> getUtente(int idUtente)
        {
            var utente = new Utente();
            try
            {
                utente = _serizioUtenti.getUtente(idUtente);
            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }

            var utenteDTO = new UtenteDTO();
            utenteDTO.IdUtente = idUtente;
            utenteDTO.Nome = utente.Nome;
            utenteDTO.Cognome = utente.Cognome;
            utenteDTO.Email = utente.Email;
            utente.Password = utente.Password;

            return Ok(ResponseFactory.WithSuccess(utenteDTO));
        }


        [HttpGet]
        [Route("/PrendiUtenti")]
        public ActionResult<BaseResponse<List<UtenteDTO>>> getUtenti(int idUtente)
        {
            List<Utente> utenti = new List<Utente>();
            try
            {
                utenti = _serizioUtenti.getUtenti();
            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            var listaUtenti = new List<UtenteDTO>();

            foreach (var utente in utenti)
            {
                var utenteDTO = new UtenteDTO();
                utenteDTO.IdUtente = idUtente;
                utenteDTO.Nome = utente.Nome;
                utenteDTO.Cognome = utente.Cognome;
                utenteDTO.Email = utente.Email;
                utenteDTO.Password = utente.Password;
                listaUtenti.Add(utenteDTO);
            }

            return Ok(ResponseFactory.WithSuccess(listaUtenti));
        }

    }
}
