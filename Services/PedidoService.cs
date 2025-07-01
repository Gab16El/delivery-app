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

        public List<Pedido> GetPedidos(int? proveedorId = null)
        {
            var query = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(prod => prod.Proveedor)
                .Include(p => p.Delivery)  
                .AsNoTracking()
                .AsQueryable();

            if (proveedorId.HasValue)
            {
                query = query.Where(p => p.Detalles.Any(d => d.Producto.ProveedorID == proveedorId.Value));
            }

            return query.ToList();
        }


        public bool RegistrarPedido(int clienteId, int productoId, int zonaId, int cantidad, string referencia)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.ProductoID == productoId);
                var zona = _context.Zonas.FirstOrDefault(z => z.ZonaID == zonaId);

                if (producto == null || zona == null || cantidad <= 0 || referencia == null)
                    return false;

                var pedido = new Pedido
                {
                    ClienteID = clienteId,
                    ZonaID = zonaId,
                    Referencia = referencia,
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
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                MessageBox.Show($"Error interno: {innerMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public List<Pedido> GetPedidosPorCliente(int clienteId)
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(prod => prod.Proveedor)
                .Include(p => p.Delivery) 
                .Where(p => p.ClienteID == clienteId)
                .AsNoTracking()
                .ToList();
        }

        public List<Usuario> GetUsuariosPorRole(int roleId)
        {
            return _context.Usuarios.Where(u => u.RoleID == roleId).AsNoTracking().ToList();
        }

        public bool AsignarDeliveryYPasarEstado(int pedidoId, int deliveryId)
        {
            try
            {
                var pedido = _context.Pedidos.FirstOrDefault(p => p.PedidoID == pedidoId);
                if (pedido == null) return false;

                // Asignar delivery y cambiar estado
                pedido.DeliveryID = deliveryId; 
                pedido.EstadoID = 2; // En Proceso

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error interno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Pedido> GetPedidosPorDelivery(int deliveryId)
        {
            return _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Zona)
                .Include(p => p.Estado)
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                        .ThenInclude(prod => prod.Proveedor)
                .Include(p => p.Delivery)
                .Where(p => p.DeliveryID == deliveryId)
                .AsNoTracking()
                .ToList();
        }

        public List<Usuario> GetDeliverysParaProveedor(int proveedorId)
        {
            // Buscar pedidos con productos del proveedor y con delivery asignado
            var deliveryIds = _context.Pedidos
                .Include(p => p.Detalles)
                    .ThenInclude(d => d.Producto)
                .Where(p => p.Detalles.Any(d => d.Producto.ProveedorID == proveedorId) && p.DeliveryID != null)
                .Select(p => p.DeliveryID.Value)
                .Distinct()
                .ToList();

            return _context.Usuarios
                .Where(u => u.RoleID == 2 && deliveryIds.Contains(u.UsuarioID))
                .ToList();
        }

        public bool CambiarEstadoPedido(int pedidoId, int nuevoEstadoId, DateTime? fechaEntrega = null)
        {
            try
            {
                var pedido = _context.Pedidos.Find(pedidoId);
                if (pedido == null) return false;

                pedido.EstadoID = nuevoEstadoId;

                if (fechaEntrega.HasValue)
                {
                    pedido.FechaEntrega = fechaEntrega.Value;
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear el error si tienes un logger
                return false;
            }
        }

    }
}