using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neptuno.Service;
using System.Data.SqlClient;

namespace Neptuno.DataAccess
{
    public class ProveedorDatos
    {
        AccesoBD oCon = new AccesoBD();

        public SqlDataReader ProveedorListar()
        {
            return oCon.runCursor("select IdProveedor,NombreCompañía,País,Ciudad From Proveedores");
        }
   
    }
}
