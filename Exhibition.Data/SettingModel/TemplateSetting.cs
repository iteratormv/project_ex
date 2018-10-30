//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Exhibition.Data.SettingModel
{
	public class TemplateSetting 
	{
		[Key]
		public int Id { get; set; }
		public bool isFNvisible { get; set; }
		public bool isLNvisible { get; set; }
		public bool isPAvisible { get; set; }
		public bool isPOvisible { get; set; }
		public bool isCOvisible { get; set; }
		public bool isCanDelete { get; set; }

        public bool isFNtoupper { get; set; }
        public bool isLNtoupper { get; set; }
        public bool isPAtoupper { get; set; }
        public bool isPOtoupper { get; set; }
        public bool isCOtoupper { get; set; }

        public string FontNameNA { get; set; }
		public string FontNamePO { get; set; }
		public string FontNameCO { get; set; }

		public float FontSizeNA { get; set; }
		public float FontSizePO { get; set; }
		public float FontSizeCO { get; set; }

		public int FontStyleNA { get; set; }
		public int FontStylePO { get; set; }
		public int FontStyleCO { get; set; }

		public string SettingName { get; set; }
	}


}
