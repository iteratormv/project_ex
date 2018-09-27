using Exhibition.Data;
using Exhibition.Data.DataModel;
using Exhibition.Vew;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;

namespace Exhibition.View
{
	public partial class GeneralForm : Form
	{
		string n = "n";
		ExhibitionVisitor select_visitor { get; set; }
		bool isSelectAndPrint = false;
		ExelData data;
		ExhibitionDataForContext context = new ExhibitionDataForContext();
		BindingSource bs = new BindingSource();



		public GeneralForm()
		{
			select_visitor = new ExhibitionVisitor();
			InitializeComponent();
			initialDataGread();
		}

		private void initialDataGread()
		{
			var dgv_collection = context.ExhibitionVisitors.Where(e => e.Status == "fact").ToList();
			bs.DataSource = dgv_collection;
			dgv_fakt_visitor.DataSource = bs;
		}

		private void mi_planed_visitors_Click(object sender, EventArgs e)
		{
			FormPlanedVisitors pvform = new FormPlanedVisitors();
			pvform.ShowDialog();
		}


		private void загрузкаФайлаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog s = new OpenFileDialog();
			if (s.ShowDialog() == DialogResult.Cancel) return;
			string filename = s.FileName;

			data = new ExelData(filename);
			//		Thread labelStatusThread = new Thread(GetStatus(data));
			//		labelStatusThread.IsBackground = true;
			//		labelStatusThread.Start();

			data.createForDatabase();
			data.getForDataToDatabase();

		}


		private void cb_code_TextChanged(object sender, EventArgs e)
		{
			if (cb_code.Text.Length <= 3) cb_code.BackColor = Color.White;
			else if (cb_code.Text.Length > 3)
			{
				var search = cb_code.Text;
				var visitorId = context.ExhibitionVisitors.Where(u => u.LastName.Contains(search)).Select(us => us.Id).FirstOrDefault();
				var visitor = context.ExhibitionVisitors.Where(u => u.Id == visitorId).FirstOrDefault();

				var visitorIds = context.ExhibitionVisitors.Where(u => u.LastName.Contains(search)).Select(us => us).ToList();
				var visitors = context.ExhibitionVisitors.Where(u => u.Id == visitorId).ToList();

				if (visitor != null)
				{
					cb_code.Text = visitor.LastName + " " + visitor.FirstName;
					cb_code.BackColor = Color.LightBlue;
					cb_code.DropDownStyle = ComboBoxStyle.DropDown;

					var collection = context.ExhibitionVisitors
						.Where(u => u.LastName.Contains(search))
						.Select(us => us.LastName + " " + us.FirstName).ToList();
					cb_code.DataSource = collection;
					isSelectAndPrint = true;
				}
			}
		}

		private void cb_code_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && isSelectAndPrint == true)
			{
				isSelectAndPrint = false;
				var current_visitor = cb_code.Text.Split();
				var current_name = current_visitor[1];
				var current_lname = current_visitor[0];
				select_visitor = context.ExhibitionVisitors.Where
				   (v => v.FirstName == current_name && v.LastName == current_lname).FirstOrDefault();
				addVisitorToFact(select_visitor);
				cb_code.Text = "";
				cb_code.BackColor = Color.White;
				initialDataGread();
			}

			if (e.KeyCode == Keys.Down && isSelectAndPrint == true)
			{
				cb_code.DroppedDown = true;
			}
		}

		private void addVisitorToFact(ExhibitionVisitor select_visitor)
		{
			//select_visitor.Status = "fact";
			//bs.Add(select_visitor);
			//context.SaveChanges();
			//printVisitor();
		}

		private void GeneralForm_Load(object sender, EventArgs e)
		{

		}

		private void printVisitor()
		{
			printPreviewDialog1.Document = printDocument1;
			printPreviewDialog1.ShowDialog();
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{

			

			//double width, height;
			//Font font_name, font_company, font_position;
			//int posXlname, posXfname, posYlname, posYfmane, posXcompany, posYcompany, posXposition, posYposition;
			//int numberWlastname, numberWfirstname, numberWcurrentcompany, numberWcurrentposition;
			//bool isOneStringName = true, isOneStringCompany = true, isOneStringPosition = true;

			//const double numberWname = 15;
			//const double numberWcompany = 27, numberWposition = 27;

			//height = e.PageBounds.Height;
			//width = e.PageBounds.Width;

			//font_name = (int)(width / numberWname);
			//font_company = (int)(width / numberWcompany);
			//font_position = (int)(width / numberWposition);

			//posYlname = (int)(height / 8);
			//posYcompany = (int)(height / 3);
			//posYposition = (int)(height / 2);

			//numberWlastname = select_visitor.LastName.Length;
			//numberWfirstname = select_visitor.FirstName.Length;
			//numberWcurrentcompany = select_visitor.Company.ToString().Length;
			//numberWcurrentposition = select_visitor.Position.ToString().Length;





		}

		private List<string> validateStrings(Font font, int width, string inputString)
		{
			List<string> validateStrings = new List<string>();
			string validateString = "";
			int maxNumberLetter = width / font.Height;
			string[] words = inputString.Split(' ');
			for (int i = 0; i < words.Length; i++)
			{
				if (validateString.Length + words[i].Length < maxNumberLetter - 2)
				{
					validateString += words[i];
				}
				else
				{
					validateStrings.Add(validateString);
					validateString = words[i];
				}
			}
			return validateStrings;
		}

		private void displayString(Font font, int width, int posY, string inputString, PrintPageEventArgs e)
		{
			int maxNumberLetter = width / font.Height;
			int posX = (maxNumberLetter - inputString.Length) / 2;
			e.Graphics.DrawString(inputString, font, Brushes.Black, posX, posY);
		}

		private void fontDialog1_Apply(object sender, EventArgs e)
		{

		}

		private void настройкаШаблонаПечатиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TemplateForm templForm = new TemplateForm();
			templForm.ShowDialog();
		}
	}
}
