using System;

namespace Labb4Productos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public byte[]? Imagen { get; set; } // Permitir nulos explícitos (Nulabilidad estricta)
        public int Anulado { get; set; }     // 1 o 0 para borrado lógico
        public string Usuario { get; set; }  // Nombre del usuario que manipula el registro
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}

