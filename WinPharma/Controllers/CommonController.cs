using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinPharma.Domain;
using WinPharma.Services;

namespace WinPharma.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CommonController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<CommonController> _logger;
		private readonly ICommonManager commonManager;

		public CommonController(ILogger<CommonController> logger, ICommonManager commonManager)
		{
			_logger = logger;
			this.commonManager = commonManager;
		}

		[HttpPost("[action]")]
		public async Task<GoodResult> GetGoods([FromBody] GoodRequest model)
		{			
			var apiResult = await this.commonManager.GetGoods(model);
			return apiResult;

		}


	}
}
