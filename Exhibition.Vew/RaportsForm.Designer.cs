namespace Exhibition.View
{
	partial class RaportsForm
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
			this.dgv_visitors = new System.Windows.Forms.DataGridView();
			this.cb_description = new System.Windows.Forms.ComboBox();
			this.btn_export = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lbl_count = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btn_print = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgv_visitors)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_visitors
			// 
			this.dgv_visitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_visitors.Location = new System.Drawing.Point(12, 89);
			this.dgv_visitors.Name = "dgv_visitors";
			this.dgv_visitors.Size = new System.Drawing.Size(776, 381);
			this.dgv_visitors.TabIndex = 1;
			// 
			// cb_description
			// 
			this.cb_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cb_description.FormattingEnabled = true;
			this.cb_description.Location = new System.Drawing.Point(12, 43);
			this.cb_description.Name = "cb_description";
			this.cb_description.Size = new System.Drawing.Size(390, 28);
			this.cb_description.TabIndex = 2;
			this.cb_description.TextChanged += new System.EventHandler(this.cb_description_TextChanged);
			// 
			// btn_export
			// 
			this.btn_export.Location = new System.Drawing.Point(577, 43);
			this.btn_export.Name = "btn_export";
			this.btn_export.Size = new System.Drawing.Size(211, 28);
			this.btn_export.TabIndex = 3;
			this.btn_export.Text = "Экспорт файла в Exel";
			this.btn_export.UseVisualStyleBackColor = true;
			this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Вы являетесь:";
			// 
			// lbl_count
			// 
			this.lbl_count.AutoSize = true;
			this.lbl_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_count.Location = new System.Drawing.Point(437, 29);
			this.lbl_count.Name = "lbl_count";
			this.lbl_count.Size = new System.Drawing.Size(39, 42);
			this.lbl_count.TabIndex = 5;
			this.lbl_count.Text = "0";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(577, 12);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(211, 23);
			this.progressBar1.TabIndex = 6;
			// 
			// btn_print
			// 
			this.btn_print.Location = new System.Drawing.Point(822, 43);
			this.btn_print.Name = "btn_print";
			this.btn_print.Size = new System.Drawing.Size(211, 28);
			this.btn_print.TabIndex = 7;
			this.btn_print.Text = "Печать этикеток";
			this.btn_print.UseVisualStyleBackColor = true;
			this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
			// 
			// RaportsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1145, 482);
			this.Controls.Add(this.btn_print);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.lbl_count);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_export);
			this.Controls.Add(this.cb_description);
			this.Controls.Add(this.dgv_visitors);
			this.Name = "RaportsForm";
			this.Text = "Отчёт";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.SizeChanged += new System.EventHandler(this.RaportsForm_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.dgv_visitors)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_visitors;
		private System.Windows.Forms.ComboBox cb_description;
		private System.Windows.Forms.Button btn_export;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbl_count;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btn_print;
	}
}