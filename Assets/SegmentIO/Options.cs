using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segmentio
{
    /// <summary>
    /// Options required to initialize the client
    /// </summary>
    public class Options
    {

        /// <summary>
        /// The REST API endpoint
        /// </summary>
        internal string Host { get; set; }

		internal int MinBatchSize { get; set; }

        internal int MaxQueueSize { get; set; }

		internal TimeSpan MinSendBatchInterval { get; set; }

		internal bool DebugLogJson { get; set; }


        public Options() {
            this.Host = Defaults.Host;
            this.MaxQueueSize = Defaults.MaxQueueCapacity;
			this.MinBatchSize = Defaults.minBatchSize;
			this.MinSendBatchInterval = Defaults.minSendBatchInterval;
			this.DebugLogJson = Defaults.debugLogJson;
        }
		
		/// <summary>
		/// Sets the maximum amount of items that can be in the queue before no more are accepted.
		/// </summary>
		/// <param name="maxQueueSize"></param>
		/// <returns></returns>
		public Options SetMaxQueueSize(int maxQueueSize) {
			this.MaxQueueSize = maxQueueSize;
			return this;
		}

      	public Options SetMinBatchSize(int minBatchSize) {
			this.MinBatchSize = minBatchSize;
			return this;
		}

		public Options SetMinSendBatchInterval(TimeSpan minSendBatchInterval) {
			this.MinSendBatchInterval = minSendBatchInterval;
			return this;
		}

		public Options SetDebugLogJson(bool debugLogJson) {
			this.DebugLogJson = debugLogJson;
			return this;
		}
    }
}
