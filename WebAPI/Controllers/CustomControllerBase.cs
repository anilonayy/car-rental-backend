using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        public ObjectResult CreateResponse<T>(IResult<T> data)
        {
            if (data.status == 204)
            {
                return new ObjectResult(null) { StatusCode = data.status };
            }
            else
            {
                return new ObjectResult(data) { StatusCode = data.status };
            }
        }
    }
}
