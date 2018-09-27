using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exhibition.Data;
using Exhibition.Data.DataModel;
using System.Data.Entity.Migrations;

namespace Exhibition
{
	class Program
	{


		static void Main(string[] args)
		{


			ExelData e = new ExelData(@"C: \Users\vlad\Documents\index.html");

			//ExhibitionDataForContext context = new ExhibitionDataForContext();

			//City city = new City();
			//city.Name = "Дебальцево";


			//Company company = new Company();
			//company.Name = "Итератор";

			//Position position = new Position();
			//position.Name = "Программист";

			//Description description = new Description();
			//description.Name = "ИТ Компания";

			//Exhibit exhibition = new Exhibit();
			//exhibition.Name = "МУК";

			//Raport raport = new Raport();
			//raport.Name = "Программирование это просто";

		//	context.Database.Delete();

			//context.Cities.Add(city);
			//context.Cities.Add(new City("Енакиево"));
			//context.Cities.Add(new City("Горловка"));
			//context.Companies.Add(company);
			//context.Companies.Add(new Company("эсэнти"));
			//context.Companies.Add(new Company("Энергетика и климат"));
			//context.Positions.Add(position);
			//context.Positions.Add(new Position("Инженер"));
			//context.Positions.Add(new Position("Дизайнер"));
			//context.Descriptions.Add(description);
			//context.Descriptions.Add(new Description("Вендор"));
			//context.Descriptions.Add(new Description("Прессса"));
			//context.Exhibits.Add(exhibition);
			//context.Exhibits.Add(new Exhibit("ПУК"));
			//context.Exhibits.Add(new Exhibit("ТУК"));
			//context.Raports.Add(raport);
			//context.Raports.Add(new Raport("Посмотри как я рисую"));
			//context.Raports.Add(new Raport("220 Киловат"));

			//context.SaveChanges();



			//ExhibitionVisitor exhibitionVisitor = new ExhibitionVisitor();
			//exhibitionVisitor.FirstName = "Григорий";
			//exhibitionVisitor.LastName = "Турчинов";
			//exhibitionVisitor.PhoneNumber = "+3805012345679";
			//exhibitionVisitor.Email = "turchin@gmail.com";
			//exhibitionVisitor.BarCode = "9876543210";
			//exhibitionVisitor.Status = "norm";
			//exhibitionVisitor.WorkPhone = "04412345678";
			//exhibitionVisitor.Pathronim = "Григорьевич";

			//exhibitionVisitor.CityId = context.Cities.Where(c=>c.Name == "Енакиево").Select(cc=>cc.Id).FirstOrDefault();
			//exhibitionVisitor.CompanyId = context.Companies.Where(co=>co.Name == "Энергетика и климат").Select(coc=>coc.Id).FirstOrDefault();
			//exhibitionVisitor.ExhibitId = context.Exhibits.Where(e=>e.Name == "ПУК").Select(ex=>ex.Id).FirstOrDefault();
			//exhibitionVisitor.PositionId = context.Positions.Where(p=>p.Name == "Дизайнер").Select(po=>po.Id).FirstOrDefault();
			//exhibitionVisitor.DescriptionId = context.Descriptions.Where(d=>d.Name == "Вендор").Select(dd=>dd.Id).FirstOrDefault();
			//exhibitionVisitor.RaportId = context.Raports.Where(r=>r.Name == "Посмотри как я рисую").Select(rr=>rr.Id).FirstOrDefault();

			//context.ExhibitionVisitors.Add(exhibitionVisitor);

			//context.SaveChanges();










			//	ExcelData exel_data = new ExcelData();
			//	exel_data.getDataToDatabase();
		}


	}
}

