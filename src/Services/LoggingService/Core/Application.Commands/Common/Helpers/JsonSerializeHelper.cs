using Application.Commands.Contracts.Common;
using Newtonsoft.Json;

namespace Application.Commands.Common.Helpers
{
    public class JsonSerializeHelper<T> : IJsonSerializeHelper<T>
    {
        public string Serialize(object? value, Type type)
        {
            return JsonConvert.SerializeObject(value, typeof(T), new JsonSerializerSettings() { });
        }
    }
}