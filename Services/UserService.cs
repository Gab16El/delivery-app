using DeliveryAppGrupo0008.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DeliveryAppGrupo0008.Services
{
    public class UserService
    {
        private readonly DeliveryContext _context;
        private const int PROVEEDOR_ROLE_ID = 4;

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
            return _context.Usuarios
                .Include(u => u.Role)
                .AsNoTracking()
                .Where(u => u.RoleID == PROVEEDOR_ROLE_ID)
                .ToList();
        }

        // Registrar usuario nuevo
        public bool RegistrarUsuario(string nombre, string email, string password, int roleId, string telefono, string direccion)
        {
            email = email.Trim().ToLower();

            if (_context.Usuarios.Any(u => u.Email.ToLower() == email))
            {
                // Ya existe usuario con ese email
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
    }
}
