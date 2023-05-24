using Neptuno.Entity;
using Neptuno.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Neptuno.Bussines
{
    public class VentaBL
    {
        private VentaDatos dao;

        public VentaBL()
        {
            dao = new VentaDatos();
        }
        // metodos
        public DataTable ClienteListar()
        {
            return dao.ClienteListar();
        }

        public DataTable VentasPorCliente(string cod)
        {
            return dao.VentasPorCliente(cod);
        }

        public DataTable DetallesPorVenta(int cod)
        {
            return dao.DetallesPorVenta(cod);
        }

        public DataTable ListarCliente()
        {
            return dao.ListarCliente();
        }

        public DataTable EmpleadoListar()
        {
            return dao.EmpleadoListar();
        }

        public DataTable ProductoListar()
        {
            return dao.ProductoListar();
        }

        public SqlDataReader ProductoDatos(int cod)
        {
            return dao.ProductoDatos(cod);
        }

        public int RegistraVenta(Venta reg)
        {
            return dao.RegistraVenta(reg);
        }
    }
}

