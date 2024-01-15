using GT.Contracts;
using GT.Controllers;
using GT.Models;
using GT.Repositories;
using GT.Services;
using Moq;
using static System.Net.Mime.MediaTypeNames;

namespace GT.Test
{
    [TestClass]
    public class PermissionServiceTest
    {
        [TestMethod]
        public  void GetPermissionTest()
        {
            //Arrange
            Mock<IPermissionRepository> mockRepository = new Mock<IPermissionRepository>();
            PermissionService permissionService=new PermissionService(mockRepository.Object);

            string text = "test";

            mockRepository.Setup(a => a.GetPermissionByText(It.IsAny<string>())).ReturnsAsync(new List<Permission>()
            {
                new Permission(){ 
                    ApellidoEmpleado="test",
                    NombreEmpleado="test",
                    FechaPermiso=DateTime.Now,
                    TipoPermisoId=1
                }
            });
            //Act
            List<Permission> result = permissionService.GetPermission(text).Result;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(text, result.First().ApellidoEmpleado);
        }
        [TestMethod]
        public void ModifyPermission()
        {
            Mock<IPermissionRepository> mockRepository = new Mock<IPermissionRepository>();
            PermissionService permissionService = new PermissionService(mockRepository.Object);
            Permission modifyPermission = new Permission()
            {
                ApellidoEmpleado = "test1",
                NombreEmpleado = "test",
                FechaPermiso = DateTime.Now,
                TipoPermisoId = 1
            };
            mockRepository.Setup(a => a.ModifyPermission(It.IsAny<Permission>())).ReturnsAsync( new Permission(){
                    ApellidoEmpleado="test",
                    NombreEmpleado="test",
                    FechaPermiso=DateTime.Now,
                    TipoPermisoId=1
            });
            //Act
            Permission result = permissionService.ModifyPermission(modifyPermission).Result;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(modifyPermission.NombreEmpleado, result.NombreEmpleado);
            Assert.AreNotEqual(modifyPermission.ApellidoEmpleado, result.ApellidoEmpleado);

        }
        [TestMethod]
        public void RequestPermission()
        {
            Mock<IPermissionRepository> mockRepository = new Mock<IPermissionRepository>();
            PermissionService permissionService = new PermissionService(mockRepository.Object);
            Permission permission = new Permission()
            {
                ApellidoEmpleado = "test",
                NombreEmpleado = "test",
                FechaPermiso = DateTime.Now,
                TipoPermisoId = 1
            };
            mockRepository.Setup(a => a.CreatePermission(It.IsAny<Permission>())).ReturnsAsync(new Permission()
            {
                Id=1,
                ApellidoEmpleado = "test",
                NombreEmpleado = "test",
                FechaPermiso = DateTime.Now,
                TipoPermisoId = 1
            });
            //Act
            Permission result = permissionService.RequestPermission(permission).Result;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(permission.NombreEmpleado, result.NombreEmpleado);
            Assert.AreNotEqual(permission.Id, result.Id);
        }
    }
}