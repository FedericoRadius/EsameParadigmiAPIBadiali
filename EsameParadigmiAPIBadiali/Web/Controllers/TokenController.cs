using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Unicam.Paradigmi.Application.Factories;

namespace EsameParadigmiAPIBadiali.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IServizioToken _tokenService;
        public TokenController(IServizioToken tokenService)
        {
            _tokenService = tokenService;
        }



        [HttpPost]
        [Route("CreaToken")]
        public IActionResult CreaToken(string username, string password) 
        {
            string token = "";
            try
            {
                token = _tokenService.CreaToken(username, password);
            }
            catch (Exception ex) { return BadRequest(ResponseFactory.WithError(ex)); }
            return Ok(ResponseFactory.WithSuccess(token));  


            
        }


       


    }
}
