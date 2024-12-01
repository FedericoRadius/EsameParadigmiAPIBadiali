using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Applicazione.Modelli;
using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.DTOs;
using EsameParadigmiAPIBadiali.Modello.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Factories;

namespace EsameParadigmiAPIBadiali.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly IServizioCategorie _servizioCategorie;

        public CategoriaController(IServizioCategorie sc)
        {
            _servizioCategorie = sc;
        }

        [HttpPost]
        [Route("/AggiungiCategoria")]
        public ActionResult addCategoria(string nome)
        {
            //ctx.Categorie.Add(cat);
            //ctx.SaveChanges();
            try {
                _servizioCategorie.addCategoria(nome);
            } catch (Exception ex) { return BadRequest( ResponseFactory.WithError(ex)); }
            return Ok();
        }


        [HttpDelete]
        [Route("/RimuoviCategoria")]
        public ActionResult RemoveCategoria(int idCategoria)
        {

            

            var categoria = new Categoria();
            categoria.IdCategoria = idCategoria;

            try
            {
                _servizioCategorie.RemoveCategoria(idCategoria);

                //var entry = ctx.Entry(categoria);
                //entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                //ctx.SaveChanges();

            }
            catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            return Ok();
        }


        [HttpGet]
        [Route("/TrovaCategoria")]
        public ActionResult<BaseResponse<CategoriaDTO>> getCategoria(int idCategoria)
        {
            Categoria c = new Categoria();
            try
            {
                c = _servizioCategorie.getCategoria(idCategoria);
            } catch (Exception ex) 
            {
                return BadRequest(ResponseFactory.WithError(ex));
            }
                

            var categoriaDTO = new CategoriaDTO();
            categoriaDTO.IdCategoria = c.IdCategoria;
            categoriaDTO.NomeCategoria = c.NomeCategoria;
            Dictionary<int, string> listaLibri = new Dictionary<int, string>();
            foreach (var libro in c.LibriDelGenere)
            {
                listaLibri.Add(libro.IdLibro, libro.LibroCollegato.Nome);
            }
            categoriaDTO.ListaIdLibriConCategoria = listaLibri;

            return Ok(ResponseFactory.WithSuccess(categoriaDTO)
            ); 
        }
    }
}
