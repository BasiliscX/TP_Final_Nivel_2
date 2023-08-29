using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmPresentacion : Form
    {
        public frmPresentacion()
        {
            InitializeComponent();
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        // Permite mover la ventana principal:
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Botones invocadores de forms:
        private void btnProductos_Click(object sender, EventArgs e)
        {
            ListaArticulos listaArticulos = new ListaArticulos();
            InvocarForm(listaArticulos);
        }
        /********************* Funciones para invocar forms ****************************/
        // Util para cada llamado que se haga ;)
        private void InvocarForm(Form form)
        {
            CerrarViejoForm();
            form.MdiParent = this;
            pnlContenedor.Controls.Add(form);
            CentrarVentanaPNL(pnlContenedor, form);
            form.Show();
        }
        private void CentrarVentanaPNL(Panel pnl, Form form)
        {
            // Obtiene las dimensiones del panel contenedor y del formulario secundario
            int panelWidth = pnl.Width;
            int panelHeight = pnl.Height;
            int formWidth = form.Width;
            int formHeight = form.Height;

            // Calcula las coordenadas X e Y para centrar el formulario en el panel
            int x = (panelWidth - formWidth) / 2;
            int y = (panelHeight - formHeight) / 2;

            // Establece la posición del formulario dentro del panel
            form.SetBounds(x, y, formWidth, formHeight);

        }
        // Cierra un form hijo abierto si lo hubiera
        private void CerrarViejoForm()
        {
            if(this.pnlContenedor.Controls.Count > 0) { this.pnlContenedor.Controls.RemoveAt(0); }
        }
        private void btnCerrarVentanas_Click(object sender, EventArgs e)
        {
            CerrarViejoForm();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*******************************************************************************/



    }
}
