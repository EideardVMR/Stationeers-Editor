using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Stationeers_World_Creator
{
    public partial class FormEditKelvin : Form
    {
        Kelvin kelvin = null;

        List<Label> labels = new List<Label>();
        List<Label> labels2 = new List<Label>();

        public FormEditKelvin(Kelvin kelvin)
        {
            this.kelvin = kelvin;
            InitializeComponent();
        }
        public FormEditKelvin(XmlNode kelvinNode)
        {
            this.kelvin = new Kelvin(kelvinNode);
            InitializeComponent();
        }

        private void FormEditKelvin_Load(object sender, EventArgs e)
        {
            PrintKelvins();
        }

        void Recalc( string name )
        {
            if (name.Split("_")[0] == "time")
            {
                foreach (Label label in labels)
                {
                    if (label.Name != "local_" + name) { continue; }

                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl.Name == name)
                        {
                            decimal time = ((NumericUpDown)ctl).Value;

                            time = time * 24;

                            decimal h = Math.Floor(time);
                            decimal m = time - h;
                            m = m * 60;
                            m = Math.Round(m, 0);

                            h += 6;
                            if (h > 24)
                            {
                                h -= 24;
                            }

                            label.Text = h.ToString().PadLeft(2, '0') + ":" + m.ToString().PadLeft(2, '0');

                            if (h == 6) { label.Text += "(Sonnenaufgang)"; }
                            if (h == 12) { label.Text += "(Mittagsonne)"; }
                            if (h == 18) { label.Text += "(Sonnenuntergang)"; }
                            if (h == 24) { label.Text += "(Mitternacht)"; }
                        }
                    }
                }
            }

            if (name.Split("_")[0] == "kelvin")
            {
                foreach (Label label in labels2)
                {
                    if (label.Name != "local_" + name) { continue; }

                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl.Name == name)
                        {
                            decimal kelvin = ((NumericUpDown)ctl).Value;
                            decimal celsius = kelvin - 273;

                            label.Text = "K (" + celsius + "°C)";
                        }
                    }
                }
            }
        }

        void PrintKelvins()
        {
            this.AutoSize = true;

            this.SuspendLayout();

            this.Controls.Clear();

            NumericUpDown comboBox_minable_list = new NumericUpDown();
            comboBox_minable_list.Name = "comboBox_minable_list";
            comboBox_minable_list.DecimalPlaces = 2;
            comboBox_minable_list.Size = new Size(152, 23);
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
                kelvin.AddFrame(comboBox_minable_list.Value);
                PrintKelvins();
            };
            // Erst am Ende hinzufügen zu Groupbox.

            Label header1 = new Label();
            header1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header1.Location = new Point(19, 19);
            header1.Name = "label9";
            header1.Size = new Size(100, 23);
            header1.TabIndex = 0;
            header1.Text = "Zeit";
            header1.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header1);

            Label header2 = new Label();
            header2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header2.Location = new Point(195, 19);
            header2.Name = "label10";
            header2.Size = new Size(100, 23);
            header2.TabIndex = 0;
            header2.Text = "Temperatur";
            header2.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header2);

            Label header3 = new Label();
            header3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            header3.Location = new Point(440, 19);
            header3.Name = "label10";
            header3.Size = new Size(200, 23);
            header3.TabIndex = 0;
            header3.Text = "Ungefähre Uhrzeit";
            header3.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(header3);

            // Minables
            int startY = 45;

            labels.Clear();
            int i = 0;
            foreach (Kelvinframe frame in kelvin.Frames)
            {
                NumericUpDown label_orename = new NumericUpDown();
                NumericUpDown numericUpDown1 = new NumericUpDown();
                Label label_anteil = new Label();
                Label label_value = new Label();
                Button button1 = new Button();

                label_orename.Location = new Point(19, startY);
                label_orename.Name = "time_" + i;
                label_orename.Size = new Size(152, 23);
                label_orename.Minimum = 0;
                label_orename.Maximum = 1;
                label_orename.TabIndex = 1;
                label_orename.Increment = (decimal)0.01;
                label_orename.DecimalPlaces = 2;
                label_orename.Value = frame.time;
                label_orename.ValueChanged += (object s, EventArgs e) =>
                {
                    frame.time = (int)((NumericUpDown)s).Value;
                    Recalc(((NumericUpDown)s).Name);
                };
                this.Controls.Add(label_orename);

                numericUpDown1.Location = new Point(195, startY);
                numericUpDown1.Name = "kelvin_" + i;
                numericUpDown1.Minimum = 0;
                numericUpDown1.Maximum = 4000;
                numericUpDown1.DecimalPlaces = 0;
                numericUpDown1.Size = new Size(100, 23);
                numericUpDown1.Value = frame.value;
                numericUpDown1.TabIndex = 2;
                numericUpDown1.ValueChanged += (object s, EventArgs e) =>
                {
                    frame.value = (int)((NumericUpDown)s).Value;
                    Recalc(((NumericUpDown)s).Name);
                };
                this.Controls.Add(numericUpDown1);

                label_value.Location = new Point(295, startY);
                label_value.Size = new Size(100, 23);
                label_value.TabIndex = 1;
                label_value.Name = "local_kelvin_" + i;
                label_value.Text = "K";
                this.Controls.Add(label_value);
                labels2.Add(label_value);

                button1.BackColor = Color.Red;
                button1.FlatStyle = FlatStyle.Flat;
                button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                button1.ForeColor = Color.White;
                button1.Location = new Point(391, startY);
                button1.Name = "button1";
                button1.Size = new Size(38, 23);
                button1.TabIndex = 15;
                button1.Text = "X";
                button1.UseVisualStyleBackColor = false;
                button1.Click += (object s, EventArgs e) =>
                {
                    kelvin.RemoveFrame(frame);
                    PrintKelvins();
                };
                this.Controls.Add(button1);

                label_anteil.Location = new Point(440, startY);
                label_anteil.Size = new Size(200, 23);
                label_anteil.TabIndex = 1;
                label_anteil.Name = "local_time_" + i;
                label_anteil.Text = "06:00";
                this.Controls.Add(label_anteil);
                labels.Add(label_anteil);

                Recalc("time_" + i);
                Recalc("kelvin_" + i);

                startY += 26;
                i++;
            }

            button_add_minable.Location = new Point(195, startY);
            comboBox_minable_list.Location = new Point(19, startY);
            this.Controls.Add(comboBox_minable_list);
            this.Controls.Add(button_add_minable);

            Button btn_save = new Button();
            btn_save.Size = new Size();
            btn_save.BackColor = Color.ForestGreen;
            btn_save.Location = new Point(412 - 112, startY + 40);
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
