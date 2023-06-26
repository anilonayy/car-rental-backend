using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Functions
{
    public class UriFunctions : IUriFunctions
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UriFunctions(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetHostUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var host = $"{request.Scheme}://{request.Host.Value}/";

            return host;
        }
    }
}
