using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segmentio
{
    public class Defaults
    {
        public static string Host = "https://api.segment.io";
		public static int minBatchSize = 5;
		public static TimeSpan minSendBatchInterval = new TimeSpan(0, 3, 0);
        public static int MaxQueueCapacity = 100;
		public static bool debugLogJson = false;

    }
}
