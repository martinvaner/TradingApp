using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TradingAppBE.DTOs;
using TrradingAppBE.Application.Services.Interfaces;

namespace TradingAppBE.Controllers
{
	[EnableCors]
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly IDataService dataService; // for testing only
		private readonly IMapper mapper;

		public DataController(IDataService dataService, IMapper mapper)
		{
			this.dataService = dataService;
			this.mapper = mapper;
		}

		[HttpGet("getUserData/{username}")]
		public async Task<ActionResult< IEnumerable<Ticker> >> GetUserTickers(string username)
		{
			try
			{
				var tickers = await dataService.GetUserTickers(username);
				var tickersDTO = this.mapper.Map<TickerDTO[]>(tickers);
				return Ok(tickersDTO);
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
