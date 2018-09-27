using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class ExhibitionSVisitor
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public string Position { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string BarCode { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public string Exhibition { get; set; }
		public string City { get; set; }
		public string Raport { get; set; }
		public string WorkPhone { get; set; }
		public string Pathronim { get; set; }
	}
}
