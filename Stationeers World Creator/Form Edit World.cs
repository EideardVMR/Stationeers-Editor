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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stationeers_World_Creator
{
    public partial class Form_Edit_World : Form
    {

        private World world_node;

        public Form_Edit_World(World node)
        {
            this.DoubleBuffered = true;

            world_node = node;
            InitializeComponent();
        }

        private void Form_Edit_World_Load(object sender, EventArgs e)
        {
            Init();
            Print();
        }

        void Init()
        {
            // Id
            textBox_id.TextChanged += (object s, EventArgs e) =>
            {
                world_node.Id = textBox_id.Text;
            };

            // Bedrock
            numericUpDown_bedrock.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.BedRockLevel = (int)numericUpDown_bedrock.Value;
            };

            // Lava
            checkBox_lava.CheckedChanged += (object s, EventArgs e) =>
            {
                world_node.HasLava = checkBox_lava.Checked;
                numericUpDown_lava.Enabled = checkBox_lava.Checked;
            };
            numericUpDown_lava.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.LavaLevel = (int)numericUpDown_lava.Value;
            };

            // Name und Beschreibung
            textBox_name_de.TextChanged += (object s, EventArgs e) =>
            {
                world_node.NameGer = textBox_name_de.Text;
            };
            textBox_name_eng.TextChanged += (object s, EventArgs e) =>
            {
                world_node.NameEng = textBox_name_eng.Text;
            };
            richTextBox_desc_eng.TextChanged += (object s, EventArgs e) =>
            {
                world_node.DescriptionEng = richTextBox_desc_eng.Text;
            };
            richTextBox_desc_ger.TextChanged += (object s, EventArgs e) =>
            {
                world_node.DescriptionGer = richTextBox_desc_ger.Text;
            };

            // Gravitation
            numericUpDown_gravity.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.Gravity = numericUpDown_gravity.Value;
            };

            // StartingCondition
            comboBox_startingcondition.SelectedIndexChanged += (object s, EventArgs e) =>
            {
                switch (comboBox_startingcondition.SelectedIndex)
                {
                    case 0:
                        world_node.StartingCondition = "Default";
                        break;
                    case 1:
                        world_node.StartingCondition = "Minimal";
                        break;
                    case 2:
                        world_node.StartingCondition = "BareBones";
                        break;
                    case 3:
                        world_node.StartingCondition = "Vulcan";
                        break;
                    case 4:
                        world_node.StartingCondition = "Venus";
                        break;
                }
            };

            // Tag/Nacht
            checkBox_freeze_time.Click += (object s, EventArgs e) =>
            {
                world_node.TimeScale = checkBox_freeze_time.Checked ? 0 : numericUpDown_timescale.Value;
                checkBox_freeze_time.Text = checkBox_freeze_time.Checked ? "Freeze" : "Läuft";
                numericUpDown_timescale.Enabled = !checkBox_freeze_time.Checked;
                numericUpDown_timescale.Value = world_node.TimeScale;
            };

            numericUpDown_timescale.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.TimeScale = checkBox_freeze_time.Checked ? 0 : numericUpDown_timescale.Value;
            };

        }

        void Print()
        {
            this.SuspendLayout();
            // Id
            textBox_id.Text = world_node.Id;

            // Bedrock
            if (world_node.BedRockLevel < -100)
            { numericUpDown_bedrock.Minimum = world_node.BedRockLevel; }
            numericUpDown_bedrock.Value = world_node.BedRockLevel;

            // Lava
            checkBox_lava.Checked = world_node.HasLava;
            numericUpDown_lava.Enabled = checkBox_lava.Checked;

            if (world_node.BedRockLevel < -100)
            { numericUpDown_lava.Minimum = world_node.LavaLevel; }
            numericUpDown_lava.Value = world_node.LavaLevel;

            // Name und Beschreibung
            textBox_name_de.Text = world_node.NameGer;
            textBox_name_eng.Text = world_node.NameEng;
            richTextBox_desc_eng.Text = world_node.DescriptionEng;
            richTextBox_desc_ger.Text = world_node.DescriptionGer;

            // Gravitation
            if (world_node.Gravity < -10)
            { numericUpDown_gravity.Minimum = world_node.Gravity; }
            numericUpDown_gravity.Value = world_node.Gravity;

            // StartingCondition
            comboBox_startingcondition.Text = world_node.StartingCondition;

            // Buttons
            button_edit_minables.Text = "Abbaubare Erze Überschreiben (" + world_node.Mineables.Count + ")";
            button_edit_deepminables.Text = "Abbaubare Deepminer Erze Überschreiben (" + world_node.DeepMineables.Count + ")";
            button_atmosphere.Text = "Atmosphäre bearbeiten (" + world_node.Atmospherics.Count + ")";
            button_kelvin.Text = "Temperaturen bearbeiten (" + world_node.Kelvin.Frames.Count + ")";
            button_weather.Text = "Wetter bearbeiten (" + (world_node.WeatherEvent.HasWeather() ? "Aktiv" : "Inaktiv") + ")";
            this.ResumeLayout(true);

            // Tag/Nacht
            checkBox_freeze_time.Checked = world_node.TimeScale == 0;
            checkBox_freeze_time.Text = checkBox_freeze_time.Checked ? "Freeze" : "Läuft";
            numericUpDown_timescale.Enabled = !checkBox_freeze_time.Checked;

            numericUpDown_timescale.Value = world_node.TimeScale;
        }

        private void button_edit_minables_Click(object sender, EventArgs e)
        {
            FormEditMinables form = new FormEditMinables(world_node);
            form.Text = "Erze überschreiben";
            form.ShowDialog();
            button_edit_minables.Text = "Abbaubare Erze Überschreiben (" + world_node.Mineables.Count + ")";
        }

        private void button_edit_deepminables_Click(object sender, EventArgs e)
        {
            FormEditMinables form = new FormEditMinables(world_node, true);
            form.Text = "Erze überschreiben (Deepminer)";
            form.ShowDialog();
            button_edit_deepminables.Text = "Abbaubare Deepminer Erze Überschreiben (" + world_node.DeepMineables.Count + ")";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_atmosphere_Click(object sender, EventArgs e)
        {
            FormEditAtmosphere form = new FormEditAtmosphere(world_node);
            form.Text = "Atmosphäre bearbeiten";
            form.ShowDialog();
            button_atmosphere.Text = "Atmosphäre bearbeiten (" + world_node.Atmospherics.Count + ")";
        }

        private void button_kelvin_Click(object sender, EventArgs e)
        {
            FormEditKelvin form = new FormEditKelvin(world_node.Kelvin);
            form.Text = "Temperaturen bearbeiten";
            form.ShowDialog();
            button_kelvin.Text = "Temperaturen bearbeiten (" + world_node.Kelvin.Frames.Count + ")";
        }

        private void button_weather_Click(object sender, EventArgs e)
        {
            if(!world_node.WeatherEvent.HasWeather() && (world_node.Kelvin.Frames.Count == 0 || world_node.Atmospherics.Count == 0))
            {
                MessageBox.Show("Für ein Wetterevent wird Eine Atmosphäre mit Temperatur benötigt. Bitte konfigurieren.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if(!world_node.WeatherEvent.HasWeather() )
            {
                world_node.CreateWeather();
            }

            FormEditWeather form = new FormEditWeather(world_node.WeatherEvent);
            form.Text = "Wetter bearbeiten";
            form.ShowDialog();
            button_weather.Text = "Wetter bearbeiten (" + (world_node.WeatherEvent.HasWeather() ? "Aktiv" : "Inaktiv") + ")";
        }
    }
}
