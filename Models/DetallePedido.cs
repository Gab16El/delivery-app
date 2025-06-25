using DeliveryAppGrupo0008.Models;

public class DetallePedido
{
    public int DetalleID { get; set; }
    public int PedidoID { get; set; }
    public Pedido Pedido { get; set; }

    public int ProductoID { get; set; }
    public Producto Producto { get; set; }

    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}