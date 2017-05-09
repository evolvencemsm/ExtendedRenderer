

using System;
using System.Globalization;


namespace AC.ExtendedRenderer.Toolkit.KryptonOutlookGrid
{
    /// <summary>
    /// Class containing functions for the IOutlookGridGroups
    /// </summary>
    public class OutlookGridGroupHelpers
    {
        /// <summary>
        /// Gets the title for a specific datetime
        /// </summary>
        /// <param name="date">The DateTime </param>
        /// <returns>The text to display</returns>
        public static string GetDayText(DateTime date)
        {
            switch (GetDateCode(date))
            {
                case "NODATE":
                    return "NODATE"; // "Today";
                case "TODAY":
                    return "TODAY"; // "Today";
                case "YESTERDAY":
                    return "YESTERDAY"; //"Yesterday";
                case "TOMORROW":
                    return "TOMORROW"; //"Tomorrow";
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                case "Sunday":
                    return UppercaseFirst(date.ToString("dddd"));
                case "NEXTWEEK":
                    return "NEXTWEEK"; //"Next Week";
                case "INTWOWEEKS": //dans le deux semaines a venir
                    return "INTWOWEEKS"; //"In two weeks"; //dans le deux semaines a venir
                case "INTHREEWEEKS": //dans les trois semaines à venir
                    return "INTHREEWEEKS"; //"In three weeks"; //dans les trois semaines à venir
                case "LATERDURINGTHISMONTH": //Plus tard au cours de ce mois 
                    return "LATERDURINGTHISMONTH"; //"Later during this month"; //Plus tard au cours de ce mois 
                case "NEXTMONTH": //Prochain mois
                    return "NEXTMONTH"; //"Next month"; //Prochain mois
                case "AFTERNEXTMONTH":  //Au-delà du prochain mois 
                    return "AFTERNEXTMONTH"; //"After next month";  //Au-delà du prochain mois 
                case "PREVIOUSWEEK":
                    return "PREVIOUSWEEK"; //"Previous Week";
                case "TWOWEEKSAGO": //Il y a deux semaines
                    return "TWOWEEKSAGO"; //"Two weeks ago"; //Il y a deux semaines
                case "THREEWEEKSAGO": //Il y a deux semaines
                    return "THREEWEEKSAGO"; //"Three weeks ago"; //Il y a deux semaines
                case "EARLIERDURINGTHISMONTH": //Il y a deux semaines
                    return "EARLIERDURINGTHISMONTH"; //"Earlier during this month";  //Plus tot au cours de ce mois
                case "PREVIOUSMONTH": //Il y a deux semaines
                    return "PREVIOUSMONTH"; //"Previous Month";  //Mois dernier
                case "BEFOREPREVIOUSMONTH":  //Mois dernier
                    return "BEFOREPREVIOUSMONTH"; //"Before Previous Month";   //Avant le mois dernier
                default:
                    return date.Date.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets the code according to a datetime
        /// </summary>
        /// <param name="date">The DateTime to analyze.</param>
        /// <returns>The associated code.</returns>
        public static string GetDateCode(DateTime date)
        {
            if (date.Date == DateTime.MinValue)//Today
            {
                return "NODATE";
            }
            else if (date.Date == DateTime.Now.Date)//Today
            {
                return "TODAY";
            }
            else if (date.Date == DateTime.Now.AddDays(-1).Date)
            {
                return "YESTERDAY";
            }
            else if (date.Date == DateTime.Now.AddDays(1).Date)
            {
                return "TOMORROW";
            }
            else if ((date.Date >= GetFirstDayOfWeek(DateTime.Now)) && (date.Date <= GetLastDayOfWeek(DateTime.Now)))
            {
                return date.Date.DayOfWeek.ToString();//"DAYOFWEEK";
            }
            else if ((date.Date > GetLastDayOfWeek(DateTime.Now)) && (date.Date <= GetLastDayOfWeek(DateTime.Now).AddDays(6)))
            {
                return "NEXTWEEK";
            }
            else if ((date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(6)) && (date.Date <= GetLastDayOfWeek(DateTime.Now).AddDays(12)))
            {
                return "INTWOWEEKS"; //dans les deux semaines a venir
            }
            else if ((date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(12)) && (date.Date <= GetLastDayOfWeek(DateTime.Now).AddDays(18)))
            {
                return "INTHREEWEEKS"; //dans les trois semaines à venir
            }
            else if ((date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(18)) && (date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1)))//AddDays(DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month)-1)))
            {
                return "LATERDURINGTHISMONTH"; //Plus tard au cours de ce mois 
            }
            else if ((date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(18)) && (date.Date > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1)) && (date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(2).AddDays(-1)))
            {
                return "NEXTMONTH"; //Prochain mois
            }
            else if ((date.Date > GetLastDayOfWeek(DateTime.Now).AddDays(18)) && (date.Date > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(2).AddDays(-1)))
            {
                return "AFTERNEXTMONTH";  //Au-delà du prochain mois 
            }
            else if ((date.Date < GetFirstDayOfWeek(DateTime.Now)) && (date.Date >= GetFirstDayOfWeek(DateTime.Now).AddDays(-7)))
            {
                return "PREVIOUSWEEK";
            }
            else if ((date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-7)) && (date.Date >= GetFirstDayOfWeek(DateTime.Now).AddDays(-14)))
            {
                return "TWOWEEKSAGO"; //Il y a deux semaines
            }
            else if ((date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-14)) && (date.Date >= GetFirstDayOfWeek(DateTime.Now).AddDays(-21)))
            {
                return "THREEWEEKSAGO"; //Il y a deux semaines
            }
            else if ((date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-21)) && (date.Date >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)))
            {
                return "EARLIERDURINGTHISMONTH"; //Il y a deux semaines
            }
            else if ((date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-21)) && (date.Date >= new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1)) && (date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1)))
            {
                return "PREVIOUSMONTH"; //Il y a deux semaines
            }
            else if ((date.Date <= GetFirstDayOfWeek(DateTime.Now).AddDays(-21)) && (date.Date <= new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1).AddDays(-1)))
            {
                return "BEFOREPREVIOUSMONTH";  //Mois dernier
            }
            else
            {
                return date.Date.ToShortDateString();
            }
        }

        /// <summary>
        /// Uppercase the first letter of the string
        /// </summary>
        /// <param name="s">The string.</param>
        /// <returns>The tring with the first letter uppercased.</returns>
        private static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        
        /// <summary>
        /// Returns the first day of the week that the specified date is in using the current culture.
        /// </summary>
        /// <param name="dayInWeek">The date to analyse</param>
        /// <returns>The first day of week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the last day of the week that the specified date is in using the current culture.
        /// </summary>
        /// <param name="dayInWeek">The date to analyse</param>
        /// <returns>The last day of week.</returns>
        public static DateTime GetLastDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo).AddDays(6);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date is in.
        /// </summary>
        /// <param name="dayInWeek">The date to analyse</param>
        /// <param name="cultureInfo">The CultureInfo</param>
        /// <returns>The first day of week.</returns>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            int difference = ((int)dayInWeek.DayOfWeek) - ((int)firstDay);
            difference = (7 + difference) % 7;
            return dayInWeek.AddDays(-difference).Date;
        }
    }
}
