namespace Stationeers_World_Creator
{
    partial class FormPlayerEdit
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            groupBox1 = new GroupBox();
            label8 = new Label();
            button_restore = new Button();
            comboBox1 = new ComboBox();
            numericUpDown_toxic = new NumericUpDown();
            numericUpDown_lung = new NumericUpDown();
            label7 = new Label();
            numericUpDown_hydration = new NumericUpDown();
            label6 = new Label();
            numericUpDown_starvation = new NumericUpDown();
            label5 = new Label();
            numericUpDown_trinken = new NumericUpDown();
            label4 = new Label();
            numericUpDown_essen = new NumericUpDown();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_toxic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_lung).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_hydration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_starvation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_trinken).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_essen).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader7, columnHeader2, columnHeader3, columnHeader6, columnHeader8, columnHeader9, columnHeader10 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(710, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Status";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Essen";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Trinken";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Verhungern";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Verdursten";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Lungenschaden";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Vergiftung";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(button_restore);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(numericUpDown_toxic);
            groupBox1.Controls.Add(numericUpDown_lung);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(numericUpDown_hydration);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(numericUpDown_starvation);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(numericUpDown_trinken);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(numericUpDown_essen);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(728, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 426);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Spielerinfo";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.Location = new Point(6, 22);
            label8.Name = "label8";
            label8.Size = new Size(288, 398);
            label8.TabIndex = 4;
            label8.Text = "Keinen Spieler ausgewählt";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_restore
            // 
            button_restore.BackColor = SystemColors.ActiveCaption;
            button_restore.FlatStyle = FlatStyle.Flat;
            button_restore.Location = new Point(6, 376);
            button_restore.Name = "button_restore";
            button_restore.Size = new Size(288, 44);
            button_restore.TabIndex = 3;
            button_restore.Text = "Vollständig wiederherstellen";
            button_restore.UseVisualStyleBackColor = false;
            button_restore.Click += button_restore_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Alive", "Dead" });
            comboBox1.Location = new Point(154, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(140, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown_toxic
            // 
            numericUpDown_toxic.Location = new Point(154, 196);
            numericUpDown_toxic.Name = "numericUpDown_toxic";
            numericUpDown_toxic.Size = new Size(113, 23);
            numericUpDown_toxic.TabIndex = 1;
            numericUpDown_toxic.ValueChanged += numericUpDown_toxic_ValueChanged;
            // 
            // numericUpDown_lung
            // 
            numericUpDown_lung.Location = new Point(154, 167);
            numericUpDown_lung.Name = "numericUpDown_lung";
            numericUpDown_lung.Size = new Size(113, 23);
            numericUpDown_lung.TabIndex = 1;
            numericUpDown_lung.ValueChanged += numericUpDown_lung_ValueChanged;
            // 
            // label7
            // 
            label7.Location = new Point(6, 196);
            label7.Name = "label7";
            label7.Size = new Size(142, 23);
            label7.TabIndex = 0;
            label7.Text = "Vergiftung";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_hydration
            // 
            numericUpDown_hydration.Location = new Point(154, 138);
            numericUpDown_hydration.Name = "numericUpDown_hydration";
            numericUpDown_hydration.Size = new Size(113, 23);
            numericUpDown_hydration.TabIndex = 1;
            numericUpDown_hydration.ValueChanged += numericUpDown_hydration_ValueChanged;
            // 
            // label6
            // 
            label6.Location = new Point(6, 167);
            label6.Name = "label6";
            label6.Size = new Size(142, 23);
            label6.TabIndex = 0;
            label6.Text = "Lungenschaden";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_starvation
            // 
            numericUpDown_starvation.Location = new Point(154, 109);
            numericUpDown_starvation.Name = "numericUpDown_starvation";
            numericUpDown_starvation.Size = new Size(113, 23);
            numericUpDown_starvation.TabIndex = 1;
            numericUpDown_starvation.ValueChanged += numericUpDown_starvation_ValueChanged;
            // 
            // label5
            // 
            label5.Location = new Point(6, 138);
            label5.Name = "label5";
            label5.Size = new Size(142, 23);
            label5.TabIndex = 0;
            label5.Text = "Verdursten";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_trinken
            // 
            numericUpDown_trinken.Location = new Point(154, 80);
            numericUpDown_trinken.Name = "numericUpDown_trinken";
            numericUpDown_trinken.Size = new Size(113, 23);
            numericUpDown_trinken.TabIndex = 1;
            numericUpDown_trinken.ValueChanged += numericUpDown_trinken_ValueChanged;
            // 
            // label4
            // 
            label4.Location = new Point(6, 109);
            label4.Name = "label4";
            label4.Size = new Size(142, 23);
            label4.TabIndex = 0;
            label4.Text = "Verhungern";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_essen
            // 
            numericUpDown_essen.Location = new Point(154, 51);
            numericUpDown_essen.Name = "numericUpDown_essen";
            numericUpDown_essen.Size = new Size(113, 23);
            numericUpDown_essen.TabIndex = 1;
            numericUpDown_essen.ValueChanged += numericUpDown_essen_ValueChanged;
            // 
            // label3
            // 
            label3.Location = new Point(6, 80);
            label3.Name = "label3";
            label3.Size = new Size(142, 23);
            label3.TabIndex = 0;
            label3.Text = "Trinken";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(6, 22);
            label2.Name = "label2";
            label2.Size = new Size(142, 23);
            label2.TabIndex = 0;
            label2.Text = "Status";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(6, 51);
            label1.Name = "label1";
            label1.Size = new Size(142, 23);
            label1.TabIndex = 0;
            label1.Text = "Essen";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Location = new Point(273, 51);
            label9.Name = "label9";
            label9.Size = new Size(21, 23);
            label9.TabIndex = 0;
            label9.Text = "%";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Location = new Point(273, 80);
            label10.Name = "label10";
            label10.Size = new Size(21, 23);
            label10.TabIndex = 0;
            label10.Text = "%";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Location = new Point(273, 109);
            label11.Name = "label11";
            label11.Size = new Size(21, 23);
            label11.TabIndex = 0;
            label11.Text = "%";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Location = new Point(273, 138);
            label12.Name = "label12";
            label12.Size = new Size(21, 23);
            label12.TabIndex = 0;
            label12.Text = "%";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            label13.Location = new Point(273, 167);
            label13.Name = "label13";
            label13.Size = new Size(21, 23);
            label13.TabIndex = 0;
            label13.Text = "%";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.Location = new Point(273, 196);
            label14.Name = "label14";
            label14.Size = new Size(21, 23);
            label14.TabIndex = 0;
            label14.Text = "%";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormPlayerEdit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 450);
            Controls.Add(groupBox1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormPlayerEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormPlayerEdit";
            Load += FormPlayerEdit_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_toxic).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_lung).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_hydration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_starvation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_trinken).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_essen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox groupBox1;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ComboBox comboBox1;
        private NumericUpDown numericUpDown_toxic;
        private NumericUpDown numericUpDown_lung;
        private Label label7;
        private NumericUpDown numericUpDown_hydration;
        private Label label6;
        private NumericUpDown numericUpDown_starvation;
        private Label label5;
        private NumericUpDown numericUpDown_trinken;
        private Label label4;
        private NumericUpDown numericUpDown_essen;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button_restore;
        private Label label8;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
    }
}