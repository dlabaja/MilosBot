using System;

namespace MilošBot.Services
{
    public class UpTimeService
    {
        public DateTime StartTime { get; }
        public TimeSpan UpTime => DateTime.Now - StartTime;

        public UpTimeService()
        {
            StartTime = DateTime.Now;
        }
    }
}
