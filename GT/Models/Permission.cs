using System.ComponentModel.DataAnnotations;

namespace GT.Models
{
    public class Permission
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string NombreEmpleado { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string ApellidoEmpleado { get; set; } = null!;
        [Required]
        public int TipoPermisoId { get; set; }
        [Required]
        public DateTime FechaPermiso { get; set; }
        public virtual PermissionType TipoPermiso{ get; set; } = null!;
    }
}
