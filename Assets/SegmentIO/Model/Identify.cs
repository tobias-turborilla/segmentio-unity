using System;
using System.Collections.Generic;
using System.Text;

namespace Segmentio.Model
{
    public class Identify : BaseAction
    {

		protected string UserId { 
			set {
				this["userId"] = value;
			}
		}

		protected Traits Traits {
			set {
				this["traits"] = value;
			}
		}

        internal Identify(string userId,
		                  Traits traits, 
		                  DateTime? timestamp,
		                  Context context)
	
			: base("identify", timestamp, context) {
			this.UserId = userId;
            this.Traits = traits ?? new Traits();
        }

    }
}
