using Downloader.Application.Repository.Interfaces;
using Downloader.Application.Services.Interfaces;
using Downloader.Core.Entities;
using Downloader.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Application.Services
{
	public class RegistrationService : IRegistrationService
	{
		// using for storage - redis, db, ...
		private readonly ITickerWritableRepository tickerWritableRepository;

		// using for getting data from other providers - API
		private readonly ITickerRepository tickerRepository;
		public RegistrationService(ITickerWritableRepository tickerWritableRepository, ITickerRepository tickerRepository)
		{
			this.tickerWritableRepository = tickerWritableRepository;
			this.tickerRepository = tickerRepository;
		}

		public async Task RegisterTicker(string tickerName)
		{
			// check if it is already registered
			var value = await tickerWritableRepository.Get(tickerName);
			if(value is null) throw new EntityAlreadyExistsException("This ticker is already registered.");

			// get data from api
			Ticker ticker = await tickerRepository.Get(tickerName);

			// save data to redis	
			await tickerWritableRepository.Write(ticker);
		}

		public Task RegisterTickers(IEnumerable<string> tickersNames)
		{
			throw new NotImplementedException();
		}
	}
}
