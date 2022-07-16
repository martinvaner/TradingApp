using AutoMapper;
using Downloader.Application.Repository.Interfaces;
using Downloader.Core.Entities;
using Downloader.Infrastructure.DTOs;
using Downloader.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Downloader.Infrastructure.YahooApi
{
	public class YahooApiRepository : ITickerRepository
	{
		private readonly HttpClient httpClient;
		private readonly ApiSettings apiSettings;
		private readonly IMapper mapper;

		public YahooApiRepository(HttpClient httpClient, ApiSettings apiSettings, IMapper mapper)
		{
			this.httpClient = httpClient;
			this.apiSettings = apiSettings;
			this.mapper = mapper;
		}
		public async Task<Ticker> Get(string tickerName)
		{
			Ticker ticker = null;
			string hos = apiSettings.Host;
			string keyyy = apiSettings.Key;

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://yh-finance.p.rapidapi.com/stock/v3/get-historical-data?symbol={tickerName}&region=US"),
				Headers =
				{
					{ "X-RapidAPI-Host", apiSettings.Host },
					{ "X-RapidAPI-Key", apiSettings.Key },
				},
			};


			var response = await this.httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				var responseStream = await response.Content.ReadAsStreamAsync();
				var tempTicker = await JsonSerializer.DeserializeAsync<TickerDTO>(responseStream);
				tempTicker.Symbol = tickerName;
				tempTicker.Date = DateTime.Now;

				ticker = mapper.Map<Ticker>(tempTicker);
			}
			else
			{
				// TODO: throw some better exception
				throw new Exception("Something went wrong.");
			}

			return ticker;
		}
	}
}
