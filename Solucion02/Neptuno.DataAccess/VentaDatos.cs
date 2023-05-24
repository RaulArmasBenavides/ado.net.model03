using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Neptuno.Service;
using System.Data;
using System.Data.SqlClient;
using Neptuno.Entity;

namespace Neptuno.DataAccess
{
   public  class VentaDatos
    {
       AccesoBD oCon = new AccesoBD();

       public DataTable ClienteListar()
       {
           return oCon.runConsulta("Select IdCliente,NombreCompañía From Clientes");
       }

       public DataTable VentasPorCliente(string cod)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter idcli = new SqlParameter("@IdCliente", cod);
           lista.Add(idcli);
           return oCon.runConsulta("Select * From Ventas Where IdCliente=@IdCliente", lista);
       }

       public DataTable DetallesPorVenta(int cod)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter idven= new SqlParameter("@Idventa", cod);
           lista.Add(idven);
           return oCon.runConsulta("Select * From Detalles Where IdVenta=@IdVenta", lista);
       }

       public DataTable ListarCliente()
       {
           return oCon.runConsulta("Select IdCliente,NombreCompañía From Clientes");
       }

       public DataTable EmpleadoListar()
       {
           return oCon.runConsulta("Select IdEmpleado,Empleado=Apellidos+' '+Nombre From Empleados order by Empleado");
       }

       public DataTable ProductoListar()
       {
           return oCon.runConsulta("Select IdProducto,NombreProducto From Productos order by NombreProducto");
       }

       public SqlDataReader ProductoDatos(int cod)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter idpro = new SqlParameter("@Idproducto", cod);
           lista.Add(idpro);
           return oCon.runCursor("Select IdProducto,Precio,stock from Productos where IdProducto=@Idproducto", lista);
       }
        
       private int NumeroVenta()
       {
           DataTable tb = oCon.runConsulta("Select Max(idpedido) from Pedidos");
           int nro =(int) tb.Rows[0][0];
           return nro;
       }

       public int RegistraVenta(Venta reg)
       {
           int nroventa ;
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter idcli = new SqlParameter("@IdCliente", reg.idcliente);
           SqlParameter idemp = new SqlParameter("@IdEmpleado", reg.idempleado);
           SqlParameter fecven = new SqlParameter("@Fecha", reg.fechaventa);
           SqlParameter tot = new SqlParameter("@Monto", reg.monto);
           lista.Add(idcli);
           lista.Add(idemp);
           lista.Add(fecven);
           lista.Add(tot);
         int z= oCon.runTransaccionStore("usp_Registra_Venta", lista);
         nroventa=NumeroVenta();
         foreach (Detalle item in reg.item)
         {
             List<SqlParameter> lista1 = new List<SqlParameter>();
             SqlParameter idven = new SqlParameter("@Idventa", nroventa);
             SqlParameter idpro = new SqlParameter("@IdProducto", item.idproducto);
             SqlParameter pre = new SqlParameter("@Precio", item.precio);
             SqlParameter cant = new SqlParameter("@Cantidad", item.cantidad);
             lista1.Add(idven);
             lista1.Add(idpro);
             lista1.Add(pre);
             lista1.Add(cant);
             int s = oCon.runTransaccionStore("usp_Registra_Detalle",lista1);
             List<SqlParameter> lista2 = new List<SqlParameter>();
             SqlParameter idpro1 = new SqlParameter("@IdProducto", item.idproducto);
             SqlParameter cant1 = new SqlParameter("@Cantidad", item.cantidad);
             lista2.Add(idpro1);
             lista2.Add(cant1);
             int p = oCon.runTransaccionStore("usp_Actualiza_Stock", lista2);
         }
           return nroventa;
       }       

    }
}
