namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        object Get(string key);
        void Add(string key, object value, int duration);

        bool IsAdd(string key);

        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
