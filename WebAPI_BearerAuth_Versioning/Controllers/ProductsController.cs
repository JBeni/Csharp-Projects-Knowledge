using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI_BearerAuth_Versioning.Controllers
{
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        [HttpGet]
        //[MapToApiVersion("1.0")]
        public IEnumerable<string> GetV1()
        {
            return new string[] { "value1", "value2", "api version 1" };
        }

        [HttpGet]
        //[MapToApiVersion("2.0")]
        public IEnumerable<string> GetV2()
        {
            return new string[] { "value1", "value2", "value3", "api with version v2" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
