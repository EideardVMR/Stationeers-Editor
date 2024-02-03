namespace Stationeers_World_Creator
{
    partial class Form_Edit_World
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Edit_World));
            textBox_id = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            numericUpDown_bedrock = new NumericUpDown();
            numericUpDown_lava = new NumericUpDown();
            checkBox_lava = new CheckBox();
            textBox_name_de = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            richTextBox_desc_eng = new RichTextBox();
            richTextBox_desc_ger = new RichTextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            textBox_name_eng = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            comboBox_terrain = new ComboBox();
            label13 = new Label();
            comboBox_startingcondition = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            numericUpDown_gravity = new NumericUpDown();
            label_creative = new Label();
            label10 = new Label();
            checkBox_gamemode = new CheckBox();
            checkBox_freeze_time = new CheckBox();
            numericUpDown_timescale = new NumericUpDown();
            button_edit_minables = new Button();
            button_edit_deepminables = new Button();
            button_save = new Button();
            button_atmosphere = new Button();
            button_kelvin = new Button();
            button_weather = new Button();
            label11 = new Label();
            label12 = new Label();
            label_temp = new Label();
            label_press = new Label();
            label_error = new Label();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_bedrock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_lava).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_gravity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_timescale).BeginInit();
            SuspendLayout();
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(143, 22);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(201, 23);
            textBox_id.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 1;
            label1.Text = "ID der Welt";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(6, 47);
            label2.Name = "label2";
            label2.Size = new Size(131, 23);
            label2.TabIndex = 3;
            label2.Text = "Bedrocklevel";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(6, 76);
            label3.Name = "label3";
            label3.Size = new Size(131, 23);
            label3.TabIndex = 5;
            label3.Text = "Lava";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_bedrock
            // 
            numericUpDown_bedrock.Location = new Point(143, 47);
            numericUpDown_bedrock.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numericUpDown_bedrock.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown_bedrock.Name = "numericUpDown_bedrock";
            numericUpDown_bedrock.Size = new Size(201, 23);
            numericUpDown_bedrock.TabIndex = 6;
            // 
            // numericUpDown_lava
            // 
            numericUpDown_lava.Location = new Point(195, 76);
            numericUpDown_lava.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numericUpDown_lava.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numericUpDown_lava.Name = "numericUpDown_lava";
            numericUpDown_lava.Size = new Size(149, 23);
            numericUpDown_lava.TabIndex = 7;
            // 
            // checkBox_lava
            // 
            checkBox_lava.AutoSize = true;
            checkBox_lava.Location = new Point(143, 80);
            checkBox_lava.Name = "checkBox_lava";
            checkBox_lava.Size = new Size(46, 19);
            checkBox_lava.TabIndex = 8;
            checkBox_lava.Text = "Aus";
            checkBox_lava.UseVisualStyleBackColor = true;
            // 
            // textBox_name_de
            // 
            textBox_name_de.Location = new Point(147, 22);
            textBox_name_de.Name = "textBox_name_de";
            textBox_name_de.Size = new Size(197, 23);
            textBox_name_de.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_id);
            groupBox1.Location = new Point(15, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(350, 58);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Systembedingt";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(richTextBox_desc_eng);
            groupBox2.Controls.Add(richTextBox_desc_ger);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(textBox_name_eng);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(textBox_name_de);
            groupBox2.Location = new Point(371, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(350, 305);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Spracheinstellungen";
            // 
            // richTextBox_desc_eng
            // 
            richTextBox_desc_eng.BorderStyle = BorderStyle.None;
            richTextBox_desc_eng.Location = new Point(147, 189);
            richTextBox_desc_eng.Name = "richTextBox_desc_eng";
            richTextBox_desc_eng.Size = new Size(197, 103);
            richTextBox_desc_eng.TabIndex = 13;
            richTextBox_desc_eng.Text = "";
            // 
            // richTextBox_desc_ger
            // 
            richTextBox_desc_ger.BorderStyle = BorderStyle.None;
            richTextBox_desc_ger.Location = new Point(147, 51);
            richTextBox_desc_ger.Name = "richTextBox_desc_ger";
            richTextBox_desc_ger.Size = new Size(197, 103);
            richTextBox_desc_ger.TabIndex = 13;
            richTextBox_desc_ger.Text = "";
            // 
            // label7
            // 
            label7.Location = new Point(10, 189);
            label7.Name = "label7";
            label7.Size = new Size(131, 34);
            label7.TabIndex = 12;
            label7.Text = "Beschreibung in Englisch";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Location = new Point(10, 45);
            label6.Name = "label6";
            label6.Size = new Size(131, 35);
            label6.TabIndex = 12;
            label6.Text = "Beschreibung in Deutsch";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(10, 160);
            label5.Name = "label5";
            label5.Size = new Size(131, 23);
            label5.TabIndex = 12;
            label5.Text = "Name in Englisch";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_name_eng
            // 
            textBox_name_eng.Location = new Point(147, 160);
            textBox_name_eng.Name = "textBox_name_eng";
            textBox_name_eng.Size = new Size(197, 23);
            textBox_name_eng.TabIndex = 11;
            // 
            // label4
            // 
            label4.Location = new Point(10, 22);
            label4.Name = "label4";
            label4.Size = new Size(131, 23);
            label4.TabIndex = 10;
            label4.Text = "Name in Deutsch";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBox_terrain);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(comboBox_startingcondition);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(numericUpDown_gravity);
            groupBox3.Controls.Add(numericUpDown_bedrock);
            groupBox3.Controls.Add(label_creative);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(checkBox_gamemode);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(checkBox_freeze_time);
            groupBox3.Controls.Add(checkBox_lava);
            groupBox3.Controls.Add(numericUpDown_timescale);
            groupBox3.Controls.Add(numericUpDown_lava);
            groupBox3.Location = new Point(15, 76);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(350, 241);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Welteinstellungen";
            // 
            // comboBox_terrain
            // 
            comboBox_terrain.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_terrain.FormattingEnabled = true;
            comboBox_terrain.Items.AddRange(new object[] { "None", "Mars", "Europa", "Vulcan", "Venus", "Mountains", "Islands", "Flatland" });
            comboBox_terrain.Location = new Point(143, 191);
            comboBox_terrain.Name = "comboBox_terrain";
            comboBox_terrain.Size = new Size(201, 23);
            comboBox_terrain.TabIndex = 9;
            // 
            // label13
            // 
            label13.Location = new Point(6, 191);
            label13.Name = "label13";
            label13.Size = new Size(131, 23);
            label13.TabIndex = 3;
            label13.Text = "Terrain";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_startingcondition
            // 
            comboBox_startingcondition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_startingcondition.FormattingEnabled = true;
            comboBox_startingcondition.Items.AddRange(new object[] { "Standard", "Nichts", "Etwas mehr als nichts", "Vulcan", "Venus" });
            comboBox_startingcondition.Location = new Point(143, 134);
            comboBox_startingcondition.Name = "comboBox_startingcondition";
            comboBox_startingcondition.Size = new Size(201, 23);
            comboBox_startingcondition.TabIndex = 9;
            // 
            // label9
            // 
            label9.Location = new Point(6, 134);
            label9.Name = "label9";
            label9.Size = new Size(131, 23);
            label9.TabIndex = 3;
            label9.Text = "Startausrüstung";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Location = new Point(6, 105);
            label8.Name = "label8";
            label8.Size = new Size(131, 23);
            label8.TabIndex = 3;
            label8.Text = "Gravitation";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_gravity
            // 
            numericUpDown_gravity.DecimalPlaces = 2;
            numericUpDown_gravity.Location = new Point(143, 105);
            numericUpDown_gravity.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            numericUpDown_gravity.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            numericUpDown_gravity.Name = "numericUpDown_gravity";
            numericUpDown_gravity.Size = new Size(201, 23);
            numericUpDown_gravity.TabIndex = 6;
            // 
            // label_creative
            // 
            label_creative.Location = new Point(6, 19);
            label_creative.Name = "label_creative";
            label_creative.Size = new Size(131, 23);
            label_creative.TabIndex = 5;
            label_creative.Text = "Creativemode";
            label_creative.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Location = new Point(6, 162);
            label10.Name = "label10";
            label10.Size = new Size(131, 23);
            label10.TabIndex = 5;
            label10.Text = "Tag/Nacht Zyklus";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBox_gamemode
            // 
            checkBox_gamemode.AutoSize = true;
            checkBox_gamemode.Location = new Point(143, 22);
            checkBox_gamemode.Name = "checkBox_gamemode";
            checkBox_gamemode.Size = new Size(46, 19);
            checkBox_gamemode.TabIndex = 8;
            checkBox_gamemode.Text = "Aus";
            checkBox_gamemode.UseVisualStyleBackColor = true;
            // 
            // checkBox_freeze_time
            // 
            checkBox_freeze_time.AutoSize = true;
            checkBox_freeze_time.Location = new Point(143, 165);
            checkBox_freeze_time.Name = "checkBox_freeze_time";
            checkBox_freeze_time.Size = new Size(46, 19);
            checkBox_freeze_time.TabIndex = 8;
            checkBox_freeze_time.Text = "Aus";
            checkBox_freeze_time.UseVisualStyleBackColor = true;
            checkBox_freeze_time.Visible = false;
            // 
            // numericUpDown_timescale
            // 
            numericUpDown_timescale.DecimalPlaces = 6;
            numericUpDown_timescale.Increment = new decimal(new int[] { 1, 0, 0, 262144 });
            numericUpDown_timescale.Location = new Point(217, 162);
            numericUpDown_timescale.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown_timescale.Name = "numericUpDown_timescale";
            numericUpDown_timescale.Size = new Size(127, 23);
            numericUpDown_timescale.TabIndex = 7;
            numericUpDown_timescale.Visible = false;
            // 
            // button_edit_minables
            // 
            button_edit_minables.BackColor = SystemColors.ActiveCaption;
            button_edit_minables.FlatStyle = FlatStyle.Flat;
            button_edit_minables.Location = new Point(15, 323);
            button_edit_minables.Name = "button_edit_minables";
            button_edit_minables.Size = new Size(350, 44);
            button_edit_minables.TabIndex = 15;
            button_edit_minables.Text = "Abbaubare Erze Überschreiben";
            button_edit_minables.UseVisualStyleBackColor = false;
            button_edit_minables.Click += button_edit_minables_Click;
            // 
            // button_edit_deepminables
            // 
            button_edit_deepminables.BackColor = SystemColors.ActiveCaption;
            button_edit_deepminables.FlatStyle = FlatStyle.Flat;
            button_edit_deepminables.Location = new Point(371, 323);
            button_edit_deepminables.Name = "button_edit_deepminables";
            button_edit_deepminables.Size = new Size(350, 44);
            button_edit_deepminables.TabIndex = 16;
            button_edit_deepminables.Text = "Abbaubare Erze Überschreiben (Deepminer)";
            button_edit_deepminables.UseVisualStyleBackColor = false;
            button_edit_deepminables.Click += button_edit_deepminables_Click;
            // 
            // button_save
            // 
            button_save.BackColor = Color.ForestGreen;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.Location = new Point(617, 584);
            button_save.Name = "button_save";
            button_save.Size = new Size(107, 44);
            button_save.TabIndex = 17;
            button_save.Text = "Fertig";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // button_atmosphere
            // 
            button_atmosphere.BackColor = SystemColors.ActiveCaption;
            button_atmosphere.FlatStyle = FlatStyle.Flat;
            button_atmosphere.Location = new Point(15, 373);
            button_atmosphere.Name = "button_atmosphere";
            button_atmosphere.Size = new Size(350, 44);
            button_atmosphere.TabIndex = 16;
            button_atmosphere.Text = "Atmosphäre bearbeiten";
            button_atmosphere.UseVisualStyleBackColor = false;
            button_atmosphere.Click += button_atmosphere_Click;
            // 
            // button_kelvin
            // 
            button_kelvin.BackColor = SystemColors.ActiveCaption;
            button_kelvin.FlatStyle = FlatStyle.Flat;
            button_kelvin.Location = new Point(372, 373);
            button_kelvin.Name = "button_kelvin";
            button_kelvin.Size = new Size(350, 44);
            button_kelvin.TabIndex = 16;
            button_kelvin.Text = "Temperaturen bearbeiten";
            button_kelvin.UseVisualStyleBackColor = false;
            button_kelvin.Click += button_kelvin_Click;
            // 
            // button_weather
            // 
            button_weather.BackColor = SystemColors.ActiveCaption;
            button_weather.FlatStyle = FlatStyle.Flat;
            button_weather.Location = new Point(15, 423);
            button_weather.Name = "button_weather";
            button_weather.Size = new Size(350, 44);
            button_weather.TabIndex = 16;
            button_weather.Text = "Wetter bearbeiten";
            button_weather.UseVisualStyleBackColor = false;
            button_weather.Click += button_weather_Click;
            // 
            // label11
            // 
            label11.Location = new Point(15, 473);
            label11.Name = "label11";
            label11.Size = new Size(100, 32);
            label11.TabIndex = 18;
            label11.Text = "Temperaturen:";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Location = new Point(15, 527);
            label12.Name = "label12";
            label12.Size = new Size(100, 32);
            label12.TabIndex = 18;
            label12.Text = "Drücke:";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_temp
            // 
            label_temp.Location = new Point(121, 473);
            label_temp.Name = "label_temp";
            label_temp.Size = new Size(244, 32);
            label_temp.TabIndex = 18;
            label_temp.Text = "Vakuum\r\nVakuum";
            label_temp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_press
            // 
            label_press.Location = new Point(121, 527);
            label_press.Name = "label_press";
            label_press.Size = new Size(244, 32);
            label_press.TabIndex = 18;
            label_press.Text = "Vakuum\r\nVakuum";
            label_press.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_error
            // 
            label_error.AutoSize = true;
            label_error.BackColor = SystemColors.Control;
            label_error.ForeColor = Color.Red;
            label_error.Location = new Point(15, 571);
            label_error.MaximumSize = new Size(596, 100000);
            label_error.MinimumSize = new Size(596, 57);
            label_error.Name = "label_error";
            label_error.Size = new Size(596, 57);
            label_error.TabIndex = 19;
            // 
            // label14
            // 
            label14.Location = new Point(143, 162);
            label14.Name = "label14";
            label14.Size = new Size(201, 23);
            label14.TabIndex = 5;
            label14.Text = "Seit 0.2.4767.21868 inaktiv";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form_Edit_World
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(734, 642);
            Controls.Add(label_error);
            Controls.Add(label_press);
            Controls.Add(label12);
            Controls.Add(label_temp);
            Controls.Add(label11);
            Controls.Add(button_save);
            Controls.Add(button_weather);
            Controls.Add(button_kelvin);
            Controls.Add(button_atmosphere);
            Controls.Add(button_edit_deepminables);
            Controls.Add(button_edit_minables);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Edit_World";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Welt bearbeiten";
            Load += Form_Edit_World_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown_bedrock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_lava).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_gravity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_timescale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_id;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown_bedrock;
        private NumericUpDown numericUpDown_lava;
        private CheckBox checkBox_lava;
        private TextBox textBox_name_de;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox textBox_name_eng;
        private Label label4;
        private RichTextBox richTextBox_desc_eng;
        private RichTextBox richTextBox_desc_ger;
        private Label label7;
        private Label label6;
        private GroupBox groupBox3;
        private Label label8;
        private NumericUpDown numericUpDown_gravity;
        private Button button_edit_minables;
        private Button button_edit_deepminables;
        private Button button_save;
        private ComboBox comboBox_startingcondition;
        private Label label9;
        private Label label10;
        private CheckBox checkBox_freeze_time;
        private NumericUpDown numericUpDown_timescale;
        private Button button_atmosphere;
        private Button button_kelvin;
        private Button button_weather;
        private Label label11;
        private Label label12;
        private Label label_temp;
        private Label label_press;
        private Label label_error;
        private Label label_creative;
        private CheckBox checkBox_gamemode;
        private ComboBox comboBox_terrain;
        private Label label13;
        private Label label14;
    }
}