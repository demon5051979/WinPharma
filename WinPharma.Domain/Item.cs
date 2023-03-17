using System;
using System.Collections.Generic;
using System.Text;

namespace WinPharma.Domain
{
	public class Item
	{
		public string Code { get; set; }
		public string Title { get; set; }
		public string Manufacturer { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
		public int Stock { get; set; }
	}
}
