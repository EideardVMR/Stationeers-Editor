namespace Stationeers_World_Creator
{
    partial class FormListNetworkTanks
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
            ListViewGroup listViewGroup1 = new ListViewGroup("Netzwerk", HorizontalAlignment.Left);
            ListViewGroup listViewGroup2 = new ListViewGroup("Tanks", HorizontalAlignment.Left);
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listView1.FullRowSelect = true;
            listViewGroup1.Header = "Netzwerk";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "Tanks";
            listViewGroup2.Name = "listViewGroup2";
            listView1.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2 });
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(980, 426);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Volumen";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Oxygen";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Nitrogen";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "CarbonDioxide";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Volatiles";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "X";
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Steam";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "NitrousOxide";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Temperatur";
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Druck";
            // 
            // FormListNetworkTanks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 450);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormListNetworkTanks";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormListNetworkTanks";
            ResizeEnd += FormListNetworkTanks_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
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
        private ColumnHeader columnHeader12;
    }
}