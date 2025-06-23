using DeliveryAppGrupo0008.Models;
using Microsoft.EntityFrameworkCore;

    public class ProductService
    {
        private readonly DeliveryContext _context;

        public ProductService(DeliveryContext context)
        {
            _context = context;
        }

        public List<Producto> GetProductos()
        {
            return _context.Productos.ToList();
        }

        public List<Producto> GetProductosConProveedor()
        {
            return _context.Productos.Include(p => p.Proveedor).AsNoTracking().ToList();
        }


    public bool RegistrarProducto(int proveedorId, string nombre, string descripcion, decimal precio)
        {
            try
            {
                var producto = new Producto
                {
                    ProveedorID = proveedorId,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio
                };

                _context.Productos.Add(producto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }