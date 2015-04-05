using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public static class EntityGenerator
	{
		public static List<T> Orders<T>(int count) where T : IOrder, new()
		{
			var orders = new List<T>(count);

			var random = new Random();

			for (int i = 0; i < count; i++)
			{
				T order = new T {Number = random.Next()};

				orders.Add(order);
			}

			return orders;
		}
	}
}
