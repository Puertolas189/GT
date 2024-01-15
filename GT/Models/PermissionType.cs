using System.ComponentModel.DataAnnotations;

namespace GT.Models
{
    public class PermissionType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; } = null!;
        public virtual List<Permission> Permissions { get; set; }
    }
}
