using DAL.DataAccess.DominioServices;
using Domnio.Productos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Negocio
{
    public class ArticuloNegocio
    {
        private List<Articulo> listaArticulos;
        private ProductosServices services = new ProductosServices();
        public void Cargar(DataGridView gridView)
        {
            ProductosServices services = new ProductosServices();
            listaArticulos = services.listar();
            gridView.DataSource = listaArticulos;
            gridView.Columns["UrlImagen"].Visible = false;
            gridView.Columns["Id"].Width = 30;
            gridView.Columns["CodigoArticulo"].Width = 80;
            gridView.Columns["Marca"].Width = 85;
            gridView.Columns["Categoria"].Width = 90;
        }
        public void CargarImg(PictureBox picture ,string img)
        {
            try
            {
                picture.Load(img);
            }
            catch (Exception)
            {
                picture.Load("https://cdn-icons-png.flaticon.com/512/6040/6040846.png");
            }
        }
        public void BusquedaGeneral(DataGridView gridView, TextBox textBox)
        {
            List<Articulo> listaFiltrada;
            string buscar=textBox.Text;

            if (buscar!="")
            {
                listaFiltrada = listaArticulos.FindAll( x=>x.CodigoArticulo.ToUpper().Contains(buscar.ToUpper()) ||
                                                        x.Nombre.ToUpper().Contains(buscar.ToUpper()) ||
                                                        x.Marca.Descripcion.ToUpper().Contains(buscar.ToUpper()) ||
                                                        x.Categoria.Descripcion.ToUpper().Contains(buscar.ToUpper()));
            }
            else { listaFiltrada = listaArticulos; }

            gridView.DataSource = null;
            gridView.DataSource= listaFiltrada;

            gridView.Columns["UrlImagen"].Visible = false;
            gridView.Columns["Id"].Width = 30;
            gridView.Columns["CodigoArticulo"].Width = 80;
            gridView.Columns["Marca"].Width = 85;
            gridView.Columns["Categoria"].Width = 90;
        }
        public void BusquedaFiltrada(ref DataGridView gridView,ComboBox campo, ComboBox criterio, string busqueda)
        {
            if (campo.SelectedIndex < 0) { MessageBox.Show("Seleccionar campo"); return; }
            else if (criterio.SelectedIndex < 0) { MessageBox.Show("Seleccionar criterio"); return; }
            if (busqueda=="") { return; }

            string cam=campo.Text, cri=criterio.Text;
            listaArticulos = services.Filtrar(cam,cri,busqueda);
            gridView.DataSource = listaArticulos;
        }
        public void AgregarArticulo(Articulo nuevo)
        {
            if (ValidarCampos(ref nuevo)) { return; }

            setMarcaCategoriaId(ref nuevo);

            services.Agregar(nuevo);

            MessageBox.Show("¡Agregado exitosamente!");
        }
        public void ModificarArticulo(Articulo modificar)
        {
            if (ValidarCampos(ref modificar)) { return; }
            setMarcaCategoriaId(ref modificar);

            services.Modificar(modificar);

            MessageBox.Show("¡Modificado exitosamente!");
        }
        public void EliminarArticulo(Articulo eliminar)
        {
            services.Eliminar(eliminar);

            MessageBox.Show("¡Eliminado exitosamente!");
        }
        public void EliminarArticulo(int id, int rango)
        {
            services.EliminarPorRango(id, rango);

            MessageBox.Show("¡Eliminado exitosamente!");
        }
        private void setMarcaCategoriaId(ref Articulo a)
        {
            switch (a.Marca.Descripcion)
            {/* "Samsung" "Apple" "Sony" "Huawei" "Motorola" */
                case "Samsung" : a.Marca.Id = 1; break;
                case "Apple"   : a.Marca.Id = 2; break;
                case "Sony"    : a.Marca.Id = 3; break;
                case "Huawei"  : a.Marca.Id = 4; break;
                case "Motorola": a.Marca.Id = 5; break;
            }
            switch (a.Categoria.Descripcion)
            {/* "Celulares", "Televisores", "Media", "Audio" */
                case "Celulares"  : a.Categoria.Id = 1; break;
                case "Televisores": a.Categoria.Id = 2; break;
                case "Media"      : a.Categoria.Id = 3; break;
                case "Audio"      : a.Categoria.Id = 4; break;
            }
        }
        private bool ValidarCampos(ref Articulo art)
        {
            if (art.CodigoArticulo == "" || art.Nombre == "" || art.Marca.Descripcion == "" || art.Categoria.Descripcion == "" || art.Precio <= 0)
            { MessageBox.Show("Hay campos necesarios sin cargar."); return true; }
            return false;
        }
    }
}
