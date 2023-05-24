using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Neptuno.Service;

namespace Neptuno.DataAccess
{
   public class EmpleadoDatos
    {
       //instanciar objeto de la clase accesobd
       AccesoBD oCon = new AccesoBD();

       public DataTable EmpleadoListar()
       {
           return oCon.runConsulta("Select IdEmpleado,Apellidos,Nombre,Cargo From Empleados");
       }


    }
}
