using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi
{
    public interface IServizioLibri
    {
        Libro getLibro(int idLibro);
        List<Libro> getLibri();
        List<Libro> FiltroLibri(int? idCategoria, string? nomeLibro, DateTime? dataDiPubblicazione, string? autore, int pagina, int? dimPag);
        void AddLibro(string nome, string autore, DateTime dataDiPubblicazione, string editore, List<int> categorie);
        void RimuoviLibro(int idLibro);
        void ModificaLibro(int idLibro, string? nuovoNome, string? uovoAutore, DateTime? nuovaData, string? nuovoEditore);
    }
}
