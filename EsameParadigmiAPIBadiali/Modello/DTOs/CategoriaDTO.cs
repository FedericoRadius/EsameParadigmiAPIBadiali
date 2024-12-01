namespace EsameParadigmiAPIBadiali.Modello.DTOs
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set;}

        public Dictionary<int, string> ListaIdLibriConCategoria { get; set; }



    }
}
