namespace Stationeers_World_Creator
{
    partial class FormThingList
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
            components = new System.ComponentModel.Container();
            listView1 = new ListView();
            ItemHash = new ColumnHeader();
            Anzahl = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            itemNameToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            entfernenToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { ItemHash, Anzahl });
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(12, 41);
            listView1.Name = "listView1";
            listView1.Size = new Size(776, 397);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // ItemHash
            // 
            ItemHash.Text = "ItemHash";
            ItemHash.Width = 300;
            // 
            // Anzahl
            // 
            Anzahl.Text = "Anzahl";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { itemNameToolStripMenuItem, toolStripSeparator1, entfernenToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(149, 54);
            // 
            // itemNameToolStripMenuItem
            // 
            itemNameToolStripMenuItem.Name = "itemNameToolStripMenuItem";
            itemNameToolStripMenuItem.Size = new Size(148, 22);
            itemNameToolStripMenuItem.Text = "ItemName";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(145, 6);
            // 
            // entfernenToolStripMenuItem
            // 
            entfernenToolStripMenuItem.Name = "entfernenToolStripMenuItem";
            entfernenToolStripMenuItem.Size = new Size(148, 22);
            entfernenToolStripMenuItem.Text = "Alle Entfernen";
            entfernenToolStripMenuItem.Click += entfernenToolStripMenuItem_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Suche";
            textBox1.Size = new Size(776, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // FormThingList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormThingList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormThingList";
            Load += FormThingList_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader ItemHash;
        private ColumnHeader Anzahl;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem itemNameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem entfernenToolStripMenuItem;
    }
}