using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentio
{
    public class Analytics
    {

        public static Client Client { get; private set; }

        /// <summary>
        /// Initialized the default Segment.io client with your API secret.
        /// </summary>
        /// <param name="secret"></param>
        public static void Initialize(string secret)
		{
			if (Client == null) {
            	Client = new Client(secret);
			}
        }

        /// <summary>
        /// Initialized the default Segment.io client with your API secret.
        /// </summary>
        /// <param name="secret"></param>
        public static void Initialize(string secret, Options options)
        {
			if (Client == null) {
				Client = new Client(secret, options);
			}
       }

        /// <summary>
        /// Disposes of the current client and allows the creation of a new one
        /// </summary>
        public static void Reset()
        {
			if (Client != null) {
				Client.Dispose();
				Client = null;
			}
        }

    }
}
