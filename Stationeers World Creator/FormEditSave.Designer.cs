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
            SuspendLayout();
            // 
            // button_rooms
            // 
            button_rooms.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_rooms.BackColor = SystemColors.ActiveCaption;
            button_rooms.FlatStyle = FlatStyle.Flat;
            button_rooms.Location = new Point(12, 12);
            button_rooms.Name = "button_rooms";
            button_rooms.Size = new Size(163, 58);
            button_rooms.TabIndex = 3;
            button_rooms.Text = "Räume";
            button_rooms.UseVisualStyleBackColor = false;
            button_rooms.Click += button_rooms_Click;
            // 
            // FormEditSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 621);
            Controls.Add(button_rooms);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "FormEditSave";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormEditSave";
            Load += FormEditSave_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button_rooms;
    }
}