namespace SingletonBehaviours
{
    public class GlobalDataController : Types.SingletonBehaviour<GlobalDataController>
    {
        private readonly Types.Collections.Dictionary<string, Types.Miscellaneous.Any> _data = new();
        public T GetData<T>(string key) => (T)(object)_data[key];
    }
}
