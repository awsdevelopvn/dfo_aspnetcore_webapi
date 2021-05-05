using System;
using DFO_Application.Interfaces;

namespace DFO_Infrastructure.Shared
{
    public class DateTimeService: IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}