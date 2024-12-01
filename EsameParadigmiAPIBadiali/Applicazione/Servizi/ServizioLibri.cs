using EsameParadigmiAPIBadiali.Applicazione.Astrazioni.Servizi;
using EsameParadigmiAPIBadiali.Modelli.Repositories;
using EsameParadigmiAPIBadiali.Modello.Entities;
using EsameParadigmiAPIBadiali.Modello.Repositories;

namespace EsameParadigmiAPIBadiali.Applicazione.Servizi
{
    public class ServizioLibri : IServizioLibri
    {

        private readonly LibroRepository _libroRepository;
        private readonly CategorieRepository _categorieRepository;

        public ServizioLibri(LibroRepository lr, CategorieRepository cr)
        {
            _libroRepository = lr;
            _categorieRepository = cr;
        }

        

        public Libro getLibro(int idLibro)
        {
            return _libroRepository.getLibro(idLibro);
        }

        public List<Libro> getLibri()
        {
            return _libroRepository.getLibri().ToList();
        }

        public void AddLibro(string nome, string autore, DateTime dataDiPubblicazione, string editore, List<int> categorie)
        {
            var libro = new Libro();
            libro.Nome = nome;
            libro.Autore = autore;
            libro.DataDiPubblicazione = dataDiPubblicazione;
            libro.Editore = editore;



            _libroRepository.Aggiunta(libro);
            //nt idLib = _libroRepository.getIdUltimoLibro();
            _libroRepository.Save();

            
            foreach (var cat in categorie)
            {
                LibroCategoria libCat = new LibroCategoria();
                libCat.IdLibro = libro.IdLibro;
                libCat.IdCategoria = cat;
                _categorieRepository.Aggiunta(libCat);

            }
            _libroRepository.Save();

        }

        public void RimuoviLibro(int idLibro)
        {
            Libro lib = new Libro();
            lib.IdLibro = idLibro;

            _libroRepository.RimuoviLibro(lib);
            _libroRepository.Save();
        }

        public void ModificaLibro(int idLibro, string? nuovoNome, string? nuovoAutore, DateTime? nuovaData, string? nuovoEditore)
        {
            _libroRepository.ModificaLibro(idLibro, nuovoNome, nuovoAutore, nuovaData, nuovoEditore);
            _libroRepository.Save();
        }

        public List<Libro> FiltroLibri(int? idCategoria, string? nomeLibro, DateTime? dataDiPubblicazione, string? autore, int pagina, int? dimPag)
        {
            IEnumerable<Libro> listaLibri;

            int dimensionePagina = 4;

            if (dimPag != null)
                dimensionePagina = dimPag.Value;

            if (idCategoria != null)
                listaLibri = _categorieRepository.getCategoria(idCategoria.Value).LibriDelGenere.Select(x => x.LibroCollegato);
            else { listaLibri = _libroRepository.getLibri(); }

            if (listaLibri == null)
                throw new Exception("Non sono stati trovati risultati o un metodo interno non è riuscito a restituire nulla.");

            if (nomeLibro != null)
                listaLibri = listaLibri.Where(x => x.Nome.StartsWith(nomeLibro));

            if (dataDiPubblicazione != null)
                listaLibri = listaLibri.Where(x => x.DataDiPubblicazione.Equals(dataDiPubblicazione)); // si da per presupposto che in nessuna delle due sia stata specificato l'orario

            if (autore != null)
                listaLibri = listaLibri.Where(x => x.Autore.StartsWith(autore));

            listaLibri = listaLibri
                .Skip((pagina-1) * dimensionePagina)
                .Take(dimensionePagina);

            return listaLibri.ToList();

        }


    }
}
