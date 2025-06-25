
using System.ComponentModel.DataAnnotations;

namespace DeliveryAppGrupo0008.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public int RoleID { get; set; }
        public Rol Role { get; set; }
        public int? ProveedorID { get; set; }  
        public Usuario Proveedor { get; set; } 

        public string Telefono {get; set;}

        public string Direccion { get; set; }
        
        public DateTime FechaRegistro { get; set; }
    }
}
