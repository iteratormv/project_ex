using System;

namespace Exhibition.Vew
{
	partial class CreatePharmaVisitorForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.txb_lname = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txb_fname = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txb_company = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txb_row_number = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txb_payment_status = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txb_payment_comment = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txb_customerno = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.btn_save_visitor = new System.Windows.Forms.Button();
			this.lbl_validator = new System.Windows.Forms.Label();
			this.cb_description = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txb_position = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmb_exhebition = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(28, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Фактические посетители (создание)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Период:";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "d.MM.yyyy HH:m";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dateTimePicker1.Location = new System.Drawing.Point(147, 48);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(252, 20);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// txb_lname
			// 
			this.txb_lname.Location = new System.Drawing.Point(147, 110);
			this.txb_lname.Name = "txb_lname";
			this.txb_lname.Size = new System.Drawing.Size(252, 20);
			this.txb_lname.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(31, 113);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Фамилия:*";
			// 
			// txb_fname
			// 
			this.txb_fname.Location = new System.Drawing.Point(147, 141);
			this.txb_fname.Name = "txb_fname";
			this.txb_fname.Size = new System.Drawing.Size(252, 20);
			this.txb_fname.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(31, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Имя:*";
			// 
			// txb_company
			// 
			this.txb_company.Location = new System.Drawing.Point(147, 173);
			this.txb_company.Name = "txb_company";
			this.txb_company.Size = new System.Drawing.Size(252, 20);
			this.txb_company.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(31, 176);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(65, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Компания:*";
			// 
			// txb_row_number
			// 
			this.txb_row_number.Location = new System.Drawing.Point(147, 234);
			this.txb_row_number.Name = "txb_row_number";
			this.txb_row_number.Size = new System.Drawing.Size(252, 20);
			this.txb_row_number.TabIndex = 18;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(31, 237);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(69, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Row Number";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(31, 296);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(81, 13);
			this.label11.TabIndex = 19;
			this.label11.Text = "Вы являетесь:";
			// 
			// txb_payment_status
			// 
			this.txb_payment_status.Location = new System.Drawing.Point(147, 324);
			this.txb_payment_status.Name = "txb_payment_status";
			this.txb_payment_status.Size = new System.Drawing.Size(252, 20);
			this.txb_payment_status.TabIndex = 22;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(31, 327);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(84, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Payment_Status";
			// 
			// txb_payment_comment
			// 
			this.txb_payment_comment.Location = new System.Drawing.Point(147, 355);
			this.txb_payment_comment.Name = "txb_payment_comment";
			this.txb_payment_comment.Size = new System.Drawing.Size(252, 20);
			this.txb_payment_comment.TabIndex = 24;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(31, 358);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(98, 13);
			this.label13.TabIndex = 23;
			this.label13.Text = "Payment_Comment";
			// 
			// txb_customerno
			// 
			this.txb_customerno.Location = new System.Drawing.Point(147, 264);
			this.txb_customerno.Name = "txb_customerno";
			this.txb_customerno.Size = new System.Drawing.Size(252, 20);
			this.txb_customerno.TabIndex = 28;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(31, 267);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(68, 13);
			this.label15.TabIndex = 27;
			this.label15.Text = "Customer No";
			// 
			// btn_save_visitor
			// 
			this.btn_save_visitor.Location = new System.Drawing.Point(100, 419);
			this.btn_save_visitor.Name = "btn_save_visitor";
			this.btn_save_visitor.Size = new System.Drawing.Size(208, 22);
			this.btn_save_visitor.TabIndex = 29;
			this.btn_save_visitor.Text = "Сохранить и закрыть";
			this.btn_save_visitor.UseVisualStyleBackColor = true;
			this.btn_save_visitor.Click += new System.EventHandler(this.btn_save_visitor_Click);
			// 
			// lbl_validator
			// 
			this.lbl_validator.AutoSize = true;
			this.lbl_validator.Location = new System.Drawing.Point(63, 392);
			this.lbl_validator.Name = "lbl_validator";
			this.lbl_validator.Size = new System.Drawing.Size(204, 13);
			this.lbl_validator.TabIndex = 30;
			this.lbl_validator.Text = "* - поля обязательные для заполнения";
			// 
			// cb_description
			// 
			this.cb_description.FormattingEnabled = true;
			this.cb_description.Location = new System.Drawing.Point(147, 293);
			this.cb_description.Name = "cb_description";
			this.cb_description.Size = new System.Drawing.Size(252, 21);
			this.cb_description.TabIndex = 31;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(31, 207);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "Должность:*";
			// 
			// txb_position
			// 
			this.txb_position.Location = new System.Drawing.Point(147, 204);
			this.txb_position.Name = "txb_position";
			this.txb_position.Size = new System.Drawing.Size(252, 20);
			this.txb_position.TabIndex = 16;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 79);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Выставка:";
			// 
			// cmb_exhebition
			// 
			this.cmb_exhebition.FormattingEnabled = true;
			this.cmb_exhebition.Location = new System.Drawing.Point(147, 79);
			this.cmb_exhebition.Name = "cmb_exhebition";
			this.cmb_exhebition.Size = new System.Drawing.Size(252, 21);
			this.cmb_exhebition.TabIndex = 6;
			// 
			// CreatePharmaVisitorForm
			// 
			this.AcceptButton = this.btn_save_visitor;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 460);
			this.Controls.Add(this.cb_description);
			this.Controls.Add(this.lbl_validator);
			this.Controls.Add(this.btn_save_visitor);
			this.Controls.Add(this.txb_customerno);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.txb_payment_comment);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.txb_payment_status);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txb_row_number);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txb_position);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txb_company);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txb_fname);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txb_lname);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cmb_exhebition);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "CreatePharmaVisitorForm";
			this.Text = "Создание посетителя";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox txb_lname;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txb_fname;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txb_company;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txb_row_number;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txb_payment_status;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txb_payment_comment;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txb_customerno;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button btn_save_visitor;
		private System.Windows.Forms.Label lbl_validator;
		private System.Windows.Forms.ComboBox cb_description;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txb_position;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cmb_exhebition;
	}
}