using System;
using System.Collections.Generic;
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
