using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingAppBE.Core.Entities;
using TradingAppBE.Infrastructure.DTOs;

namespace TradingAppBE.Infrastructure.MappingProfiles
{
	public class PriceProfile : Profile
	{
		public PriceProfile()
		{
			CreateMap<PriceDTO, Price>();
			CreateMap<Price, PriceDTO>();
		}
	}
}
