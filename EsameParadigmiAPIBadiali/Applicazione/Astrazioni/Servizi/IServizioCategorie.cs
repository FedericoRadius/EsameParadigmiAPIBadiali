using EsameParadigmiAPIBadiali.Modello.Contesto;
using EsameParadigmiAPIBadiali.Modello.Entities;

namespace EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi
{
    public interface IServizioCategorie
    {

        public void addCategoria(string nome);

        public void RemoveCategoria(int idCategoria);

        public Categoria getCategoria(int idCategoria);
    }
}
