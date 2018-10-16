using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class ExhibitionVisitor
	{		
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string BarCode { get; set; }
		public string Status { get; set; }
		public string WorkPhone { get; set; }
		public string Pathronim { get; set; }
		public DateTime? DateCreated { get; set; }

		public int CityId { get; set; }
		public int CompanyId { get; set; }
		public int PositionId { get; set; }
		public int DescriptionId { get; set; }
		public int ExhibitId { get; set; }
		public int RaportId { get; set; }

		public City City { get; set; }
		public Company Company { get; set; }
		public Position Position { get; set; }
		public Description Description { get; set; }
		public Exhibit Exhibit { get; set; }
		public Raport Raport { get; set; }
	}
}
