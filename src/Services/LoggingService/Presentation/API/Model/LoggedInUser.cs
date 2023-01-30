namespace API.Model
{
    public class LoggedInUser
    {
        #region Public Properties

        public string EmailAddress { get; set; }
        public long Id { get; set; }
        public int RoleId { get; set; }

        #endregion Public Properties
    }
}