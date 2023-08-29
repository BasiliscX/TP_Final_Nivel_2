using System;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Domnio.Productos;
using UI.Negocio;

namespace UI
{
    public partial class ListaArticulos : Form
    {
        private ArticuloNegocio articulo=new ArticuloNegocio();
        private Articulo articuloAM =new Articulo();
        private CultureInfo cultureInfo = new CultureInfo("en-US");

        public ListaArticulos()
        {
            InitializeComponent();
            articulo.Cargar(dgbProductos);
            cargarCampoCriterio();
        }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~ Herramientas ~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /// <summary>
        /// TextBox:
        ///     Cambia a color Cyan el color de fondo si no hay carácteres.
        /// </summary>
        private void CambiarColorTxtVacio(string Boton)
        {
            switch (Boton)
            {
                case "btnBuscar":
                    if (txtBusquedaParametros.Text=="") { txtBusquedaParametros.BackColor = Color.Cyan; }
                    break;
                case "btnAgregar":
                    if (txtBusqArt.Text == "") { txtBusqArt.BackColor = Color.Cyan; }
                    if (txtBusqNombre.Text == "") { txtBusqNombre.BackColor = Color.Cyan; }
                    if (txtBusqPrecio.Text == "") { txtBusqPrecio.BackColor = Color.Cyan; }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// TextBox:
        ///     Limpia si hay carácteres y reestablece el color de fondo.
        /// </summary>
        private void ReiniciarTxt()
        {
            txtBusquedaGeneral.Text = "";
            txtBusqArt.BackColor = System.Drawing.SystemColors.Control;
            txtBusquedaParametros.Text = "";
            txtBusquedaParametros.BackColor=System.Drawing.SystemColors.Control;
            txtBusqArt.Text = "";
            txtBusqNombre.BackColor = System.Drawing.SystemColors.Control;
            txtBusqNombre.Text = "";
            txtbusqDescripcion.BackColor = System.Drawing.SystemColors.Control;
            txtbusqDescripcion.Text = "";
            txtBusqPrecio.BackColor = System.Drawing.SystemColors.Control;
            txtBusqPrecio.Text = "";
            txtUrlImagen.BackColor = System.Drawing.SystemColors.Control;
            txtUrlImagen.Text = "";
            txtEliminarIgual.Text = "";
            txtEliminarMayor.Text = "";
            txtEliminarMenor.Text = "";
        }
        /// <summary>
        /// Carga el objeto articuloAM(agregar/modificar) con los textbox y combobox.
        /// </summary>
        private void CargarArticulo()
        {
            articuloAM.Marca=new Marca();
            articuloAM.Categoria=new Categoria();
            try
            {
                articuloAM.CodigoArticulo = txtBusqArt.Text.ToUpper();
                articuloAM.Nombre = txtBusqNombre.Text;
                articuloAM.Descripcion = txtbusqDescripcion.Text;
                articuloAM.Marca.Descripcion = cbMarca.Text;
                articuloAM.Categoria.Descripcion = cbCategoria.Text;
                articuloAM.Precio = decimal.Parse(txtBusqPrecio.Text, cultureInfo);
                articuloAM.UrlImagen = txtUrlImagen.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hay campos vacios.");
            }
        }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~ Buscar productos ~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        /* Inicia interfaz de buscar productos */
        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            // Colores de textbox:
            ReiniciarTxt();
            pnlBotones.Visible = true;

            if (pnlBotones.Visible == true)
            {
                pnlBusquedaCampDes.Visible = false;
                lblBusquedaGeneral.Visible = false;
                btnModificar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
                pnlUrlImagen.Visible = false;
                pnlEliminar.Visible = true;
                lbBusquedaGeneral.Visible = true;
                pnlBusquedaCampDes.Visible = true;
                lblBusquedaGeneral.Visible = true;
                btnBuscar.Visible = true;
                lblBusq.Visible = true;
            }
        }
        /* Buscador general */
        private void txtBusquedaGeneral_TextChanged(object sender, EventArgs e)
        {
            articulo.BusquedaGeneral(dgbProductos, txtBusquedaGeneral);
        }
        /* Busqueda avanzada */
        private void cargarCampoCriterio()
        {
            /* Campos para busqueda */
            cbCampo.Items.Add("Precio");
            cbCampo.Items.Add("Descripción");

            /* Campos para Agregar y Modificar */
            cbMarca.Items.Add("Samsung");
            cbMarca.Items.Add("Apple");
            cbMarca.Items.Add("Sony");
            cbMarca.Items.Add("Huawei");
            cbMarca.Items.Add("Motorola");
            cbCategoria.Items.Add("Celulares");
            cbCategoria.Items.Add("Televisores");
            cbCategoria.Items.Add("Media");
            cbCategoria.Items.Add("Audio");
        }
        /* Campo seleccionado */
        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReiniciarTxt();

            string opcion = cbCampo.SelectedItem.ToString();

            switch (opcion)
            {
                case "Precio":
                    cbCriterio.Items.Clear();
                    cbCriterio.Items.Add("Mayor e igual a:");
                    cbCriterio.Items.Add("Igual a:");
                    cbCriterio.Items.Add("Menor e igual a:");
                    break;
                case "Descripción":
                    cbCriterio.Items.Clear();
                    cbCriterio.Items.Add("Empieza con:");
                    cbCriterio.Items.Add("Contiene:");
                    cbCriterio.Items.Add("Termina con:");
                    break;
                default:
                    break;
            }
        }
        /* Limita a solo númerico cuando la busqueda sea por precio */
        private void txtBusquedaParametros_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBusquedaParametros.BackColor = System.Drawing.SystemColors.Control;
            if (cbCampo.Text == "Precio") { Helper.SoloDecimales(ref e); }
        }
        /* boton de busqueda avanzada */
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CambiarColorTxtVacio("btnBuscar");
            articulo.BusquedaFiltrada(ref dgbProductos, cbCampo, cbCriterio, txtBusquedaParametros.Text);
        }
        /* Comportamientos de los botones y TextBox de agregar modificar */
        private void txtBusqArt_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblCodArt.Visible = false;
            txtBusqArt.BackColor = System.Drawing.SystemColors.Control;
        }
        private void txtBusqNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBusqNombre.BackColor = System.Drawing.SystemColors.Control;
        }
        private void txtbusqDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtbusqDescripcion.BackColor = System.Drawing.SystemColors.Control;
        }
        private void txtBusqPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.SoloDecimales(ref e);
            lblPrecio.Visible=false;
            txtBusqPrecio.BackColor = System.Drawing.SystemColors.Control;
        }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~ Agregar productos ~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        /* Inicia interfaz de agregrar productos */
        private void btnAgregarArticulos_Click(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            ReiniciarTxt();

            if (pnlBotones.Visible == true)
            {                 
                pnlBusquedaCampDes.Visible = false;
                lblBusquedaGeneral.Visible = false;
                btnModificar.Visible = false;
                btnEliminar.Visible = false;
                pnlEliminar.Visible = false;
                btnAgregar.Visible = true;
                pnlUrlImagen.Visible = true;
                lblBusq.Visible = true;
            }
        }
        /* Boton De agregar */
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CambiarColorTxtVacio("btnAgregar");
            articuloAM.Marca=new Marca();
            articuloAM.Categoria=new Categoria();

            try
            {
                CargarArticulo();
                articulo.AgregarArticulo(articuloAM);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hay campos sin cargar");
            }
            finally { articulo.Cargar(dgbProductos); }

        }
        /* Label de UrlImagen */
        private void txtUrlImagen_KeyPress(object sender, KeyPressEventArgs e)
        {
            lblIagen.Visible=false;
        }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~ Modificar productos ~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        private void btnModificarArticulos_Click(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            ReiniciarTxt();

            if (pnlBotones.Visible == true)
            {
                pnlBusquedaCampDes.Visible = false;
                lbBusquedaGeneral.Visible = false;
                lblBusquedaGeneral.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = false;
                pnlEliminar.Visible = false;
                btnModificar.Visible = true;
                pnlUrlImagen.Visible = true;
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            CambiarColorTxtVacio("btnEliminar");

            try
            {
                CargarArticulo();
                articulo.ModificarArticulo(articuloAM);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Hay campos sin cargar");
            }
            finally
            { articulo.Cargar(dgbProductos); }
        }
        /* Carga en el DatagridView la fila seleccionada */
        private void dgbProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnModificar.Visible == true)
            {
                articuloAM = (Articulo)dgbProductos.CurrentRow.DataBoundItem;

                txtBusqArt.Text = articuloAM.CodigoArticulo;
                txtBusqNombre.Text = articuloAM.Nombre;
                txtbusqDescripcion.Text=articuloAM.Descripcion;
                cbMarca.Text = articuloAM.Marca.Descripcion;
                cbCategoria.Text=articuloAM.Categoria.Descripcion;
                txtBusqPrecio.Text = articuloAM.Precio.ToString();
                txtUrlImagen.Text = articuloAM.UrlImagen;
            }
        }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~ Eliminar productos ~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        /* Inicia interfaz de eliminar productos */
        private void btnEliminarArticulos_Click(object sender, EventArgs e)
        {
            pnlBotones.Visible = true;
            ReiniciarTxt();

            if (pnlBotones.Visible == true)
            {
                pnlBusquedaCampDes.Visible = false;
                lblBusquedaGeneral.Visible = false;
                btnModificar.Visible = false;
                btnAgregar.Visible = false;
                btnEliminar.Visible = true;
                pnlUrlImagen.Visible = true;
                pnlEliminar.Visible = true;
            }
        }
        /* Boton de eliminar por selección */
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                articuloAM = (Articulo)dgbProductos.CurrentRow.DataBoundItem;
                articulo.EliminarArticulo(articuloAM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { articulo.Cargar(dgbProductos); }
        }
        /* Boton de eliminar por valor igual */
        private void btnEliminarIgual_Click(object sender, EventArgs e)
        {
            int id=0;
            try
            {
                id = int.Parse(txtEliminarIgual.Text);
                articulo.EliminarArticulo(id, 0);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Número demasiado grande.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Especificar correctamente.");
            }
            finally
            {
                articulo.Cargar(dgbProductos);
                ReiniciarTxt();
            }
        }
        /* Boton de eliminar por valor mayor e igual */
        private void btnEliminarMayor_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtEliminarMayor.Text);
                articulo.EliminarArticulo(id, 1);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Número demasiado grande.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Especificar correctamente.");
            }
            finally 
            {
                articulo.Cargar(dgbProductos);
                ReiniciarTxt();
            }
        }
        /* Boton de eliminar por valor menor e igual */
        private void btnEliminarMenor_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtEliminarMenor.Text);
                articulo.EliminarArticulo(id, 2);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Número demasiado grande.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Especificar correctamente.");
            }
            finally 
            {
                articulo.Cargar(dgbProductos);
                ReiniciarTxt();
            }
        }

        /* Textbox parámetros de entrada */
        private void txtEliminarIgual_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.SoloEnteros(ref e);
        }
        private void txtEliminarMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.SoloEnteros(ref e);
        }
        private void txtEliminarMenor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Helper.SoloEnteros(ref e);
        }
        /* Eventos del botón Eliminar */
        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            lblEliminarSeleccion.Visible = true;
        }
        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            lblEliminarSeleccion.Visible = false;
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~ Listar productos ~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /* Carga en la DataGridView los productos */
        private void btnListarArticulos_Click(object sender, EventArgs e)
        {
            articulo.Cargar(dgbProductos);
        }
        /* Carga la imagen de la selecion */
        private void dgbProductos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccion = (Articulo)dgbProductos.CurrentRow.DataBoundItem;
            articulo.CargarImg(pcbArticulo, seleccion.UrlImagen);
        }
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg";

            try
            {
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    txtUrlImagen.Text = archivo.FileName;
                    //IMGDefault(archivo.FileName);
                    articulo.CargarImg(pcbArticulo,archivo.FileName);
                    if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP"))) 
                    {
                        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["IMGfolder"] + archivo.SafeFileName); 
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}
