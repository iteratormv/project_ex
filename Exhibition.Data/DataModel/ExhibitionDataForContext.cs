﻿namespace Exhibition.Data.DataModel
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class ExhibitionDataForContext : DbContext
	{
		// Контекст настроен для использования строки подключения "ExhibitionDataForContext" из файла конфигурации  
		// приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
		// "Exhibition.Data.DataModel.ExhibitionDataForContext" в экземпляре LocalDb. 
		// 
		// Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ExhibitionDataForContext" 
		// в файле конфигурации приложения.
		public ExhibitionDataForContext()
			: base("name=ExhibitionDataForContext")
		{
		}

		// Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
		// о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
		public DbSet<ExhibitionVisitor> ExhibitionVisitors { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Description> Descriptions { get; set; }
		public DbSet<Exhibit> Exhibits { get; set; }
		public DbSet<Raport> Raports { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}