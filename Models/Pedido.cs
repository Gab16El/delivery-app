using DeliveryAppGrupo0008.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pedido
{
    [Key]
    [Column("PedidoID")]
    public int PedidoID { get; set; }
    public int ClienteID { get; set; }
    public Usuario Cliente { get; set; }
    public int? DeliveryID { get; set; }
    public Usuario Delivery { get; set; }

    public int ZonaID { get; set; }
    public Zona Zona { get; set; }

    public string? Referencia { get; set; }
    public int EstadoID { get; set; }
    public EstadoPedido Estado { get; set; }
    public DateTime FechaPedido { get; set; }
    public DateTime? FechaEntrega { get; set; }
    public decimal Total { get; set; }

    public ICollection<DetallePedido> Detalles { get; set; } // relación 1 a muchos con detalles
}