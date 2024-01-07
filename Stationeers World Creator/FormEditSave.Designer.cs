namespace Stationeers_World_Creator
{
    partial class FormEditSave
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
            button_rooms = new Button();
            comboBox_difficulty = new ComboBox();
            groupBox1 = new GroupBox();
            checkBox_research = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox_world = new ComboBox();
            groupBox2 = new GroupBox();
            textBox_seed = new TextBox();
            label5 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button_rooms
            // 
            button_rooms.BackColor = SystemColors.ActiveCaption;
            button_rooms.FlatStyle = FlatStyle.Flat;
            button_rooms.Location = new Point(570, 130);
            button_rooms.Name = "button_rooms";
            button_rooms.Size = new Size(176, 58);
            button_rooms.TabIndex = 3;
            button_rooms.Text = "Räume";
            button_rooms.UseVisualStyleBackColor = false;
            button_rooms.Click += button_rooms_Click;
            // 
            // comboBox_difficulty
            // 
            comboBox_difficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_difficulty.FormattingEnabled = true;
            comboBox_difficulty.Location = new Point(158, 19);
            comboBox_difficulty.Name = "comboBox_difficulty";
            comboBox_difficulty.Size = new Size(189, 23);
            comboBox_difficulty.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox_research);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBox_world);
            groupBox1.Controls.Add(comboBox_difficulty);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 112);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Optionen";
            // 
            // checkBox_research
            // 
            checkBox_research.AutoSize = true;
            checkBox_research.Location = new Point(158, 77);
            checkBox_research.Name = "checkBox_research";
            checkBox_research.Size = new Size(46, 19);
            checkBox_research.TabIndex = 6;
            checkBox_research.Text = "Aus";
            checkBox_research.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(146, 19);
            label3.TabIndex = 5;
            label3.Text = "Forschung";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(146, 23);
            label2.TabIndex = 5;
            label2.Text = "Welt";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(146, 23);
            label1.TabIndex = 0;
            label1.Text = "Schwierigkeitsgrad";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_world
            // 
            comboBox_world.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_world.FormattingEnabled = true;
            comboBox_world.Location = new Point(158, 48);
            comboBox_world.Name = "comboBox_world";
            comboBox_world.Size = new Size(189, 23);
            comboBox_world.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox_seed);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(382, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(364, 112);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Welt";
            // 
            // textBox_seed
            // 
            textBox_seed.Location = new Point(158, 19);
            textBox_seed.Name = "textBox_seed";
            textBox_seed.Size = new Size(200, 23);
            textBox_seed.TabIndex = 0;
            // 
            // label5
            // 
            label5.ForeColor = Color.FromArgb(255, 128, 0);
            label5.Location = new Point(6, 45);
            label5.Name = "label5";
            label5.Size = new Size(352, 64);
            label5.TabIndex = 0;
            label5.Text = "Das ändern des Seed führt zu löschung der \"world.bin\".\r\nDiese Datei speichert das aktuell erstellte Terrain.\r\nDas Savegame wird länger zum laden benötigen, da das Terrain neu erstellt werden muss.\r\n";
            // 
            // label4
            // 
            label4.Location = new Point(6, 18);
            label4.Name = "label4";
            label4.Size = new Size(146, 23);
            label4.TabIndex = 0;
            label4.Text = "Weltseed";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(382, 130);
            button1.Name = "button1";
            button1.Size = new Size(182, 58);
            button1.TabIndex = 3;
            button1.Text = "Raketen";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button_rooms_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(194, 130);
            button2.Name = "button2";
            button2.Size = new Size(182, 58);
            button2.TabIndex = 3;
            button2.Text = "Gasnetzwerke / Tanks";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button_rooms_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(12, 130);
            button3.Name = "button3";
            button3.Size = new Size(176, 58);
            button3.TabIndex = 3;
            button3.Text = "Gegenstände";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button_rooms_Click;
            // 
            // FormEditSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(761, 201);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button_rooms);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormEditSave";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEditSave";
            Load += FormEditSave_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_rooms;
        private ComboBox comboBox_difficulty;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private ComboBox comboBox_world;
        private CheckBox checkBox_research;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox textBox_seed;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label5;
    }
}