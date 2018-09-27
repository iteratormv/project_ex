using Exhibition.Data;
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
	public partial class FormPlanedVisitors : Form
	{

		ExhibitionDataContext_ context = new ExhibitionDataContext_();
		BindingSource bsExibitionPlanedVisitors = new BindingSource();

		public FormPlanedVisitors()
		{
			InitializeComponent();
			bsExibitionPlanedVisitors.DataSource = context.ExhibitionSVisitors.ToList();
			dgvPlanedVisitors.DataSource = bsExibitionPlanedVisitors;
			//InitDataGridView();
		}

		private void InitDataGridView()
		{
			throw new NotImplementedException();
		}

		private List<ExhibitionSVisitor> GetDatabaseAllCollection()
		{
			var collection = context.ExhibitionSVisitors.ToList();
			return collection;
		}
	}
}
