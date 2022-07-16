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
using Downloader.Application.Services.Interfaces;

namespace Downloader.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DataController : ControllerBase
	{
		private readonly IDownloadService downloadService;
		public DataController(IDownloadService downloadService)
		{
			this.downloadService = downloadService;
		}

		[HttpGet("getData/{symbol}")]
		public async Task<ActionResult<Ticker>> GetData(string symbol)
		{
			try
			{
				Ticker ticker = await downloadService.DownloadData(symbol);
				return Ok(ticker);
			}
			catch(Exception e)
			{
				// TODO: log here

				return Problem("Something went wrong.");
			}
		}

		[HttpPut("subscribe")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult Subscribe(Tickers tickers)
		{
			// register new service - call register method from application
			// add new tickers to TICKERS array in redis - these will be periodically updated

			return NotFound();
		}

		[HttpPut("unsubscribe")]
		[Consumes(MediaTypeNames.Application.Json)]
		public ActionResult Unsubscribe(Tickers tickers)
		{
			// remove given tickers from TICKERS array in redis

			return NotFound();
		}
	}
}
