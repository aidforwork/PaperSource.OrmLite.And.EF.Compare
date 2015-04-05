using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.DataAnnotations;

using Common;

namespace OrmLiteModel
{
	public partial class Order : IOrder
	{
		[AutoIncrement]
		public int Id { get; set; }

		[Required]
		[Index(NonClustered = true)]
		public int Number { get; set; }

		[CustomField("NVARCHAR(20)")]
		public string Text { get; set; }

		public int? CustomerId { get; set; }
	}
}
