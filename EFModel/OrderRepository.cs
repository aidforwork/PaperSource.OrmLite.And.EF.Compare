using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel
{
	public class OrderRepository
	{
		public string ConnectionString { get; set; }

		public OrderRepository(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public void InsertAll(List<Order> orders)
		{
			using (var context = new Context(ConnectionString))
			{
				context.Orders.AddRange(orders);

				context.SaveChanges();
			}
		}

		public void DeleteAll()
		{
			using (var context = new Context(ConnectionString))
			{
				context.Orders.RemoveRange(context.Orders);

				context.SaveChanges();
			}
		}

		public double UpdateAllWithTimer()
		{
			using (var context = new Context(ConnectionString))
			{
				var orders = context.Orders.ToList();

				orders.ForEach(order => order.Number *= -1);

				var stopwatch = new Stopwatch();

				stopwatch.Start();
				context.SaveChanges();
				stopwatch.Stop();

				return stopwatch.Elapsed.TotalMilliseconds;
			}
		}

		public List<Order> SelectAll()
		{
			using (var context = new Context(ConnectionString))
			{
				return context.Orders.AsNoTracking().ToList();
			}
		}

		public Order SelectById(int id)
		{
			using (var context = new Context(ConnectionString))
			{
				return context.Orders.AsNoTracking().FirstOrDefault(order => order.Id == id);
			}
		}
	}
}
