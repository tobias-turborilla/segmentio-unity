using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentio.Model
{
    public class Track : BaseAction
    {
		protected string UserId { 
			set {
				this["userId"] = value;
			}
		}

		protected string EventName { 
			set {
				this["event"] = value;
			}
		}

		protected Properties Properties { 
			set {
				this["properties"] = value;
			}
		}

        internal Track(string userId, 
		               string eventName,
            		   Properties properties, 
		               DateTime? timestamp,
		               Context context)

            : base("track", timestamp, context) {
			this.UserId = userId;
            this.EventName = eventName;
            this.Properties = properties ?? new Properties();
        }
    }
}
