using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domnio;
using Domnio.Productos;

namespace DAL.DataAccess.DominioServices
{
    public class ProductosServices
    {
        private DataAccessServices dataAccess;
        public List<Articulo> listar()
        {
            dataAccess = new DataAccessServices();

            List<Articulo> lista = new List<Articulo>();
            try
            {
                dataAccess.SetConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion MD, C.Descripcion CD, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca=M.Id and A.IdCategoria=C.Id");
                dataAccess.EjecutarLectura();
                WhileLectorRead(lista, dataAccess);

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { dataAccess.CerrarConexion(); }
        }
        public List<Articulo> Filtrar(string campo, string criterio, string busqueda)
        {
            dataAccess = new DataAccessServices();
            List<Articulo> lista= new List<Articulo>();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion MD, C.Descripcion CD, A.ImagenUrl, A.Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca=M.Id and A.IdCategoria=C.Id and ";

                switch (campo)
                {
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor e igual a:": consulta += "A.precio >= "+busqueda; break;
                            case "Igual a:"        : consulta += "A.precio = " +busqueda; break;
                            case "Menor e igual a:": consulta += "A.precio <= "+busqueda; break;
                        }
                        break;
                    case "Descripción":
                        switch (criterio)
                        {
                            case "Empieza con:": consulta += "A.Descripcion like '" + busqueda + "%'" ; break;
                            case "Contiene:"   : consulta += "A.Descripcion like '%" + busqueda + "%'"; break;
                            case "Termina con:": consulta += "A.Descripcion like '%" + busqueda + "'" ; break;
                        }
                        break;
                }

                dataAccess.SetConsulta(consulta);
                dataAccess.EjecutarLectura();
                WhileLectorRead(lista, dataAccess);

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Agregar(Articulo nuevo)
        {
            dataAccess = new DataAccessServices();
            try
            {
                dataAccess.SetConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@codArt, @nombre, @descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                dataAccess.SetParametros("codArt", nuevo.CodigoArticulo);
                dataAccess.SetParametros("nombre", nuevo.Nombre);
                dataAccess.SetParametros("descripcion", nuevo.Descripcion);
                dataAccess.SetParametros("IdMarca", nuevo.Marca.Id);
                dataAccess.SetParametros("IdCategoria", nuevo.Categoria.Id);
                dataAccess.SetParametros("ImagenUrl", nuevo.UrlImagen);
                dataAccess.SetParametros("Precio", nuevo.Precio);
                dataAccess.EjecutarAccion();
            }
            catch (SqlException ex)
            {
                return;
            }
            finally { dataAccess.CerrarConexion(); }
        }
        public void Modificar(Articulo articulo)
        {
            dataAccess = new DataAccessServices();
            try
            {
                dataAccess.SetConsulta("update ARTICULOS set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, ImagenUrl=@ImagenUrl, Precio=@Precio where Id=@Id");

                dataAccess.SetParametros("Codigo", articulo.CodigoArticulo);
                dataAccess.SetParametros("Nombre", articulo.Nombre);
                dataAccess.SetParametros("Descripcion", articulo.Descripcion);
                dataAccess.SetParametros("IdMarca", articulo.Marca.Id);
                dataAccess.SetParametros("IdCategoria", articulo.Categoria.Id);
                dataAccess.SetParametros("ImagenUrl", articulo.UrlImagen);
                dataAccess.SetParametros("Precio", articulo.Precio);
                dataAccess.SetParametros("Id", articulo.Id);

                dataAccess.EjecutarAccion();
            }
            catch (SqlException ex)
            {
                return;
            }
            finally { dataAccess.CerrarConexion(); }
        }
        public void Eliminar(Articulo eliminar)
        {
            dataAccess=new DataAccessServices();
            try
            {
                dataAccess.SetConsulta("delete from ARTICULOS where Id=@Id");
                dataAccess.SetParametros("Id", eliminar.Id);
                dataAccess.EjecutarAccion();
            }
            catch (SqlException ex)
            {
                return;
            }
            finally { dataAccess.CerrarConexion() ; }
        }
        public void EliminarPorRango(int id,int rango)
        {
            dataAccess = new DataAccessServices();
            try
            {
                string consulta = "delete from ARTICULOS where ";
                switch (rango)
                {
                    case 0: consulta += " Id=@Id"; break;
                    case 1: consulta += "Id>=@Id"; break;
                    case 2: consulta += "Id<=@Id"; break;
                    default:
                        break;
                }


                dataAccess.SetConsulta(consulta);
                dataAccess.SetParametros("Id", id);
                dataAccess.EjecutarAccion();
            }
            catch (SqlException ex)
            {
                return;
            }
            finally { dataAccess.CerrarConexion(); }
        }
        private void WhileLectorRead(List<Articulo> lista, DataAccessServices services)
        {
            while (services.Reader.Read())
            {
                Articulo aux = new Articulo();
                aux.Marca=new Marca();
                aux.Categoria=new Categoria();

                aux.Id = (int)services.Reader["Id"];
                aux.CodigoArticulo = (string)services.Reader["Codigo"];
                aux.Nombre = (string)services.Reader["Nombre"];
                aux.Descripcion = (string)services.Reader["Descripcion"];
                aux.Marca.Descripcion = (string)services.Reader["MD"];
                aux.Categoria.Descripcion = (string)services.Reader["CD"];
                aux.UrlImagen = (string)services.Reader["ImagenUrl"];
                aux.Precio = (decimal)services.Reader["Precio"];

                lista.Add(aux);
            }

        }
    }
}
