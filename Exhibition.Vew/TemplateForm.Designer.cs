namespace Exhibition.Vew
{
	partial class TemplateForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_save_setting = new System.Windows.Forms.Button();
			this.cb_firstname = new System.Windows.Forms.CheckBox();
			this.cmb_font_firstname = new System.Windows.Forms.ComboBox();
			this.cmb_setting_name = new System.Windows.Forms.ComboBox();
			this.cmb_font_lastname = new System.Windows.Forms.ComboBox();
			this.cb_lasname = new System.Windows.Forms.CheckBox();
			this.cmb_font_pathronim = new System.Windows.Forms.ComboBox();
			this.cb_patronim = new System.Windows.Forms.CheckBox();
			this.cmb_font_company = new System.Windows.Forms.ComboBox();
			this.cb_company = new System.Windows.Forms.CheckBox();
			this.cmb_font_position = new System.Windows.Forms.ComboBox();
			this.cb_position = new System.Windows.Forms.CheckBox();
			this.btn_del_setting = new System.Windows.Forms.Button();
			this.btn_set_setting = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_save_setting
			// 
			this.btn_save_setting.Location = new System.Drawing.Point(46, 266);
			this.btn_save_setting.Name = "btn_save_setting";
			this.btn_save_setting.Size = new System.Drawing.Size(380, 23);
			this.btn_save_setting.TabIndex = 0;
			this.btn_save_setting.Text = "сохранить конфигурацию";
			this.btn_save_setting.UseVisualStyleBackColor = true;
			this.btn_save_setting.Click += new System.EventHandler(this.btn_save_setting_Click);
			// 
			// cb_firstname
			// 
			this.cb_firstname.AutoSize = true;
			this.cb_firstname.Location = new System.Drawing.Point(46, 73);
			this.cb_firstname.Name = "cb_firstname";
			this.cb_firstname.Size = new System.Drawing.Size(48, 17);
			this.cb_firstname.TabIndex = 1;
			this.cb_firstname.Text = "Имя";
			this.cb_firstname.UseVisualStyleBackColor = true;
			// 
			// cmb_font_firstname
			// 
			this.cmb_font_firstname.FormattingEnabled = true;
			this.cmb_font_firstname.Location = new System.Drawing.Point(190, 69);
			this.cmb_font_firstname.Name = "cmb_font_firstname";
			this.cmb_font_firstname.Size = new System.Drawing.Size(236, 21);
			this.cmb_font_firstname.TabIndex = 3;
			this.cmb_font_firstname.Click += new System.EventHandler(this.cmb_font_firstname_Click);
			// 
			// cmb_setting_name
			// 
			this.cmb_setting_name.FormattingEnabled = true;
			this.cmb_setting_name.Location = new System.Drawing.Point(46, 27);
			this.cmb_setting_name.Name = "cmb_setting_name";
			this.cmb_setting_name.Size = new System.Drawing.Size(380, 21);
			this.cmb_setting_name.TabIndex = 4;
			this.cmb_setting_name.DropDownClosed += new System.EventHandler(this.cmb_setting_name_DropDownClosed);
			// 
			// cmb_font_lastname
			// 
			this.cmb_font_lastname.FormattingEnabled = true;
			this.cmb_font_lastname.Location = new System.Drawing.Point(190, 106);
			this.cmb_font_lastname.Name = "cmb_font_lastname";
			this.cmb_font_lastname.Size = new System.Drawing.Size(236, 21);
			this.cmb_font_lastname.TabIndex = 6;
			this.cmb_font_lastname.Click += new System.EventHandler(this.cmb_font_lastname_Click);
			// 
			// cb_lasname
			// 
			this.cb_lasname.AutoSize = true;
			this.cb_lasname.Location = new System.Drawing.Point(46, 110);
			this.cb_lasname.Name = "cb_lasname";
			this.cb_lasname.Size = new System.Drawing.Size(75, 17);
			this.cb_lasname.TabIndex = 5;
			this.cb_lasname.Text = "Фамилия";
			this.cb_lasname.UseVisualStyleBackColor = true;
			// 
			// cmb_font_pathronim
			// 
			this.cmb_font_pathronim.FormattingEnabled = true;
			this.cmb_font_pathronim.Location = new System.Drawing.Point(190, 143);
			this.cmb_font_pathronim.Name = "cmb_font_pathronim";
			this.cmb_font_pathronim.Size = new System.Drawing.Size(236, 21);
			this.cmb_font_pathronim.TabIndex = 8;
			this.cmb_font_pathronim.Click += new System.EventHandler(this.cmb_font_pathronim_Click);
			// 
			// cb_patronim
			// 
			this.cb_patronim.AutoSize = true;
			this.cb_patronim.Location = new System.Drawing.Point(46, 147);
			this.cb_patronim.Name = "cb_patronim";
			this.cb_patronim.Size = new System.Drawing.Size(73, 17);
			this.cb_patronim.TabIndex = 7;
			this.cb_patronim.Text = "Отчество";
			this.cb_patronim.UseVisualStyleBackColor = true;
			// 
			// cmb_font_company
			// 
			this.cmb_font_company.FormattingEnabled = true;
			this.cmb_font_company.Location = new System.Drawing.Point(190, 181);
			this.cmb_font_company.Name = "cmb_font_company";
			this.cmb_font_company.Size = new System.Drawing.Size(236, 21);
			this.cmb_font_company.TabIndex = 10;
			this.cmb_font_company.Click += new System.EventHandler(this.cmb_font_company_Click);
			// 
			// cb_company
			// 
			this.cb_company.AutoSize = true;
			this.cb_company.Location = new System.Drawing.Point(46, 185);
			this.cb_company.Name = "cb_company";
			this.cb_company.Size = new System.Drawing.Size(77, 17);
			this.cb_company.TabIndex = 9;
			this.cb_company.Text = "Компания";
			this.cb_company.UseVisualStyleBackColor = true;
			// 
			// cmb_font_position
			// 
			this.cmb_font_position.FormattingEnabled = true;
			this.cmb_font_position.Location = new System.Drawing.Point(190, 218);
			this.cmb_font_position.Name = "cmb_font_position";
			this.cmb_font_position.Size = new System.Drawing.Size(236, 21);
			this.cmb_font_position.TabIndex = 12;
			this.cmb_font_position.Click += new System.EventHandler(this.cmb_font_position_Click);
			// 
			// cb_position
			// 
			this.cb_position.AutoSize = true;
			this.cb_position.Location = new System.Drawing.Point(46, 222);
			this.cb_position.Name = "cb_position";
			this.cb_position.Size = new System.Drawing.Size(84, 17);
			this.cb_position.TabIndex = 11;
			this.cb_position.Text = "Должность";
			this.cb_position.UseVisualStyleBackColor = true;
			// 
			// btn_del_setting
			// 
			this.btn_del_setting.Location = new System.Drawing.Point(46, 310);
			this.btn_del_setting.Name = "btn_del_setting";
			this.btn_del_setting.Size = new System.Drawing.Size(380, 23);
			this.btn_del_setting.TabIndex = 13;
			this.btn_del_setting.Text = "удалить конфигурацию";
			this.btn_del_setting.UseVisualStyleBackColor = true;
			this.btn_del_setting.Click += new System.EventHandler(this.btn_del_setting_Click);
			// 
			// btn_set_setting
			// 
			this.btn_set_setting.Location = new System.Drawing.Point(46, 356);
			this.btn_set_setting.Name = "btn_set_setting";
			this.btn_set_setting.Size = new System.Drawing.Size(380, 23);
			this.btn_set_setting.TabIndex = 14;
			this.btn_set_setting.Text = "применить конфигурацию";
			this.btn_set_setting.UseVisualStyleBackColor = true;
			this.btn_set_setting.Click += new System.EventHandler(this.btn_set_setting_Click);
			// 
			// TemplateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 408);
			this.Controls.Add(this.btn_set_setting);
			this.Controls.Add(this.btn_del_setting);
			this.Controls.Add(this.cmb_font_position);
			this.Controls.Add(this.cb_position);
			this.Controls.Add(this.cmb_font_company);
			this.Controls.Add(this.cb_company);
			this.Controls.Add(this.cmb_font_pathronim);
			this.Controls.Add(this.cb_patronim);
			this.Controls.Add(this.cmb_font_lastname);
			this.Controls.Add(this.cb_lasname);
			this.Controls.Add(this.cmb_setting_name);
			this.Controls.Add(this.cmb_font_firstname);
			this.Controls.Add(this.cb_firstname);
			this.Controls.Add(this.btn_save_setting);
			this.Name = "TemplateForm";
			this.Text = "TemplateForm";
			this.Load += new System.EventHandler(this.TemplateForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_save_setting;
		private System.Windows.Forms.CheckBox cb_firstname;
		private System.Windows.Forms.ComboBox cmb_font_firstname;
		private System.Windows.Forms.ComboBox cmb_setting_name;
		private System.Windows.Forms.ComboBox cmb_font_lastname;
		private System.Windows.Forms.CheckBox cb_lasname;
		private System.Windows.Forms.ComboBox cmb_font_pathronim;
		private System.Windows.Forms.CheckBox cb_patronim;
		private System.Windows.Forms.ComboBox cmb_font_company;
		private System.Windows.Forms.CheckBox cb_company;
		private System.Windows.Forms.ComboBox cmb_font_position;
		private System.Windows.Forms.CheckBox cb_position;
		private System.Windows.Forms.Button btn_del_setting;
		private System.Windows.Forms.Button btn_set_setting;
	}
}