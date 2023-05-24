using Neptuno.DataAccess;
using System.Data;

namespace Neptuno.Bussines
{
    public class EmpleadoBL
    {
        EmpleadoDatos dao = new EmpleadoDatos();

        public DataTable EmpleadoListar()
        {
            return dao.EmpleadoListar();
        }
    }
}
