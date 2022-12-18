namespace Laba5
{
	partial class Form1
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
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.openButton = new System.Windows.Forms.Button();
			this.conversionButton = new System.Windows.Forms.Button();
			this.buttonBinarization = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.morphologicalButton = new System.Windows.Forms.Button();
			this.invertButton = new System.Windows.Forms.Button();
			this.Markbutton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(12, 12);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(426, 426);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// openButton
			// 
			this.openButton.Location = new System.Drawing.Point(444, 12);
			this.openButton.Name = "openButton";
			this.openButton.Size = new System.Drawing.Size(344, 23);
			this.openButton.TabIndex = 1;
			this.openButton.Text = "Open Image";
			this.openButton.UseVisualStyleBackColor = true;
			this.openButton.Click += new System.EventHandler(this.openButton_Click);
			// 
			// conversionButton
			// 
			this.conversionButton.Location = new System.Drawing.Point(444, 41);
			this.conversionButton.Name = "conversionButton";
			this.conversionButton.Size = new System.Drawing.Size(344, 23);
			this.conversionButton.TabIndex = 2;
			this.conversionButton.Text = "Apply Conversion Filter";
			this.conversionButton.UseVisualStyleBackColor = true;
			this.conversionButton.Click += new System.EventHandler(this.ConversionButton_Click);
			// 
			// buttonBinarization
			// 
			this.buttonBinarization.Location = new System.Drawing.Point(577, 70);
			this.buttonBinarization.Name = "buttonBinarization";
			this.buttonBinarization.Size = new System.Drawing.Size(211, 23);
			this.buttonBinarization.TabIndex = 3;
			this.buttonBinarization.Text = "Apply binarization";
			this.buttonBinarization.UseVisualStyleBackColor = true;
			this.buttonBinarization.Click += new System.EventHandler(this.buttonBinarization_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(444, 73);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(127, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "128";
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// morphologicalButton
			// 
			this.morphologicalButton.Location = new System.Drawing.Point(444, 128);
			this.morphologicalButton.Name = "morphologicalButton";
			this.morphologicalButton.Size = new System.Drawing.Size(344, 23);
			this.morphologicalButton.TabIndex = 5;
			this.morphologicalButton.Text = "Apply Morphological Filter";
			this.morphologicalButton.UseVisualStyleBackColor = true;
			this.morphologicalButton.Click += new System.EventHandler(this.morphologicalButton_Click);
			// 
			// invertButton
			// 
			this.invertButton.Location = new System.Drawing.Point(444, 99);
			this.invertButton.Name = "invertButton";
			this.invertButton.Size = new System.Drawing.Size(344, 23);
			this.invertButton.TabIndex = 6;
			this.invertButton.Text = "Apply Invert Filter";
			this.invertButton.UseVisualStyleBackColor = true;
			this.invertButton.Click += new System.EventHandler(this.invertButton_Click);
			// 
			// Markbutton
			// 
			this.Markbutton.Location = new System.Drawing.Point(444, 157);
			this.Markbutton.Name = "Markbutton";
			this.Markbutton.Size = new System.Drawing.Size(344, 23);
			this.Markbutton.TabIndex = 7;
			this.Markbutton.Text = "Mark Symbols";
			this.Markbutton.UseVisualStyleBackColor = true;
			this.Markbutton.Click += new System.EventHandler(this.Markbutton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Markbutton);
			this.Controls.Add(this.invertButton);
			this.Controls.Add(this.morphologicalButton);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonBinarization);
			this.Controls.Add(this.conversionButton);
			this.Controls.Add(this.openButton);
			this.Controls.Add(this.pictureBox);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button openButton;
		private System.Windows.Forms.Button conversionButton;
		private System.Windows.Forms.Button buttonBinarization;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button morphologicalButton;
		private System.Windows.Forms.Button invertButton;
		private System.Windows.Forms.Button Markbutton;
	}
}

