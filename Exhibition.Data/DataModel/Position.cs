using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class Position
	{
		public int Id { get; set; }
		[MaxLength(200)]
		[Required]
		[Display(Name = "Должность")]
		public string Name { get; set; }

		public Position()
		{
			Name = "";
		}

		public Position(string name)
		{
			Name = name;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
