namespace Stationeers_World_Creator
{
    partial class FormNewCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewCollection));
            label1 = new Label();
            textBox_name = new TextBox();
            button_save = new Button();
            button_abort = new Button();
            label2 = new Label();
            textBox_author = new TextBox();
            textBox_version = new TextBox();
            label3 = new Label();
            label4 = new Label();
            richTextBox_description = new RichTextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 0;
            label1.Text = "Name der Kollektion";
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(12, 27);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(299, 23);
            textBox_name.TabIndex = 1;
            textBox_name.TextChanged += textBox_name_TextChanged;
            // 
            // button_save
            // 
            button_save.Location = new Point(236, 360);
            button_save.Name = "button_save";
            button_save.Size = new Size(75, 23);
            button_save.TabIndex = 2;
            button_save.Text = "Speichern";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // button_abort
            // 
            button_abort.Location = new Point(12, 360);
            button_abort.Name = "button_abort";
            button_abort.Size = new Size(75, 23);
            button_abort.TabIndex = 3;
            button_abort.Text = "Abbrechen";
            button_abort.UseVisualStyleBackColor = true;
            button_abort.Click += button_abort_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Author";
            // 
            // textBox_author
            // 
            textBox_author.Location = new Point(12, 71);
            textBox_author.Name = "textBox_author";
            textBox_author.Size = new Size(299, 23);
            textBox_author.TabIndex = 5;
            textBox_author.TextChanged += textBox_author_TextChanged;
            // 
            // textBox_version
            // 
            textBox_version.Location = new Point(12, 115);
            textBox_version.Name = "textBox_version";
            textBox_version.Size = new Size(299, 23);
            textBox_version.TabIndex = 7;
            textBox_version.Text = "0.0.0";
            textBox_version.TextChanged += textBox_version_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 6;
            label3.Text = "Version";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 141);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 8;
            label4.Text = "Beschreibung";
            // 
            // richTextBox_description
            // 
            richTextBox_description.BorderStyle = BorderStyle.None;
            richTextBox_description.Location = new Point(12, 159);
            richTextBox_description.Name = "richTextBox_description";
            richTextBox_description.Size = new Size(299, 96);
            richTextBox_description.TabIndex = 9;
            richTextBox_description.Text = "";
            richTextBox_description.TextChanged += richTextBox_description_TextChanged;
            // 
            // label5
            // 
            label5.Location = new Point(12, 258);
            label5.Name = "label5";
            label5.Size = new Size(299, 99);
            label5.TabIndex = 10;
            label5.Text = resources.GetString("label5.Text");
            // 
            // FormNewCollection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 391);
            Controls.Add(label5);
            Controls.Add(richTextBox_description);
            Controls.Add(label4);
            Controls.Add(textBox_version);
            Controls.Add(label3);
            Controls.Add(textBox_author);
            Controls.Add(label2);
            Controls.Add(button_abort);
            Controls.Add(button_save);
            Controls.Add(textBox_name);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormNewCollection";
            Text = "Kollektion erstellen/bearbeiten";
            Load += FormNewCollection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_name;
        private Button button_save;
        private Button button_abort;
        private Label label2;
        private TextBox textBox_author;
        private TextBox textBox_version;
        private Label label3;
        private Label label4;
        private RichTextBox richTextBox_description;
        private Label label5;
    }
}