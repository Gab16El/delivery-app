
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryAppGrupo0008.Models
{
    public class EstadoPedido
    {
        [Key]
        [Column("EstadoID")]
        public int EstadoID { get; set; }  
        public string Estado { get; set; }
    }
}