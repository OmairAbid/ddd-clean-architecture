using Application.Commands.Common.Enumerations;
using EventBus.Models;
using KellermanSoftware.CompareNetObjects;

namespace Application.Commands.Common.Helpers
{
    public class AuditLogHelper : IAuditLogHelper
    {
        #region Public Methods

        public Task<IList<AuditDelta>> CompareAsync(object originalOjbect, object changedObject, List<string> includeColumns, Dictionary<string, string> keyMappings)
        {
            IList<AuditDelta> _deltaList = new List<AuditDelta>();
            CompareLogic _compObjects;
            ComparisonResult _compResult;
            List<Difference> _differences;
            AuditDelta _auditDelta;
            _compObjects = new CompareLogic();
            _compObjects.Config.MaxDifferences = 150;
            _compObjects.Config.IgnoreObjectTypes = true;
            _compResult = _compObjects.Compare(originalOjbect, changedObject);
            _differences = _compResult.Differences.Where(a => !string.IsNullOrEmpty(a.PropertyName) && includeColumns.Contains(a.PropertyName.Split('.')[1])).OrderByDescending(x => x.Object1TypeName).ToList();

            foreach (dynamic _diff in _differences)
            {
                if (!IsObjectValueChanged(_diff))
                {
                    continue;
                }

                _auditDelta = new AuditDelta()
                {
                    FieldName = _diff.ParentObject1.AttributeName,
                    ValueBefore = (!string.IsNullOrEmpty(_diff.Object1Value) && (_diff.Object1Value.ToUpper() == Flag.TRUE.ToString() || _diff.Object1Value.ToUpper() == Flag.FALSE.ToString())) ? _diff.Object1Value.Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-").ToLower() : _diff.Object1Value.Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-"),
                    ValueAfter = (!string.IsNullOrEmpty(_diff.Object2Value) && (_diff.Object2Value.ToUpper() == Flag.TRUE.ToString() || _diff.Object2Value.ToUpper() == Flag.FALSE.ToString())) ? _diff.Object2Value.Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-").ToLower() : _diff.Object2Value.Replace(Constants.Constants.AUDIT_LOG_EMPTY_VALUE, "-"),
                    DisplayKey = keyMappings.ContainsKey(_diff.ParentObject1.AttributeName) ? keyMappings[_diff.ParentObject1.AttributeName] : _diff.ParentObject1.AttributeName,
                    FieldType = ((!string.IsNullOrEmpty(_diff.Object2Value) && (_diff.Object2Value.ToUpper() == Flag.FALSE.ToString() || _diff.Object2Value.ToUpper() == Flag.TRUE.ToString())) ||
                    (!string.IsNullOrEmpty(_diff.Object1Value) && (_diff.Object1Value.ToUpper() == Flag.FALSE.ToString() || _diff.Object1Value.ToUpper() == Flag.TRUE.ToString()))) ? AuditLogFieldType.CHECKBOX.ToString().ToLower() : string.Empty
                };

                _deltaList.Add(_auditDelta);
            }
            return Task.FromResult(_deltaList);
        }

        #endregion Public Methods

        #region Private Methods

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

        #endregion Private Methods
    }
}