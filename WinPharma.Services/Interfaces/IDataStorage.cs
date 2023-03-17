using System;
using System.Collections.Generic;
using System.Text;
using WinPharma.Domain;

namespace WinPharma.Services
{
	public interface IDataStorage
	{
		GoodResult Data { get; set; }
	}
}
