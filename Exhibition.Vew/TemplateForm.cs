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
		BindingSource bs = new BindingSource();
		string current_setting { get; set; }

		public TemplateForm()
		{
			InitializeComponent();
			if (context.TemplateSettings.Select(c => c).ToList().Count() == 0)
			{
				InitDefaultSetting();
			}
			var collection = context.TemplateSettings.Select(t => t.SettingName).ToList();
			cmb_setting_name.DataSource = collection;
			current_setting = context.TemplateSettings
				.Where(q=>q.isCanDelete == false).Select(d=>d.CyrrentSetting).FirstOrDefault();
		//	current_setting = "default";
		}

		private void TemplateForm_Load(object sender, EventArgs e)
		{
			this.displayInfo(current_setting);
		}

		private void InitDefaultSetting()
		{
			var defaultSetting = new TemplateSetting();

			defaultSetting.isCanDelete = false;
			defaultSetting.isFNvisible = true;
			defaultSetting.isLNvisible = true;
			defaultSetting.isPAvisible = true;
			defaultSetting.isCOvisible = true;
			defaultSetting.isPOvisible = true;
			defaultSetting.FontFN = "Arial 10";
			defaultSetting.FontLN = "Arial 10";
			defaultSetting.FontPA = "Arial 10";
			defaultSetting.FontCO = "Arial 5";
			defaultSetting.FontPO = "Arial 5";
			defaultSetting.SettingName = "default";
			defaultSetting.CyrrentSetting = "default";

			context.TemplateSettings.Add(defaultSetting);
			context.SaveChanges();
		}

		private void SaveSetting(string name)
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
			setting.SettingName = name;

			context.TemplateSettings.Add(setting);
			context.SaveChanges();
			current_setting = name;
		}

		private void displayInfo(string name)
		{
			var setting = context.TemplateSettings.Where(s => s.SettingName == name).FirstOrDefault();
			var allSettings = context.TemplateSettings.Select(s => s.SettingName).ToList();
			cmb_setting_name.DataSource = allSettings;
			cmb_setting_name.Text = setting.SettingName;
			cmb_font_firstname.Text = setting.FontFN;
			cmb_font_lastname.Text = setting.FontLN;
			cmb_font_pathronim.Text = setting.FontPA;
			cmb_font_company.Text = setting.FontCO;
			cmb_font_position.Text = setting.FontPO;
			cb_firstname.Checked = setting.isFNvisible;
			cb_lasname.Checked = setting.isLNvisible;
			cb_patronim.Checked = setting.isPAvisible;
			cb_company.Checked = setting.isCOvisible;
			cb_position.Checked = setting.isPOvisible;
		}

		private void btn_save_setting_Click(object sender, EventArgs e)
		{
			string s_name = cmb_setting_name.Text;
			if (context.TemplateSettings.Where(t => t.SettingName == s_name).Count() == 0)
			{
				this.SaveSetting(s_name);
				MessageBox.Show("Конфигурация " + s_name +  " сохранена");
				cmb_setting_name.DataSource = context.TemplateSettings.Select(t=>t.SettingName).ToList();
     			this.Refresh();
				cmb_setting_name.Text = s_name;
			}
			else MessageBox.Show("Такое имя конфигурации уже существует");
		}

		private void cmb_setting_name_DropDownClosed(object sender, EventArgs e)
		{
			var cs = cmb_setting_name.SelectedValue.ToString();
			displayInfo(cs);
			current_setting = cs;			
		}

		private void btn_del_setting_Click(object sender, EventArgs e)
		{
			var sn = cmb_setting_name.Text;
			var del_setting = context.TemplateSettings.Where(s => s.SettingName == sn).FirstOrDefault();

			if (del_setting.isCanDelete)
			{
				context.TemplateSettings.Remove(del_setting);
				context.SaveChanges();
				MessageBox.Show("Конфигурация " + sn + " удалена");
				setDault();
				cmb_setting_name.DataSource = context.TemplateSettings.Select(t => t.SettingName).ToList();
				this.Refresh();

				//нужно удалить дефолт из базы
				cmb_setting_name.Text = "default";

			}
			else MessageBox.Show("Данная конфигурация не может быть удалена");
		}

		private void btn_set_setting_Click(object sender, EventArgs e)
		{
			current_setting = cmb_setting_name.Text;
			setDault();
		}

		private void setDault()
		{
			var default_setting = context.TemplateSettings.
			Where(t => t.SettingName == "default").FirstOrDefault();
			context.TemplateSettings.Remove(default_setting);
			context.SaveChanges();
			default_setting.CyrrentSetting = "default";
			context.TemplateSettings.Add(default_setting);
			context.SaveChanges();
		}
		}
}
