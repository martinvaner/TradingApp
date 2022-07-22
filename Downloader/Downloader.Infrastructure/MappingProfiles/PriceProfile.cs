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
	public class PriceProfile : Profile
	{
		public PriceProfile()
		{
			CreateMap<PriceDTO, Price>().ReverseMap();
		}
	}
}
