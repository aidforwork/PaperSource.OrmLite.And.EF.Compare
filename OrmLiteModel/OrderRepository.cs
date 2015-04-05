using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.OrmLite;

namespace OrmLiteModel
{
	public class OrderRepository
	{
		public string ConnectionString { get; set; }

		public OrderRepository(string connectionString)
		{
			ConnectionString = connectionString;
		}

		protected IDbConnection OpenDbConnection()
		{
			var dbFactory = new OrmLiteConnectionFactory(ConnectionString, SqlServerDialect.Provider);

			IDbConnection db = dbFactory.Open();

			return db;
		}

		public void InsertAll(List<Order> orders)
		{
			using (var db = OpenDbConnection())
			{
				db.InsertAll(orders);
			}
		}

		public void DeleteAll()
		{
			using (var db = OpenDbConnection())
			{
				db.DeleteAll<Order>();
			}
		}

		public void UpdateAll(List<Order> orders)
		{
			using (var db = OpenDbConnection())
			{
				db.UpdateAll(orders);
			}
		}

		public List<Order> SelectAll()
		{
			using (var db = OpenDbConnection())
			{
				return db.Select<Order>();
			}
		}
	}
}
