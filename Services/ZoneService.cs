using DeliveryAppGrupo0008.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAppGrupo0008.Services
{
    public class ZoneService
    {
        private readonly DeliveryContext _context;

        public ZoneService(DeliveryContext context)
        {
            _context = context;
        }

        public List<Zona> GetZonas()
        {
            return _context.Zonas.AsNoTracking().ToList();
        }

        public bool RegistrarZona(string nombre, string descripcion, decimal precioDelivery)
        {
            try
            {
                var zona = new Zona
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    PrecioDelivery = precioDelivery
                };

                _context.Zonas.Add(zona);
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
