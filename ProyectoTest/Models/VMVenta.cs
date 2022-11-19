using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoTest.Models
{
    public class VMVenta
    {
        public string Nombre { get; set; }

        public int TotalProducto { get; set; }

        public string Contacto { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string FechaCompra { get; set; }

        public decimal Total { get; set; }
    }
}