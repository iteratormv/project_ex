using Exhibition.Data.SettingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exhibition.Data.BizLayer
{
	public class SettingStorage
	{
		CurrentSetting cs { get; set; }
		public List<TemplateSetting> lts { get; set; }
		ExhibitionSettingContext context;

		public SettingStorage()
		{
			context = new ExhibitionSettingContext();
			if (context.CurrentSettings.Select(s => s).Count() == 0)
			{
				CurrentSetting ncs = new CurrentSetting("default");
				context.CurrentSettings.Add(ncs);
				context.SaveChanges();

			}

			if (context.TemplateSettings.Select(t => t).Count() == 0)
			{
				TemplateSetting defaultSetting = new TemplateSetting();
				defaultSetting.isCanDelete = false;
				defaultSetting.isFNvisible = true;
				defaultSetting.isLNvisible = true;
				defaultSetting.isPAvisible = true;
				defaultSetting.isCOvisible = true;
				defaultSetting.isPOvisible = true;
				defaultSetting.FontFN = "Arial 9,75 Regular";
				defaultSetting.FontLN = "Arial 9,75 Regular";
				defaultSetting.FontPA = "Arial 9,75 Regular";
				defaultSetting.FontCO = "Arial 8,25 Regular";
				defaultSetting.FontPO = "Arial 8,25 Regular";
				defaultSetting.SettingName = "default";

				context.TemplateSettings.Add(defaultSetting);
				context.SaveChanges();
			}
			cs = context.CurrentSettings.Select(c => c).FirstOrDefault();
			lts = context.TemplateSettings.Select(t => t).ToList(); 
		}

		public void addSettingToStorage(TemplateSetting ts)
		{
			lts.Add(ts);
			context.TemplateSettings.Add(ts);
			context.SaveChanges();
		}

		public void delSettingFromStorage(TemplateSetting ts)
		{
			lts.Remove(ts);
			context.TemplateSettings.Remove(ts);
			context.SaveChanges();
		}

		public string getCSName()
		{
			return cs.CSName;
		}

		public void setCS(string curname)
		{
			cs.CSName = curname;
			var delcs = context.CurrentSettings.Select(c => c).FirstOrDefault();
			context.CurrentSettings.Remove(delcs);
			context.SaveChanges();
			context.CurrentSettings.Add(cs);
			context.SaveChanges();
		}

	}
}
