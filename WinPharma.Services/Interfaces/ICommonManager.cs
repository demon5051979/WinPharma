using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinPharma.Domain;

namespace WinPharma.Services
{
	public interface ICommonManager
	{
		Task<GoodResult> GetGoods(GoodRequest model);
	}
}
