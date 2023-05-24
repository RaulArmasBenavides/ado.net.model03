using Neptuno.DataAccess;
using System.Data;
using Neptuno.Entity;

namespace Neptuno.Bussines
{
   public  class ProductoBL
    {
       ProductoDatos dao = new ProductoDatos();

       public DataTable ProduductoPorNombre(string nom)
       {
           return dao.ProduductoPorNombre(nom);
       }

       public DataTable CategoriaListar()
       {
           return dao.CategoriaListar();
       }

       public DataTable ProduductoPorCategoria(int cod)
       {
           return dao.ProduductoPorCategoria(cod);
       }

       public DataTable ProductoListar()
       {
           return dao.ProductoListar();
       }

       public DataTable ProveedorListar()
       {
           return dao.ProveedorListar();
       }

       public int ProductoAdicionar(Producto reg)
       {
           return dao.ProductoAdicionar(reg);
       }

       public int ProductoModificar(Producto reg)
       {
           return dao.ProductoModificar(reg);
       }

       public int ProductoEliminar(Producto reg)
       {
           return dao.ProductoEliminar(reg);
       }

       public DataTable ProductoPorCodigo(int codi)
       {
           return dao.ProductoPorCodigo(codi);
       }

       public bool ValidaUsuario(string xuser, string xpass)
       {
           return dao.ValidaUsuario(xuser,xpass);
       }


    }
}
