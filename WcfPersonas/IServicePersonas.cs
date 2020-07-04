using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfPersonas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicePersonas" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePersonas
    {
        [OperationContract]
        List<EntPersona> Obtener();
        [OperationContract]
        List<EntPersona> ObtenerNombre(String nombre);
        [OperationContract]
        EntPersona ObtenerId(int id);
        [OperationContract]
        Boolean ObtenerRepetido(String nombre, String paterno, String materno);
        [OperationContract]
        void Create(EntPersona persona);
        [OperationContract]
        void Edit(EntPersona persona);
        [OperationContract]
        void Delete(EntPersona persona);


    }
}
