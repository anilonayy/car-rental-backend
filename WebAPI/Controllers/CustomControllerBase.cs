using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        public ObjectResult CreateResponse<T>(ICustomResult<T> data)
        {
            if (data.statusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = data.statusCode };
            }
            else
            {
                return new ObjectResult(data) { StatusCode = data.statusCode };
            }
        }
    }
}
