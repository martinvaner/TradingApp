using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TradingAppBE.Model;
using TrradingAppBE.Application.Services.Interfaces;

namespace TradingAppBE.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly IDataService dataService; // for testing only

		public DataController(IDataService dataService)
		{
			this.dataService = dataService;
		}

		[HttpGet("getUserData/{username}")]
		public async Task<ActionResult< IEnumerable<Ticker> >> GetUserTickers(string username)
		{
			try
			{
				var tickers = await dataService.GetUserTickers(username);
				return Ok(tickers);
			}
			catch(Exception e)
			{
				// TODO: log here
				System.Diagnostics.Debug.WriteLine(e.StackTrace);
				return Problem("Something went wrong.");
			}
		}

		[HttpGet("getData/{symbol}")]
		public async Task<ActionResult<Ticker>> GetData(string symbol)
		{
			// try get it from redis
			// if it is not there, call downloader to get data

			try
			{
				Ticker ticker = await dataService.GetTickerData(symbol);
				return Ok(ticker);
			}
			catch (Exception e)
			{
				// TODO: log here
				System.Diagnostics.Debug.WriteLine(e.StackTrace);
				return Problem("Something went wrong.");
			}
		}

		[HttpPost("subscribe")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult Subscribe(Tickers tickers)
		{
			// register new service - call subscribe in downloader

			return NotFound();
		}

		[HttpDelete("unsubscribe")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult Unsubscribe(Tickers tickers)
		{
			// remove given tickers from TICKERS array in redis

			return NotFound();
		}
	}
}
