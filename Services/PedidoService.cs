using DeliveryAppGrupo0008.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAppGrupo0008.Services
{
    public class PedidoService
    {
        private readonly DeliveryContext _context;

        public PedidoService(DeliveryContext context)
        {
            _context = context;
        }

        public List<Pedido> GetPedidos()
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(prod => prod.Proveedor)
                .AsNoTracking()
                .ToList();
        }

        public bool RegistrarPedido(int clienteId, int productoId, int zonaId, int cantidad)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.ProductoID == productoId);
                var zona = _context.Zonas.FirstOrDefault(z => z.ZonaID == zonaId);

                if (producto == null || zona == null || cantidad <= 0)
                    return false;

                var pedido = new Pedido
                {
                    ClienteID = clienteId,
                    ZonaID = zonaId,
                    EstadoID = 1, // Pendiente
                    FechaPedido = DateTime.Now,
                    Total = (producto.Precio * cantidad) + zona.PrecioDelivery,
                    Detalles = new List<DetallePedido>()
                };

                var detalle = new DetallePedido
                {
                    ProductoID = productoId,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                };

                pedido.Detalles.Add(detalle);

                _context.Pedidos.Add(pedido);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
