using GT.Contracts;
using GT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GT.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly GlobalTaskEFContext _context;

        public PermissionRepository(GlobalTaskEFContext context)
        {
            _context = context;
        }
        public async Task<Permission> CreatePermission(Permission permission)
        {
            EntityEntry<Permission> entityEntry = await _context.Permissions.AddAsync(permission);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<bool> DeletePermission(int Id)
        {
            Permission permission =await _context.Permissions.FirstOrDefaultAsync(x => x.Id == Id);
            if (permission == null)
            {
                throw new Exception("Permission not found.");
            }
            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Permission> GetPermissionById(int Id)
        {
            Permission permission =await _context.Permissions.FirstOrDefaultAsync(x => x.Id == Id);
            if (permission == null)
            {
                throw new Exception("Permission not found.");
            }
            return permission;
        }

        public async Task<List<Permission>> GetPermissionByText(string text)
        {
            List<Permission> lstPermission = await _context.Permissions
                .Include(a=>a.TipoPermiso)
                .Where(x => x.NombreEmpleado.Contains(text) 
                    || x.ApellidoEmpleado.Contains(text) 
                    || x.TipoPermiso.Descripcion.Contains(text)).ToListAsync();

            if (lstPermission == null && lstPermission.Count>0)
            {
                throw new Exception("Permissions not found.");
            }
            return lstPermission;
        }

        public async Task<Permission> ModifyPermission(Permission permission)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
    }
}
