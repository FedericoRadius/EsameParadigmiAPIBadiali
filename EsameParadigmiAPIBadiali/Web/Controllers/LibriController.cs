using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Applicazione.Modelli;
using EsameParadigmiAPIBadiali.Modelli.Repositories;
using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.DTOs;
using EsameParadigmiAPIBadiali.Modello.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Factories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace EsameParadigmiAPIBadiali.Web.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibriController : ControllerBase
    {
        private readonly IServizioLibri _LibriServizio;

        public LibriController(IServizioLibri sl)
        {
            _LibriServizio = sl;
        }



        [HttpGet]
        [Route("getLibro")]
        public ActionResult<BaseResponse<LibroDTO>> getLibro(int id)
        {
            Libro libro = new Libro();

            try
            {
                libro = _LibriServizio.getLibro(id);
            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            LibroDTO libroDTO = new LibroDTO();
            libroDTO.IdLibro = libro.IdLibro;
            libroDTO.Nome = libro.Nome;
            libroDTO.Autore = libro.Autore;
            libroDTO.DataDiPubblicazione = libro.DataDiPubblicazione;
            libroDTO.Editore = libro.Editore;
            libroDTO.Categorie = libro.Categorie.Select(x=> x.CategoriaCollegata.NomeCategoria).ToList();


            return Ok(ResponseFactory.WithSuccess(libroDTO));
        }

        [HttpGet]
        [Route("getLibri")]
        public ActionResult<BaseResponse<List<LibroDTO>>> getLibri()
        {
            var libri = new List<Libro>();
            try
            {
                libri = _LibriServizio.getLibri();
            } catch (Exception ex) { return BadRequest( ResponseFactory.WithError(ex)); }

            var libriDTO = new List<LibroDTO>();
            foreach (var item in libri)
            {
                libriDTO.Add(new LibroDTO(item));
            }

            return Ok(ResponseFactory.WithSuccess(libriDTO));
        }

        [HttpPost]
        [Route("AggiungiLibro")]
        public ActionResult addLibro(string nome, string autore, DateTime dataDiPubblicazione, string editore, List<int>? categorie)
        {
            try
            {
                if (categorie[0] == 0)
                    categorie = new List<int>();
                _LibriServizio.AddLibro(nome, autore, dataDiPubblicazione, editore, categorie);
            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            return Ok();
        }

        [HttpDelete]
        [Route("RimuoviLibro")]
        public ActionResult RimuoviLibro(int idLibro)
        {
            try
            {
                _LibriServizio.RimuoviLibro(idLibro);
            }
            catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }

            return Ok();
        }

        [HttpPatch]
        [Route("ModificaLibro")]
        public ActionResult ModificaLibro(int idLibro, string? nuovoNome, string? nuovoAutore, DateTime? nuovaData, string? nuovoEditore)
        {
            try
            {
                _LibriServizio.ModificaLibro(idLibro, nuovoNome, nuovoAutore, nuovaData, nuovoEditore);
            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            return Ok();
            
        }


        [HttpGet]
        [Route("RicercaLibri")]
        public ActionResult<List<LibroDTO>> RicercaLibri(int? idCategoria,  string? nomeLibro, string? autore, DateTime? dataDiPubblicazione, int pagina, int? dimPag)
        {
            var listaDTOs = new List<LibroDTO>();

            try
            {
                if (idCategoria == null && nomeLibro == null && dataDiPubblicazione == null && autore == null)
                    throw new Exception("Inserire almeno un filtro.");
                var lista = _LibriServizio.FiltroLibri(idCategoria, nomeLibro, dataDiPubblicazione, autore, pagina, dimPag);
                listaDTOs = lista.Select(x => new LibroDTO (x) { }).ToList();

            } catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            return Ok(ResponseFactory.WithSuccess(listaDTOs));
        }

    }
}
