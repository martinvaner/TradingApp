using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAppBE.Infrastructure.EF.DTOs
{
	public class UserDTO
	{
		public int Id { get; set; }
		public string Username { get; set; }

		public ICollection<UserTickerDTO> UserTickers { get; set; } = new List<UserTickerDTO>();
	}
}
