using System.Globalization;

namespace LocadoraWebApi
{
    public static class ManipulationDate
    {
        public static int GetWeekInMonth(DateTime date)
        {
            DateTime tempdate = date.AddDays(-date.Day + 1);
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNumStart = ciCurr.Calendar.GetWeekOfYear(tempdate, CalendarWeekRule.FirstFourDayWeek, ciCurr.DateTimeFormat.FirstDayOfWeek);
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, ciCurr.DateTimeFormat.FirstDayOfWeek);
            return weekNum - weekNumStart + 1;
        }
    }
}
