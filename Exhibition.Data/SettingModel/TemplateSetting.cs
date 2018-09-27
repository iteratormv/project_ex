using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.SettingModel
{
	public class TemplateSetting 
	{
		[Key]
		public int Id { get; set; }
	//	public string FirstName { get; set; }
	//	public string LastName { get; set; }
	//	public string Pathronim { get; set; }
	//	public string Position { get; set; }
	//	public string Company { get; set; }
		public bool isFNvisible { get; set; }
		public bool isLNvisible { get; set; }
		public bool isPAvisible { get; set; }
		public bool isPOvisible { get; set; }
		public bool isCOvisible { get; set; }
		public bool isCanDelete { get; set; }
		public string FontFN { get; set; }
		public string FontLN { get; set; }
		public string FontPA { get; set; }
		public string FontPO { get; set; }
		public string FontCO { get; set; }
		public string SettingName { get; set; }
		public string CyrrentSetting { get; set; }
	}
}
