namespace EventBus
{
    public interface IMessage<T>
    {
        #region Public Properties

        string Action { get; set; }
        public T Data { get; set; }
        Guid Id { get; set; }
        string PerformedBy { get; set; }
        public string Reciever { get; set; }
        string Type { get; set; }

        #endregion Public Properties
    }

    public interface IMessage
    {
        #region Public Properties

        string Action { get; set; }
        public dynamic Data { get; set; }
        Guid Id { get; set; }
        string PerformedBy { get; set; }
        public string Reciever { get; set; }
        string Type { get; set; }

        #endregion Public Properties
    }
}