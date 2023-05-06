using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio,M.Id as IdMarca, M.Descripcion as Marca,C.Id as IdCategoria, C.Descripcion as Categoria from ARTICULOS as A inner join MARCAS as M on A.IdMarca = M.Id inner join CATEGORIAS as C on A.IdCategoria = C.Id");
                //datos.setearConsulta("SELECT Id,Codigo,Nombre,Descripcion FROM ARTICULOS");
                datos.setearConsulta("SELECT A.Id AId,Codigo,Nombre,A.Descripcion ADes, C.Descripcion CDes, M.Descripcion MDes, Precio FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE C.Id=A.IdCategoria AND M.Id=A.IdMarca\r\n");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["AId"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ADes"];
                    aux.Categoria = new Categoria();
                    //aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["CDes"];
                    aux.Marca = new Marca();
                    //aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["MDes"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    listaArticulos.Add(aux);
                }
                return listaArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio) VALUES (@codigo,@nombre,@desc,@marca,@categoria,@precio)");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@desc", nuevo.Descripcion);
                datos.setearParametro("@marca", nuevo.Marca.Id);
                datos.setearParametro("@categoria", nuevo.Categoria.Id);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        

    }
}
