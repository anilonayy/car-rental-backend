using System.Reflection;

namespace Core.Utilities.Results
{
    public interface IResult<T>
    {
        public T? data { get; set; }
        public string title { get; }
        public string message { get;}
        public bool success { get; }
        public int status { get; }


    }
}
