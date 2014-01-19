using System;
using System.Collections.Generic;

namespace Segmentio.Model
{
    public class Traits : Props
    {
		new public Traits Put(string key, object val) 
		{
			this.Add (key, val);
			return this;
		}

    }
}
