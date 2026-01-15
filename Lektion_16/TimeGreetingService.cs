using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lektion_16
{
    public class TimeGreetingService : IDateTimeProvider
    {
        public DateTime GetTimeNow()
        {
            return DateTime.Now;
        }

        public string GetGreeting(IDateTimeProvider dtp)
        {
            string message = "";

            DateTime now = dtp.GetTimeNow();

            if (now.Hour < 12)
            {
                message = "Morning!";
            }
            if (now.Hour >= 12 && now.Hour < 20)
            {
                message = "Afternoon, ya'll";
            }
            if (now.Hour >= 20)
            {
                message = "'tis night";
            }


            return message;
        }
    }
}

public interface IDateTimeProvider
{
    public DateTime GetTimeNow();
}

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime GetTimeNow()
    {
        return DateTime.Now;
    }
}

public class CustomDateTimeProvider : IDateTimeProvider
{
    public DateTime GetTimeNow()
    {
        return new DateTime(2025, 10, 14, 22, 0, 0);
    }
}