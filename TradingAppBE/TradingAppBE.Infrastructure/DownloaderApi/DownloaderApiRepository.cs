using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TradingAppBE.Infrastructure.DTOs;
using TradingAppBE.Infrastructure.Settings;
using TrradingAppBE.Application.Repository.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace TradingAppBE.Infrastructure.DownloaderApi
{
	public class DownloaderApiRepository : IDownloaderApiRepository
	{
		private readonly HttpClient httpClient;
		private readonly ApiSettings apiSettings;
		private readonly IMapper mapper;

		public DownloaderApiRepository(HttpClient httpClient, ApiSettings apiSettings, IMapper mapper)
		{
			this.httpClient = httpClient;
			this.apiSettings = apiSettings;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<Ticker>> Create(string[] names)
		{
			Ticker[] newTickers;
			Dictionary<string, string[]> tickers = new Dictionary<string, string[]>();
			tickers.Add("names", names);
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri(apiSettings.Host + $"/data/subscribe"),
				Content = new StringContent(JsonSerializer.Serialize(tickers), Encoding.UTF8, Application.Json)
			};

			var response = await this.httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				var responseStream = await response.Content.ReadAsByteArrayAsync();
				TickerDTO[] tempTickers = JsonSerializer.Deserialize<TickerDTO[]>(responseStream);

				newTickers = mapper.Map<Ticker[]>(tempTickers);

				return newTickers;
			}
			else
			{
				// TODO: throw some better exception
				var errors = await response.Content.ReadAsStringAsync();
				throw new Exception($"Something went wrong. Status {response.StatusCode}, Errors: {errors}");
			}
		}

		public async Task<Ticker> Get(string symbol)
		{

			Ticker ticker = null;

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(apiSettings.Host + $"/data/getData/{symbol}"),
			};

			var response = await this.httpClient.SendAsync(request);

			if (response.IsSuccessStatusCode)
			{
				var responseStream = await response.Content.ReadAsByteArrayAsync();
				TickerDTO tempTicker = JsonSerializer.Deserialize<TickerDTO>(responseStream);

				ticker = mapper.Map<Ticker>(tempTicker);
			}
			else
			{
				// TODO: throw some better exception
				var errors = await response.Content.ReadAsStringAsync();
				throw new Exception($"Something went wrong. Status {response.StatusCode}, Errors: {errors}");
			}

			return ticker;
		}
	}
}
