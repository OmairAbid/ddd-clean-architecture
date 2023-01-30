using EventBus.Models;

namespace Application.Commands.Contracts.Common
{
    public interface IAuditLogHelper
    {
        /// <summary>
        /// Gets the objects as input, the columns to compare and the language keys format of change
        /// </summary>
        /// <param name="olderObject">The values before change</param>
        /// <param name="changedObject">The values after change</param>
        /// <param name="includeColumns">Columns that are to be checked for the change</param>
        /// <param name="keyMappings">Language keys required for translation</param>
        /// <returns>returns the result in proper format</returns>
        IList<AuditDelta> CompareObjectsForSpecificColumns(object olderObject, object changedObject, List<string> includeColumns, Dictionary<string, string> keyMappings);
    }
}