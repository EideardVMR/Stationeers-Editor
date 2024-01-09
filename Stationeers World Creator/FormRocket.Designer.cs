namespace Stationeers_World_Creator
{
    partial class FormRocket
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
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            groupBox1 = new GroupBox();
            label_blocker = new Label();
            button_reset = new Button();
            numericUpDown_progress = new NumericUpDown();
            comboBox_position = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            comboBox_mode = new ComboBox();
            label2 = new Label();
            comboBox_state = new ComboBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_progress).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(465, 399);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Name";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Position";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Modus";
            columnHeader4.Width = 100;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(label_blocker);
            groupBox1.Controls.Add(button_reset);
            groupBox1.Controls.Add(numericUpDown_progress);
            groupBox1.Controls.Add(comboBox_position);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBox_mode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox_state);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(483, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 399);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Raketeninformationen";
            // 
            // label_blocker
            // 
            label_blocker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_blocker.Location = new Point(6, 19);
            label_blocker.Name = "label_blocker";
            label_blocker.Size = new Size(293, 374);
            label_blocker.TabIndex = 4;
            label_blocker.Text = "keine Rakete ausgewählt";
            label_blocker.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_reset
            // 
            button_reset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_reset.BackColor = SystemColors.ActiveCaption;
            button_reset.FlatStyle = FlatStyle.Flat;
            button_reset.Location = new Point(6, 354);
            button_reset.Name = "button_reset";
            button_reset.Size = new Size(293, 39);
            button_reset.TabIndex = 3;
            button_reset.Text = "Auf Landingpad setzen";
            button_reset.UseVisualStyleBackColor = false;
            button_reset.Click += button_reset_Click;
            // 
            // numericUpDown_progress
            // 
            numericUpDown_progress.Location = new Point(112, 106);
            numericUpDown_progress.Name = "numericUpDown_progress";
            numericUpDown_progress.Size = new Size(155, 23);
            numericUpDown_progress.TabIndex = 2;
            numericUpDown_progress.ValueChanged += numericUpDown_progress_ValueChanged;
            // 
            // comboBox_position
            // 
            comboBox_position.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_position.FormattingEnabled = true;
            comboBox_position.Location = new Point(112, 77);
            comboBox_position.Name = "comboBox_position";
            comboBox_position.Size = new Size(187, 23);
            comboBox_position.TabIndex = 1;
            comboBox_position.SelectedIndexChanged += comboBox_position_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Location = new Point(273, 106);
            label5.Name = "label5";
            label5.Size = new Size(26, 23);
            label5.TabIndex = 0;
            label5.Text = "%";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(6, 106);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            label4.Text = "Fortschritt";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(6, 77);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 0;
            label3.Text = "Position";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_mode
            // 
            comboBox_mode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_mode.FormattingEnabled = true;
            comboBox_mode.Location = new Point(112, 48);
            comboBox_mode.Name = "comboBox_mode";
            comboBox_mode.Size = new Size(187, 23);
            comboBox_mode.TabIndex = 1;
            comboBox_mode.SelectedIndexChanged += comboBox_mode_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            label2.Text = "Modus";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox_state
            // 
            comboBox_state.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_state.FormattingEnabled = true;
            comboBox_state.Location = new Point(112, 19);
            comboBox_state.Name = "comboBox_state";
            comboBox_state.Size = new Size(187, 23);
            comboBox_state.TabIndex = 1;
            comboBox_state.SelectedIndexChanged += comboBox_state_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Status";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormRocket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 423);
            Controls.Add(groupBox1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormRocket";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormRocket";
            Load += FormRocket_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_progress).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private GroupBox groupBox1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ComboBox comboBox_state;
        private Label label1;
        private NumericUpDown numericUpDown_progress;
        private ComboBox comboBox_position;
        private Label label4;
        private Label label3;
        private ComboBox comboBox_mode;
        private Label label2;
        private Button button_reset;
        private Label label_blocker;
        private Label label5;
    }
}