using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WinPharma.Domain;
using static System.Net.WebRequestMethods;

namespace WinPharma.Services
{
	public class CommonManager : ICommonManager
	{
		const string apiAddress = @"http://fakestock.everys.com/api/v1/Stock";
		private const string credentials = "candidate:candidate321";

		private readonly IDataStorage dataStorage;

		public CommonManager(IDataStorage dataStorage)
		{
			this.dataStorage = dataStorage;
		}

		public async Task<GoodResult> GetGoods(GoodRequest model)
		{
			var client = new HttpClient();
			string base64credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64credentials);

			// ToDo: Здесь можно найти более красивый способ для маппинга параметров или передавать по другому
			var pars = new Dictionary<string, string>();
			pars["Filter"] = model.Filter;
			pars["Expand"] = model.Expand;
			pars["Orderby"] = model.Orderby;
			pars["OrderDirection"] = model.OrderDirection;
			pars["Skip"] = model.Skip.ToString();
			pars["Take"] = model.Take.ToString();

			var url = new Uri(QueryHelpers.AddQueryString(apiAddress, pars));

			var response = await client.GetAsync(url);
			//response.EnsureSuccessStatusCode();
			string responseString = await response.Content.ReadAsStringAsync();
			
			var result = JsonConvert.DeserializeObject<GoodResult>(responseString);

			if (result.Status.ToLower() == "ok")
			{
				this.dataStorage.Data = result;
			}
			else
			{
				result = this.dataStorage.Data;
				result.IsFreshData = false;
			}
			return result;
		}

	}
}
