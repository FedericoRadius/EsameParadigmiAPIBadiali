using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;
using EsameParadigmiAPIBadiali.Modello.Repositories;

namespace EsameParadigmiAPIBadiali.Applicazione.Servizi
{
    public class ServizioCategorie : IServizioCategorie
    {
        private readonly CategorieRepository _categorieRepository;

        public ServizioCategorie(CategorieRepository cr) 
        {
            _categorieRepository = cr;
        }

        public void addCategoria(string nome)
        {
            Categoria cat = new Categoria();
            cat.NomeCategoria = nome;

            _categorieRepository.Aggiunta(cat);
            _categorieRepository.Save();
        }

        public void RemoveCategoria(int idCategoria)
        {
            var categoria = _categorieRepository.getCategoria(idCategoria);
            if (categoria.LibriDelGenere.Count > 0)
                throw new Exception("Non è possibile eliminare una categoria se ci sono libri che ne fanno parte.");
            Categoria cat = new Categoria();
            cat.IdCategoria = idCategoria;
            _categorieRepository.Rimozione(cat);
            _categorieRepository.Save();
        }

        public Categoria getCategoria(int idCategoria)
        {
            return _categorieRepository.getCategoria(idCategoria);
        }

        
    }
}
