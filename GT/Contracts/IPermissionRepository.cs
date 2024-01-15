using GT.Models;

namespace GT.Contracts
{
    public interface IPermissionRepository
    {
        Task<Permission> CreatePermission(Permission permission);
        Task<Permission> ModifyPermission(Permission permission);
        Task<bool> DeletePermission(int Id);
        Task<Permission> GetPermissionById(int Id);
        Task<List<Permission>> GetPermissionByText(string text);
    }
}
