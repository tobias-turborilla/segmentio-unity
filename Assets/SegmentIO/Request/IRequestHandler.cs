using System;
using System.Collections;
using System.Text;

using Segmentio.Model;

namespace Segmentio.Request
{
    internal interface IRequestHandler
    {
		void MakeRequest(Batch batch); 
		bool IsReady();
		void Poll();
    }
}
