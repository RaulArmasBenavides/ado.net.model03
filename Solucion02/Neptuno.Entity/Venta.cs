using System;
using System.Collections.Generic;

namespace Neptuno.Entity
{
   public class Venta
    {
       // propiedades
       public int idventa { get; set; }
       public string idcliente { get; set; }
       public int idempleado { get; set; }
       public DateTime fechaventa { get; set; }
       public decimal monto { get; set; }
       public List<Detalle> item { get; set; }
    }
}
