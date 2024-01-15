using GT.Models;
using Microsoft.AspNetCore.Mvc;

namespace GT.Services
{
    public interface IPermissionService
    {
        public Task<List<Permission>> GetPermission(string text);
        public Task<Permission> RequestPermission([FromQuery] Permission permission);
        public Task<Permission> ModifyPermission([FromQuery] Permission permission);
    }
}
