using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryAppGrupo0008.Models
{
    public class Pedido
    {
        [Key]
        [Column("PedidoID")]
        public int PedidoID { get; set; }  // Aquí es int y es el ID

        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public int ProveedorID { get; set; }
        public Proveedor Proveedor { get; set; }

        public int ZonaID { get; set; }
        public Zona Zona { get; set; }

        public int EstadoID { get; set; }
        public EstadoPedido Estado { get; set; }

        public DateTime FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal Total { get; set; }
    }

}
