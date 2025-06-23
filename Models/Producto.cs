using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryAppGrupo0008.Models
{
    public class Producto
    {
        [Key]
        [Column("ProductoID")]
        public int ProductoID { get; set; }  

        public int ProveedorID { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
    }
}
