using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public interface IOrder
	{
		int Id { get; set; }
		int Number { get; set; }
		string Text { get; set; }
		int? CustomerId { get; set; }
	}
}
