using DeliveryAppGrupo0008.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DeliveryAppGrupo0008.Services
{
    public class UserService
    {
        private readonly DeliveryContext _context;

        public UserService(DeliveryContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios (sin incluir contraseña)
        public List<Usuario> GetUsuarios()
        {
            return _context.Usuarios
                .Include(u => u.Role)
                .AsNoTracking()
                .ToList();
        }

        public List<Usuario> GetProveedores()
        {
            int proveedorRoleId = 4;
            return _context.Usuarios
                .Where(u => u.RoleID == proveedorRoleId)
                .AsNoTracking()
                .ToList();
        }

        // Registrar usuario nuevo
        public bool RegistrarUsuario(string nombre, string email, string password, int roleId, string telefono, string direccion)
        {
            email = email.Trim().ToLower();

            if (_context.Usuarios.Any(u => u.Email.ToLower() == email))
            {
                return false;
            }

            var usuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                PasswordHash = ComputeSha256Hash(password),
                RoleID = roleId,
                Telefono = telefono,
                Direccion = direccion,
                FechaRegistro = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return true;
        }

        // Método auxiliar para el hash
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }


        // asignar proveedor a trabajador
        public bool RegistrarTrabajador(string nombre, string email, string password, string telefono, string direccion, int proveedorId)
        {
            email = email.Trim().ToLower();

            if (_context.Usuarios.Any(u => u.Email.ToLower() == email))
                return false;

            var trabajador = new Usuario
            {
                Nombre = nombre,
                Email = email,
                PasswordHash = ComputeSha256Hash(password),
                RoleID = 2,
                Telefono = telefono,
                Direccion = direccion,
                ProveedorID = proveedorId,  
                FechaRegistro = DateTime.Now
            };

            _context.Usuarios.Add(trabajador);
            _context.SaveChanges();
            return true;
        }

        public List<Usuario> GetTrabajadoresDeProveedor(int proveedorId)
        {
            return _context.Usuarios
                .Include(u => u.Role)
                .Where(u => u.RoleID == 2 && u.ProveedorID == proveedorId)
                .AsNoTracking()
                .ToList();
        }

        public bool EliminarUsuario(int usuarioId)
        {
            var usuario = _context.Usuarios.Find(usuarioId);

            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
    }
}