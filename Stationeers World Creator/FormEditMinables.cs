using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Stationeers_World_Creator
{
    public partial class FormEditMinables : Form
    {
        World world = null;
        bool deepminable = false;
        public FormEditMinables(World world, bool deepminable = false)
        {
            this.world = world;
            this.deepminable = deepminable;
            InitializeComponent();
        }

        private void FormEditMinables_Load(object sender, EventArgs e)
        {
            PrintMinables();
        }

        void PrintMinables()
        {
            this.AutoSize = true;

            this.SuspendLayout();

            this.Controls.Clear();

            ComboBox comboBox_minable_list = new ComboBox();
            comboBox_minable_list.FormattingEnabled = true;
            comboBox_minable_list.Items.AddRange(new object[] { "Iron", "Gold", "Coal", "Copper", "Uranium", "Silver", "Nickel", "Lead", "Silicon", "Cobalt", "Ice", "Oxite", "Volatiles", "Nitrice" });
            comboBox_minable_list.Name = "comboBox_minable_list";
            comboBox_minable_list.Size = new Size(170, 23);
            comboBox_minable_list.TabIndex = 1;
            // Erst am Ende hinzufügen zu Groupbox.

            Button button_add_minable = new Button();
            button_add_minable.Name = "button_add_minable";
            button_add_minable.Size = new Size(152, 23);
            button_add_minable.TabIndex = 14;
            button_add_minable.Text = "Hinzufügen";
            button_add_minable.UseVisualStyleBackColor = true;
            button_add_minable.Click += (object s, EventArgs e) =>
            {
                if(comboBox_minable_list.SelectedItem == null)
                {
                    MessageBox.Show("Wähle ein Erz aus", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (deepminable)
                { world.AddDeepMinable(comboBox_minable_list.SelectedItem.ToString());
                } else { world.AddMinable(comboBox_minable_list.SelectedItem.ToString()); }
                
                PrintMinables();
            };
            // Erst am Ende hinzufügen zu Groupbox.

            Label header1 = new Label();
            header1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header1.Location = new Point(19, 19);
            header1.Name = "label9";
            header1.Size = new Size(100, 23);
            header1.TabIndex = 0;
            header1.Text = "Erz";
            header1.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header1);

            Label header2 = new Label();
            header2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header2.Location = new Point(195, 19);
            header2.Name = "label10";
            header2.Size = new Size(100, 23);
            header2.TabIndex = 0;
            header2.Text = "Rarität";
            header2.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header2);

            Label header3 = new Label();
            header3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header3.Location = new Point(334, 19);
            header3.Name = "label11";
            header3.Size = new Size(132, 23);
            header3.TabIndex = 0;
            header3.Text = "Erz pro Vorkommen";
            header3.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header3);

            Label header4 = new Label();
            header4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header4.Location = new Point(486, 19);
            header4.Name = "label12";
            header4.Size = new Size(214, 23);
            header4.TabIndex = 0;
            header4.Text = "Vorkommen pro Ader";
            header4.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header4);

            // Minables
            int startY = 45;

            List<Mineable> minelist;
            if(deepminable)
            { minelist = world.DeepMineables;
            } else { minelist = world.Mineables; }

            foreach (Mineable m in minelist)
            {
                comboBox_minable_list.Items.Remove(m.DisplayName);

                Label label_orename = new Label();
                NumericUpDown numericUpDown1 = new NumericUpDown();
                NumericUpDown numericUpDown2 = new NumericUpDown();
                Label label_slash2 = new Label();
                NumericUpDown numericUpDown3 = new NumericUpDown();
                NumericUpDown numericUpDown4 = new NumericUpDown();
                Label label_slash1 = new Label();
                NumericUpDown numericUpDown5 = new NumericUpDown();
                Button button1 = new Button();

                label_orename.Location = new Point(19, startY);
                label_orename.Name = "label_orename1";
                label_orename.Size = new Size(152, 23);
                label_orename.TabIndex = 1;
                label_orename.Text = m.DisplayName;
                this.Controls.Add(label_orename);

                numericUpDown1.Location = new Point(195, startY);
                numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
                numericUpDown1.Name = "numericUpDown1";
                numericUpDown1.Size = new Size(100, 23);
                numericUpDown1.Value = (decimal)m.Rarity;
                numericUpDown1.TabIndex = 2;
                numericUpDown1.MouseWheel += (object s, MouseEventArgs e) =>
                {
                    ((HandledMouseEventArgs)e).Handled = true;
                };
                numericUpDown1.ValueChanged += (object s, EventArgs e) =>
                {
                    m.Rarity = (int)((NumericUpDown)s).Value;
                };
                this.Controls.Add(numericUpDown1);

                numericUpDown2.Location = new Point(327, startY);
                numericUpDown2.Name = "numericUpDown2";
                numericUpDown2.Size = new Size(56, 23);
                numericUpDown2.Value = (decimal)m.MinDropQuantity;
                numericUpDown2.Maximum = (decimal)m.MaxDropQuantity;
                numericUpDown2.TabIndex = 2;
                numericUpDown2.ValueChanged += (object s, EventArgs e) =>
                {
                    numericUpDown3.Minimum = numericUpDown2.Value;
                };
                numericUpDown2.MouseWheel += (object s, MouseEventArgs e) =>
                {
                    ((HandledMouseEventArgs)e).Handled = true;
                };
                numericUpDown2.ValueChanged += (object s, EventArgs e) =>
                {
                    m.MinDropQuantity = (int)((NumericUpDown)s).Value;
                };
                this.Controls.Add(numericUpDown2);

                label_slash2.Font = new Font("Segoe UI", 13F);
                label_slash2.Location = new Point(389, startY - 3);
                label_slash2.Name = "label13";
                label_slash2.Size = new Size(15, 23);
                label_slash2.TabIndex = 14;
                label_slash2.Text = "/";
                this.Controls.Add(label_slash2);

                numericUpDown3.Location = new Point(410, startY);
                numericUpDown3.Minimum = (decimal)m.MinDropQuantity;
                numericUpDown3.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
                numericUpDown3.Name = "numericUpDown3";
                numericUpDown3.Size = new Size(56, 23);
                numericUpDown3.TabIndex = 2;
                numericUpDown3.Value = (decimal)m.MaxDropQuantity;
                numericUpDown3.ValueChanged += (object s, EventArgs e) =>
                {
                    numericUpDown2.Maximum = numericUpDown3.Value;
                };
                numericUpDown3.MouseWheel += (object s, MouseEventArgs e) =>
                {
                    ((HandledMouseEventArgs)e).Handled = true;
                };
                numericUpDown3.ValueChanged += (object s, EventArgs e) =>
                {
                    m.MaxDropQuantity = (int)((NumericUpDown)s).Value;
                };
                this.Controls.Add(numericUpDown3);

                numericUpDown4.Location = new Point(487, startY);
                numericUpDown4.Name = "numericUpDown4";
                numericUpDown4.Size = new Size(56, 23);
                numericUpDown4.Value = (decimal)m.MinVeinAttempts;
                numericUpDown4.Maximum = (decimal)m.MaxVeinAttempts;
                numericUpDown4.TabIndex = 2;
                numericUpDown4.ValueChanged += (object s, EventArgs e) =>
                {
                    numericUpDown5.Minimum = numericUpDown4.Value;
                };
                numericUpDown4.MouseWheel += (object s, MouseEventArgs e) =>
                {
                    ((HandledMouseEventArgs)e).Handled = true;
                };
                numericUpDown4.ValueChanged += (object s, EventArgs e) =>
                {
                    m.MinVeinAttempts = (int)((NumericUpDown)s).Value;
                };
                this.Controls.Add(numericUpDown4);

                label_slash1.Font = new Font("Segoe UI", 13F);
                label_slash1.Location = new Point(549, startY - 3);
                label_slash1.Name = "label13";
                label_slash1.Size = new Size(15, 23);
                label_slash1.TabIndex = 14;
                label_slash1.Text = "/";
                this.Controls.Add(label_slash1);

                numericUpDown5.Location = new Point(570, startY);
                numericUpDown5.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
                numericUpDown5.Name = "numericUpDown5";
                numericUpDown5.Size = new Size(56, 23);
                numericUpDown5.Value = (decimal)m.MaxVeinAttempts;
                numericUpDown5.TabIndex = 2;
                numericUpDown5.ValueChanged += (object s, EventArgs e) =>
                {
                    numericUpDown4.Maximum = numericUpDown5.Value;
                };
                numericUpDown5.MouseWheel += (object s, MouseEventArgs e) =>
                {
                    ((HandledMouseEventArgs)e).Handled = true;
                };
                numericUpDown5.ValueChanged += (object s, EventArgs e) =>
                {
                    m.MaxVeinAttempts = (int)((NumericUpDown)s).Value;
                };
                this.Controls.Add(numericUpDown5);

                button1.BackColor = Color.Red;
                button1.FlatStyle = FlatStyle.Flat;
                button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                button1.ForeColor = Color.White;
                button1.Location = new Point(643, startY);
                button1.Name = "button1";
                button1.Size = new Size(38, 23);
                button1.TabIndex = 15;
                button1.Text = "X";
                button1.UseVisualStyleBackColor = false;
                button1.Click += (object s, EventArgs e) =>
                {
                    if (deepminable)
                    { world.RemoveDeepMinable(m);
                    } else { world.RemoveMinable(m);}
                    PrintMinables();
                };
                this.Controls.Add(button1);

                startY += 26;
            }

            button_add_minable.Location = new Point(195, startY);
            comboBox_minable_list.Location = new Point(19, startY);
            this.Controls.Add(comboBox_minable_list);
            this.Controls.Add(button_add_minable);

            if (comboBox_minable_list.Items.Count == 0)
            {
                comboBox_minable_list.Enabled = false;
                button_add_minable.Enabled = false;
            }

            Button btn_save = new Button();
            btn_save.Size = new Size();
            btn_save.BackColor = Color.ForestGreen;
            btn_save.Location = new Point(570, 417);
            btn_save.Size = new Size(112, 41);
            btn_save.TabIndex = 14;
            btn_save.Text = "Fertig";
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += (object s, EventArgs e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(btn_save);

            this.ResumeLayout(true);
        }
    }
}
