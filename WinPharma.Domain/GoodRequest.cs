using System;
using System.Collections.Generic;
using System.Text;

namespace WinPharma.Domain
{
	public class GoodRequest
	{
		public int Skip { get; set; }
		public int Take { get; set; }
		public string Expand { get; set; }
		public string Filter { get; set; }
		public string Orderby { get; set; }
		public string OrderDirection { get; set; }
	}
}
