namespace EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi
{
    public interface IServizioToken
    {

        public string CreaToken(string username, string password);
    }
}
