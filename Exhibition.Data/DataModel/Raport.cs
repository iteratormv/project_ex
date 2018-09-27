using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class Raport
	{
		public int Id { get; set; }
		[MaxLength(200)]
		[Display(Name = "Доклад")]
		public string Name { get; set; }

		public Raport()
		{
			Name = "";
		}

		public Raport(string name)
		{
			Name = name;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
