using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentio.Model
{
    internal class Batch : Dictionary<string, object>
    {

		protected string Secret { 
			set {
				this["secret"] = value;
			}
		}

		internal List<BaseAction> batch { 
			set {
				this["batch"] = value;
			}
			get {
				return ContainsKey("batch") ? this["batch"] as List<BaseAction> : new List<BaseAction>();
			}
		}
	
		protected Context context { 
			set {
				this["context"] = value;
			}
			get {
				return ContainsKey("batch") ? this["batch"] as Context : new Context();
			}
		}

		protected Batch() { 
			this.context = new Context();
			this.context.Add("library", "analytics-.NET");
		}

        internal Batch(string secret, List<BaseAction> batch) : this()
        {
            this.Secret = secret;
            this.batch = batch;
        }
    }
}
