namespace Exhibition.Vew
{
	partial class ColorForm
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
			this.dgv_colors = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgv_colors)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv_colors
			// 
			this.dgv_colors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_colors.Location = new System.Drawing.Point(25, 65);
			this.dgv_colors.Name = "dgv_colors";
			this.dgv_colors.Size = new System.Drawing.Size(314, 234);
			this.dgv_colors.TabIndex = 0;
			this.dgv_colors.DoubleClick += new System.EventHandler(this.dgv_colors_DoubleClick);
			// 
			// ColorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 325);
			this.Controls.Add(this.dgv_colors);
			this.Name = "ColorForm";
			this.Text = "ColorForm";
			((System.ComponentModel.ISupportInitialize)(this.dgv_colors)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgv_colors;
	}
}