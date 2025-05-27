using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUD969.Services
{
    public interface ITimezoneService
    {
        public string LocalLabel { get; }
        public DateTime ConvertFromUTC(DateTime localDateTime);
        public DateTime ConvertToUTC(DateTime universalDateTime);
        public bool CheckIfDateTimeIsDuringBusinessHours(DateTime time);
    }
    public class TimezoneService : ITimezoneService
    {
        private TimeZoneInfo _TimeZoneInfo;
        public TimezoneService()
        {
            _TimeZoneInfo = TimeZoneInfo.Local;
        }

        public string LocalLabel
        {
            get
            {
                return _TimeZoneInfo.StandardName;
            }
        }

        public bool CheckIfDateTimeIsDuringBusinessHours(DateTime time)
        {
            time = DateTime.SpecifyKind(time, DateTimeKind.Local);
            time = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(time, "Eastern Standard Time");
            DateTime startTime = new DateTime(time.Year, time.Month, time.Day, 9, 0, 0);
            DateTime endTime = new DateTime(time.Year, time.Month, time.Day, 17, 0, 0);
            return (time > startTime && time < endTime);
        }

        public DateTime ConvertFromUTC(DateTime universalDateTime)
        {
            universalDateTime = DateTime.SpecifyKind(universalDateTime, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(universalDateTime, _TimeZoneInfo);
        }

        public DateTime ConvertToUTC(DateTime localDateTime)
        {
            localDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Local);
            return TimeZoneInfo.ConvertTimeToUtc(localDateTime, _TimeZoneInfo);
        }
    }
}
