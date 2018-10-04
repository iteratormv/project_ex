using System.ComponentModel.DataAnnotations;

namespace Exhibition.Data.SettingModel
{
	public class CurrentSetting
	{
		[Key]
		public int Id { get; set; }
		public string CSName { get; set; }

		public CurrentSetting()
		{
			
		}

		public CurrentSetting(string name)
		{
			CSName = name;
		}
	}
}