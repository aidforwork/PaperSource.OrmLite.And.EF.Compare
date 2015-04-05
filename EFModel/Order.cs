using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace EFModel
{
	[Table("Order")]
	public partial class Order : IOrder
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int Number { get; set; }

		[StringLength(20)]
		public string Text { get; set; }

		public int? CustomerId { get; set; }
	}
}
