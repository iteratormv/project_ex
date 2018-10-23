using Exhibition.Data;
using Exhibition.Data.BizLayer;
using Exhibition.Data.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exhibition.View
{
	public partial class RaportsForm : Form
	{

		ExhibitionDataForContext context = new ExhibitionDataForContext();
		BindingSource bsVisitors = new BindingSource();
		BindingSource bsDescriptions = new BindingSource();
		int mode { get; set; }

		public RaportsForm(int m)
		{
			InitializeComponent();
			progressBar1.Visible = false;
			var description_collection = context.Descriptions.Select(s => s).ToList();
			description_collection.Add(new Description("Все","White"));

			bsDescriptions.DataSource = description_collection;
			cb_description.DataSource = bsDescriptions;
			cb_description.ValueMember = "Id";
			cb_description.DisplayMember = "Name";
			cb_description.Text = "Все";
			mode = m;

//			List<ExhibitionVisitor> visitor_collection = null;
			List<BizVisitor> view_visitor_collection = null;
			switch(mode){
				case 1:
					view_visitor_collection = context.ExhibitionVisitors.Where
						(v => v.Status=="registered" || v.Status == "fact" || v.Status == "factcorrect").Select(s => new BizVisitor
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
							vStatus = s.Status,
							vBarcode = s.BarCode
						}).ToList();
					break;
				case 2:
					view_visitor_collection = context.ExhibitionVisitors.Where
						(v => v.Status == "fact" || v.Status == "factcorrect").Select(s => new BizVisitor
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
							vStatus = s.Status,
							vBarcode = s.BarCode
						}).ToList();
					break;
				case 3:
					view_visitor_collection = context.ExhibitionVisitors.Where
						(v => v.Status == "newfact" || v.Status == "newfactcorrect").Select(s => new BizVisitor
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
							vStatus = s.Status,
							vBarcode = s.BarCode
						}).ToList();
					break;
				case 4:
					view_visitor_collection = context.ExhibitionVisitors.Where
						(v => v.Status == "registered").Select(s => new BizVisitor
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
							vStatus = s.Status,
							vBarcode = s.BarCode
						}).ToList();
					break;
			}
			bsVisitors.DataSource = view_visitor_collection;
			dgv_visitors.DataSource = bsVisitors;

			dgv_visitors.Columns["vId"].Visible = false;
			dgv_visitors.Columns["vLastName"].HeaderText = "Фамилия";
			dgv_visitors.Columns["vLastName"].Width = 120;
			dgv_visitors.Columns["vFirstName"].HeaderText = "Имя";
			dgv_visitors.Columns["vFirstName"].Width = 120;
			dgv_visitors.Columns["vPathronim"].HeaderText = "Отчество";
			dgv_visitors.Columns["vPathronim"].Width = 120;
			dgv_visitors.Columns["vConpany"].HeaderText = "Компания";
			dgv_visitors.Columns["vConpany"].Width = 150;
			dgv_visitors.Columns["vPosition"].HeaderText = "Должность";
			dgv_visitors.Columns["vPosition"].Width = 150;
			dgv_visitors.Columns["vDescription"].HeaderText = "Вы являетесь";
			dgv_visitors.Columns["vDescription"].Width = 150;
			dgv_visitors.Columns["vPhoneMobile"].HeaderText = "Телефон мобильный";
			dgv_visitors.Columns["vPhoneMobile"].Width = 100;
			dgv_visitors.Columns["vBarCode"].HeaderText = "Штрих код";
			dgv_visitors.Columns["vBarCode"].Width = 100;
			dgv_visitors.Columns["vPhoneWork"].HeaderText = "Телефон рабочий";
			dgv_visitors.Columns["vPhoneWork"].Width = 100;
			dgv_visitors.Columns["vEmail"].HeaderText = "E-Mail";
			dgv_visitors.Columns["vEmail"].Width = 150;
			dgv_visitors.Columns["vRegDate"].HeaderText = "Дата регистрации";
			dgv_visitors.Columns["vRegDate"].Width = 150;
			dgv_visitors.Columns["vExhibit"].HeaderText = "Выставка";
			dgv_visitors.Columns["vExhibit"].Width = 80;
			dgv_visitors.Columns["vRaport"].HeaderText = "Доклад";
			dgv_visitors.Columns["vRaport"].Width = 80;
			dgv_visitors.Columns["vCity"].HeaderText = "Город";
			dgv_visitors.Columns["vCity"].Width = 80;
			dgv_visitors.Columns["vStatus"].Visible = false;

			lbl_count.Text = view_visitor_collection.Count().ToString();
		}

		private List<ExhibitionVisitor> GetDatabaseAllCollection()
		{
			var collection = context.ExhibitionVisitors.ToList();
			return collection;
		}

		private void RaportsForm_SizeChanged(object sender, EventArgs e)
		{
			dgv_visitors.Width = this.Width - 50;
			dgv_visitors.Height = this.Height - 150;
		}

		private void cb_description_TextChanged(object sender, EventArgs e)
		{
			if (mode != 0)
			{
				List<ExhibitionVisitor> visitor_collection = new List<ExhibitionVisitor>();
				List<ExhibitionVisitor> visitor_current_collection = null;
				List<BizVisitor> view_visitor_collection = null;

				var desription_id = context.Descriptions.Where(d => d.Name == cb_description.Text).Select(s => s.Id).FirstOrDefault();

				switch (mode)
				{
					case 1:
						view_visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "registered" || v.Status == "fact" || v.Status == "factcorrect")
							.Where
					(d => d.DescriptionId == desription_id).Select(s => new BizVisitor
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
						vStatus = s.Status,
						vBarcode = s.BarCode
					}).ToList();
						break;
					case 2:
						view_visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "fact" || v.Status == "factcorrect")
							.Where
					(d => d.DescriptionId == desription_id).Select(s => new BizVisitor
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
						vStatus = s.Status,
						vBarcode = s.BarCode
					}).ToList();
						break;
					case 3:
						view_visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "newfact" || v.Status == "newfactcorrect")
							.Where
					(d => d.DescriptionId == desription_id).Select(s => new BizVisitor
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
						vStatus = s.Status,
						vBarcode = s.BarCode
					}).ToList();
						break;
					case 4:
						view_visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "registered")
							.Where
					(d => d.DescriptionId == desription_id).Select(s => new BizVisitor
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
						vStatus = s.Status,
						vBarcode = s.BarCode
					}).ToList();
						break;
				}

				bsVisitors.DataSource = view_visitor_collection;
				dgv_visitors.DataSource = bsVisitors;
				lbl_count.Text = view_visitor_collection.Count().ToString();
			}
		}

		private void btn_export_Click(object sender, EventArgs e)
		{
			ExelData data = new ExelData();
			data.saveDataToFile(this.dgv_visitors, this.progressBar1);
		}
	}
}
