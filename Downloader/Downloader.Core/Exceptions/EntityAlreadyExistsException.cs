using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Downloader.Core.Exceptions
{
	public class EntityAlreadyExistsException : Exception
	{
		public EntityAlreadyExistsException() : base() { }
		public EntityAlreadyExistsException(string message) : base(message) { }
		public EntityAlreadyExistsException(string message, Exception e) : base(message, e) { }
	}
}
