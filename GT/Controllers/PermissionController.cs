using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GT.Models;
using Microsoft.Extensions.Logging;
using GT.Contracts;
using System.Security;
using GT.Services;

namespace GT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        public readonly IPermissionService _permissionService;
        //public readonly ElasticClient _ecClient;
        //private  string strIndexName= "permissions";
        public PermissionController(IPermissionService permissionService)//, ElasticClient elasticClient)
        {
            _permissionService = permissionService;
            //_ecClient = elasticClient;
        }
        [HttpGet]
        [Route("GetPermission")]
        public async Task<IActionResult> GetPermission(string text)
        {
            try
            {
               List< Permission> newPermission = await _permissionService.GetPermission(text);
                return Ok(newPermission);

                //    var ecHealth= _ecClient.Cluster.Health();
                //    if(ecHealth.IsValid && ecHealth.ApiCall.Success)
                //    {
                //        var ecResponse = _ecClient.Search<PermissionES>(x => x.Index(strIndexName).Query(q => q.MatchAll()));
                //        return Ok(ecResponse);
                //    }

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet]
        [Route("RequestPermission")]
        public async Task<IActionResult> RequestPermission([FromQuery] Permission permission)
        {
            try
            {
                Permission newPermission= await _permissionService.RequestPermission(permission);
                return Ok(newPermission.Id);
                //string indexToWrite = "permissions";

                //IndexRequest<PermissionES> indexRequest = new IndexRequest<PermissionES>(strIndexName, Guid.NewGuid())
                //{
                //    Document = permissionES
                //};

                //var indexResult = _ecClient.Index(indexRequest);
                //return Ok(indexResult);

                //if (!indexResult.IsValid)
                //{
                //    logger.LogError(indexResult.DebugInformation);
                //}
                //else
                //{
                //    logger.LogInformation(indexResult.DebugInformation);
                //}
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet]
        [Route("ModifyPermission")]
        public async Task<IActionResult> ModifyPermission([FromQuery] Permission permission)
        {
            try
            {
                Permission newPermission = await _permissionService.ModifyPermission(permission);
                return Ok(newPermission.Id);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
