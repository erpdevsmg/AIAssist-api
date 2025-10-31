using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIAssistantAPI.Service.Interface
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
    public class DateTimeProvider : IDateTimeProvider
    {

        //public DateTime Now => DateTime.UtcNow.AddHours(4);
        private static readonly TimeZoneInfo _uaeTimeZone =
        TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");

        public DateTime Now => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _uaeTimeZone);
    }
}
