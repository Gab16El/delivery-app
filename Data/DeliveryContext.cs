using Microsoft.EntityFrameworkCore;
using DeliveryAppGrupo0008.Models;

public class DeliveryContext : DbContext
{
    public DeliveryContext(DbContextOptions<DeliveryContext> options)
        : base(options)
    {
    }

    // Define aquí tus tablas, por ejemplo:
    public DbSet<Producto> Productos { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Zona> Zonas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Rol> Roles { get; set; }


    public DbSet<EstadoPedido> EstadosPedidos { get; set; }
}
