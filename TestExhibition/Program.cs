using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exhibition.Data;

namespace TestExhibition
{
	class Program
	{
		static void Main(string[] args)
		{
			ExcelData exel_data = new ExcelData();
			for (int row = 0; row < exel_data.excelWorksheetRow; row++)
			{
				for (int col = 0; col < exel_data.excelWorksheetCol; col++)
				{
					Console.Write(exel_data.data[row, col]);
					Console.Write(" ");
				}
				Console.WriteLine();
			}
		}
	}
}
