using Newtonsoft.Json;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string title { get; set; }
        public string message { get; set; }
        public int status { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}