﻿using Exhibition.Data;
using Exhibition.Data.BizLayer;
using Exhibition.Data.DataModel;
using Exhibition.Data.SettingModel;
using Exhibition.Vew;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Exhibition.View
{
	public partial class GeneralForm : Form
	{
		ExhibitionVisitor select_visitor { get; set; }
		bool isSelectAndPrint = false;
		ExelData data;
		ExhibitionDataForContext context = new ExhibitionDataForContext();
		ExhibitionSettingContext sett_context = new ExhibitionSettingContext();
		BindingSource bs = new BindingSource();
		SettingStorage ss { get; set; }
		TemplateForm templForm;

		public GeneralForm()
		{
			select_visitor = new ExhibitionVisitor();
			InitializeComponent();
			initialDataGread();
			ss = new SettingStorage();
			templForm = new TemplateForm(ss);
		}

		private void initialDataGread()
		{
			List<ExhibitionVisitor> dgv_collection = null;
			if(context.ExhibitionVisitors.Select(s=>s).Count()!=0) dgv_collection = context.ExhibitionVisitors.Where(e => (e.Status == "fact"||e.Status == "newfact")).ToList();
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
		            var cl = context.Descriptions.Where(d => d.Id == visitor.DescriptionId).Select(s => s.Color).FirstOrDefault();
					var col = Color.FromName(cl);
					pb_color.BackColor = col;
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
			select_visitor.Status = "fact";
			bs.Add(select_visitor);
			context.SaveChanges();
			printVisitor();
		}

		public void addVisitorToFact(ExhibitionVisitor select_visitor, string status)
		{
			this.select_visitor = select_visitor;
			bs.Add(select_visitor);
			context.ExhibitionVisitors.Add(select_visitor);
			context.SaveChanges();
			printVisitor();
		}


		private void GeneralForm_Load(object sender, EventArgs e)
		{

		}

		private void printVisitor()
		{
			printDialog1.Document = printDocument1;
			DialogResult r =  printDialog1.ShowDialog();
			if (r == DialogResult.OK) printDocument1.Print();


		//	printPreviewDialog1.Document = printDocument1;
		//	printPreviewDialog1.ShowDialog();
		}

		private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
		{
			double width, height;
			string current_setting_name = sett_context.CurrentSettings.FirstOrDefault().CSName;
			int posYlname, posYcompany, posYposition;

			height = e.PageBounds.Height;
			width = e.PageBounds.Width;

			var settings = sett_context.TemplateSettings.
				Where(f => f.SettingName == current_setting_name).
				Select(s => s).FirstOrDefault();

			posYlname = (int)(height / 10);
			posYcompany = (int)(height / 22 * 10);
			posYposition = (int)(height / 14 * 10);

			string print_name = "";
			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isLNvisible).FirstOrDefault()) print_name += select_visitor.LastName + " ";
			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isFNvisible).FirstOrDefault()) print_name += select_visitor.FirstName + " ";
			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isPAvisible).FirstOrDefault()) print_name += select_visitor.Pathronim;

			if (print_name != "")
			{
				string[] print_names = print_name.Split(' ');

				FontFamily nff = new FontFamily(settings.FontNameNA);
				FontStyle nfs = (FontStyle)settings.FontStyleNA;
				float nfz = settings.FontSizeNA;
				Font nfont = new Font(nff, nfz, nfs);
				var list_name = validateStrings(nfont, (int)width, print_name);
				for (int i = 0; i < list_name.Count(); i++)
				{
					displayString(nfont, (int)width, posYlname + i * (int)nfz * 15 / 10, list_name[i], e);
				}
			}

			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isCOvisible).FirstOrDefault())
			{
				if (select_visitor.CompanyId!=1)
				{
					string print_company = context.Companies.Where(v=>v.Id == select_visitor.CompanyId).Select(v=>v.Name).FirstOrDefault();
					string[] print_companys = print_company.Split(' ');
					FontFamily cff = new FontFamily(settings.FontNameCO);
					FontStyle сfs = (FontStyle)settings.FontStyleCO;
					float cfz = settings.FontSizeCO;
					Font сfont = new Font(cff, cfz, сfs);
					var list_company = validateStrings(сfont, (int)width, print_company);
					for (int i = 0; i < list_company.Count(); i++)
					{
						displayString(сfont, (int)width, posYcompany + i * (int)cfz * 15 / 10, list_company[i], e);
					}
				}
			}

			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isPOvisible).FirstOrDefault())
			{
				if (select_visitor.PositionId != 1)
				{
					string print_position = context.Positions.Where(p=>p.Id == select_visitor.PositionId).Select(p=>p.Name).FirstOrDefault();
					string[] print_positions = print_position.Split(' ');
					FontFamily pff = new FontFamily(settings.FontNamePO);
					FontStyle pfs = (FontStyle)settings.FontStylePO;
					float pfz = settings.FontSizePO;
					Font pfont = new Font(pff, pfz, pfs);
					var list_position = validateStrings(pfont, (int)width, print_position);
					for (int i = 0; i < list_position.Count(); i++)
					{
						displayString(pfont, (int)width, posYposition + i * (int)pfz * 15 / 10, list_position[i], e);
					}
				}
			}
		}

		private List<string> validateStrings(Font font, int width, string inputString)
		{
			List<string> valStrings = new List<string>();
			string validateString = "";
			int maxNumberLetter =(int)( width / font.Size * 1.2);
			string[] words = inputString.Split(' ');
			for (int i = 0; i < words.Length; i++)
			{
				if (validateString.Length + words[i].Length < maxNumberLetter - 2)
				{
					validateString += (" " + words[i]);
				}
				else
				{
					valStrings.Add(validateString);
					validateString = words[i];
				}
			}
			valStrings.Add(validateString);
			return valStrings;
		}

		private void displayString(Font font, int width, int posY, string inputString, PrintPageEventArgs e)
		{
			string s = inputString.Trim();
			int maxNumberLetter =(int)(width / font.Size * 1.2);
			int posX = (int)(font.Size/1.2*(maxNumberLetter - s.Length) / 2);
			e.Graphics.DrawString(s, font, Brushes.Black, posX, posY);
		}

		private void fontDialog1_Apply(object sender, EventArgs e)
		{

		}

		private void настройкаШаблонаПечатиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TemplateForm templForm = new TemplateForm(ss);
			templForm.ShowDialog();
		}

		private void настройкаЦветаБейджаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorForm cf = new ColorForm();
			cf.ShowDialog();
		}

		private void btn_create_visitior_Click(object sender, EventArgs e)
		{
			CreateVisitorForm cv_form = new CreateVisitorForm(this);
			cv_form.ShowDialog();
		}

		private void dgv_fakt_visitor_DoubleClick(object sender, EventArgs e)
		{

		}
	}
}
