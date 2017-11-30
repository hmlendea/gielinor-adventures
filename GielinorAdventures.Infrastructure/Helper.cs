using System;

namespace GielinorAdventures.Infrastructure
{
    public static class Helper
    {
        static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        static Random rnd;

        public static Random Random
        {
            get
            {
                if (rnd == null)
                {
                    rnd = new Random();
                }

                return rnd;
            }
        }

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
    }
}
