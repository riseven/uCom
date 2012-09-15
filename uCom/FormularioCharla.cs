using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace uCom
{
    public partial class FormularioCharla : Form
    {
        private Contacto contactoAsociado;
        private String nombreUsuario;
        private Boolean ultimoUsuario = false;
        private Boolean primerMensaje = true;

        public Contacto ContactoAsociado
        {
            get { return contactoAsociado; }
            set { contactoAsociado = value; }
        }

        public String NombreUsuario

        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public FormularioCharla()
        {
            InitializeComponent();
        }

        private void FormularioCharla_FormClosed(object sender, FormClosedEventArgs e)
        {
            contactoAsociado.Charla = null;
        }

        public void RecibirMensaje(String mensaje)
        {
            String texto = "";
            if (primerMensaje)
            {
                primerMensaje = false;

                texto += contactoAsociado.Nombre + ": ";
            }
            else
            {
                texto += Environment.NewLine;

                if (ultimoUsuario)
                {
                    texto += Environment.NewLine + contactoAsociado.Nombre + ": ";
                }
                else
                {
                    for (int i = 0; i < contactoAsociado.Nombre.Length; i++)
                        texto += " ";

                    texto += "  ";
                }
            }
            ultimoUsuario = false;

            texto += mensaje;
            tbLog.Text += texto;

            DesplazarVista();
        }

        private void DesplazarVista()
        {
            // Movemos el scroll para que se vea la ultima fila escrita
            tbLog.ScrollToCaret();
        }

        private void botonEnviar_Click(object sender, EventArgs e)
        {
            // Primero escribimos el texto en nuestro cliente
            String texto = "";
            if (primerMensaje)
            {
                primerMensaje = false;

                texto += nombreUsuario + ": ";
                
            }
            else
            {
                texto += Environment.NewLine;

                if (ultimoUsuario)
                {
                    for (int i = 0; i < nombreUsuario.Length; i++)
                        texto += " ";

                    texto += "  ";
                }
                else
                {
                    texto += Environment.NewLine + nombreUsuario + ": ";
                }
            }
            ultimoUsuario = true;
            texto += tbIntro.Text;
            tbLog.Text += texto;


            // Enviamos el mensaje al contacto asociado. Consiste en enviarle
            // un mensaje M, con el texto.

            // En primer lugar comprobamos si hay que resolver la ip
            if (contactoAsociado.IP == "")
            {
                contactoAsociado.IP = Dns.GetHostAddresses(contactoAsociado.Direccion)[0].ToString();
            }

            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(contactoAsociado.IP, 11984);
                Byte[] sendBytes = Encoding.ASCII.GetBytes("M" + tbIntro.Text);
                udpClient.Send(sendBytes, sendBytes.Length);
                tbIntro.Text = "";
                udpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tbLog.ScrollToCaret();
        }
    }
}