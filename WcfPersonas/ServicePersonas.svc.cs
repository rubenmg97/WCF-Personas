using DaobussinesPersonas;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfPersonas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicePersonas" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicePersonas.svc o ServicePersonas.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicePersonas : IServicePersonas
    {
        DBPersona comando = new DBPersona();
        public List<EntPersona> Obtener()
        {
            List<EntPersona> ls = new List<EntPersona>();
            ls = comando.Obtener();
            return ls;
        }

        public List<EntPersona> ObtenerNombre(String nombre)
        {
            List<EntPersona> ls = new List<EntPersona>();
            ls = comando.Obtener(nombre);
            return ls;
        }

        public EntPersona ObtenerId(int id)
        {
            EntPersona persona = new EntPersona();
            persona = comando.Obtener(id);
            return persona;
        }

        public Boolean ObtenerRepetido(String nombre, String paterno, String materno)
        {
            Boolean flag = false;
            flag = comando.Obtener(nombre, paterno, materno);
            return flag;
        }

        public void Create(EntPersona persona)
        {
            comando.Create(persona);
        }
        public void Edit(EntPersona persona)
        {
            comando.Edit(persona);
        }
        public void Delete(EntPersona persona)
        {
            comando.Delete(persona);
        }

    }
}
