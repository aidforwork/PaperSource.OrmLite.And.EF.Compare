using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Common;
using EFModel;

namespace Tests
{
	[TestFixture]
	public class EFTests : Base
	{
		[SetUp]
		public void SetUp()
		{
			var repository = CreateRepository();
			repository.DeleteAll();
		}

		private OrderRepository CreateRepository()
		{
			return new OrderRepository(ConnectionString);
		}

		private List<Order> CreateOrders()
		{
			return EntityGenerator.Orders<Order>(BatchSize);
		}

		[TestCase(1)]
		[TestCase(10)]
		[TestCase(100)]
		[TestCase(1000)]
		public void Insert(int count)
		{
			var repository = CreateRepository();

			var stopwatch = new Stopwatch();

			for (int i = 0; i < count; i++)
			{
				var orders = CreateOrders();

				stopwatch.Start();
				repository.InsertAll(orders);
				stopwatch.Stop();

				repository.DeleteAll();
			}

			Console.WriteLine("Insert x{0} = {1} ms", count, stopwatch.Elapsed.TotalMilliseconds);
		}

		[TestCase(1)]
		[TestCase(10)]
		[TestCase(100)]
		[TestCase(1000)]
		public void Select(int count)
		{
			var repository = CreateRepository();

			var stopwatch = new Stopwatch();

			for (int i = 0; i < count; i++)
			{
				var orders = CreateOrders();

				repository.InsertAll(orders);

				stopwatch.Start();
				orders = repository.SelectAll();
				stopwatch.Stop();

				repository.DeleteAll();
			}

			Console.WriteLine("Select x{0} = {1} ms", count, stopwatch.Elapsed.TotalMilliseconds);
		}

		[TestCase(1)]
		[TestCase(10)]
		[TestCase(100)]
		[TestCase(1000)]
		public void Update(int count)
		{
			var repository = CreateRepository();

			var list = new List<double>();

			for (int i = 0; i < count; i++)
			{
				var orders = CreateOrders();

				repository.InsertAll(orders);

				double ms = repository.UpdateAllWithTimer();

				list.Add(ms);

				repository.DeleteAll();
			}

			Console.WriteLine("Update x{0} = {1} ms", count, list.Sum());
		}
	}
}
