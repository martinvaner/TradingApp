using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TradingAppBE.DTOs;

namespace TradingAppBE.MappingProfiles
{
	public class AnalyticsProfile : Profile
	{
		public AnalyticsProfile()
		{
			CreateMap<Analytics, AnalyticsDTO>().ReverseMap();
		}
	}
}
