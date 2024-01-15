using GT.Contracts;
using GT.Models;
using Microsoft.AspNetCore.Mvc;

namespace GT.Services
{
    public class PermissionService: IPermissionService
    {
        public readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<List<Permission>> GetPermission(string text)
        {
            try
            {
                List<Permission> newPermission = await _permissionRepository.GetPermissionByText(text);
                return newPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Permission> RequestPermission([FromQuery] Permission permission)
        {
            try
            {
                Permission newPermission = await _permissionRepository.CreatePermission(permission);
                return newPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Permission> ModifyPermission([FromQuery] Permission permission)
        {
            try
            {
                Permission newPermission = await _permissionRepository.ModifyPermission(permission);
                return newPermission;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
