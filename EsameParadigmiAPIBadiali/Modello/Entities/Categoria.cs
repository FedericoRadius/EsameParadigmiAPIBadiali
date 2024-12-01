using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsameParadigmiAPIBadiali.Modello.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<LibroCategoria> LibriDelGenere { get; set; }



    }


}
