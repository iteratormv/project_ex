﻿namespace Exhibition.View
{
	partial class GeneralForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.выставкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mi_desktop = new System.Windows.Forms.ToolStripMenuItem();
			this.mi_planed_visitors = new System.Windows.Forms.ToolStripMenuItem();
			this.mi_fact_visitors = new System.Windows.Forms.ToolStripMenuItem();
			this.загрузкаФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbl_code = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbl_staus = new System.Windows.Forms.Label();
			this.cb_code = new System.Windows.Forms.ComboBox();
			this.dgv_fakt_visitor = new System.Windows.Forms.DataGridView();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.настройкаШаблонаПечатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_fakt_visitor)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выставкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1170, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// выставкаToolStripMenuItem
			// 
			this.выставкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_desktop,
            this.mi_planed_visitors,
            this.mi_fact_visitors,
            this.загрузкаФайлаToolStripMenuItem,
            this.настройкаШаблонаПечатиToolStripMenuItem});
			this.выставкаToolStripMenuItem.Name = "выставкаToolStripMenuItem";
			this.выставкаToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
			this.выставкаToolStripMenuItem.Text = "Выставка";
			// 
			// mi_desktop
			// 
			this.mi_desktop.Name = "mi_desktop";
			this.mi_desktop.Size = new System.Drawing.Size(219, 22);
			this.mi_desktop.Text = "Рабочий стол";
			// 
			// mi_planed_visitors
			// 
			this.mi_planed_visitors.Name = "mi_planed_visitors";
			this.mi_planed_visitors.Size = new System.Drawing.Size(219, 22);
			this.mi_planed_visitors.Text = "Планируемые посетители";
			this.mi_planed_visitors.Click += new System.EventHandler(this.mi_planed_visitors_Click);
			// 
			// mi_fact_visitors
			// 
			this.mi_fact_visitors.Name = "mi_fact_visitors";
			this.mi_fact_visitors.Size = new System.Drawing.Size(219, 22);
			this.mi_fact_visitors.Text = "Фактические посетители";
			// 
			// загрузкаФайлаToolStripMenuItem
			// 
			this.загрузкаФайлаToolStripMenuItem.Name = "загрузкаФайлаToolStripMenuItem";
			this.загрузкаФайлаToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.загрузкаФайлаToolStripMenuItem.Text = "Загрузка файла";
			this.загрузкаФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузкаФайлаToolStripMenuItem_Click);
			// 
			// lbl_code
			// 
			this.lbl_code.AutoSize = true;
			this.lbl_code.Location = new System.Drawing.Point(122, 118);
			this.lbl_code.Name = "lbl_code";
			this.lbl_code.Size = new System.Drawing.Size(28, 13);
			this.lbl_code.TabIndex = 1;
			this.lbl_code.Text = "код:";
			// 
			// lbl_staus
			// 
			this.lbl_staus.AutoSize = true;
			this.lbl_staus.Location = new System.Drawing.Point(66, 610);
			this.lbl_staus.Name = "lbl_staus";
			this.lbl_staus.Size = new System.Drawing.Size(84, 13);
			this.lbl_staus.TabIndex = 3;
			this.lbl_staus.Text = "operation - none";
			// 
			// cb_code
			// 
			this.cb_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_code.FormattingEnabled = true;
			this.cb_code.IntegralHeight = false;
			this.cb_code.ItemHeight = 31;
			this.cb_code.Location = new System.Drawing.Point(156, 109);
			this.cb_code.Name = "cb_code";
			this.cb_code.Size = new System.Drawing.Size(448, 39);
			this.cb_code.TabIndex = 4;
			this.cb_code.TextChanged += new System.EventHandler(this.cb_code_TextChanged);
			this.cb_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_code_KeyDown);
			// 
			// dgv_fakt_visitor
			// 
			this.dgv_fakt_visitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_fakt_visitor.Location = new System.Drawing.Point(24, 173);
			this.dgv_fakt_visitor.Name = "dgv_fakt_visitor";
			this.dgv_fakt_visitor.Size = new System.Drawing.Size(1123, 434);
			this.dgv_fakt_visitor.TabIndex = 5;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// fontDialog1
			// 
			this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
			// 
			// настройкаШаблонаПечатиToolStripMenuItem
			// 
			this.настройкаШаблонаПечатиToolStripMenuItem.Name = "настройкаШаблонаПечатиToolStripMenuItem";
			this.настройкаШаблонаПечатиToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
			this.настройкаШаблонаПечатиToolStripMenuItem.Text = "Настройка шаблона печати";
			this.настройкаШаблонаПечатиToolStripMenuItem.Click += new System.EventHandler(this.настройкаШаблонаПечатиToolStripMenuItem_Click);
			// 
			// GeneralForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1170, 656);
			this.Controls.Add(this.dgv_fakt_visitor);
			this.Controls.Add(this.cb_code);
			this.Controls.Add(this.lbl_staus);
			this.Controls.Add(this.lbl_code);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "GeneralForm";
			this.Text = "Exhibition";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.GeneralForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_fakt_visitor)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem выставкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mi_desktop;
		private System.Windows.Forms.ToolStripMenuItem mi_planed_visitors;
		private System.Windows.Forms.ToolStripMenuItem mi_fact_visitors;
		private System.Windows.Forms.ToolStripMenuItem загрузкаФайлаToolStripMenuItem;
		private System.Windows.Forms.Label lbl_code;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lbl_staus;
		private System.Windows.Forms.ComboBox cb_code;
		private System.Windows.Forms.DataGridView dgv_fakt_visitor;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.ToolStripMenuItem настройкаШаблонаПечатиToolStripMenuItem;
		private System.Windows.Forms.ColorDialog colorDialog1;
	}
}

