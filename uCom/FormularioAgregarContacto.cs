using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace uCom
{
    public partial class FormularioAgregarContacto : Form
    {
        public String Direccion
        {
            get
            {
                return tbDireccion.Text;
            }
            set
            {
                tbDireccion.Text = value;
            }
        }

        public FormularioAgregarContacto()
        {
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}