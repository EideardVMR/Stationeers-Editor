namespace Stationeers_World_Creator
{
    partial class FormEditRooms
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
            ID = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            Volumen = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { ID, columnHeader2, Volumen, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11 });
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(849, 601);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // ID
            // 
            ID.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Blöcke";
            // 
            // Volumen
            // 
            Volumen.Text = "Volumen";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Oxygen";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Nitrogen";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "CarbonDioxide";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Volatiles";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "X";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Steam";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "NitrousOxide";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Temperatur";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Druck";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.ForeColor = Color.Green;
            label1.Location = new Point(12, 631);
            label1.Name = "label1";
            label1.Size = new Size(361, 15);
            label1.TabIndex = 1;
            label1.Text = "Für diesen Raum wurden alle Atmosphäreninformationen ermittelt.";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.ForeColor = Color.Orange;
            label2.Location = new Point(12, 646);
            label2.Name = "label2";
            label2.Size = new Size(687, 15);
            label2.TabIndex = 1;
            label2.Text = "Für diesen Raum wurden  alle Atmosphäreninformationen gefunden. Leider weichen die Berechnungen zum Rauminhalt >1% ab.";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(12, 661);
            label3.Name = "label3";
            label3.Size = new Size(704, 15);
            label3.TabIndex = 1;
            label3.Text = "Für diesen Raum nicht alle (oder zu viele) Atmosphäreninformationen ermittelt. Ein bearbeiten der Atmosphäre könnte fehlschlagen.";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(12, 616);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 1;
            label4.Text = "Legende";
            // 
            // FormEditRooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 694);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormEditRooms";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEditRooms";
            Load += FormEditRooms_Load;
            ResizeEnd += FormEditRooms_SizeChanged;
            SizeChanged += FormEditRooms_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader ID;
        private ColumnHeader Volumen;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}