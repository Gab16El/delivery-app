
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryAppGrupo0008.Models
{
    public class Proveedor
    {
        [Key]
        [Column("ProveedorID")]
        public int ProveedorID { get; set; }

        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
