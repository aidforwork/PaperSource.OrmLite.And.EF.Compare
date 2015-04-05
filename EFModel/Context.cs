using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModel
{
	internal class Context : DbContext
	{
		public DbSet<Order> Orders { get; set; }

		public Context(string cn)
			: base(cn)
		{
		}

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
		//}
	}
}
