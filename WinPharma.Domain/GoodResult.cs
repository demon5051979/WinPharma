using System;
using System.Collections.Generic;
using System.Text;

namespace WinPharma.Domain
{
	public class GoodResult
	{
		public Result Result { get; set; }
		public string Status { get; set; }
		public string RequestId { get; set; }
		public bool IsFreshData { get; set; } = true;
	}
}
