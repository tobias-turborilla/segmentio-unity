using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentio.Model
{
	public class Alias : BaseAction
	{
		
		protected string From { 
			set {
				this["from"] = value;
			}
		}

		protected string To { 
			set {
				this["to"] = value;
			}
		}
		
		internal Alias(string from, string to, DateTime? timestamp, Context context)
			: base("alias", timestamp, context) {
			this.From = from;
			this.To = to;
		}

	}
}

