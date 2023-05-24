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
   public class ProductoDatos
    {
       AccesoBD oCon = new AccesoBD();

       public DataTable ProduductoPorNombre(string nom)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter nombre = new SqlParameter("@Nombre", nom + "%");
           lista.Add(nombre);
           return oCon.runConsulta("Select * From Productos Where NombreProducto LIKE @Nombre", lista);
       }

       public DataTable CategoriaListar()
       {
           return oCon.runConsulta("Select IdCategoría,NombreCategoría From Categorías");
       }

       public DataTable ProduductoPorCategoria(int cod)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter idcat = new SqlParameter("@IdCategoria", cod);
           lista.Add(idcat);
           return oCon.runConsulta("Select IdProducto,NombreProducto,Precio,Stock From Productos Where IdCategoria=@IdCategoria", lista);
       }

       public DataTable ProductoListar()
       {
          return oCon.runConsultaStore("usp_Productos_Listar");
       }

       public DataTable ProveedorListar()
       {
           return oCon.runConsulta("Select IdProveedor,NombreCompañía From Proveedores");
       }

       public int ProductoAdicionar(Producto reg)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter nom = new SqlParameter("@Nombre", reg.nombre);
           SqlParameter idpro = new SqlParameter("@Idproveedor",reg.idprove);
           SqlParameter idcat = new SqlParameter("@IdCategoria", reg.idcat);
           SqlParameter pre = new SqlParameter("@Precio", reg.precio);
           SqlParameter stk = new SqlParameter("@Stock", reg.stock);
           lista.Add(nom);
           lista.Add(idpro);
           lista.Add(idcat);
           lista.Add(pre);
           lista.Add(stk);
           return oCon.runTransaccionStore("usp_Producto_Insertar", lista);
       }

       public int ProductoModificar(Producto reg)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter cod = new SqlParameter("@IdProducto", reg.codigo);
           SqlParameter nom = new SqlParameter("@Nombre", reg.nombre);
           SqlParameter idpro = new SqlParameter("@Idproveedor", reg.idprove);
           SqlParameter idcat = new SqlParameter("@IdCategoria", reg.idcat);
           SqlParameter pre = new SqlParameter("@Precio", reg.precio);
           SqlParameter stk = new SqlParameter("@Stock", reg.stock);
           lista.Add(cod);
           lista.Add(nom);
           lista.Add(idpro);
           lista.Add(idcat);
           lista.Add(pre);
           lista.Add(stk);
           return oCon.runTransaccionStore("usp_Producto_Modificar", lista);
       }

       public int ProductoEliminar(Producto reg)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter cod = new SqlParameter("@IdProducto", reg.codigo);
           lista.Add(cod);
          return oCon.runTransaccionStore("usp_Producto_Eliminar", lista);
       }

       public DataTable ProductoPorCodigo(int codi)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter cod = new SqlParameter("@IdProducto", codi);
           lista.Add(cod);
           return oCon.runConsultaStore("usp_Producto_Datos",lista);
       }

       public bool ValidaUsuario(string xuser,string xpass)
       {
           List<SqlParameter> lista = new List<SqlParameter>();
           SqlParameter vusuario = new SqlParameter("@Usuario", xuser);
           SqlParameter vclave = new SqlParameter("@Clave", xpass);
           lista.Add(vusuario);
           lista.Add(vclave);
           return oCon.runValidaConsulta("Select Nombre,Apellidos from Empleados Where Nombre=@Usuario and Apellidos=@Clave", lista);
       }


    }
}
