using Exhibition.Data.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exhibition.Vew
{
	public partial class ColorForm : Form
	{
		ExhibitionDataForContext context = new ExhibitionDataForContext();
		BindingSource bs = new BindingSource();


		public ColorForm()
		{
			InitializeComponent();
			var collection = context.Descriptions.Select(d => d).ToList();
			List<Description> ld = new List<Description>();
			foreach (var i in collection)
			{
				if (i.Name != "none")
				{
					ld.Add(i);
				}
			}
			bs.DataSource = ld;
			dgv_colors.DataSource = bs;
			dgv_colors.Columns["Id"].Visible = false;
		//	dgv_colors.Rows[3].Visible = false;
		//	initColor(collection);
		}

		private void initColor(List<Description> collection )
		{

			int count = 0;
			foreach (var i in collection)
			{
				var co = Color.FromName(i.Color);
				this.dgv_colors.Refresh();
				this.dgv_colors.Rows[count].Cells[2].Style.BackColor = co;
				count++;
			}
			this.dgv_colors.Refresh();
		}

			private void dgv_colors_DoubleClick(object sender, EventArgs e)
		{
			var description = bs.Current as Description;
			var r = dgv_colors.CurrentCell.RowIndex;
			var color_dialog = new ColorDialog();
			var f = color_dialog.ShowDialog();
			var color = color_dialog.Color;
			Description nd = description;
			nd.Color = color.Name;
			try
			{
				context.Descriptions.AddOrUpdate(nd);
				context.SaveChanges();
				this.dgv_colors.Refresh();
				this.dgv_colors.Rows[r].Cells[2].Style.BackColor = color;
			}
			catch { }
		}

	}
}
