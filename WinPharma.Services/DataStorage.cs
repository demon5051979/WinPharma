using System;
using System.Collections.Generic;
using System.Text;
using WinPharma.Domain;

namespace WinPharma.Services
{
	public class DataStorage : IDataStorage
	{
		private GoodResult data = new GoodResult();

		public GoodResult Data
		{
			get
			{
				return data;
			}
			set
			{
				data = value;
			}
		}
	}
}
