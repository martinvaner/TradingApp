using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TradingAppBE.DTOs;

namespace TradingAppBE.MappingProfiles
{
	public class TickerProfile : Profile
	{
		public TickerProfile()
		{
			CreateMap<Ticker, TickerDTO>().ForMember(d => d.Prices, opt => opt.MapFrom(src => src.Prices)).ReverseMap();

		}
	}
}
