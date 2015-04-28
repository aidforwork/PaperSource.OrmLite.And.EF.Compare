using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Base
	{
		public Base()
		{
			BatchSize = 1000;

			ConnectionString = ConfigurationManager.ConnectionStrings["EntityDataModel"].ConnectionString;
		}

		public string ConnectionString { get; private set; }

		public int BatchSize { get; private set; }

		public int GenerateRandomId(int id)
		{
			var random = new Random();

			return id + random.Next(0, BatchSize - 1);
		}
	}
}
