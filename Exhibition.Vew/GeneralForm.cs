﻿using Exhibition.Data;
using Exhibition.Data.BizLayer;
using Exhibition.Data.DataModel;
using Exhibition.Data.SettingModel;
using Exhibition.Vew;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
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
			List<PharmaVisitor> dgv_collection = null;
			initialDataGread(dgv_collection);
			ss = new SettingStorage();
			templForm = new TemplateForm(ss);
			var count = context.ExhibitionVisitors.Where(v => v.Status != "registered").Select(s => s).Count() - 1;
			lb_count.Text = count.ToString();
			lbl_payment_status.Visible = false;
			
		}

		private void initialDataGread(List<BizVisitor> dgv_collection)
		{
			if (context.ExhibitionVisitors.Select(s => s).Count() != 0) dgv_collection = context.ExhibitionVisitors.Where(e =>
				 (e.Status == "fact" || e.Status == "newfact" || e.Status == "factcorrect" || e.Status == "newfactcorrect")).
				 Select(s => new BizVisitor
				 {
					 vId = s.Id,
					 vLastName = s.LastName,
					 vFirstName = s.FirstName,
					 vPathronim = s.Pathronim,
					 vConpany = s.Company.Name,
					 vPosition = s.Position.Name,
					 vDescription = s.Description.Name,
					 vPhoneMobile = s.PhoneNumber,
					 vPhoneWork = s.WorkPhone,
					 vEmail = s.Email,
					 vRegDate = s.DateCreated.ToString(),
					 vExhibit = s.Exhibit.Name,
					 vRaport = s.Raport.Name,
					 vCity = s.City.Name,
					 vBarcode = s.BarCode

				 }).ToList();
			bs.DataSource = dgv_collection;
			dgv_fakt_visitor.DataSource = bs;
			dgv_fakt_visitor.Columns["vId"].Visible = false;
			dgv_fakt_visitor.Columns["vLastName"].HeaderText = "Фамилия";
			dgv_fakt_visitor.Columns["vLastName"].Width = 120;
			dgv_fakt_visitor.Columns["vFirstName"].HeaderText = "Имя";
			dgv_fakt_visitor.Columns["vFirstName"].Width = 120;
			dgv_fakt_visitor.Columns["vPathronim"].HeaderText = "Отчество";
			dgv_fakt_visitor.Columns["vPathronim"].Width = 120;
			dgv_fakt_visitor.Columns["vConpany"].HeaderText = "Компания";
			dgv_fakt_visitor.Columns["vConpany"].Width = 150;
			dgv_fakt_visitor.Columns["vPosition"].HeaderText = "Должность";
			dgv_fakt_visitor.Columns["vPosition"].Width = 150;
			dgv_fakt_visitor.Columns["vDescription"].HeaderText = "Вы являетесь";
			dgv_fakt_visitor.Columns["vDescription"].Width = 150;
			dgv_fakt_visitor.Columns["vPhoneMobile"].HeaderText = "Телефон мобильный";
			dgv_fakt_visitor.Columns["vPhoneMobile"].Width = 100;
			dgv_fakt_visitor.Columns["vPhoneWork"].HeaderText = "Телефон рабочий";
			dgv_fakt_visitor.Columns["vPhoneWork"].Width = 100;
			dgv_fakt_visitor.Columns["vEmail"].HeaderText = "E-Mail";
			dgv_fakt_visitor.Columns["vEmail"].Width = 150;
			dgv_fakt_visitor.Columns["vRegDate"].HeaderText = "Дата регистрации";
			dgv_fakt_visitor.Columns["vRegDate"].Width = 150;
			dgv_fakt_visitor.Columns["vExhibit"].HeaderText = "Выставка";
			dgv_fakt_visitor.Columns["vExhibit"].Width = 80;
			dgv_fakt_visitor.Columns["vRaport"].HeaderText = "Доклад";
			dgv_fakt_visitor.Columns["vRaport"].Width = 80;
			dgv_fakt_visitor.Columns["vCity"].HeaderText = "Город";
			dgv_fakt_visitor.Columns["vCity"].Width = 80;
		}



		private void initialDataGread(List<PharmaVisitor> dgv_collection)
		{
			if (context.ExhibitionVisitors.Select(s => s).Count() != 0) dgv_collection = context.ExhibitionVisitors.Where(e =>
				 (e.Status == "fact" || e.Status == "newfact" || e.Status == "factcorrect" || e.Status == "newfactcorrect")).
				 Select(s => new PharmaVisitor
				 {
					 pId = s.Id,
					 pSurName = s.LastName,
					 pForName = s.FirstName,
					 pConpany = s.Company.Name,
					 pJobTitle = s.Position.Name,
					 pCustomerNo = s.PhoneNumber,
					 pRowNumber = s.Email,
					 pBarcode = s.BarCode,
					 pDescription = s.Description.Name,
					 pRegDate = s.DateCreated.ToString(),
					 pPaymentStatus = s.Payment_Status,
					 pPaymentComment = s.Payment_Status_Comment,
					 pStatus = s.Status
				 }).ToList();
			bs.DataSource = dgv_collection;
			dgv_fakt_visitor.DataSource = bs;
			dgv_fakt_visitor.Columns["pId"].Visible = false;
			dgv_fakt_visitor.Columns["pSurName"].HeaderText = "SurName";
			dgv_fakt_visitor.Columns["pSurName"].Width = 120;
			dgv_fakt_visitor.Columns["pForName"].HeaderText = "ForName";
			dgv_fakt_visitor.Columns["pForName"].Width = 120;
			dgv_fakt_visitor.Columns["pConpany"].HeaderText = "Conpany";
			dgv_fakt_visitor.Columns["pConpany"].Width = 150;
			dgv_fakt_visitor.Columns["pJobTitle"].HeaderText = "JobTitle";
			dgv_fakt_visitor.Columns["pJobTitle"].Width = 150;
			dgv_fakt_visitor.Columns["pDescription"].HeaderText = "Description";
			dgv_fakt_visitor.Columns["pDescription"].Width = 150;
			dgv_fakt_visitor.Columns["pRowNumber"].HeaderText = "RowNumber";
			dgv_fakt_visitor.Columns["pRowNumber"].Width = 100;
			dgv_fakt_visitor.Columns["pBarcode"].HeaderText = "Barcode";
			dgv_fakt_visitor.Columns["pBarcode"].Width = 100;
			dgv_fakt_visitor.Columns["pCustomerNo"].HeaderText = "CustomerNo";
			dgv_fakt_visitor.Columns["pCustomerNo"].Width = 150;
			dgv_fakt_visitor.Columns["pRegDate"].HeaderText = "RegDate";
			dgv_fakt_visitor.Columns["pRegDate"].Width = 150;
			dgv_fakt_visitor.Columns["pPaymentStatus"].HeaderText = "PaymentStatus";
			dgv_fakt_visitor.Columns["pPaymentStatus"].Width = 80;
			dgv_fakt_visitor.Columns["pPaymentComment"].HeaderText = "PaymentComment";
			dgv_fakt_visitor.Columns["pPaymentComment"].Width = 80;
			dgv_fakt_visitor.Columns["pStatus"].HeaderText = "Status";
			dgv_fakt_visitor.Columns["pStatus"].Width = 80;
		}



		private void mi_planed_visitors_Click(object sender, EventArgs e)
		{
			RaportsForm pvform = new RaportsForm(2);
			pvform.ShowDialog();
		}

		private void загрузкаФайлаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog s = new OpenFileDialog();
			if (s.ShowDialog() == DialogResult.Cancel) return;
			string filename = s.FileName;

			data = new ExelData(filename, this.pb_exel_to_db);


			data.createForDatabase();
  //		data.getForDataToDatabase();
            data.getForDataToDatabase(this.pb_exel_to_db);

            pb_exel_to_db.Visible = false;

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
			
			if (e.KeyCode == Keys.Enter )
			{
				var cs = context.ExhibitionVisitors.Where(vi => vi.BarCode == cb_code.Text).Select(s => s);
				if (cs.Count()>0)
				{
					select_visitor = cs.FirstOrDefault();
					addVisitorToFact(select_visitor, "fact");
				}
			}

			if (e.KeyCode == Keys.Enter && isSelectAndPrint == true)
			{
				
				isSelectAndPrint = false;
				var current_visitor = cb_code.Text.Split();
				var current_name = current_visitor[1];
				var current_lname = current_visitor[0];
				select_visitor = context.ExhibitionVisitors.Where
				   (v => v.FirstName == current_name && v.LastName == current_lname || v.FirstName.Contains(current_name) && v.LastName.Contains(current_lname)).FirstOrDefault();
				if (select_visitor.Status == "registered")
				{
					addVisitorToFact(select_visitor);
	//				cb_code.Text = "";
	//				cb_code.BackColor = Color.White;
	//				initialDataGread();
				}
				else
				{
					СhoiceForm c_form = new СhoiceForm(this, select_visitor);
					c_form.ShowDialog();
				}

				cb_code.Text = "";
				cb_code.BackColor = Color.White;
				List < PharmaVisitor > dgv = null;
				initialDataGread(dgv);
			}

			if (e.KeyCode == Keys.Down && isSelectAndPrint == true)
			{
				cb_code.DroppedDown = true;
			}
		}

		private void addVisitorToFact(ExhibitionVisitor select_visitor)
		{
			select_visitor.Status = "fact";
			select_visitor.DateCreated = DateTime.Now;

			bs.Add(new PharmaVisitor(select_visitor, context));
	//		bs.Add(new BizVisitor(select_visitor, context));
			context.SaveChanges();
			var cl = context.Descriptions.Where(d => d.Id == select_visitor.DescriptionId).Select(s => s.Color).FirstOrDefault();
			var col = Color.FromName(cl);
			var count = context.ExhibitionVisitors.Where(v => v.Status != "registered").Select(s => s).Count() - 1;
			lb_count.Text = count.ToString();
			pb_color.BackColor = col;

			string pcl = "Black";
			if (select_visitor.Payment_Status == "UNPAID") pcl = "Red";
			if (select_visitor.Payment_Status == "PAID") pcl = "Green";
			if (select_visitor.Payment_Status == "FOC") pcl = "Blue";
			var pcol = Color.FromName(pcl);

			lbl_payment_status.ForeColor = pcol;
			lbl_payment_status.Text = select_visitor.Payment_Status;
			lbl_payment_status.Visible = true;
			printVisitor();
		}

		public void addVisitorToFact(ExhibitionVisitor select_visitor, string status)
		{
			this.select_visitor = select_visitor;
			if (context.ExhibitionVisitors.Where(s => s.BarCode == select_visitor.BarCode).Select(v => v).Count() == 0)
			{
				bs.Add(new PharmaVisitor(select_visitor, context));
			//	bs.Add(new BizVisitor(select_visitor, context));
			}
			context.ExhibitionVisitors.AddOrUpdate(select_visitor);
			context.SaveChanges();
			var cl = context.Descriptions.Where(d => d.Id == select_visitor.DescriptionId).Select(s => s.Color).FirstOrDefault();
			var col = Color.FromName(cl);
			var count = context.ExhibitionVisitors.Where(v => v.Status != "registered").Select(s => s).Count() - 1;
			lb_count.Text = count.ToString();
			pb_color.BackColor = col;

			string pcl = "Black";
			if (select_visitor.Payment_Status == "UNPAID") pcl = "Red";
			if (select_visitor.Payment_Status == "PAID") pcl = "Green";
			if (select_visitor.Payment_Status == "FOC") pcl = "Blue";
			var pcol = Color.FromName(pcl);

			lbl_payment_status.ForeColor = pcol;
			lbl_payment_status.Text = select_visitor.Payment_Status;
			lbl_payment_status.Visible = true;
			List<PharmaVisitor> dgv = null;
			initialDataGread(dgv);
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
		}

		public void printVisitor(ExhibitionVisitor visitor)
		{
			select_visitor = visitor;
			printDialog1.Document = printDocument1;
			DialogResult r = printDialog1.ShowDialog();
			if (r == DialogResult.OK) printDocument1.Print();
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
			posYcompany = (int)(height / 14 * 10);
			posYposition = (int)(height / 11 * 10);


            string print_first_name = select_visitor.FirstName;
            string print_last_name = select_visitor.LastName;
            string print_pathronim = select_visitor.Pathronim;
            string print_company = context.Companies.Where(v => v.Id == select_visitor.CompanyId).Select(v => v.Name).FirstOrDefault();
            string print_position = context.Positions.Where(p => p.Id == select_visitor.PositionId).Select(p => p.Name).FirstOrDefault();

            if (ss.lts.Where(s => s.SettingName == current_setting_name).Select(c => c.isFNtoupper).FirstOrDefault()) { print_first_name = print_first_name.ToUpper(); }
            if (ss.lts.Where(s => s.SettingName == current_setting_name).Select(c => c.isLNtoupper).FirstOrDefault()) { print_last_name = print_last_name.ToUpper(); }
            if (ss.lts.Where(s => s.SettingName == current_setting_name).Select(c => c.isPAtoupper).FirstOrDefault()) { print_pathronim = print_pathronim.ToUpper(); }
            if (ss.lts.Where(s => s.SettingName == current_setting_name).Select(c => c.isPOtoupper).FirstOrDefault()) { print_position = print_position.ToUpper(); }
            if (ss.lts.Where(s => s.SettingName == current_setting_name).Select(c => c.isCOtoupper).FirstOrDefault()) { print_company = print_company.ToUpper(); }

            string print_name = "";
			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isLNvisible).FirstOrDefault()) print_name += print_last_name + " ";
			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isFNvisible).FirstOrDefault()) print_name += print_first_name + " ";
			if (ss.lts.Where(s => s.SettingName == current_setting_name)
				.Select(c => c.isPAvisible).FirstOrDefault()) print_name += print_pathronim;

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
			CreatePharmaVisitorForm cv_form = new CreatePharmaVisitorForm(this);
			cv_form.ShowDialog();
			this.Refresh();
		}

		private void dgv_fakt_visitor_DoubleClick(object sender, EventArgs e)
		{
			//			var cur_visitor = bs.Current as BizVisitor;
			var cur_visitor = bs.Current as PharmaVisitor;
			CreatePharmaVisitorForm cv_form = new CreatePharmaVisitorForm(this, cur_visitor);
			cv_form.ShowDialog();
			this.Refresh();
		}

		private void зарегистрированныеПосетилеиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RaportsForm pvform = new RaportsForm(1);
			pvform.ShowDialog();
		}

		private void актуализированныеПосетилелиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RaportsForm pvform = new RaportsForm(2);
			pvform.ShowDialog();
		}

		private void неактуализированниыеПосетителиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RaportsForm pvform = new RaportsForm(4);
			pvform.ShowDialog();
		}

		private void созданныеПосетителиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RaportsForm pvform = new RaportsForm(3);
			pvform.ShowDialog();
		}

		private void GeneralForm_SizeChanged(object sender, EventArgs e)
		{
			dgv_fakt_visitor.Width = this.Width - 60;
			dgv_fakt_visitor.Height = this.Height - 230;
		}

		private void dgv_fakt_visitor_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				var cur_visitor = bs.Current as PharmaVisitor;
				CreatePharmaVisitorForm cv_form = new CreatePharmaVisitorForm(this, cur_visitor);
				cv_form.ShowDialog();
				this.Refresh();
			}

		}
	}
}
