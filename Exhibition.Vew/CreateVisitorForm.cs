﻿using Exhibition.Data.DataModel;
using Exhibition.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exhibition.Vew
{
	public partial class CreateVisitorForm : Form
	{
		ExhibitionDataForContext context = new ExhibitionDataForContext();
		bool need_print { get; set; }
		GeneralForm create_form;

		public CreateVisitorForm(GeneralForm f)
		{
			InitializeComponent();
			cmb_exhebition.DataSource = context.Exhibits.Where(v => v.Name != "none").Select(s => s).ToList();
			cmb_exhebition.DisplayMember = "Name";
			cmb_exhebition.ValueMember = "Id";
			need_print = false;
			create_form = f;
		}

		private void btn_save_visitor_Click(object sender, EventArgs e)
		{
			if (txb_fname.Text != "" && txb_lname.Text != "" && txb_company.Text != "" && txb_position.Text != "" && txb_email.Text != "")
			{
				ExhibitionVisitor visitor = new ExhibitionVisitor();
				visitor.LastName = txb_lname.Text;
				visitor.FirstName = txb_fname.Text;
				visitor.PhoneNumber = txb_phone_mobile.Text;
				visitor.Email = txb_email.Text;
				visitor.BarCode = getLastBarcode().ToString();
				visitor.Status = "newfact";
				visitor.CityId = getCityId(txb_city.Text);
				visitor.CompanyId = getCompanyId(txb_company.Text);
				visitor.PositionId = getPositionId(txb_position.Text);
				visitor.ExhibitId = getExhibitId(cmb_exhebition.Text);
				visitor.DescriptionId = getDescriptionId(txb_description.Text);
				visitor.RaportId = getRaportId(txb_raport.Text);
				visitor.DateCreated = DateTime.Now;
				if (txb_phone_work.Text != "") { visitor.WorkPhone = txb_phone_work.Text; }
				if (txb_pathronim.Text != "") { visitor.Pathronim = txb_pathronim.Text; }

				lbl_validator.Text = "посетитель "+visitor.LastName + " " + visitor.FirstName + " успешно сохранён в базе";
				lbl_validator.ForeColor = Color.Green;
				this.Refresh();
				need_print = true;
				create_form.addVisitorToFact(visitor, visitor.Status);
				Thread.Sleep(1000);
				this.Close();
			}
			else
			{
				lbl_validator.Text = "* - не все обязательные поля заполнены";
				lbl_validator.ForeColor = Color.Red;
			}
		}

		private int getLastBarcode()
		{
			var barcodes_s = context.ExhibitionVisitors.Select(v =>v.BarCode).ToList();
			List<int> barcodes_snn = new List<int>();
			foreach (string i in barcodes_s)
			{
				if (i != null&& i!="none") barcodes_snn.Add(int.Parse(i));
			}
			var last_barcode = barcodes_snn.Max();
			return (last_barcode + 1);
		}

		private int getCityId(string s)
		{
			if (s == "") { return context.Cities.Where(c => c.Name == "none").Select(x => x.Id).FirstOrDefault(); }
			else {
				var id = context.Cities.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
				if (id != 0) { return id; }
				else {
					City city = new City(s);
					context.Cities.Add(city);
					context.SaveChanges();
					var nid = context.Cities.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
					return nid;
				}
			}
		}

		private int getCompanyId(string s)
		{
			if (s == "") { return context.Companies.Where(c => c.Name == "none").Select(x => x.Id).FirstOrDefault(); }
			else
			{
				var id = context.Companies.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
				if (id != 0) { return id; }
				else
				{
					Company company = new Company(s);
					context.Companies.Add(company);
					context.SaveChanges();
					var nid = context.Companies.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
					return nid;
				}
			}
		}

		private int getPositionId(string s)
		{
			if (s == "") { return context.Positions.Where(c => c.Name == "none").Select(x => x.Id).FirstOrDefault(); }
			else
			{
				var id = context.Positions.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
				if (id != 0) { return id; }
				else
				{
					Position position = new Position(s);
					context.Positions.Add(position);
					context.SaveChanges();
					var nid = context.Positions.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
					return nid;
				}
			}
		}

		private int getDescriptionId(string s)
		{
			if (s == "") { return context.Descriptions.Where(c => c.Name == "none").Select(x => x.Id).FirstOrDefault(); }
			else
			{
				var id = context.Descriptions.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
				if (id != 0) { return id; }
				else
				{
					Description description = new Description(s, "White");
					context.Descriptions.Add(description);
					context.SaveChanges();
					var nid = context.Descriptions.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
					return nid;
				}
			}
		}

		private int getExhibitId(string s)
		{
			if (s == "") { return context.Exhibits.Where(c => c.Name == "none").Select(x => x.Id).FirstOrDefault(); }
			else
			{
				var id = context.Exhibits.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
				if (id != 0) { return id; }
				else
				{
					Exhibit exhibit = new Exhibit(s);
					context.Exhibits.Add(exhibit);
					context.SaveChanges();
					var nid = context.Exhibits.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
					return nid;
				}
			}
		}

		private int getRaportId(string s)
		{
			if (s == "") { return context.Raports.Where(c => c.Name == "none").Select(x => x.Id).FirstOrDefault(); }
			else
			{
				var id = context.Raports.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
				if (id != 0) { return id; }
				else
				{
					Raport raport = new Raport(s);
					context.Raports.Add(raport);
					context.SaveChanges();
					var nid = context.Raports.Where(c => c.Name == s).Select(x => x.Id).FirstOrDefault();
					return nid;
				}
			}
		}
	}
}
