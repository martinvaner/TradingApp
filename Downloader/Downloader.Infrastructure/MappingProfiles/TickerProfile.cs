using AutoMapper;
using Downloader.Core.Entities;
using Downloader.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Infrastructure.MappingProfiles
{
	public class TickerProfile : Profile
	{
		public TickerProfile()
		{
			CreateMap<Ticker, TickerDTO>();
			CreateMap<TickerDTO, Ticker>().ForMember(d => d.Prices, opt => opt.MapFrom(src => src.Prices));
		}
	}
}
