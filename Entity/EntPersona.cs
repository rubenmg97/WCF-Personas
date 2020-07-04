using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EntPersona
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Paterno { get; set; }
        public String Materno { get; set; }
        public Boolean Sexo { get; set; }
        public DateTime Nacimiento { get; set; }
        public DateTime Alta { get; set; }
        public int Edad { get; set; }

        private String formatoAlta;
        public String FormatoAlta
        {
            get
            {
                formatoAlta = Alta.ToString("dd/MM/yyyy");
                return formatoAlta;
            }
        }

        private String formatoNacimiento;
        public String FormatoNacimiento
        {
            get
            {
                formatoNacimiento = Nacimiento.ToString("dd/MM/yyyy");
                return formatoNacimiento;
            }
        }

        private String nombreCompleto;
        public String NombreCompleto
        {
            get
            {
                nombreCompleto = Nombre + " " + Paterno + " " + Materno;
                return nombreCompleto;
            }
        }


    }
}
