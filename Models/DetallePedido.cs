using DeliveryAppGrupo0008.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("DetallesPedido")]
public class DetallePedido
{
    [Key]
    [Column("DetalleID")]
    public int DetalleID { get; set; }
    public int PedidoID { get; set; }
    public Pedido Pedido { get; set; }

    public int ProductoID { get; set; }
    public Producto Producto { get; set; }

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}