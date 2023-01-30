using Application.Commands.Common.Enumerations;
using Application.Commands.Contracts.Common;
using EventBus.Models;
using KellermanSoftware.CompareNetObjects;

namespace Application.Commands.Common.Helpers
{
    public class AuditLogHelper : IAuditLogHelper
    {
        public IList<AuditDelta> CompareObjectsForSpecificColumns(object originalOjbect, object changedObject, List<string> includeColumns, Dictionary<string, string> keyMappings)
        {
            List<AuditDelta> _deltaList = new List<AuditDelta>();
            CompareLogic _compObjects;
            ComparisonResult _compResult;
            List<Difference> _differences;
            AuditDelta _auditDelta;
            try
            {
                _compObjects = new CompareLogic();
                _compObjects.Config.MaxDifferences = 150;
                _compResult = _compObjects.Compare(originalOjbect, changedObject);
                _differences = _compResult.Differences.Where(a => includeColumns.Contains(a.PropertyName)).OrderByDescending(x => x.Object1TypeName).ToList();
                foreach (Difference _diff in _differences)
                {
                    //If both values are null or empty than don't log
                    if (!IsObjectValueChanged(_diff))
                    {
                        continue;
                    }

                    _auditDelta = new AuditDelta()
                    {
                        FieldName = _diff.PropertyName,
                        ValueBefore = (!string.IsNullOrEmpty(_diff.Object1Value) && (_diff.Object1Value.ToUpper() == Flag.TRUE.ToString() || _diff.Object1Value.ToUpper() == Flag.FALSE.ToString())) ? _diff.Object1Value.ToLower().Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-") : _diff.Object1Value.Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-"),
                        ValueAfter = (!string.IsNullOrEmpty(_diff.Object2Value) && (_diff.Object2Value.ToUpper() == Flag.TRUE.ToString() || _diff.Object2Value.ToUpper() == Flag.FALSE.ToString())) ? _diff.Object2Value.ToLower().Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-") : _diff.Object2Value.Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-"),
                        DisplayKey = keyMappings.ContainsKey(_diff.PropertyName) ? keyMappings[_diff.PropertyName] : _diff.PropertyName
                    };
                    _deltaList.Add(_auditDelta);
                }
            }
            catch (Exception ex)
            {
            }
            return _deltaList;
        }

        private static bool IsObjectValueChanged(Difference difference)
        {
            if (((string.IsNullOrEmpty(difference.Object1Value) || difference.Object1Value == Constants.Constants.AUDIT_LOG_EMPTY_VALUE) && (string.IsNullOrEmpty(difference.Object2Value) || difference.Object2Value == Constants.Constants.AUDIT_LOG_EMPTY_VALUE))
                       || !string.IsNullOrEmpty(difference.Object1Value) && !string.IsNullOrEmpty(difference.Object2Value) && !IsValueChanged(difference))
            {
                return false;
            }
            return true;
        }

        private static bool IsValueChanged(Difference difference)
        {
            bool _isChanged = false;
            if (IsCheckbox(difference))
            {
                if (difference.Object1Value.ToLower() != difference.Object2Value.ToLower())
                {
                    _isChanged = true;
                }
            }
            else
            {
                if (difference.Object1Value != difference.Object2Value)
                {
                    _isChanged = true;
                }
            }
            return _isChanged;
        }

        private static bool IsCheckbox(Difference difference)
        {
            if (
                (difference.Object1Value.ToUpper() == Flag.TRUE.ToString() || difference.Object1Value.ToUpper() == Flag.FALSE.ToString()) &&
                (difference.Object2Value.ToUpper() == Flag.TRUE.ToString() || difference.Object2Value.ToUpper() == Flag.FALSE.ToString())
                )
            {
                return true;
            }

            return false;
        }
    }
}