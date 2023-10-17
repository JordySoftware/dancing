using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_Factura.Model
{
    [Table("factura")]
    public class Factura
    {
        [Key]
        public int id_factura { get; set; }
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public int cant { get; set; }
        public int precio { get; set; }
        public int total { get; set; }


    }
}
