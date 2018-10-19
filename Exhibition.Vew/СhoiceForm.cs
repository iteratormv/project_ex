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

		public СhoiceForm()
		{
			InitializeComponent();
		}

		public СhoiceForm(GeneralForm form, ExhibitionVisitor visitor)
		{
			InitializeComponent();
			g_form = form;
			this.visitor = visitor;
		}

		private void btn_edit_Click(object sender, EventArgs e)
		{
			CreateVisitorForm cv_form = new CreateVisitorForm(g_form, visitor);
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
