using DeliveryAppGrupo0008.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryAppGrupo0008.Services
{
    public class ReporteService
    {
        private readonly DeliveryContext _context;

        public ReporteService(DeliveryContext context)
        {
            _context = context;
        }

        public decimal ObtenerVentasTotales(DateTime desde, DateTime hasta, int? proveedorId = null)
        {
            var query = _context.DetallePedidos
                .Where(d => d.Pedido.FechaPedido >= desde && d.Pedido.FechaPedido <= hasta);

            if (proveedorId.HasValue)
            {
                query = query.Where(d => d.Producto.ProveedorID == proveedorId.Value);
            }

            return query.Sum(d => d.Cantidad * d.PrecioUnitario);
        }

        public List<(string Producto, int Cantidad)> ObtenerTopProductos(DateTime desde, DateTime hasta, int? proveedorId = null)
        {
            var query = _context.DetallePedidos
                .Where(d => d.Pedido.FechaPedido >= desde && d.Pedido.FechaPedido <= hasta);

            if (proveedorId.HasValue)
            {
                query = query.Where(d => d.Producto.ProveedorID == proveedorId.Value);
            }

            return query
                .GroupBy(d => d.Producto.Nombre)
                .Select(g => new { Producto = g.Key, Cantidad = g.Sum(x => x.Cantidad) })
                .OrderByDescending(x => x.Cantidad)
                .Take(5)
                .ToList()
                .Select(x => (x.Producto, x.Cantidad))
                .ToList();
        }

        public (string Cliente, decimal TotalGastado)? ObtenerMejorCliente(DateTime desde, DateTime hasta, int? proveedorId = null)
        {
            var query = _context.DetallePedidos
                .Where(d => d.Pedido.FechaPedido >= desde && d.Pedido.FechaPedido <= hasta);

            if (proveedorId.HasValue)
            {
                query = query.Where(d => d.Producto.ProveedorID == proveedorId.Value);
            }

            var result = query
                .GroupBy(d => d.Pedido.Cliente)
                .Select(g => new
                {
                    Cliente = g.Key.Nombre,
                    TotalGastado = g.Sum(x => x.Cantidad * x.PrecioUnitario)
                })
                .OrderByDescending(x => x.TotalGastado)
                .FirstOrDefault();

            return result != null ? (result.Cliente, result.TotalGastado) : null;
        }
    }
}