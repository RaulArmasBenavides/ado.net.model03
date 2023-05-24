using Neptuno.DataAccess;
using System.Data.SqlClient;

namespace Neptuno.Bussines
{
   public  class ProveedorBL
    {
       ProveedorDatos dao = new ProveedorDatos();

       public SqlDataReader ProveedorListar()
       {
           return dao.ProveedorListar();
       }
    }
}
