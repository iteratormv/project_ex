namespace Exhibition.Data.DataModel
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class ExhibitionDataContext_ : DbContext
	{
		// Контекст настроен для использования строки подключения "ExhibitionDataContext_" из файла конфигурации  
		// приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
		// "Exhibition.Data.DataModel.ExhibitionDataContext_" в экземпляре LocalDb. 
		// 
		// Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ExhibitionDataContext_" 
		// в файле конфигурации приложения.
		public ExhibitionDataContext_()
			: base("name=ExhibitionDataContext_")
		{
		}
		public virtual DbSet<ExhibitionSVisitor> ExhibitionSVisitors { get; set; }

		// Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
		// о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}