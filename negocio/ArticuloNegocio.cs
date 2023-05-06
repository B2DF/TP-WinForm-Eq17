using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Reflection;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            //SqlConnection conexion = new SqlConnection();
            //SqlCommand comando = new SqlCommand();
            //SqlDataReader lector;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, "+
                //    "M.Descripcion as Marca, C.Descripcion as Categoria "+
                //    "from ARTICULOS as A inner "+
                //    "join MARCAS as M on A.IdMarca = M.Id inner "+
                //    "join CATEGORIAS as C on A.IdCategoria = C.Id";
                //comando.Connection = conexion;
                //conexion.Open();
                //lector = comando.ExecuteReader();
                datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio,M.Id as IdMarca, M.Descripcion as Marca,C.Id as IdCategoria, C.Descripcion as Categoria from ARTICULOS as A inner join MARCAS as M on A.IdMarca = M.Id inner join CATEGORIAS as C on A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (int)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    //aux.ImagenUrl = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    lista.Add(aux);
                }
                
                return lista;
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
