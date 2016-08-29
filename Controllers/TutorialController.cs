using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TutorialController : Controller 
    {
        [HttpGet()]
        public async Task<string> Get([FromServices] INodeServices nodeService) {
            var dummy = new DummyClass() 
            {
                firstName = "Johnny",
                age = 24
            };
            try {
                var result = await nodeService.InvokeAsync<string>("./node_modules/custom/testNodeModule", dummy);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
