using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Modello.DTOs
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }
        public string Nome { get; set; }
        public string Autore { get; set; }
        public DateTime DataDiPubblicazione { get; set; }
        public string Editore { get; set; }

        public List<string> Categorie { get; set; }

        public LibroDTO() { }

        public LibroDTO(int idLibro, string nome, string autore, DateTime datapubbl, string editore, List<string> categorie) 
        {
            this.IdLibro = idLibro;
            this.Nome = nome;
            this.Autore = autore;
            this.DataDiPubblicazione = datapubbl;
            this.Editore = editore;
            this.Categorie = categorie;
        }

        public LibroDTO(Libro lib)
        {
            this.IdLibro = lib.IdLibro;
            this.Nome = lib.Nome;
            this.Autore = lib.Autore;
            this.DataDiPubblicazione = lib.DataDiPubblicazione;
            this.Editore = lib.Editore;
            this.Categorie = lib.Categorie.Select(x => x.CategoriaCollegata.NomeCategoria).ToList(); ;
        }

    }
}
