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
            if(data.StatusCode==204)
            {
                return new ObjectResult(null) { StatusCode = data.StatusCode };
            }
            else
            {
                return new ObjectResult(data) { StatusCode = data.StatusCode };
            }
        }
    }
}
