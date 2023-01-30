namespace Application.Queries.Common.Models
{
    public class ProfilesQueryResponse
    {
        #region Public Constructors

        public ProfilesQueryResponse()
        {
            ProfileDetail = new List<ProfileDetailQuery>();
        }

        #endregion Public Constructors

        #region Public Properties

        public DateTime CreatedOn { get; set; }
        public String Description { get; set; }
        public Int32 Id { get; set; }
        public Int32 IsPrivate { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public String Name { get; set; }
        public IList<ProfileDetailQuery> ProfileDetail { get; set; }
        public Int32 Status { get; set; }
        public Int32 Type { get; set; }

        #endregion Public Properties
    }

    public class ProfileDetailQuery
    {
        #region Public Constructors

        public ProfileDetailQuery()
        {
            ProfileDetailValue = new List<ProfileDetailValueQuery>();
        }

        #endregion Public Constructors

        #region Public Properties

        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public int Id { get; set; }
        public List<ProfileDetailValueQuery> ProfileDetailValue { get; set; }
        public int ProfileId { get; set; }

        #endregion Public Properties
    }

    public class ProfileDetailValueQuery
    {
        #region Public Properties

        /// <summary>
        /// ProfileCommon: Possible values like APPEARANCES, DOCUMENT_HASHING_ALGORITHM,
        /// PDF_SIGNATURE_TYPE etc
        /// </summary>
        public string AttributeName { get; set; }

        public string AttributeValue { get; set; }
        public int ProfileDetailId { get; set; }

        #endregion Public Properties
    }
}