
using System.ComponentModel.DataAnnotations;

namespace DeliveryAppGrupo0008.Models
{
    public class Rol
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
