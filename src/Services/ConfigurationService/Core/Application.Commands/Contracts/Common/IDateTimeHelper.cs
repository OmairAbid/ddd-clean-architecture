using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Contracts.Common;
/// <summary>Interface for date times helper.</summary>
public interface IDateTimeHelper
{
    #region Public Properties

    /// <summary>Gets the ISO date format.</summary>
    /// <value>The ISO date format.</value>
    string ISO_DATE_FORMAT { get; }

    /// <summary>Gets the ISO date format only date.</summary>
    /// <value>The ISO date format only date.</value>
    string ISO_DATE_FORMAT_ONLY_DATE { get; }

    /// <summary>Gets the ISO date format with timezone.</summary>
    /// <value>The ISO date format with timezone.</value>
    string ISO_DATE_FORMAT_WITH_TIMEZONE { get; }

    /// <summary>Gets the ISO time format.</summary>
    /// <value>The ISO time format.</value>
    string ISO_TIME_FORMAT { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>Convert DateTime From UTC.</summary>
    /// <param name="modifyDate">.</param>
    /// <param name="timeZone">  .</param>
    /// <returns>The date converted time from UTC.</returns>
    string ConvertDateTimeFromUTC(DateTime modifyDate, string timeZone);

    /// <summary>Convert DateTime From UTC To Date.</summary>
    /// <param name="modifyDate">.</param>
    /// <param name="timeZone">  .</param>
    /// <returns>The date converted time from UTC to date.</returns>
    DateTime ConvertDateTimeFromUTCToDate(DateTime modifyDate, string timeZone);

    /// <summary>Convert DateTime To UTC.</summary>
    /// <param name="modifyDate">.</param>
    /// <param name="timeZone">  .</param>
    /// <returns>The date converted time to UTC.</returns>
    string ConvertDateTimeToUTC(DateTime modifyDate, string timeZone);

    /// <summary>Convert to ISO string with timezone information Used in document processing XML.</summary>
    /// <param name="dateTime">.</param>
    /// <param name="timeZone">.</param>
    /// <returns>The given data converted to an ISO string with time zone.</returns>
    string ConvertToISOStringWithTimeZone(DateTime dateTime, string timeZone);

    /// <summary>Get current UTC date and time.</summary>
    /// <returns>The current UTC date time.</returns>
    DateTime GetCurrentUTCDateTime();

    /// <summary>Get Daylight saving offset information for given date.</summary>
    /// <param name="date">    .</param>
    /// <param name="timeZone">.</param>
    /// <returns>The dts time zone offset.</returns>
    string GetDTSTimeZoneOffset(DateTime date, string timeZone);

    /// <summary>Get ISO Week.</summary>
    /// <param name="dateTime">.</param>
    /// <returns>The ISO week.</returns>
    int GetISOWeek(DateTime dateTime);

    /// <summary>Get Time Zone Offset.</summary>
    /// <param name="timeZone">.</param>
    /// <returns>The time zone offset.</returns>
    string GetTimeZoneOffset(string timeZone);

    /// <summary>To Date Format.</summary>
    /// <param name="currDate">.</param>
    /// <returns>CurrDate as a string.</returns>
    string ToDateFormat(DateTime currDate);

    /// <summary>To ISO 8601 Format.</summary>
    /// <param name="datetime">.</param>
    /// <param name="timeZone">.</param>
    /// <returns>The given data converted to a string.</returns>
    string ToISO8601Format(DateTime datetime, string timeZone);

    /// <summary>To ISO 8601 String.</summary>
    /// <param name="datetime">.</param>
    /// <param name="timeZone">.</param>
    /// <returns>The given data converted to a string.</returns>
    string ToISO8601String(DateTime datetime, string timeZone);

    /// <summary>To Iso String.</summary>
    /// <param name="datetime">.</param>
    /// <param name="timeZone">.</param>
    /// <returns>The given data converted to a string.</returns>
    string ToIsoString(DateTime datetime, string timeZone);

    #endregion Public Methods
}
