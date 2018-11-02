using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exhibition.Data.DataModel;
using Microsoft.Office.Interop.Excel;

namespace Exhibition.Data
{
	public class ExelData
	{
		public int excelWorksheetRow { get; }
		public int excelWorksheetCol { get; }
		public string[,] data { get; }
		public string status { get; set; }


        public ExelData(string fName, ProgressBar pb)
        {
            pb.Visible = true;
            pb.Value = 1;
            Microsoft.Office.Interop.Excel.Application excel_app =
                new Microsoft.Office.Interop.Excel.Application();

            string[] partsPath = fName.Split('\\');
            foreach (string s in partsPath)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n" + partsPath.Length.ToString());
            string res = "";
            for (int i = 0; i < partsPath.Length - 1; i++)
            {
                res += partsPath[i] + "\\";
            }
            res += partsPath[partsPath.Length - 1];

            string file_name = res;

            Workbook work_book = excel_app.Workbooks.Open(file_name, Type.Missing);

            Worksheet work_shet = (Worksheet)work_book.Worksheets[1];

            Range excelRange = work_shet.UsedRange;

            object[,] vallueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);

            excelWorksheetRow = work_shet.UsedRange.Rows.Count;
            excelWorksheetCol = work_shet.UsedRange.Columns.Count;
            data = new string[excelWorksheetRow, excelWorksheetCol];

            pb.Maximum = excelWorksheetRow;

            for (int row = 1; row <= excelWorksheetRow; ++row)
            {
   //            pb.Refresh();
                for (int col = 1; col <= excelWorksheetCol; ++col)
                {
                    if (vallueArray[row, col] == null) data[row - 1, col - 1] = " ";
                    else data[row - 1, col - 1] = vallueArray[row, col].ToString();
                }
            }
            status = "create excel data with forigen key";
        }



        public ExelData(string fName)
		{

			Microsoft.Office.Interop.Excel.Application excel_app =
				new Microsoft.Office.Interop.Excel.Application();

			string[] partsPath = fName.Split('\\');
			foreach (string s in partsPath)
			{
				Console.WriteLine(s);
			}
			Console.WriteLine("\n" + partsPath.Length.ToString());
			string res = "";
			for (int i = 0; i < partsPath.Length - 1; i++)
			{
				res += partsPath[i] + "\\";
			}
			res += partsPath[partsPath.Length - 1];

			string file_name = res;

			Workbook work_book = excel_app.Workbooks.Open(file_name, Type.Missing);

			Worksheet work_shet = (Worksheet)work_book.Worksheets[1];

			Range excelRange = work_shet.UsedRange;

			object[,] vallueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);

			excelWorksheetRow = work_shet.UsedRange.Rows.Count;
			excelWorksheetCol = work_shet.UsedRange.Columns.Count;
			data = new string[excelWorksheetRow, excelWorksheetCol];

			for (int row = 1; row <= excelWorksheetRow; ++row)
			{
				for (int col = 1; col <= excelWorksheetCol; ++col)
				{
					if (vallueArray[row, col] == null) data[row - 1, col - 1] = " ";
					else data[row - 1, col - 1] = vallueArray[row, col].ToString();
				}
			}
			status = "create excel data with forigen key";
		}

		public ExelData()
		{
			Microsoft.Office.Interop.Excel.Application excel_app =
				new Microsoft.Office.Interop.Excel.Application();

			string file_name = "D:\\Exhibition\\bookxlsx.xlsx";

			Workbook work_book = excel_app.Workbooks.Open(file_name, Type.Missing);

			Worksheet work_shet = (Worksheet)work_book.Worksheets[1];

			Range excelRange = work_shet.UsedRange;

			object[,] vallueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);

			excelWorksheetRow = work_shet.UsedRange.Rows.Count;
			excelWorksheetCol = work_shet.UsedRange.Columns.Count;
			data = new string[excelWorksheetRow, excelWorksheetCol];

			for (int row = 1; row <= excelWorksheetRow; ++row)
			{
				for (int col = 1; col <= excelWorksheetCol; ++col)
				{
					if (vallueArray[row, col] == null) data[row - 1, col - 1] = " ";
					else data[row - 1, col - 1] = vallueArray[row, col].ToString();
				}
			}
			status = "create excel data";
		}

		public void getDataToDatabase()
		{
			for (int row = 0; row < excelWorksheetRow; row++)
			{
				using (ExhibitionDataContext_ context = new ExhibitionDataContext_())
				{
					ExhibitionSVisitor visitor = new ExhibitionSVisitor();
					visitor.LastName = data[row, 0];
					visitor.FirstName = data[row, 1];
					visitor.Company = data[row, 2];
					visitor.Position = data[row, 3];
					visitor.PhoneNumber = data[row, 4];
					visitor.Email = data[row, 5];
					visitor.Description = data[row, 6];
					visitor.BarCode = data[row, 7];

					context.ExhibitionSVisitors.Add(visitor);
					context.SaveChanges();
				}
			}
			Console.WriteLine("Data send to database");
		}


        public void getForDataToDatabase(ProgressBar pb)
        {
            for (int row = 0; row < excelWorksheetRow; row++)
            {
                pb.Value = row;
                using (ExhibitionDataForContext context = new ExhibitionDataForContext())
                {
                    var e_company = data[row, 2];
                    if (e_company.Length == 0 || e_company == " ") e_company = "none";
                    if (context.Companies.Where(cc => cc.Name.Equals(e_company)).ToList().Count() == 0)
                    {
                        context.Companies.Add(new Company(e_company));
                    }

                    var e_position = data[row, 3];
                    if (e_position.Length == 0 || e_position == " ") e_position = "none";
                    if (context.Positions.Where(p => p.Name.Equals(e_position)).Count() == 0)
                    {
                        context.Positions.Add(new Position(e_position));
                    }

                    var e_discription = data[row, 6];
                    if (e_discription.Length == 0 || e_discription == " ") e_discription = "none";
                    if (context.Descriptions.Where(d => d.Name.Equals(e_discription)).Count() == 0)
                    {
                        context.Descriptions.Add(new Description(e_discription, "White"));
                    }

                    if (context.Cities.Where(c => c.Name.Equals("none")).Count() == 0)
                    {
                        context.Cities.Add(new City("none"));
                    }

                    if (context.Exhibits.Where(e => e.Name.Equals("none")).Count() == 0)
                    {
                        context.Exhibits.Add(new Exhibit("none"));
                    }

                    if (context.Raports.Where(r => r.Name.Equals("none")).Count() == 0)
                    {
                        context.Raports.Add(new Raport("none"));
                    }

                    context.SaveChanges();

                    ExhibitionVisitor visitor = new ExhibitionVisitor();
                    visitor.LastName = data[row, 0];
                    visitor.FirstName = data[row, 1];

                    visitor.CityId = context.Cities.Where(ci => ci.Name.Equals
                    ("none")).Select(c => c.Id).FirstOrDefault();
                    visitor.ExhibitId = context.Cities.Where(e => e.Name.Equals
                    ("none")).Select(ex => ex.Id).FirstOrDefault();
                    visitor.RaportId = context.Cities.Where(r => r.Name.Equals
                    ("none")).Select(ra => ra.Id).FirstOrDefault();

                    visitor.CompanyId = context.Companies.Where
                        (co => co.Name.Equals(e_company)).Select(coc => coc.Id).FirstOrDefault();
                    visitor.PositionId = context.Positions.Where
                        (p => p.Name.Equals(e_position)).Select(po => po.Id).FirstOrDefault();
                    visitor.PhoneNumber = data[row, 4];
                    visitor.Email = data[row, 5];
                    visitor.DescriptionId = context.Descriptions.Where
                        (d => d.Name.Equals(e_discription)).Select(dd => dd.Id).FirstOrDefault();
                    visitor.BarCode = data[row, 7];

					visitor.Payment_Status = data[row, 8];
					visitor.Payment_Status_Comment = data[row, 9];
					visitor.Source_Code = data[row, 10];
					visitor.Event_Code = data[row, 11];
					visitor.Event_Name = data[row, 12];

                    visitor.Status = "registered";

                    context.ExhibitionVisitors.Add(visitor);
                    context.SaveChanges();

                }
            }
            status = "get excel data to database";
        }



        public void getForDataToDatabase()
		{
			for (int row = 0; row < excelWorksheetRow; row++)
			{
				using (ExhibitionDataForContext context = new ExhibitionDataForContext())
				{
					var e_company = data[row, 2];
					if (e_company.Length==0|| e_company == " ") e_company = "none";
					if (context.Companies.Where(cc => cc.Name.Equals(e_company)).ToList().Count() == 0)
					{
						context.Companies.Add(new Company(e_company));
					}

					var e_position = data[row, 3];
					if (e_position.Length == 0 || e_position == " ") e_position = "none";
					if (context.Positions.Where(p => p.Name.Equals(e_position)).Count() == 0)
					{
						context.Positions.Add(new Position(e_position));
					}

					var e_discription = data[row, 6];
					if (e_discription.Length == 0 || e_discription == " ") e_discription = "none";
					if (context.Descriptions.Where(d => d.Name.Equals(e_discription)).Count() == 0)
					{
						context.Descriptions.Add(new Description(e_discription, "White"));
					}

					if (context.Cities.Where(c => c.Name.Equals("none")).Count() == 0)
					{
						context.Cities.Add(new City("none"));
					}

					if (context.Exhibits.Where(e => e.Name.Equals("none")).Count() == 0)
					{
						context.Exhibits.Add(new Exhibit("none"));
					}

					if (context.Raports.Where(r => r.Name.Equals("none")).Count() == 0)
					{
						context.Raports.Add(new Raport("none"));
					}

					context.SaveChanges();

					ExhibitionVisitor visitor = new ExhibitionVisitor();
					visitor.LastName = data[row, 0];
					visitor.FirstName = data[row, 1];

					visitor.CityId = context.Cities.Where(ci => ci.Name.Equals
					("none")).Select(c => c.Id).FirstOrDefault();
					visitor.ExhibitId = context.Cities.Where(e => e.Name.Equals
					("none")).Select(ex => ex.Id).FirstOrDefault();
					visitor.RaportId = context.Cities.Where(r => r.Name.Equals
					("none")).Select(ra => ra.Id).FirstOrDefault();

					visitor.CompanyId = context.Companies.Where
						(co => co.Name.Equals(e_company)).Select(coc => coc.Id).FirstOrDefault();
					visitor.PositionId = context.Positions.Where
						(p => p.Name.Equals(e_position)).Select(po => po.Id).FirstOrDefault();
					visitor.PhoneNumber = data[row, 4];
					visitor.Email = data[row, 5];
					visitor.DescriptionId = context.Descriptions.Where
						(d => d.Name.Equals(e_discription)).Select(dd => dd.Id).FirstOrDefault();
					visitor.BarCode = data[row, 7];

					visitor.Payment_Status = data[row, 8];
					visitor.Payment_Status_Comment = data[row, 9];
					visitor.Source_Code = data[row, 10];
					visitor.Event_Code = data[row, 11];
					visitor.Event_Name = data[row, 12];

					visitor.Status = "registered";

					context.ExhibitionVisitors.Add(visitor);
					context.SaveChanges();

				}
			}
			status = "get excel data to database";
		}

		public void saveDataToFile(DataGridView dgv_visitors, ProgressBar pb)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			DialogResult res = sfd.ShowDialog();
			if (res == DialogResult.OK)
			{
				string path = sfd.FileName + ".xlsx";
				Microsoft.Office.Interop.Excel.Application exelapp = new Microsoft.Office.Interop.Excel.Application();
				Microsoft.Office.Interop.Excel.Workbook workbook = exelapp.Workbooks.Add();
				Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;

				pb.Visible = true;
				pb.Maximum = dgv_visitors.RowCount-1;

				worksheet.Rows[1].Columns[1] = "Имя";
				worksheet.Rows[1].Columns[2] = "Фамилия";
				worksheet.Rows[1].Columns[3] = "Отчество";
				worksheet.Rows[1].Columns[4] = "Компания";
				worksheet.Rows[1].Columns[5] = "Должность";
				worksheet.Rows[1].Columns[6] = "Штрихкод";
				worksheet.Rows[1].Columns[7] = "Вы являетесь";
				worksheet.Rows[1].Columns[8] = "Телефон мобильный";
				worksheet.Rows[1].Columns[9] = "Телефон рабочий";
				worksheet.Rows[1].Columns[10] = "E-Mail";
				worksheet.Rows[1].Columns[11] = "Дата";
				worksheet.Rows[1].Columns[12] = "Выставка";
				worksheet.Rows[1].Columns[13] = "Доклад";
				worksheet.Rows[1].Columns[14] = "Город";

				for (int i = 1; i < dgv_visitors.RowCount; i++)
				{
					pb.Value = i;					
					worksheet.Rows[i+1].Columns[1] = dgv_visitors.Rows[i - 1].Cells[1].Value;
					worksheet.Rows[i+1].Columns[2] = dgv_visitors.Rows[i - 1].Cells[2].Value;
					worksheet.Rows[i+1].Columns[3] = dgv_visitors.Rows[i - 1].Cells[3].Value;
					worksheet.Rows[i+1].Columns[4] = dgv_visitors.Rows[i - 1].Cells[4].Value;
					worksheet.Rows[i+1].Columns[5] = dgv_visitors.Rows[i - 1].Cells[5].Value;
					worksheet.Rows[i+1].Columns[6] = dgv_visitors.Rows[i - 1].Cells[6].Value;
					worksheet.Rows[i+1].Columns[7] = dgv_visitors.Rows[i - 1].Cells[7].Value;
					worksheet.Rows[i+1].Columns[8] = dgv_visitors.Rows[i - 1].Cells[8].Value;
					worksheet.Rows[i+1].Columns[9] = dgv_visitors.Rows[i - 1].Cells[9].Value;
					worksheet.Rows[i+1].Columns[10] = dgv_visitors.Rows[i - 1].Cells[10].Value;
					worksheet.Rows[i+1].Columns[11] = dgv_visitors.Rows[i - 1].Cells[11].Value;
					worksheet.Rows[i+1].Columns[12] = dgv_visitors.Rows[i - 1].Cells[12].Value;
					worksheet.Rows[i+1].Columns[13] = dgv_visitors.Rows[i - 1].Cells[13].Value;
					worksheet.Rows[i+1].Columns[14] = dgv_visitors.Rows[i - 1].Cells[14].Value;
				}
				pb.Visible = false;
				exelapp.AlertBeforeOverwriting = false;
				workbook.SaveAs(path);
				exelapp.Quit();
			}
		}

		public void createForDatabase()
		{
			using (ExhibitionDataForContext context = new ExhibitionDataForContext())
			{
				context.Database.Delete();
				context.Companies.Add(new Company("none"));
				context.Positions.Add(new Position("none"));
				context.Descriptions.Add(new Description("none", "none"));
				context.Cities.Add(new City("none"));
				context.Exhibits.Add(new Exhibit("none"));
				context.Raports.Add(new Raport("none"));

				context.SaveChanges();

				ExhibitionVisitor visitor = new ExhibitionVisitor();
				visitor.LastName = "none";
				visitor.FirstName = "none";
				visitor.CompanyId = context.Companies.Where
					(co => co.Name.Equals("none")).Select(coc => coc.Id).FirstOrDefault();
				visitor.PositionId = context.Positions.Where
					(p => p.Name.Equals("none")).Select(po => po.Id).FirstOrDefault();
				visitor.PhoneNumber = "none";
				visitor.Email = "none";
				visitor.DescriptionId = context.Descriptions.Where
					(d => d.Name.Equals("none")).Select(dd => dd.Id).FirstOrDefault();
				visitor.BarCode = "none";

				visitor.CityId = context.Cities.Where
					(ci => ci.Name.Equals("none")).Select(cit => cit.Id).FirstOrDefault();
				visitor.ExhibitId = context.Exhibits.Where
					(e => e.Name.Equals("none")).Select(ex => ex.Id).FirstOrDefault();
				visitor.RaportId = context.Raports.Where(r => r.Name.Equals("none"))
					.Select(ra => ra.Id).FirstOrDefault();

				visitor.Status = "none";

				visitor.Payment_Status = "none";
				visitor.Payment_Status_Comment = "none";
				visitor.Source_Code = "none";
				visitor.Event_Code = "none";
				visitor.Event_Name = "none";

				context.ExhibitionVisitors.Add(visitor);
				context.SaveChanges();
			}
			status = "create database";
		}

	}
}
