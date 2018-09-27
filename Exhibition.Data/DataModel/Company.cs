using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class Company
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(200)]
		[Display(Name = "Организация")]
		public string Name { get; set; }

		public Company()
		{
			Name = "";
		}

		public Company(string name)
		{
			Name = name;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
