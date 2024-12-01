using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsameParadigmiAPIBadiali.Modello.Entities
{
    public class LibroCategoria
    {
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public virtual Libro LibroCollegato { get; set; }
        public virtual Categoria CategoriaCollegata { get; set; }

        public LibroCategoria() { }

    }
}
