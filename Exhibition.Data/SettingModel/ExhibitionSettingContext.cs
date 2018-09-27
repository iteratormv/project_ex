namespace Exhibition.Data.SettingModel
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class ExhibitionSettingContext : DbContext
	{
		// Контекст настроен для использования строки подключения "ExhibitionSettingContext" из файла конфигурации  
		// приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
		// "Exhibition.Data.SettingModel.ExhibitionSettingContext" в экземпляре LocalDb. 
		// 
		// Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ExhibitionSettingContext" 
		// в файле конфигурации приложения.
		public ExhibitionSettingContext()
			: base("name=ExhibitionSettingContext")
		{
		}

		// Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
		// о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }

		public virtual DbSet<TemplateSetting> TemplateSettings { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}