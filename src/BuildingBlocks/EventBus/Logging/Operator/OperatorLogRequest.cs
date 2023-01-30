using EventBus.Models;

namespace EventBus.Logging.Operator
{
    public class OperatorLogRequest
    {
        #region Public Constructors

        public OperatorLogRequest(string action, string module, string subModule, DOData detail, DOData information, List<AuditDelta> auditLog, string agent, string agentDetail, string administratorEmail = "", string createdBy = "")
        {
            Action = action;
            AgentDetail = agentDetail;
            Module = module;
            SubModule = subModule;
            Detail = detail;
            Information = information;
            Agent = agent;
            AdministratorEmail = administratorEmail;
            CreatedBy = createdBy;
            AuditLog = auditLog;
        }

        public OperatorLogRequest()
        {
            Detail = new DOData();
            Information = new DOData();
        }

        #endregion Public Constructors

        #region Public Properties

        public String Action { get; set; }
        public String? AdministratorEmail { get; set; }
        public String Agent { get; set; }
        public String AgentDetail { get; set; }
        public List<AuditDelta> AuditLog { get; set; }
        public String? CreatedBy { get; set; }
        public DOData Detail { get; set; }
        public DOData Information { get; set; }
        public String? Module { get; set; }
        public String SubModule { get; set; }

        #endregion Public Properties
    }
}