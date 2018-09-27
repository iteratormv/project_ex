using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.DataModel
{
	public class City
	{
		public int Id { get; set; }
		[MaxLength(200)]
		[Display(Name = "Город")]
		public string Name { get; set; }

		public City()
		{
			Name = "";
		}

		public City(String name)
		{
			Name = name;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
