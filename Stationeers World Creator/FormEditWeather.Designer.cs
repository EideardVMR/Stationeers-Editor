namespace Stationeers_World_Creator
{
    partial class FormEditWeather
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            numericUpDown_start_max = new NumericUpDown();
            label1 = new Label();
            numericUpDown_start_min = new NumericUpDown();
            groupBox2 = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            numericUpDown_dur_max = new NumericUpDown();
            label6 = new Label();
            numericUpDown_dur_min = new NumericUpDown();
            groupBox3 = new GroupBox();
            label7 = new Label();
            label8 = new Label();
            numericUpDown_cd_max = new NumericUpDown();
            label9 = new Label();
            numericUpDown_cd_min = new NumericUpDown();
            groupBox4 = new GroupBox();
            label10 = new Label();
            label12 = new Label();
            numericUpDown_start_cd = new NumericUpDown();
            button_kelvin = new Button();
            button_Color = new Button();
            button_save = new Button();
            groupBox5 = new GroupBox();
            button_WeatherAshStorm = new Button();
            button_WeatherVenusStorm = new Button();
            button_WeatherSnowStorm = new Button();
            button_WeatherDustStorm = new Button();
            label11 = new Label();
            colorDialog1 = new ColorDialog();
            button_delete = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_start_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_start_min).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_dur_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_dur_min).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_cd_max).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_cd_min).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_start_cd).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numericUpDown_start_max);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(numericUpDown_start_min);
            groupBox1.Location = new Point(330, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(307, 120);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vorbereitungszeit";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(5, 19);
            label2.Name = "label2";
            label2.Size = new Size(296, 37);
            label2.TabIndex = 1;
            label2.Text = "Diese Einstellung legt fest, wie viele Sekunden du vor dem Surm gewarnt wirst (z.B. durch die Wetterstation)";
            // 
            // label3
            // 
            label3.Location = new Point(5, 88);
            label3.Name = "label3";
            label3.Size = new Size(82, 23);
            label3.TabIndex = 1;
            label3.Text = "Maximum";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_start_max
            // 
            numericUpDown_start_max.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_start_max.Location = new Point(93, 88);
            numericUpDown_start_max.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_start_max.Name = "numericUpDown_start_max";
            numericUpDown_start_max.Size = new Size(208, 23);
            numericUpDown_start_max.TabIndex = 0;
            numericUpDown_start_max.ValueChanged += numericUpDown_start_max_ValueChanged;
            // 
            // label1
            // 
            label1.Location = new Point(5, 59);
            label1.Name = "label1";
            label1.Size = new Size(82, 23);
            label1.TabIndex = 1;
            label1.Text = "Minimum";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_start_min
            // 
            numericUpDown_start_min.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_start_min.Location = new Point(93, 59);
            numericUpDown_start_min.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_start_min.Name = "numericUpDown_start_min";
            numericUpDown_start_min.Size = new Size(208, 23);
            numericUpDown_start_min.TabIndex = 0;
            numericUpDown_start_min.ValueChanged += numericUpDown_start_min_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(numericUpDown_dur_max);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numericUpDown_dur_min);
            groupBox2.Location = new Point(17, 138);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(307, 136);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dauer";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.Location = new Point(5, 19);
            label4.Name = "label4";
            label4.Size = new Size(296, 37);
            label4.TabIndex = 1;
            label4.Text = "Diese Einstellung legt fest, wie viele Sekunden der Sturm andauern kann.";
            // 
            // label5
            // 
            label5.Location = new Point(5, 102);
            label5.Name = "label5";
            label5.Size = new Size(82, 23);
            label5.TabIndex = 1;
            label5.Text = "Maximum";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_dur_max
            // 
            numericUpDown_dur_max.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_dur_max.Location = new Point(93, 102);
            numericUpDown_dur_max.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_dur_max.Name = "numericUpDown_dur_max";
            numericUpDown_dur_max.Size = new Size(208, 23);
            numericUpDown_dur_max.TabIndex = 0;
            numericUpDown_dur_max.ValueChanged += numericUpDown_dur_max_ValueChanged;
            // 
            // label6
            // 
            label6.Location = new Point(5, 73);
            label6.Name = "label6";
            label6.Size = new Size(82, 23);
            label6.TabIndex = 1;
            label6.Text = "Minimum";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_dur_min
            // 
            numericUpDown_dur_min.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_dur_min.Location = new Point(93, 73);
            numericUpDown_dur_min.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_dur_min.Name = "numericUpDown_dur_min";
            numericUpDown_dur_min.Size = new Size(208, 23);
            numericUpDown_dur_min.TabIndex = 0;
            numericUpDown_dur_min.ValueChanged += numericUpDown_dur_min_ValueChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(numericUpDown_cd_max);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(numericUpDown_cd_min);
            groupBox3.Location = new Point(330, 138);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(307, 136);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Cooldown";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.Location = new Point(5, 19);
            label7.Name = "label7";
            label7.Size = new Size(296, 51);
            label7.TabIndex = 1;
            label7.Text = "Diese Einstellung legt fest, wie viele Tage (InGame) gewartet werden soll, bis ein neuer Sturm geplant wird.";
            // 
            // label8
            // 
            label8.Location = new Point(5, 102);
            label8.Name = "label8";
            label8.Size = new Size(82, 23);
            label8.TabIndex = 1;
            label8.Text = "Maximum";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_cd_max
            // 
            numericUpDown_cd_max.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_cd_max.Location = new Point(93, 102);
            numericUpDown_cd_max.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_cd_max.Name = "numericUpDown_cd_max";
            numericUpDown_cd_max.Size = new Size(208, 23);
            numericUpDown_cd_max.TabIndex = 0;
            numericUpDown_cd_max.ValueChanged += numericUpDown_cd_max_ValueChanged;
            // 
            // label9
            // 
            label9.Location = new Point(5, 73);
            label9.Name = "label9";
            label9.Size = new Size(82, 23);
            label9.TabIndex = 1;
            label9.Text = "Minimum";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_cd_min
            // 
            numericUpDown_cd_min.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_cd_min.Location = new Point(93, 73);
            numericUpDown_cd_min.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_cd_min.Name = "numericUpDown_cd_min";
            numericUpDown_cd_min.Size = new Size(208, 23);
            numericUpDown_cd_min.TabIndex = 0;
            numericUpDown_cd_min.ValueChanged += numericUpDown_cd_min_ValueChanged;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(numericUpDown_start_cd);
            groupBox4.Location = new Point(17, 280);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(307, 136);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Beginner Cooldown";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.Location = new Point(5, 19);
            label10.Name = "label10";
            label10.Size = new Size(296, 51);
            label10.TabIndex = 1;
            label10.Text = "Diese Einstellung legt fest, wie viele Tage (InGame) mindestens vergangen sein müssen bis ein Sturm eintreten darf.";
            // 
            // label12
            // 
            label12.Location = new Point(5, 75);
            label12.Name = "label12";
            label12.Size = new Size(82, 23);
            label12.TabIndex = 1;
            label12.Text = "Minimum";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_start_cd
            // 
            numericUpDown_start_cd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numericUpDown_start_cd.Location = new Point(93, 75);
            numericUpDown_start_cd.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown_start_cd.Name = "numericUpDown_start_cd";
            numericUpDown_start_cd.Size = new Size(208, 23);
            numericUpDown_start_cd.TabIndex = 0;
            numericUpDown_start_cd.ValueChanged += numericUpDown_start_cd_ValueChanged;
            // 
            // button_kelvin
            // 
            button_kelvin.BackColor = SystemColors.ActiveCaption;
            button_kelvin.FlatStyle = FlatStyle.Flat;
            button_kelvin.Location = new Point(330, 289);
            button_kelvin.Name = "button_kelvin";
            button_kelvin.Size = new Size(307, 44);
            button_kelvin.TabIndex = 17;
            button_kelvin.Text = "Temperaturen bearbeiten";
            button_kelvin.UseVisualStyleBackColor = false;
            button_kelvin.Click += button_kelvin_Click;
            // 
            // button_Color
            // 
            button_Color.BackColor = SystemColors.ActiveCaption;
            button_Color.FlatStyle = FlatStyle.Flat;
            button_Color.Location = new Point(330, 339);
            button_Color.Name = "button_Color";
            button_Color.Size = new Size(307, 44);
            button_Color.TabIndex = 17;
            button_Color.Text = "Farbe bearbeiten";
            button_Color.UseVisualStyleBackColor = false;
            button_Color.Click += button_Color_Click;
            // 
            // button_save
            // 
            button_save.BackColor = Color.ForestGreen;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.Location = new Point(530, 389);
            button_save.Name = "button_save";
            button_save.Size = new Size(107, 44);
            button_save.TabIndex = 18;
            button_save.Text = "Fertig";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button_WeatherAshStorm);
            groupBox5.Controls.Add(button_WeatherVenusStorm);
            groupBox5.Controls.Add(button_WeatherSnowStorm);
            groupBox5.Controls.Add(button_WeatherDustStorm);
            groupBox5.Controls.Add(label11);
            groupBox5.Location = new Point(17, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(307, 120);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Vorbereitungszeit";
            // 
            // button_WeatherAshStorm
            // 
            button_WeatherAshStorm.BackColor = Color.RosyBrown;
            button_WeatherAshStorm.FlatStyle = FlatStyle.Popup;
            button_WeatherAshStorm.Location = new Point(6, 77);
            button_WeatherAshStorm.Name = "button_WeatherAshStorm";
            button_WeatherAshStorm.Size = new Size(150, 33);
            button_WeatherAshStorm.TabIndex = 2;
            button_WeatherAshStorm.Text = "Aschesturm";
            button_WeatherAshStorm.UseVisualStyleBackColor = false;
            button_WeatherAshStorm.Click += button_WeatherAshStorm_Click;
            // 
            // button_WeatherVenusStorm
            // 
            button_WeatherVenusStorm.BackColor = Color.RosyBrown;
            button_WeatherVenusStorm.FlatStyle = FlatStyle.Popup;
            button_WeatherVenusStorm.Location = new Point(162, 77);
            button_WeatherVenusStorm.Name = "button_WeatherVenusStorm";
            button_WeatherVenusStorm.Size = new Size(139, 33);
            button_WeatherVenusStorm.TabIndex = 2;
            button_WeatherVenusStorm.Text = "Venussturm";
            button_WeatherVenusStorm.UseVisualStyleBackColor = false;
            button_WeatherVenusStorm.Click += button_WeatherVenusStorm_Click;
            // 
            // button_WeatherSnowStorm
            // 
            button_WeatherSnowStorm.BackColor = Color.RosyBrown;
            button_WeatherSnowStorm.FlatStyle = FlatStyle.Popup;
            button_WeatherSnowStorm.Location = new Point(162, 38);
            button_WeatherSnowStorm.Name = "button_WeatherSnowStorm";
            button_WeatherSnowStorm.Size = new Size(139, 33);
            button_WeatherSnowStorm.TabIndex = 2;
            button_WeatherSnowStorm.Text = "Schneesturm";
            button_WeatherSnowStorm.UseVisualStyleBackColor = false;
            button_WeatherSnowStorm.Click += button_WeatherSnowStorm_Click;
            // 
            // button_WeatherDustStorm
            // 
            button_WeatherDustStorm.BackColor = Color.YellowGreen;
            button_WeatherDustStorm.FlatStyle = FlatStyle.Popup;
            button_WeatherDustStorm.Location = new Point(6, 38);
            button_WeatherDustStorm.Name = "button_WeatherDustStorm";
            button_WeatherDustStorm.Size = new Size(150, 33);
            button_WeatherDustStorm.TabIndex = 2;
            button_WeatherDustStorm.Text = "Staubsturm";
            button_WeatherDustStorm.UseVisualStyleBackColor = false;
            button_WeatherDustStorm.Click += button_WeatherDustStorm_Click;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.Location = new Point(5, 19);
            label11.Name = "label11";
            label11.Size = new Size(296, 16);
            label11.TabIndex = 1;
            label11.Text = "Diese Einstellung legt fest, wie der Sturm aussehen soll\r\n";
            // 
            // button_delete
            // 
            button_delete.BackColor = Color.IndianRed;
            button_delete.FlatStyle = FlatStyle.Flat;
            button_delete.Location = new Point(330, 389);
            button_delete.Name = "button_delete";
            button_delete.Size = new Size(115, 44);
            button_delete.TabIndex = 18;
            button_delete.Text = "Wetter abschalten";
            button_delete.UseVisualStyleBackColor = false;
            button_delete.Click += button_delete_Click;
            // 
            // FormEditWeather
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(649, 450);
            Controls.Add(button_delete);
            Controls.Add(button_save);
            Controls.Add(button_Color);
            Controls.Add(button_kelvin);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox5);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormEditWeather";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEditWeather";
            Load += FormEditWeather_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_start_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_start_min).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_dur_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_dur_min).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_cd_max).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_cd_min).EndInit();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_start_cd).EndInit();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown_start_max;
        private Label label1;
        private NumericUpDown numericUpDown_start_min;
        private GroupBox groupBox2;
        private Label label4;
        private Label label5;
        private NumericUpDown numericUpDown_dur_max;
        private Label label6;
        private NumericUpDown numericUpDown_dur_min;
        private GroupBox groupBox3;
        private Label label7;
        private Label label8;
        private NumericUpDown numericUpDown_cd_max;
        private Label label9;
        private NumericUpDown numericUpDown_cd_min;
        private GroupBox groupBox4;
        private Label label10;
        private Label label12;
        private NumericUpDown numericUpDown_start_cd;
        private Button button_kelvin;
        private Button button_Color;
        private Button button_save;
        private GroupBox groupBox5;
        private Label label11;
        private Button button_WeatherAshStorm;
        private Button button_WeatherSnowStorm;
        private Button button_WeatherDustStorm;
        private Button button_WeatherVenusStorm;
        private ColorDialog colorDialog1;
        private Button button_delete;
    }
}