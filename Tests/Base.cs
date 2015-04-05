using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using OrmLiteModel;

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
	}
}
