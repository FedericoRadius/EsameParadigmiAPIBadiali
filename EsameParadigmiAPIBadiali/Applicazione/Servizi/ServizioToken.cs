using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Options;
using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Modelli.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EsameParadigmiAPIBadiali.Applicazione.Servizi
{
    public class ServizioToken : IServizioToken
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAuthOption;


        public ServizioToken(UtenteRepository utenteRepository ,IOptions<JwtAuthenticationOption> jwtAuthOption)
        {
            _utenteRepository = utenteRepository;
            _jwtAuthOption = jwtAuthOption.Value;
        }



        //Pacchetti nuget necessari  System.IdentityModel.Tokens.Jwt  TODO
        public string CreaToken(string username, string password )
        {
            var utente = _utenteRepository.Autenticazione(username, password);
            if (utente == null)
                throw new Exception("Nessun utente con questa combinazione di username e password.");

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("id_utente", utente.IdUtente.ToString()));
            claims.Add(new Claim("Nome", utente.Nome));
            claims.Add(new Claim("Cognome", utente.Cognome));

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
                );
            var credentials = new SigningCredentials(securityKey
                , SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: credentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
