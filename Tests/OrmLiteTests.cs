using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Common;
using OrmLiteModel;

namespace Tests
{
	[TestFixture]
	public class OrmLiteTests : Base
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

			var stopwatch = new Stopwatch();

			for (int i = 0; i < count; i++)
			{
				var orders = CreateOrders();

				repository.InsertAll(orders);

				orders = repository.SelectAll();

				orders.ForEach(order => order.Number *= -1);

				stopwatch.Start();
				repository.UpdateAll(orders);
				stopwatch.Stop();

				repository.DeleteAll();
			}

			Console.WriteLine("Update x{0} = {1} ms", count, stopwatch.Elapsed.TotalMilliseconds);
		}

		[TestCase(1)]
		[TestCase(10)]
		[TestCase(100)]
		[TestCase(1000)]
		public void SelectSingle(int count)
		{
			var repository = CreateRepository();

			var stopwatch = new Stopwatch();

			for (int i = 0; i < count; i++)
			{
				var orders = CreateOrders();

				repository.InsertAll(orders);

				int firstId = repository.SelectFirstId();

				int randomId = GenerateRandomId(firstId);

				stopwatch.Start();
				var order = repository.SelectById(randomId);
				stopwatch.Stop();

				Assert.IsNotNull(order);

				repository.DeleteAll();
			}

			Console.WriteLine("SelectSingle x{0} = {1} ms", count, stopwatch.Elapsed.TotalMilliseconds);
		}
	}
}
