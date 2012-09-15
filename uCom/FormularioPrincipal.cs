using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.IO;

namespace uCom
{
    public partial class FormularioPrincipal : Form
    {
        private List<Contacto> listaDatosContactos;
        public static UdpClient udpListener;

        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            listaDatosContactos = new List<Contacto>();
            udpListener = new UdpClient(11984);

            CargarDatos();

            if (tbNombre.Text == "")
            {
                listaContactos.Enabled = false;
                botonBuscarContactos.Enabled = false;
                botonAgregar.Enabled = false;
                botonEliminar.Enabled = false;
                botonIniciar.Enabled = false;

                tbMensaje.Text = "Debe introducir un nombre antes de empezar a utilizar uCom";
            }

            MostrarListaContactos();
        }

        private void botonNombreOK_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "")
            {
                MessageBox.Show("Debe introducir un nombre");
            }
            else
            {
                listaContactos.Enabled = true;
                botonBuscarContactos.Enabled = true;
                botonAgregar.Enabled = true;
                botonEliminar.Enabled = true;
                botonIniciar.Enabled = true;

                tbMensaje.Text = "Bienvenido a uCom. La solución descentralizada de mensajería instantánea con el mínimo consumo de ancho de banda. Hecho por Riseven. 2007";
            }
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            if (listaContactos.SelectedIndex < 0)
            {
                MessageBox.Show("No hay ningún contacto seleccionado");
            }
            else
            {
                listaDatosContactos.RemoveAt(listaContactos.SelectedIndex);
                MostrarListaContactos();
            }
        }

        private void botonAgregar_Click(object sender, EventArgs e)
        {
            FormularioAgregarContacto fac = new FormularioAgregarContacto();
            fac.Direccion = "";
            if (fac.ShowDialog() == DialogResult.OK)
            {
                Contacto c = new Contacto();
                c.Direccion = fac.Direccion;
                c.Nombre = "";
                c.Conectado = false;
                listaDatosContactos.Add(c);

                MostrarListaContactos();
            }
        }

        private void MostrarListaContactos()
        {
            listaContactos.Items.Clear();

            foreach (Contacto c in listaDatosContactos)
            {
                String texto = "";
                if (c.Nombre == "")
                {
                    texto = "(" + c.Direccion + ")";
                }
                else
                {
                    texto = c.Nombre;
                }
                
                if (c.Conectado)
                {
                    texto += " [Conectado]";
                }
                else
                {
                    texto += " [Desconectado]";
                }

                listaContactos.Items.Add(texto);
            }
        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            if (listaContactos.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un contacto con el que charlar");
            }
            else
            {
                Contacto c = listaDatosContactos[listaContactos.SelectedIndex];
                if (c.Conectado == false)
                {
                    MessageBox.Show("El contacto no está conectado");
                    return;
                }

                if (c.Charla == null)
                {

                    // Abrimos la ventana de charla
                    FormularioCharla fc = new FormularioCharla();
                    fc.Show();

                    // Vinculamos la ventana al contacto
                    listaDatosContactos[listaContactos.SelectedIndex].Charla = fc;
                    fc.ContactoAsociado = listaDatosContactos[listaContactos.SelectedIndex];
                    fc.NombreUsuario = tbNombre.Text;
                }
            }
        }

        private void NotificarPresencia(Contacto c)
        {
            // Notificamos nuestra presencia al contacto c. Consiste en enviarle
            // un mensaje N, con nuestro nombre. El contestara con un mensaje
            // de respuesta R, con su nombre (si está conectado)

            // En primer lugar comprobamos si hay que resolver la ip
            try
            {
                if (c.IP == "")
                {
                    c.IP = Dns.GetHostAddresses(c.Direccion)[0].ToString();
                }

                UdpClient udpClient = new UdpClient();

                udpClient.Connect(c.IP, 11984);
                Byte[] sendBytes = Encoding.ASCII.GetBytes("N" + tbNombre.Text);
                udpClient.Send(sendBytes, sendBytes.Length);
                udpClient.Close();

                c.Conectado = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ResponderPresencia(Contacto c)
        {
            // Notificamos nuestra presencia al contacto c. Consiste en enviarle
            // un mensaje N, con nuestro nombre. El contestara con un mensaje
            // de respuesta R, con su nombre (si está conectado)

            // En primer lugar comprobamos si hay que resolver la ip
            if (c.IP == "")
            {
                c.IP = Dns.GetHostAddresses(c.Direccion)[0].ToString();
            }

            UdpClient udpClient = new UdpClient();
            try
            {
                udpClient.Connect(c.IP, 11984);
                Byte[] sendBytes = Encoding.ASCII.GetBytes("R" + tbNombre.Text);
                udpClient.Send(sendBytes, sendBytes.Length);
                udpClient.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void botonBuscarContactos_Click(object sender, EventArgs e)
        {
            foreach (Contacto c in listaDatosContactos)
            {
                NotificarPresencia(c);
            }
        }

        private void timerEscucha_Tick(object sender, EventArgs e)
        {
            if (udpListener.Available > 0)
            {
                IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receivedBytes = udpListener.Receive(ref remoteIpEndPoint);

                //MessageBox.Show(Encoding.ASCII.GetString(receivedBytes));
                ;

                // Hay que adivinar a quien corresponde esta IP
                foreach (Contacto c in listaDatosContactos)
                {
                    if (c.IP == remoteIpEndPoint.Address.ToString())
                    {
                        // Comprobamos el tipo del mensaje
                        switch ( receivedBytes[0] )
                        {
                            case (Byte)'N':
                                c.Conectado = true;
                                c.Nombre = Encoding.ASCII.GetString( receivedBytes, 1, receivedBytes.Length-1);

                                // Contestamos
                                ResponderPresencia(c);

                                break;
                            case (Byte)'R':
                                c.Conectado = true;
                                c.Nombre = Encoding.ASCII.GetString(receivedBytes, 1, receivedBytes.Length - 1);
                                break;
                            case (Byte)'M':
                                c.Conectado = true;

                                if (c.Charla == null)
                                {
                                    c.Charla = new FormularioCharla();

                                    c.Charla.ContactoAsociado = c;
                                    c.Charla.NombreUsuario = tbNombre.Text;

                                    c.Charla.Show();
                                }

                                c.Charla.RecibirMensaje(Encoding.ASCII.GetString(receivedBytes, 1, receivedBytes.Length - 1));
                                break;
                        }

                        MostrarListaContactos();
                        return;
                    }
                }

                // El mensaje es de alguien nuevo, lo añadimos
                Contacto nuevo = new Contacto();
                nuevo.Conectado = true;
                nuevo.Direccion = remoteIpEndPoint.Address.ToString();
                nuevo.IP = nuevo.Direccion;

                listaDatosContactos.Add(nuevo);

                switch (receivedBytes[0])
                {
                    case (Byte)'N':
                        nuevo.Conectado = true;
                        nuevo.Nombre = Encoding.ASCII.GetString(receivedBytes, 1, receivedBytes.Length - 1);

                        // Contestamos
                        ResponderPresencia(nuevo);

                        break;
                    case (Byte)'R':
                        nuevo.Conectado = true;
                        nuevo.Nombre = Encoding.ASCII.GetString(receivedBytes, 1, receivedBytes.Length - 1);
                        break;
                    case (Byte)'M':
                        nuevo.Conectado = true;

                        if (nuevo.Charla == null)
                        {
                            nuevo.Charla = new FormularioCharla();

                            nuevo.Charla.ContactoAsociado = nuevo;
                            nuevo.Charla.NombreUsuario = tbNombre.Text;

                            nuevo.Charla.Show();
                        }

                        nuevo.Charla.RecibirMensaje(Encoding.ASCII.GetString(receivedBytes, 1, receivedBytes.Length - 1));
                        break;
                }

                MostrarListaContactos();

            }
        }

        private void FormularioPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlDocument data = new XmlDocument();
            XmlElement nombre = data.CreateElement("Nombre");
            nombre.Attributes.Append(data.CreateAttribute("Value"));
            nombre.Attributes["Value"].Value = tbNombre.Text;
            data.AppendChild(nombre);

            foreach (Contacto c in listaDatosContactos)
            {
                XmlElement nodo = data.CreateElement("Contacto");
                nodo.Attributes.Append(data.CreateAttribute("Direccion"));
                nodo.Attributes["Direccion"].Value = c.Direccion;
                nombre.AppendChild(nodo);
            }

            StreamWriter sw = File.CreateText("ucomdata.xml");
            sw.Write(data.OuterXml);
            sw.Close();
        }

        private void CargarDatos()
        {
            XmlDocument data = new XmlDocument();

            StreamReader sr = File.OpenText("ucomdata.xml");
            data.LoadXml(sr.ReadToEnd());
            sr.Close();

            XmlNode nombre = data.FirstChild;
            tbNombre.Text = nombre.Attributes["Value"].Value;

            foreach (XmlNode contacto in nombre.ChildNodes)
            {
                Contacto c = new Contacto();
                c.Charla = null;
                c.Conectado = false;
                c.IP = "";
                c.Nombre = "";
                c.Direccion = contacto.Attributes["Direccion"].Value;

                listaDatosContactos.Add(c);
            }
        }
    }
}
