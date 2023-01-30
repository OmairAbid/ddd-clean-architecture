namespace Domain.Entities
{
    public class Profile
    {
        #region Public Properties

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? Description { get; set; }
        public string HMAC { get; set; }
        public int Id { get; set; }
        public int IsPrivate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }

        #endregion Public Properties
    }
}