namespace uCom
{
    partial class FormularioPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.listaContactos = new System.Windows.Forms.ListBox();
            this.botonAgregar = new System.Windows.Forms.Button();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonIniciar = new System.Windows.Forms.Button();
            this.botonBuscarContactos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.botonNombreOK = new System.Windows.Forms.Button();
            this.timerEscucha = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbMensaje
            // 
            this.tbMensaje.Location = new System.Drawing.Point(12, 12);
            this.tbMensaje.Multiline = true;
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.ReadOnly = true;
            this.tbMensaje.Size = new System.Drawing.Size(255, 49);
            this.tbMensaje.TabIndex = 1;
            this.tbMensaje.Text = "Bienvenido a uCom. La solución descentralizada de mensajería instantánea con el m" +
                "ínimo consumo de ancho de banda. Hecho por Riseven. 2007";
            // 
            // listaContactos
            // 
            this.listaContactos.BackColor = System.Drawing.Color.Honeydew;
            this.listaContactos.FormattingEnabled = true;
            this.listaContactos.Location = new System.Drawing.Point(12, 93);
            this.listaContactos.Name = "listaContactos";
            this.listaContactos.Size = new System.Drawing.Size(174, 238);
            this.listaContactos.TabIndex = 2;
            // 
            // botonAgregar
            // 
            this.botonAgregar.Location = new System.Drawing.Point(192, 155);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(75, 53);
            this.botonAgregar.TabIndex = 3;
            this.botonAgregar.Text = "Agregar Contacto";
            this.botonAgregar.UseVisualStyleBackColor = true;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(192, 214);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(75, 53);
            this.botonEliminar.TabIndex = 4;
            this.botonEliminar.Text = "Eliminar Contacto";
            this.botonEliminar.UseVisualStyleBackColor = true;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // botonIniciar
            // 
            this.botonIniciar.Location = new System.Drawing.Point(192, 273);
            this.botonIniciar.Name = "botonIniciar";
            this.botonIniciar.Size = new System.Drawing.Size(75, 53);
            this.botonIniciar.TabIndex = 5;
            this.botonIniciar.Text = "Iniciar Charla";
            this.botonIniciar.UseVisualStyleBackColor = true;
            this.botonIniciar.Click += new System.EventHandler(this.botonIniciar_Click);
            // 
            // botonBuscarContactos
            // 
            this.botonBuscarContactos.Location = new System.Drawing.Point(192, 96);
            this.botonBuscarContactos.Name = "botonBuscarContactos";
            this.botonBuscarContactos.Size = new System.Drawing.Size(75, 53);
            this.botonBuscarContactos.TabIndex = 6;
            this.botonBuscarContactos.Text = "Buscar Contactos Conectados";
            this.botonBuscarContactos.UseVisualStyleBackColor = true;
            this.botonBuscarContactos.Click += new System.EventHandler(this.botonBuscarContactos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // tbNombre
            // 
            this.tbNombre.BackColor = System.Drawing.Color.MistyRose;
            this.tbNombre.Location = new System.Drawing.Point(62, 67);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(164, 20);
            this.tbNombre.TabIndex = 8;
            // 
            // botonNombreOK
            // 
            this.botonNombreOK.Location = new System.Drawing.Point(232, 65);
            this.botonNombreOK.Name = "botonNombreOK";
            this.botonNombreOK.Size = new System.Drawing.Size(35, 23);
            this.botonNombreOK.TabIndex = 9;
            this.botonNombreOK.Text = "OK";
            this.botonNombreOK.UseVisualStyleBackColor = true;
            this.botonNombreOK.Click += new System.EventHandler(this.botonNombreOK_Click);
            // 
            // timerEscucha
            // 
            this.timerEscucha.Enabled = true;
            this.timerEscucha.Tick += new System.EventHandler(this.timerEscucha_Tick);
            // 
            // FormularioPrincipal
            // 
            this.AcceptButton = this.botonNombreOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(280, 342);
            this.Controls.Add(this.botonNombreOK);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonBuscarContactos);
            this.Controls.Add(this.botonIniciar);
            this.Controls.Add(this.botonEliminar);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.listaContactos);
            this.Controls.Add(this.tbMensaje);
            this.Name = "FormularioPrincipal";
            this.Text = "uCom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormularioPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMensaje;
        private System.Windows.Forms.ListBox listaContactos;
        private System.Windows.Forms.Button botonAgregar;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonIniciar;
        private System.Windows.Forms.Button botonBuscarContactos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Button botonNombreOK;
        private System.Windows.Forms.Timer timerEscucha;
    }
}

