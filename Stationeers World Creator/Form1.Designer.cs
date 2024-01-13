namespace Stationeers_World_Creator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            textBox_stationeers_path = new TextBox();
            label_check_ws = new Label();
            label_check_ws_header = new Label();
            groupBox1 = new GroupBox();
            button_start = new Button();
            label_check_lang = new Label();
            label_check_lang_header = new Label();
            groupBox3 = new GroupBox();
            listView_worlds = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            contextMenuStrip_welten = new ContextMenuStrip(components);
            weltToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            weltBearbeitenToolStripMenuItem = new ToolStripMenuItem();
            weltEntfernenToolStripMenuItem = new ToolStripMenuItem();
            weltKopierenToolStripMenuItem = new ToolStripMenuItem();
            button_save = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            toolStripStatusLabel_Statistics = new ToolStripStatusLabel();
            groupBox2 = new GroupBox();
            listView_collections = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            contextMenuStrip_collection = new ContextMenuStrip(components);
            collectionToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            kollektionErstellenToolStripMenuItem = new ToolStripMenuItem();
            kollektionBearbeitenToolStripMenuItem = new ToolStripMenuItem();
            kollektionLöschenToolStripMenuItem = new ToolStripMenuItem();
            kollektionAktivierenToolStripMenuItem = new ToolStripMenuItem();
            kollektionDeaktivierenToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            listView_savegames = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            contextMenuStrip1 = new ContextMenuStrip(components);
            savegameNameToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            backupsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            contextMenuStrip_welten.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            contextMenuStrip_collection.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(803, 463);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(163, 217);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.BackColor = Color.FromArgb(213, 132, 1);
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.BANNER___Kopie;
            pictureBox2.Location = new Point(-1, -2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(979, 158);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label3
            // 
            label3.Location = new Point(6, 22);
            label3.Name = "label3";
            label3.Size = new Size(99, 23);
            label3.TabIndex = 10;
            label3.Text = "Stationeers Pfad";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_stationeers_path
            // 
            textBox_stationeers_path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_stationeers_path.Location = new Point(111, 22);
            textBox_stationeers_path.Name = "textBox_stationeers_path";
            textBox_stationeers_path.Size = new Size(668, 23);
            textBox_stationeers_path.TabIndex = 9;
            textBox_stationeers_path.TextChanged += textBox_stationeers_path_TextChanged;
            // 
            // label_check_ws
            // 
            label_check_ws.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_check_ws.BackColor = Color.Red;
            label_check_ws.ForeColor = Color.White;
            label_check_ws.Location = new Point(824, 194);
            label_check_ws.Name = "label_check_ws";
            label_check_ws.Size = new Size(142, 23);
            label_check_ws.TabIndex = 17;
            label_check_ws.Text = "nicht gefunden";
            label_check_ws.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_check_ws_header
            // 
            label_check_ws_header.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_check_ws_header.BackColor = Color.Red;
            label_check_ws_header.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label_check_ws_header.ForeColor = Color.White;
            label_check_ws_header.Location = new Point(824, 173);
            label_check_ws_header.Name = "label_check_ws_header";
            label_check_ws_header.Size = new Size(142, 23);
            label_check_ws_header.TabIndex = 16;
            label_check_ws_header.Text = "worldsettings.xml";
            label_check_ws_header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(button_start);
            groupBox1.Controls.Add(textBox_stationeers_path);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 173);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(785, 81);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Einstellungen";
            // 
            // button_start
            // 
            button_start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_start.BackColor = SystemColors.ActiveCaption;
            button_start.FlatStyle = FlatStyle.Flat;
            button_start.Location = new Point(684, 51);
            button_start.Name = "button_start";
            button_start.Size = new Size(95, 23);
            button_start.TabIndex = 13;
            button_start.Text = "Starten";
            button_start.UseVisualStyleBackColor = false;
            button_start.Click += button_start_Click;
            // 
            // label_check_lang
            // 
            label_check_lang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_check_lang.BackColor = Color.Red;
            label_check_lang.ForeColor = Color.White;
            label_check_lang.Location = new Point(824, 252);
            label_check_lang.Name = "label_check_lang";
            label_check_lang.Size = new Size(142, 23);
            label_check_lang.TabIndex = 21;
            label_check_lang.Text = "keine gefunden";
            label_check_lang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_check_lang_header
            // 
            label_check_lang_header.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_check_lang_header.BackColor = Color.Red;
            label_check_lang_header.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label_check_lang_header.ForeColor = Color.White;
            label_check_lang_header.Location = new Point(824, 231);
            label_check_lang_header.Name = "label_check_lang_header";
            label_check_lang_header.Size = new Size(142, 23);
            label_check_lang_header.TabIndex = 20;
            label_check_lang_header.Text = "Sprachdateien";
            label_check_lang_header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(listView_worlds);
            groupBox3.Location = new Point(6, 209);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(765, 341);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Meine Welten";
            // 
            // listView_worlds
            // 
            listView_worlds.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView_worlds.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listView_worlds.ContextMenuStrip = contextMenuStrip_welten;
            listView_worlds.Enabled = false;
            listView_worlds.FullRowSelect = true;
            listView_worlds.Location = new Point(7, 22);
            listView_worlds.Name = "listView_worlds";
            listView_worlds.Size = new Size(752, 313);
            listView_worlds.TabIndex = 0;
            listView_worlds.UseCompatibleStateImageBehavior = false;
            listView_worlds.View = View.Details;
            listView_worlds.DoubleClick += listView_worlds_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Id";
            columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Name";
            columnHeader2.Width = 450;
            // 
            // contextMenuStrip_welten
            // 
            contextMenuStrip_welten.Items.AddRange(new ToolStripItem[] { weltToolStripMenuItem, toolStripSeparator1, weltBearbeitenToolStripMenuItem, weltEntfernenToolStripMenuItem, weltKopierenToolStripMenuItem });
            contextMenuStrip_welten.Name = "contextMenuStrip1";
            contextMenuStrip_welten.Size = new Size(181, 98);
            contextMenuStrip_welten.Opening += contextMenuStrip_welten_Opening;
            // 
            // weltToolStripMenuItem
            // 
            weltToolStripMenuItem.Enabled = false;
            weltToolStripMenuItem.Name = "weltToolStripMenuItem";
            weltToolStripMenuItem.Size = new Size(180, 22);
            weltToolStripMenuItem.Text = "toolStripMenuItem1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // weltBearbeitenToolStripMenuItem
            // 
            weltBearbeitenToolStripMenuItem.Name = "weltBearbeitenToolStripMenuItem";
            weltBearbeitenToolStripMenuItem.Size = new Size(180, 22);
            weltBearbeitenToolStripMenuItem.Text = "Welt bearbeiten";
            weltBearbeitenToolStripMenuItem.Click += weltBearbeitenToolStripMenuItem_Click;
            // 
            // weltEntfernenToolStripMenuItem
            // 
            weltEntfernenToolStripMenuItem.Name = "weltEntfernenToolStripMenuItem";
            weltEntfernenToolStripMenuItem.Size = new Size(180, 22);
            weltEntfernenToolStripMenuItem.Text = "Welt entfernen";
            weltEntfernenToolStripMenuItem.Click += weltEntfernenToolStripMenuItem_Click;
            // 
            // weltKopierenToolStripMenuItem
            // 
            weltKopierenToolStripMenuItem.Name = "weltKopierenToolStripMenuItem";
            weltKopierenToolStripMenuItem.Size = new Size(180, 22);
            weltKopierenToolStripMenuItem.Text = "Welt kopieren";
            // 
            // button_save
            // 
            button_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_save.BackColor = SystemColors.ActiveCaption;
            button_save.Enabled = false;
            button_save.FlatStyle = FlatStyle.Flat;
            button_save.Location = new Point(803, 786);
            button_save.Name = "button_save";
            button_save.Size = new Size(163, 58);
            button_save.TabIndex = 2;
            button_save.Text = "Speichern";
            button_save.UseVisualStyleBackColor = false;
            button_save.Click += button_save_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2, toolStripStatusLabel_Statistics });
            statusStrip1.Location = new Point(0, 847);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(978, 22);
            statusStrip1.TabIndex = 21;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(75, 17);
            toolStripStatusLabel1.Text = "Version: 0.1.0";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(681, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel_Statistics
            // 
            toolStripStatusLabel_Statistics.BackColor = Color.Brown;
            toolStripStatusLabel_Statistics.ForeColor = Color.White;
            toolStripStatusLabel_Statistics.Name = "toolStripStatusLabel_Statistics";
            toolStripStatusLabel_Statistics.Size = new Size(176, 17);
            toolStripStatusLabel_Statistics.Text = "Statistikdaten übermitteln: Aktiv";
            toolStripStatusLabel_Statistics.TextAlign = ContentAlignment.MiddleRight;
            toolStripStatusLabel_Statistics.Click += toolStripStatusLabel_Statistics_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(listView_collections);
            groupBox2.Location = new Point(6, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(765, 197);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Meine Kollektionen";
            // 
            // listView_collections
            // 
            listView_collections.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView_collections.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader3 });
            listView_collections.ContextMenuStrip = contextMenuStrip_collection;
            listView_collections.Enabled = false;
            listView_collections.FullRowSelect = true;
            listView_collections.Location = new Point(6, 22);
            listView_collections.Name = "listView_collections";
            listView_collections.Size = new Size(753, 169);
            listView_collections.TabIndex = 1;
            listView_collections.UseCompatibleStateImageBehavior = false;
            listView_collections.View = View.Details;
            listView_collections.DoubleClick += listView_collections_DoubleClick;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Name";
            columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Autor";
            columnHeader5.Width = 250;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Version";
            columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Welten";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status";
            // 
            // contextMenuStrip_collection
            // 
            contextMenuStrip_collection.Items.AddRange(new ToolStripItem[] { collectionToolStripMenuItem, toolStripSeparator2, kollektionErstellenToolStripMenuItem, kollektionBearbeitenToolStripMenuItem, kollektionLöschenToolStripMenuItem, kollektionAktivierenToolStripMenuItem, kollektionDeaktivierenToolStripMenuItem });
            contextMenuStrip_collection.Name = "contextMenuStrip_collection";
            contextMenuStrip_collection.Size = new Size(195, 142);
            contextMenuStrip_collection.Opening += contextMenuStrip_collection_Opening;
            // 
            // collectionToolStripMenuItem
            // 
            collectionToolStripMenuItem.Enabled = false;
            collectionToolStripMenuItem.Name = "collectionToolStripMenuItem";
            collectionToolStripMenuItem.Size = new Size(194, 22);
            collectionToolStripMenuItem.Text = "Collection";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(191, 6);
            // 
            // kollektionErstellenToolStripMenuItem
            // 
            kollektionErstellenToolStripMenuItem.Name = "kollektionErstellenToolStripMenuItem";
            kollektionErstellenToolStripMenuItem.Size = new Size(194, 22);
            kollektionErstellenToolStripMenuItem.Text = "Kollektion erstellen";
            kollektionErstellenToolStripMenuItem.Click += kollektionErstellenToolStripMenuItem_Click;
            // 
            // kollektionBearbeitenToolStripMenuItem
            // 
            kollektionBearbeitenToolStripMenuItem.Name = "kollektionBearbeitenToolStripMenuItem";
            kollektionBearbeitenToolStripMenuItem.Size = new Size(194, 22);
            kollektionBearbeitenToolStripMenuItem.Text = "Kollektion bearbeiten";
            kollektionBearbeitenToolStripMenuItem.Click += kollektionBearbeitenToolStripMenuItem_Click;
            // 
            // kollektionLöschenToolStripMenuItem
            // 
            kollektionLöschenToolStripMenuItem.Name = "kollektionLöschenToolStripMenuItem";
            kollektionLöschenToolStripMenuItem.Size = new Size(194, 22);
            kollektionLöschenToolStripMenuItem.Text = "Kollektion löschen";
            kollektionLöschenToolStripMenuItem.Click += kollektionLöschenToolStripMenuItem_Click;
            // 
            // kollektionAktivierenToolStripMenuItem
            // 
            kollektionAktivierenToolStripMenuItem.Name = "kollektionAktivierenToolStripMenuItem";
            kollektionAktivierenToolStripMenuItem.Size = new Size(194, 22);
            kollektionAktivierenToolStripMenuItem.Text = "Kollektion aktivieren";
            kollektionAktivierenToolStripMenuItem.Click += kollektionAktivierenToolStripMenuItem_Click;
            // 
            // kollektionDeaktivierenToolStripMenuItem
            // 
            kollektionDeaktivierenToolStripMenuItem.Name = "kollektionDeaktivierenToolStripMenuItem";
            kollektionDeaktivierenToolStripMenuItem.Size = new Size(194, 22);
            kollektionDeaktivierenToolStripMenuItem.Text = "Kollektion deaktivieren";
            kollektionDeaktivierenToolStripMenuItem.Click += kollektionDeaktivierenToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Enabled = false;
            tabControl1.Location = new Point(12, 260);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(785, 584);
            tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(777, 556);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Welten";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(listView_savegames);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(777, 556);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Savegames";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_savegames
            // 
            listView_savegames.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView_savegames.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listView_savegames.ContextMenuStrip = contextMenuStrip1;
            listView_savegames.FullRowSelect = true;
            listView_savegames.Location = new Point(6, 6);
            listView_savegames.Name = "listView_savegames";
            listView_savegames.Size = new Size(765, 544);
            listView_savegames.TabIndex = 0;
            listView_savegames.UseCompatibleStateImageBehavior = false;
            listView_savegames.View = View.Details;
            listView_savegames.SelectedIndexChanged += listView_savegames_SelectedIndexChanged;
            listView_savegames.DoubleClick += listView_savegames_DoubleClick;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Name";
            columnHeader8.Width = 260;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Version";
            columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Spieltage";
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Pfad";
            columnHeader11.Width = 260;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Geändert";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { savegameNameToolStripMenuItem, toolStripSeparator3, backupsToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(161, 54);
            // 
            // savegameNameToolStripMenuItem
            // 
            savegameNameToolStripMenuItem.Name = "savegameNameToolStripMenuItem";
            savegameNameToolStripMenuItem.Size = new Size(160, 22);
            savegameNameToolStripMenuItem.Text = "SavegameName";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(157, 6);
            // 
            // backupsToolStripMenuItem
            // 
            backupsToolStripMenuItem.Name = "backupsToolStripMenuItem";
            backupsToolStripMenuItem.Size = new Size(160, 22);
            backupsToolStripMenuItem.Text = "Backups";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 869);
            Controls.Add(tabControl1);
            Controls.Add(label_check_lang);
            Controls.Add(label_check_lang_header);
            Controls.Add(statusStrip1);
            Controls.Add(label_check_ws);
            Controls.Add(button_save);
            Controls.Add(label_check_ws_header);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(0, 701);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stationeers Editor";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            contextMenuStrip_welten.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            contextMenuStrip_collection.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label3;
        private TextBox textBox_stationeers_path;
        private Label label_world_uuid;
        private Label label_check_ws;
        private Label label_check_ws_header;
        private GroupBox groupBox1;
        private Label label_check_lang;
        private Label label_check_lang_header;
        private GroupBox groupBox3;
        private ListView listView_worlds;
        private ColumnHeader columnHeader1;
        private Button button_save;
        private ColumnHeader columnHeader2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ContextMenuStrip contextMenuStrip_welten;
        private ToolStripMenuItem weltToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem weltBearbeitenToolStripMenuItem;
        private GroupBox groupBox2;
        private ListView listView_collections;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ContextMenuStrip contextMenuStrip_collection;
        private ToolStripMenuItem weltEntfernenToolStripMenuItem;
        private ToolStripMenuItem weltKopierenToolStripMenuItem;
        private ToolStripMenuItem collectionToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem kollektionErstellenToolStripMenuItem;
        private ToolStripMenuItem kollektionBearbeitenToolStripMenuItem;
        private ToolStripMenuItem kollektionLöschenToolStripMenuItem;
        private Button button_start;
        private ColumnHeader columnHeader7;
        private ToolStripMenuItem kollektionAktivierenToolStripMenuItem;
        private ToolStripMenuItem kollektionDeaktivierenToolStripMenuItem;
        private ColumnHeader columnHeader3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListView listView_savegames;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem savegameNameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem backupsToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel_Statistics;
    }
}
