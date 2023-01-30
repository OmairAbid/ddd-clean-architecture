using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Common.Models
{
    public class AdministratorRoleQueryResponse
    {
        public string Description { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public List<AdministratorRoleDetail> AdministratorRoleDetail { get; set; }

        public AdministratorRoleQueryResponse()
        {
            AdministratorRoleDetail = new List<AdministratorRoleDetail>();
        }
    }

    public class AdministratorRoleDetail
    {
        public int Id { get; set; }

        public Int32 AdministratorRoleId { get; set; }

        public String AttributeName { get; set; }

        /// <summary>
        /// Is admin allowed to read existing record
        /// </summary>
        public Boolean Read { get; set; }

        /// <summary>
        /// Is admin allowed to add/update record
        /// </summary>
        public Nullable<Boolean> AddUpdate { get; set; }

        /// <summary>
        /// Is admin allowed to delete record
        /// </summary>
        public Nullable<Boolean> Delete { get; set; }

        public String CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public String LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}