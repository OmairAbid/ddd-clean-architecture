using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Common.Helpers;
public class DateTimeHelper : IDateTimeHelper
{
    #region Public Properties

    public string ISO_DATE_FORMAT { get { return "yyyy-MM-dd HH:mm:ss"; } }
    public string ISO_DATE_FORMAT_ONLY_DATE { get { return "yyyy-MM-dd"; } }
    public string ISO_DATE_FORMAT_WITH_TIMEZONE { get { return "yyyy-MM-dd HH:mm:ss tt"; } }
    public string ISO_TIME_FORMAT { get { return "HH:mm:ss"; } }

    #endregion Public Properties

    #region Public Methods

    public string ConvertDateTimeFromUTC(DateTime modifyDate, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        DateTime _newDateTime;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        _newDateTime = (_sourceTimeZone == null ? modifyDate : TimeZoneInfo.ConvertTimeFromUtc(modifyDate, _sourceTimeZone));
        return _newDateTime.ToString(ISO_DATE_FORMAT);
    }

    public DateTime ConvertDateTimeFromUTCToDate(DateTime modifyDate, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        DateTime _newDate;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        _newDate = TimeZoneInfo.ConvertTimeFromUtc(modifyDate, _sourceTimeZone);
        return _newDate;
    }

    public string ConvertDateTimeToUTC(DateTime modifyDate, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        DateTime _newDateTime;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        modifyDate = DateTime.SpecifyKind(modifyDate, DateTimeKind.Unspecified);
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        _newDateTime = TimeZoneInfo.ConvertTimeToUtc(modifyDate, _sourceTimeZone);
        return _newDateTime.ToString(ISO_DATE_FORMAT);
    }

    public string ConvertToISOStringWithTimeZone(DateTime dateTime, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        return (TimeZoneInfo.ConvertTimeFromUtc(dateTime, _sourceTimeZone).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"));
    }

    public DateTime GetCurrentUTCDateTime()
    {
        return DateTime.UtcNow;
    }

    public string GetDTSTimeZoneOffset(DateTime date, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        TimeSpan _utcOffset;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        _utcOffset = _sourceTimeZone.GetUtcOffset(date);
        return ((_utcOffset < TimeSpan.Zero) ? "-" : "+") + _utcOffset.ToString(@"hh\:mm");
    }

    public int GetISOWeek(DateTime dateTime)
    {
        return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
    }

    public string GetTimeZoneOffset(string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        return ((_sourceTimeZone.GetUtcOffset(DateTime.Now) < TimeSpan.Zero) ? "-" : "+") + _sourceTimeZone.BaseUtcOffset.ToString(@"hh\:mm");
    }

    public string ToDateFormat(DateTime currDate)
    {
        return currDate.ToString(ISO_DATE_FORMAT);
    }

    public string ToISO8601Format(DateTime datetime, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        return datetime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFF") + ((_sourceTimeZone.GetUtcOffset(DateTime.Now) < TimeSpan.Zero) ? "-" : "+") + _sourceTimeZone.BaseUtcOffset.ToString(@"hh\:mm");
    }

    public string ToISO8601String(DateTime datetime, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        TimeSpan _utcOffset;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }

        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        _utcOffset = _sourceTimeZone.GetUtcOffset(datetime);

        // updated to get daylight saving off set
        return datetime.AddHours(_utcOffset.Hours).AddMinutes(_utcOffset.Minutes).ToString(ISO_DATE_FORMAT) + ((_utcOffset < TimeSpan.Zero) ? " -" : " +") + _utcOffset.ToString(@"hh\:mm");
    }

    public string ToIsoString(DateTime datetime, string timeZone)
    {
        TimeZoneInfo _sourceTimeZone;
        TimeSpan _utcOffset;
        if (string.IsNullOrEmpty(timeZone))
        {
            timeZone = TimeZoneInfo.Local.StandardName;
        }
        _sourceTimeZone = GetTimeZoneInfo(timeZone);
        _utcOffset = _sourceTimeZone.GetUtcOffset(datetime);
        return (TimeZoneInfo.ConvertTimeFromUtc(datetime, _sourceTimeZone).ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFF") + ((_utcOffset < TimeSpan.Zero) ? "-" : "+") + _utcOffset.ToString(@"hh\:mm"));
    }

    #endregion Public Methods

    #region Private Methods

    private TimeZoneInfo GetTimeZoneInfo(string timeZone)
    {
        return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(o => o.StandardName == timeZone);
    }

    #endregion Private Methods
}
