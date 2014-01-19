using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentio.Model
{
    public abstract class BaseAction : Dictionary<string, object>
    {

		private string Action {
			set {
				this["action"] = value;
			}
		}

		private string Timestamp { 
			set {
				this["timestamp"] = value;
			} 
		}
		
		private Context Context {
			set {
				this["context"] = value;
			} 
		}

		public BaseAction(string action, DateTime? timestamp, Context context) : base()
		{
			this.Action = action;
			if (timestamp.HasValue) this.Timestamp = timestamp.Value.ToString("o");
			this.Context = context;
        }
    }
}
