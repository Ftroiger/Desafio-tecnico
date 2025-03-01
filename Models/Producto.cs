using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio_tecnico.Models
{
    [Table("productos")]
    public class Producto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

    }
}
