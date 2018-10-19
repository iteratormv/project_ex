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

			List<ExhibitionVisitor> visitor_collection = null;
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
							vCity = s.City.Name
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
							vCity = s.City.Name
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
							vCity = s.City.Name
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
							vCity = s.City.Name
						}).ToList();
					break;
			}
			bsVisitors.DataSource = view_visitor_collection;
			dgv_vasitors.DataSource = bsVisitors;

			dgv_vasitors.Columns["vId"].Visible = false;
			dgv_vasitors.Columns["vLastName"].HeaderText = "Фамилия";
			dgv_vasitors.Columns["vLastName"].Width = 120;
			dgv_vasitors.Columns["vFirstName"].HeaderText = "Имя";
			dgv_vasitors.Columns["vFirstName"].Width = 120;
			dgv_vasitors.Columns["vPathronim"].HeaderText = "Отчество";
			dgv_vasitors.Columns["vPathronim"].Width = 120;
			dgv_vasitors.Columns["vConpany"].HeaderText = "Компания";
			dgv_vasitors.Columns["vConpany"].Width = 150;
			dgv_vasitors.Columns["vPosition"].HeaderText = "Должность";
			dgv_vasitors.Columns["vPosition"].Width = 150;
			dgv_vasitors.Columns["vDescription"].HeaderText = "Вы являетесь";
			dgv_vasitors.Columns["vDescription"].Width = 150;
			dgv_vasitors.Columns["vPhoneMobile"].HeaderText = "Телефон мобильный";
			dgv_vasitors.Columns["vPhoneMobile"].Width = 100;
			dgv_vasitors.Columns["vPhoneWork"].HeaderText = "Телефон рабочий";
			dgv_vasitors.Columns["vPhoneWork"].Width = 100;
			dgv_vasitors.Columns["vEmail"].HeaderText = "E-Mail";
			dgv_vasitors.Columns["vEmail"].Width = 150;
			dgv_vasitors.Columns["vRegDate"].HeaderText = "Дата регистрации";
			dgv_vasitors.Columns["vRegDate"].Width = 150;
			dgv_vasitors.Columns["vExhibit"].HeaderText = "Выставка";
			dgv_vasitors.Columns["vExhibit"].Width = 80;
			dgv_vasitors.Columns["vRaport"].HeaderText = "Доклад";
			dgv_vasitors.Columns["vRaport"].Width = 80;
			dgv_vasitors.Columns["vCity"].HeaderText = "Город";
			dgv_vasitors.Columns["vCity"].Width = 80;

			lbl_count.Text = view_visitor_collection.Count().ToString();
		}

		private List<ExhibitionVisitor> GetDatabaseAllCollection()
		{
			var collection = context.ExhibitionVisitors.ToList();
			return collection;
		}

		private void RaportsForm_SizeChanged(object sender, EventArgs e)
		{
			dgv_vasitors.Width = this.Width - 50;
			dgv_vasitors.Height = this.Height - 150;
		}

		private void cb_description_TextChanged(object sender, EventArgs e)
		{
			if (mode != 0)
			{
				List<ExhibitionVisitor> visitor_collection = null;
				List<ExhibitionVisitor> visitor_current_collection = null;
				switch (mode)
				{
					case 1:
						visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "registered" || v.Status == "fact" || v.Status == "factcorrect").Select(s => s).ToList();
						break;
					case 2:
						visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "fact" || v.Status == "factcorrect").Select(s => s).ToList();
						break;
					case 3:
						visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "newfact" || v.Status == "newfactcorrect").Select(s => s).ToList();
						break;
					case 4:
						visitor_collection = context.ExhibitionVisitors.Where
							(v => v.Status == "registered").Select(s => s).ToList();
						break;
				}
				var desription_id = context.Descriptions.Where(d => d.Name == cb_description.Text).Select(s => s.Id).FirstOrDefault();
				visitor_current_collection = visitor_collection.Where
					(d => d.DescriptionId == desription_id).Select(s => s).ToList();
				bsVisitors.DataSource = visitor_current_collection;
				dgv_vasitors.DataSource = bsVisitors;
				lbl_count.Text = visitor_current_collection.Count().ToString();
			}
		}

		private void btn_export_Click(object sender, EventArgs e)
		{
			ExelData data = new ExelData();
			data.saveDataToFile(this.dgv_vasitors, this.progressBar1);
		}
	}
}
