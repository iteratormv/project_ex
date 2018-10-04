using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class Description
	{
		public int Id { get; set; }
		[MaxLength(200)]
		[Display(Name = "Вы являетесь")]
		public string Name { get; set; }
		public string Color { get; set; }

		public Description()
		{
			Name = "";
			Color = "";
		}

		public Description(string name, string color)
		{
			Name = name;
			Color = color;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
