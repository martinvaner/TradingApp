using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrradingAppBE.Application.Repository.Interfaces
{
	public interface IUserTickersRepository
	{
		Task<IEnumerable<string>> GetUserTickers(string username);
	}
}
