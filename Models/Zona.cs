using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DeliveryAppGrupo0008.Models
{
    public class Zona
    {
        [Key]
        [Column("ZonaID")]
        public int ZonaID { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}