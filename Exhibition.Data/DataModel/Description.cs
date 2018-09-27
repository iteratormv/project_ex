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

		public Description()
		{
			Name = "";
		}

		public Description(string name)
		{
			Name = name;
		}

		public virtual List<ExhibitionVisitor> ExhibitionVisitors { get; set; }
	}
}
