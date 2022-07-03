using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Downloader.Model;
using System.Net.Mime;
using Downloader.Core.Entities;
using Downloader.Application.Repository.Interfaces;

namespace Downloader.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly ITickerRepository tickerRepository; // for testing
		private readonly ITickerWritableRepository tickerWritableRepository; // for testing
		public DataController(ITickerRepository tickerRepository, ITickerWritableRepository tickerWritableRepository)
		{
			this.tickerRepository = tickerRepository;
			this.tickerWritableRepository = tickerWritableRepository;
		}

		[HttpGet("getData/{symbol}")]
		public async Task<ActionResult<Ticker>> GetData(string symbol)
		{
			Ticker ticker = await tickerRepository.Get("AMZN");
			Console.WriteLine();

			// get ticker data
			// if it is cached - get it from redis else get it from API

			//await redisService.WriteToRedis("testValue2", "This is the value of testValue thing");

			//var val = await redisService.ReadFromRedis("testValue2");
			//System.Diagnostics.Debug.WriteLine("redis testValue: " + val);

			//Ticker ticker = await dataDownloader.GetTickerHistoricalPrices(symbol);
			//if (ticker == null) return NotFound();



			return Ok();
		}

		[HttpPut("subscribe")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult Subscribe(Tickers tickers)
		{
			// register new service - call register method from application

			return NotFound();
		}

		[HttpPut("unsubscribe")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult Unsubscribe(Tickers tickers)
		{
			return NotFound();
		}
	}
}
