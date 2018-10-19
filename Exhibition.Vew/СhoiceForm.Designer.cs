namespace Exhibition.Vew
{
	partial class СhoiceForm
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
			this.btn_edit = new System.Windows.Forms.Button();
			this.lbl_text = new System.Windows.Forms.Label();
			this.btn_print = new System.Windows.Forms.Button();
			this.btn_exit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_edit
			// 
			this.btn_edit.Location = new System.Drawing.Point(12, 73);
			this.btn_edit.Name = "btn_edit";
			this.btn_edit.Size = new System.Drawing.Size(132, 23);
			this.btn_edit.TabIndex = 0;
			this.btn_edit.Text = "Редактировать";
			this.btn_edit.UseVisualStyleBackColor = true;
			this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
			// 
			// lbl_text
			// 
			this.lbl_text.AutoSize = true;
			this.lbl_text.Location = new System.Drawing.Point(99, 33);
			this.lbl_text.Name = "lbl_text";
			this.lbl_text.Size = new System.Drawing.Size(225, 13);
			this.lbl_text.TabIndex = 2;
			this.lbl_text.Text = "Данный посетитель уже зарегистрирован!";
			// 
			// btn_print
			// 
			this.btn_print.Location = new System.Drawing.Point(150, 73);
			this.btn_print.Name = "btn_print";
			this.btn_print.Size = new System.Drawing.Size(132, 23);
			this.btn_print.TabIndex = 3;
			this.btn_print.Text = "Печать";
			this.btn_print.UseVisualStyleBackColor = true;
			this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
			// 
			// btn_exit
			// 
			this.btn_exit.Location = new System.Drawing.Point(288, 73);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(132, 23);
			this.btn_exit.TabIndex = 4;
			this.btn_exit.Text = "Выход";
			this.btn_exit.UseVisualStyleBackColor = true;
			this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
			// 
			// СhoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 125);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.btn_print);
			this.Controls.Add(this.lbl_text);
			this.Controls.Add(this.btn_edit);
			this.Name = "СhoiceForm";
			this.Text = "Сделай выбор";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_edit;
		private System.Windows.Forms.Label lbl_text;
		private System.Windows.Forms.Button btn_print;
		private System.Windows.Forms.Button btn_exit;
	}
}