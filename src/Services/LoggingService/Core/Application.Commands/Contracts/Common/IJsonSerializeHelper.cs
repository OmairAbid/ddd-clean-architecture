namespace Application.Commands.Contracts.Common
{
    public interface IJsonSerializeHelper<T>
    {
        public string Serialize(object? ojb, Type type);
    }
}