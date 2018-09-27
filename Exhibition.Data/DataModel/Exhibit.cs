using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class Exhibit
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(200)]
		[Display(Name = "Выставка")]
		public string Name { get; set; }

		public Exhibit()
		{
			Name = "";
		}

		public Exhibit(String name)
		{
			Name = name;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
