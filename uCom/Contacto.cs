using System;
using System.Collections.Generic;
using System.Text;

namespace uCom
{
    public class Contacto
    {
        private String direccion = "";
        private String nombre = "";
        private Boolean conectado = false;
        private FormularioCharla charla = null;
        private String ip = "";

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Boolean Conectado
        {
            get { return conectado; }
            set { conectado = value; }
        }

        public FormularioCharla Charla
        {
            get { return charla; }
            set { charla = value; }
        }

        public String IP
        {
            get { return ip; }
            set { ip = value; }
        }
        
    }
}
