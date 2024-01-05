using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationeers_World_Creator
{
    public partial class FormEditAtmosphere : Form
    {
        World world = null;

        List<Label> labels = new List<Label>();

        public FormEditAtmosphere(World world)
        {
            this.world = world;
            InitializeComponent();
        }

        private void FormEditAtmosphere_Load(object sender, EventArgs e)
        {
            PrintAtmospherics();
        }

        void Recalc()
        {
            decimal gesamtmols = 0;

            foreach (Atmosphere a in world.Atmospherics)
            {
                gesamtmols += a.Quantity;
            }

            int i = 0;
            foreach (Atmosphere a in world.Atmospherics)
            {
                labels[i].Text = Math.Round((a.Quantity / gesamtmols * 100), 2).ToString() + " %";
                i++;
            }
        }

        void PrintAtmospherics()
        {
            this.AutoSize = true;

            this.SuspendLayout();

            this.Controls.Clear();

            ComboBox comboBox_minable_list = new ComboBox();
            comboBox_minable_list.FormattingEnabled = true;
            comboBox_minable_list.Items.AddRange(new object[] { "Oxygen", "CarbonDioxide", "Pollutant", "Volatiles", "Water", "Nitrogen", "NitrousOxide"});
            comboBox_minable_list.Name = "comboBox_minable_list";
            comboBox_minable_list.DropDownStyle = ComboBoxStyle.DropDownList;
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
                if (comboBox_minable_list.SelectedItem == null)
                {
                    MessageBox.Show("Wähle ein Gas aus", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                world.AddAtmosphere(comboBox_minable_list.SelectedItem.ToString());

                PrintAtmospherics();
            };
            // Erst am Ende hinzufügen zu Groupbox.

            Label header1 = new Label();
            header1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header1.Location = new Point(19, 19);
            header1.Name = "label9";
            header1.Size = new Size(100, 23);
            header1.TabIndex = 0;
            header1.Text = "Gas";
            header1.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header1);

            Label header2 = new Label();
            header2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header2.Location = new Point(195, 19);
            header2.Name = "label10";
            header2.Size = new Size(100, 23);
            header2.TabIndex = 0;
            header2.Text = "Anzahl Mols";
            header2.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header2);

            Label header3 = new Label();
            header3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header3.Location = new Point(360, 19);
            header3.Name = "label10";
            header3.Size = new Size(100, 23);
            header3.TabIndex = 0;
            header3.Text = "Anteil in %";
            header3.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header3);

            // Minables
            int startY = 45;

            labels.Clear();
            foreach (Atmosphere a in world.Atmospherics)
            {
                comboBox_minable_list.Items.Remove(a.Type);

                Label label_orename = new Label();
                NumericUpDown numericUpDown1 = new NumericUpDown();
                Label label_anteil = new Label();
                Button button1 = new Button();

                label_orename.Location = new Point(19, startY);
                label_orename.Name = "label_orename1";
                label_orename.Size = new Size(152, 23);
                label_orename.TabIndex = 1;
                label_orename.Text = a.Type;
                this.Controls.Add(label_orename);

                numericUpDown1.Location = new Point(195, startY);
                numericUpDown1.Name = "numericUpDown1";
                numericUpDown1.Minimum = 0;
                numericUpDown1.Maximum = 10000;
                numericUpDown1.DecimalPlaces = 8;
                numericUpDown1.Size = new Size(100, 23);
                numericUpDown1.Value = (decimal)a.Quantity;
                numericUpDown1.TabIndex = 2;
                numericUpDown1.ValueChanged += (object s, EventArgs e) =>
                {
                    a.Quantity = (int)((NumericUpDown)s).Value;
                    Recalc();
                };
                this.Controls.Add(numericUpDown1);

                label_anteil.Location = new Point(360, startY);
                label_anteil.Size = new Size(52, 23);
                label_anteil.TabIndex = 1;
                label_anteil.Name = a.Type;
                label_anteil.Text = "0 %";
                this.Controls.Add(label_anteil);
                labels.Add(label_anteil);

                button1.BackColor = Color.Red;
                button1.FlatStyle = FlatStyle.Flat;
                button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                button1.ForeColor = Color.White;
                button1.Location = new Point(311, startY);
                button1.Name = "button1";
                button1.Size = new Size(38, 23);
                button1.TabIndex = 15;
                button1.Text = "X";
                button1.UseVisualStyleBackColor = false;
                button1.Click += (object s, EventArgs e) =>
                {
                    world.RemoveAtmosphere(a);
                    PrintAtmospherics();
                };
                this.Controls.Add(button1);

                startY += 26;
            }
            comboBox_minable_list.Text = comboBox_minable_list.Items[0].ToString();

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
            btn_save.Location = new Point(412-112, startY + 40);
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
            Recalc();
        }
    }
}
