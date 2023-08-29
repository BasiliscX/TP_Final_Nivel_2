namespace UI
{
    partial class frmPresentacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPresentacion));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pnlMenuvertical = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCerrarVentanas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProductos = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlTitulo.SuspendLayout();
            this.pnlMenuvertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.pnlTitulo.Controls.Add(this.panel10);
            this.pnlTitulo.Controls.Add(this.panel11);
            this.pnlTitulo.Controls.Add(this.btnFinalizar);
            this.pnlTitulo.Controls.Add(this.panel9);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1300, 40);
            this.pnlTitulo.TabIndex = 0;
            this.pnlTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitulo_MouseDown);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel10.Location = new System.Drawing.Point(1140, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 32);
            this.panel10.TabIndex = 18;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel11.Location = new System.Drawing.Point(1287, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(10, 32);
            this.panel11.TabIndex = 17;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(1140, 3);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(157, 32);
            this.btnFinalizar.TabIndex = 14;
            this.btnFinalizar.Text = "Finalizar sesión";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.panel9.Location = new System.Drawing.Point(1140, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(10, 32);
            this.panel9.TabIndex = 16;
            // 
            // pnlMenuvertical
            // 
            this.pnlMenuvertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.pnlMenuvertical.Controls.Add(this.pbLogo);
            this.pnlMenuvertical.Controls.Add(this.panel8);
            this.pnlMenuvertical.Controls.Add(this.panel2);
            this.pnlMenuvertical.Controls.Add(this.panel6);
            this.pnlMenuvertical.Controls.Add(this.btnCerrarVentanas);
            this.pnlMenuvertical.Controls.Add(this.panel1);
            this.pnlMenuvertical.Controls.Add(this.btnProductos);
            this.pnlMenuvertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuvertical.Location = new System.Drawing.Point(0, 40);
            this.pnlMenuvertical.Name = "pnlMenuvertical";
            this.pnlMenuvertical.Size = new System.Drawing.Size(220, 610);
            this.pnlMenuvertical.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.BackgroundImage")));
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLogo.Cursor = System.Windows.Forms.Cursors.PanNE;
            this.pbLogo.Location = new System.Drawing.Point(12, 15);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(84, 75);
            this.pbLogo.TabIndex = 14;
            this.pbLogo.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel8.Location = new System.Drawing.Point(170, 556);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 32);
            this.panel8.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Location = new System.Drawing.Point(33, 556);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 32);
            this.panel2.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(220, 222);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 100);
            this.panel6.TabIndex = 0;
            // 
            // btnCerrarVentanas
            // 
            this.btnCerrarVentanas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCerrarVentanas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarVentanas.FlatAppearance.BorderSize = 0;
            this.btnCerrarVentanas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnCerrarVentanas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarVentanas.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarVentanas.ForeColor = System.Drawing.Color.White;
            this.btnCerrarVentanas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarVentanas.Location = new System.Drawing.Point(36, 556);
            this.btnCerrarVentanas.Name = "btnCerrarVentanas";
            this.btnCerrarVentanas.Size = new System.Drawing.Size(144, 32);
            this.btnCerrarVentanas.TabIndex = 11;
            this.btnCerrarVentanas.Text = "Cerrar ventana";
            this.btnCerrarVentanas.UseVisualStyleBackColor = false;
            this.btnCerrarVentanas.Click += new System.EventHandler(this.btnCerrarVentanas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Location = new System.Drawing.Point(3, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 50);
            this.panel1.TabIndex = 1;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnProductos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProductos.BackgroundImage")));
            this.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(6, 326);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(214, 50);
            this.btnProductos.TabIndex = 0;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(220, 40);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1080, 610);
            this.pnlContenedor.TabIndex = 2;
            // 
            // frmPresentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenuvertical);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmPresentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.pnlTitulo.ResumeLayout(false);
            this.pnlMenuvertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Panel pnlMenuvertical;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrarVentanas;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}

