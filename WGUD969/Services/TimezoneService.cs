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
    }
    public class TimezoneService : ITimezoneService
    {
        private TimeZoneInfo _TimeZoneInfo;
        public TimezoneService()
        {
            _TimeZoneInfo = TimeZoneInfo.Local;
        }

        public string LocalLabel {
            get {
                return _TimeZoneInfo.StandardName;
            }
        }
    }
}
