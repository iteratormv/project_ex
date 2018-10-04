using Exhibition.Data.BizLayer;
using Exhibition.Data.SettingModel;
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
	public partial class TemplateForm : Form
	{
		ExhibitionSettingContext context = new ExhibitionSettingContext();
		SettingStorage tss; 

		public TemplateForm(SettingStorage ss)
		{
			InitializeComponent();
			tss = ss;
		}

		private void TemplateForm_Load(object sender, EventArgs e)
		{
			this.displayInfo(tss.getCSName());
		}

		private TemplateSetting createSetting()
		{
			var setting = new TemplateSetting();

			setting.isCanDelete = true;
			setting.isFNvisible = cb_firstname.Checked;
			setting.isLNvisible = cb_lasname.Checked;
			setting.isPAvisible = cb_patronim.Checked;
			setting.isCOvisible = cb_company.Checked;
			setting.isPOvisible = cb_position.Checked;
			setting.FontFN = cmb_font_firstname.Text;
			setting.FontLN = cmb_font_lastname.Text;
			setting.FontPA = cmb_font_pathronim.Text;
			setting.FontCO = cmb_font_company.Text;
			setting.FontPO = cmb_font_position.Text;
			setting.SettingName = cmb_setting_name.Text;

			return setting;
		}

		private void SaveSetting()
		{
			tss.addSettingToStorage(createSetting());
		}

		private void displayInfo(string currentSettingName)
		{
			var currentSetting = tss.lts.Where(cc => cc.SettingName == currentSettingName).FirstOrDefault();
			var settings = tss.lts;

			cmb_setting_name.DataSource = settings.Select(s=>s.SettingName).ToList();
			cmb_setting_name.Text = currentSettingName;
			cmb_font_firstname.Text = currentSetting.FontFN;
			cmb_font_lastname.Text = currentSetting.FontLN;
			cmb_font_pathronim.Text = currentSetting.FontPA;
			cmb_font_company.Text = currentSetting.FontCO;
			cmb_font_position.Text = currentSetting.FontPO;
			cb_firstname.Checked = currentSetting.isFNvisible;
			cb_lasname.Checked = currentSetting.isLNvisible;
			cb_patronim.Checked = currentSetting.isPAvisible;
			cb_company.Checked = currentSetting.isCOvisible;
			cb_position.Checked = currentSetting.isPOvisible;
		}

		private void btn_save_setting_Click(object sender, EventArgs e)
		{
			string s_name = cmb_setting_name.Text;

			if (tss.lts.Where(s=>s.SettingName == s_name).Count() == 0)
			{
				this.SaveSetting();
				MessageBox.Show("Конфигурация " + s_name +  " сохранена");
				cmb_setting_name.DataSource = tss.lts.Select(s => s.SettingName).ToList();
				this.Refresh();
				cmb_setting_name.Text = s_name;
			}
			else MessageBox.Show("Такое имя конфигурации уже существует");;
		}

		private void btn_del_setting_Click(object sender, EventArgs e)
		{
			var sn = cmb_setting_name.Text;
			var del_setting = tss.lts.Where(s=>s.SettingName == sn).FirstOrDefault();

			if (del_setting.isCanDelete)
			{
				tss.delSettingFromStorage(del_setting);
				MessageBox.Show("Конфигурация " + sn + " удалена");
				cmb_setting_name.DataSource = tss.lts.Select(s=>s.SettingName).ToList();
				this.Refresh();
				cmb_setting_name.Text = "default";
				tss.setCS("default");
			}
			else MessageBox.Show("Данная конфигурация не может быть удалена");
		}

		private void btn_set_setting_Click(object sender, EventArgs e)
		{
			var ss = cmb_setting_name.Text;
			tss.setCS(ss);
		}

		private void cmb_setting_name_DropDownClosed(object sender, EventArgs e)
		{
			var cs = cmb_setting_name.SelectedValue.ToString();
			displayInfo(cs);
		}

		private void cmb_font_firstname_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			var result = fd.ShowDialog();
			if (result == DialogResult.OK)
			{
				cmb_font_firstname.Text = fd.Font.Name + " " + fd.Font.Size + " " + fd.Font.Style;
			}
		}

		private void cmb_font_lastname_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			var result = fd.ShowDialog();
			if (result == DialogResult.OK)
			{
				cmb_font_lastname.Text = fd.Font.Name + " " + fd.Font.Size + " " + fd.Font.Style;
			}
		}

		private void cmb_font_pathronim_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			var result = fd.ShowDialog();
			if (result == DialogResult.OK)
			{
				cmb_font_pathronim.Text = fd.Font.Name + " " + fd.Font.Size + " " + fd.Font.Style;
			}
		}

		private void cmb_font_company_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			var result = fd.ShowDialog();
			if (result == DialogResult.OK)
			{
				cmb_font_company.Text = fd.Font.Name + " " + fd.Font.Size + " " + fd.Font.Style;
			}
		}

		private void cmb_font_position_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();
			var result = fd.ShowDialog();
			if (result == DialogResult.OK)
			{
				cmb_font_position.Text = fd.Font.Name + " " + fd.Font.Size + " " + fd.Font.Style;
			}
		}
	}
}
