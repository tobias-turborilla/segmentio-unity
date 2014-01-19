using System;
using System.Collections.Generic;

namespace Segmentio.Model
{
    public class Properties : Props
    {
		new public Properties Put(string key, object val) 
		{
			this.Add (key, val);
			return this;
		}
    }

}
