using DeliveryAppGrupo0008.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DeliveryAppGrupo0008.Services
{
    public class AuthService
    {
        private readonly DeliveryContext _context;

        public AuthService(DeliveryContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string password)
        {
            string hashedPassword = ComputeSha256Hash(password);
            Console.WriteLine($"Buscando usuario con email={email} y hash={hashedPassword}");

            var user = _context.Usuarios
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email && u.PasswordHash == hashedPassword);

            if (user == null)
                Console.WriteLine("Usuario no encontrado o contraseña incorrecta");
            else
                Console.WriteLine($"Usuario encontrado: {user.Nombre}");

            return user;
        }

        public bool Register(string nombre, string email, string password, int roleId)
        {
            email = email.Trim().ToLower();

            if (_context.Usuarios.Any(u => u.Email.ToLower() == email))
            {
                // El usuario ya existe
                return false;
            }

            var user = new Usuario
            {
                Nombre = nombre,
                Email = email,
                PasswordHash = ComputeSha256Hash(password),
                RoleID = roleId,
                FechaRegistro = DateTime.Now
            };

            _context.Usuarios.Add(user);
            _context.SaveChanges();

            return true;
        }


        public bool IsAdmin(Usuario user)
        {
            return user?.Role?.RoleName == "Admin";
        }

        public bool IsEmpleado(Usuario user)
        {
            return user?.Role?.RoleName == "Empleado";
        }

        public bool IsCliente(Usuario user)
        {
            return user?.Role?.RoleName == "Cliente";
        }

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