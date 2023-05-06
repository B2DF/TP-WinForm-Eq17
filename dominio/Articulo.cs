using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        /*
         * Los datos mínimos con los que deberá contar el artículo son los siguientes:

            Código de artículo.
            Nombre.
            Descripción.
            Marca (seleccionable de una lista desplegable).
            Categoría (seleccionable de una lista desplegable.
            Imagen.
            Precio.
         */
        public int Id { get; set; }
        public int CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }

    }
}
