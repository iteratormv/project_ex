using Exhibition.Data.BizLayer;
using Exhibition.Data.DataModel;
using Exhibition.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exhibition.Vew
{
	public partial class СhoiceForm : Form
	{

		GeneralForm g_form { get; set; }
		ExhibitionVisitor visitor { get; set; }
		BizVisitor biz_visitor { get; set; }
		ExhibitionDataForContext context = new ExhibitionDataForContext();

		public СhoiceForm()
		{
			InitializeComponent();
		}

		public СhoiceForm(GeneralForm form, BizVisitor visitor)
		{
			InitializeComponent();
			g_form = form;
			this.visitor = context.ExhibitionVisitors.Where(v => v.BarCode == visitor.vBarcode).Select(s => s).FirstOrDefault();
			this.biz_visitor = visitor;
		}


		public СhoiceForm(GeneralForm form, ExhibitionVisitor visitor)
		{
			InitializeComponent();
			g_form = form;
			this.visitor = visitor;
			this.biz_visitor = new BizVisitor();
			biz_visitor.vId = visitor.Id;
			biz_visitor.vLastName = visitor.LastName;
			biz_visitor.vFirstName = visitor.FirstName;
			biz_visitor.vPathronim = visitor.Pathronim;
			biz_visitor.vConpany = context.Companies.Where(c => c.Id == visitor.CompanyId).Select(s => s.Name).FirstOrDefault();
			biz_visitor.vPosition = context.Positions.Where(p => p.Id == visitor.PositionId).Select(s => s.Name).FirstOrDefault();
			biz_visitor.vDescription = context.Descriptions.Where(d => d.Id == visitor.DescriptionId).Select(s => s.Name).FirstOrDefault();
			biz_visitor.vPhoneMobile = visitor.PhoneNumber;
			biz_visitor.vPhoneWork = visitor.WorkPhone;
			biz_visitor.vEmail = visitor.Email;
			biz_visitor.vRegDate = visitor.DateCreated.ToString();
			biz_visitor.vExhibit = context.Exhibits.Where(e => e.Id == visitor.ExhibitId).Select(s => s.Name).FirstOrDefault();
			biz_visitor.vRaport = context.Raports.Where(r => r.Id == visitor.RaportId).Select(s => s.Name).FirstOrDefault();
			biz_visitor.vCity = context.Cities.Where(c=>c.Id == visitor.CityId).Select(s=>s.Name).FirstOrDefault();
			biz_visitor.vStatus = visitor.Status;
			biz_visitor.vBarcode = visitor.BarCode;
		}


		private void btn_edit_Click(object sender, EventArgs e)
		{
			CreateVisitorForm cv_form = new CreateVisitorForm(g_form, biz_visitor);
			cv_form.ShowDialog();
			g_form.Refresh();
			g_form.cb_code.Text = "";
			g_form.cb_code.BackColor = Color.White;
			this.Close();
		}

		private void btn_print_Click(object sender, EventArgs e)
		{
			g_form.printVisitor(visitor);
			this.Close();

		}

		private void btn_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
