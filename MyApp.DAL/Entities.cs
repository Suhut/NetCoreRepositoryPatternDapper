using Dapper.Contrib.Extensions;
using System;

namespace MyApp.DAL
{
	[Table("Tm_Customer")]
	public class Tm_Customer
	{
		[ExplicitKey]
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public System.DateTime? CreatedDate { get; set; }
		public Guid? CreatedUser { get; set; }
		public System.DateTime? ModifiedDate { get; set; }
		public Guid? ModifiedUser { get; set; }

	}
 
}

