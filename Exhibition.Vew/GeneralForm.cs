using Exhibition.Data;
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
			if(context.ExhibitionVisitors.Select(s=>s).Count()!=0) dgv_collection = context.ExhibitionVisitors.Where(e => e.Status == "fact").ToList();
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
			double width, height;
			string[] font_fnames, font_lnames, font_patronims, font_companys, font_positions;
			string current_setting_name = sett_context.CurrentSettings.FirstOrDefault().CSName;
			int posYlname, posYcompany, posYposition;//, posYfmane, posYpathronim;


			height = e.PageBounds.Height;
			width = e.PageBounds.Width;

			font_fnames = sett_context.TemplateSettings.
				Where(f=>f.SettingName == current_setting_name).
				Select(s=>s.FontFN).FirstOrDefault().ToString().Split(' ');
			font_lnames = sett_context.TemplateSettings.
				Where(f => f.SettingName == current_setting_name).
				Select(s => s.FontLN).FirstOrDefault().Split(' ');
			font_patronims = sett_context.TemplateSettings.
				Where(f => f.SettingName == current_setting_name).
				Select(s => s.FontPA).FirstOrDefault().Split(' ');
			font_companys = sett_context.TemplateSettings.
				Where(f => f.SettingName == current_setting_name).
				Select(s => s.FontCO).FirstOrDefault().Split(' ');
			font_positions = sett_context.TemplateSettings.
				Where(f => f.SettingName == current_setting_name).
				Select(s => s.FontPO).FirstOrDefault().Split(' ');

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
				FontFamily nff = new FontFamily(font_fnames[0]);
				FontStyle nfs = (FontStyle)int.Parse("2");
				Font nfont = new Font(nff, float.Parse(font_fnames[1]), nfs);
				var list_name = validateStrings(nfont, (int)width, print_name);
				for (int i = 0; i < list_name.Count(); i++)
				{
					displayString(nfont, (int)width, posYlname + i * (int)float.Parse(font_fnames[1]) * 15 / 10, list_name[i], e);
				}
			}

			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isCOvisible).FirstOrDefault())
			{
				if (select_visitor.CompanyId!=1)
				{
					string print_company = context.Companies.Where(v=>v.Id == select_visitor.CompanyId).Select(v=>v.Name).FirstOrDefault();
					string[] print_companys = print_company.Split(' ');
					FontFamily cff = new FontFamily(font_companys[0]);
					FontStyle сfs = (FontStyle)int.Parse("2");
					Font сfont = new Font(cff, float.Parse(font_companys[1]), сfs);
					var list_company = validateStrings(сfont, (int)width, print_company);
					for (int i = 0; i < list_company.Count(); i++)
					{
						displayString(сfont, (int)width, posYcompany + i * (int)float.Parse(font_companys[1]) * 15 / 10, list_company[i], e);
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
					FontFamily pff = new FontFamily(font_positions[0]);
					FontStyle pfs = (FontStyle)int.Parse("2");
					Font pfont = new Font(pff, float.Parse(font_positions[1]), pfs);
					var list_position = validateStrings(pfont, (int)width, print_position);
					for (int i = 0; i < list_position.Count(); i++)
					{
						displayString(pfont, (int)width, posYposition + i * (int)float.Parse(font_positions[1]) * 15 / 10, list_position[i], e);
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

		//private void cb_code_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	var search = cb_code.Text;
		//	var se = search.Split(' ');
		//	string sea = se[0];
		//	var visitorId = context.ExhibitionVisitors.Where(u => u.LastName.Contains(sea)).Select(us => us.Id).FirstOrDefault();
		//	var visitor = context.ExhibitionVisitors.Where(u => u.Id == visitorId).FirstOrDefault();

		//	if (visitor != null)
		//	{
		//		var cl = context.Descriptions.Where(d => d.Id == visitor.DescriptionId).Select(s => s.Color).FirstOrDefault();
		//		var col = Color.FromName(cl);
		//		pb_color.BackColor = col;
		//		cb_code.Text = visitor.LastName + " " + visitor.FirstName;
		//	}

		//private void cb_code_DropDownClosed(object sender, EventArgs e)
		//{
		//	var search = cb_code.Text;
		//	var se = search.Split(' ');
		//	string sea = se[0];
		//	var visitorId = context.ExhibitionVisitors.Where(u => u.LastName.Contains(sea)).Select(us => us.Id).FirstOrDefault();
		//	var visitor = context.ExhibitionVisitors.Where(u => u.Id == visitorId).FirstOrDefault();

		//	if (visitor != null)
		//	{
		//		var cl = context.Descriptions.Where(d => d.Id == visitor.DescriptionId).Select(s => s.Color).FirstOrDefault();
		//		var col = Color.FromName(cl);
		//		pb_color.BackColor = col;
		//		cb_code.Text = visitor.LastName + " " + visitor.FirstName;
		//		//cb_code.BackColor = Color.LightBlue;
		//		//cb_code.DropDownStyle = ComboBoxStyle.DropDown;

		//		//var collection = context.ExhibitionVisitors
		//		//	.Where(u => u.LastName.Contains(search))
		//		//	.Select(us => us.LastName + " " + us.FirstName).ToList();
		//		//cb_code.DataSource = collection;
		//		//isSelectAndPrint = true;
		//	}
	//	}
	}
}
