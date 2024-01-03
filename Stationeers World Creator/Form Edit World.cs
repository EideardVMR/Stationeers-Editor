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
            // Gamemode
            checkBox_gamemode.CheckedChanged += (object s, EventArgs e) =>
            {
                world_node.GameMode = checkBox_gamemode.Checked ? "Creative" : "Survival";
                checkBox_gamemode.Text = world_node.GameMode;
                CheckForProblems();
            };

            // Id
            textBox_id.TextChanged += (object s, EventArgs e) =>
            {
                world_node.Id = textBox_id.Text;
                CheckForProblems();
            };

            // Bedrock
            numericUpDown_bedrock.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.BedRockLevel = (int)numericUpDown_bedrock.Value;
                CheckForProblems();
            };

            // Lava
            checkBox_lava.CheckedChanged += (object s, EventArgs e) =>
            {
                world_node.HasLava = checkBox_lava.Checked;
                numericUpDown_lava.Enabled = checkBox_lava.Checked;
                CheckForProblems();
            };
            numericUpDown_lava.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.LavaLevel = (int)numericUpDown_lava.Value;
                CheckForProblems();
            };

            // Terrain
            comboBox_terrain.SelectedValueChanged += (object s, EventArgs e) =>
            {
                world_node.CustomTerrain = comboBox_terrain.Text;
            };

            // Name und Beschreibung
            textBox_name_de.TextChanged += (object s, EventArgs e) =>
            {
                world_node.NameGer = textBox_name_de.Text;
                CheckForProblems();
            };
            textBox_name_eng.TextChanged += (object s, EventArgs e) =>
            {
                world_node.NameEng = textBox_name_eng.Text;
                CheckForProblems();
            };
            richTextBox_desc_eng.TextChanged += (object s, EventArgs e) =>
            {
                world_node.DescriptionEng = richTextBox_desc_eng.Text;
                if (!world_node.DescriptionEng.Contains("Created with Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)"))
                {
                    world_node.DescriptionEng += "\n\nCreated with Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)";
                    richTextBox_desc_eng.Text = world_node.DescriptionEng;
                }
                CheckForProblems();
            };
            richTextBox_desc_ger.TextChanged += (object s, EventArgs e) =>
            {
                world_node.DescriptionGer = richTextBox_desc_ger.Text;
                if (!world_node.DescriptionGer.Contains("Erstellt mit Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)"))
                {
                    world_node.DescriptionGer += "\n\nErstellt mit Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)";
                    richTextBox_desc_ger.Text = world_node.DescriptionGer;
                }
                CheckForProblems();
            };

            // Gravitation
            numericUpDown_gravity.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.Gravity = numericUpDown_gravity.Value;
                CheckForProblems();
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
                CheckForProblems();
            };

            // Tag/Nacht
            checkBox_freeze_time.Click += (object s, EventArgs e) =>
            {
                world_node.TimeScale = checkBox_freeze_time.Checked ? 0 : numericUpDown_timescale.Value;
                checkBox_freeze_time.Text = checkBox_freeze_time.Checked ? "Freeze" : "Läuft";
                numericUpDown_timescale.Enabled = !checkBox_freeze_time.Checked;
                numericUpDown_timescale.Value = world_node.TimeScale;
                CheckForProblems();
            };

            numericUpDown_timescale.ValueChanged += (object s, EventArgs e) =>
            {
                world_node.TimeScale = checkBox_freeze_time.Checked ? 0 : numericUpDown_timescale.Value;
                CheckForProblems();
            };

            CheckForProblems();
        }

        void Print()
        {
            this.SuspendLayout();
            // Gamemode
            checkBox_gamemode.Checked = world_node.GameMode == "Creative";
            checkBox_gamemode.Text = world_node.GameMode;

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

            // Terrain
            if (world_node.CustomTerrain == "FullCustom")
            {
                comboBox_terrain.Enabled = false;
            }
            else
            {
                comboBox_terrain.Enabled = true;
                comboBox_terrain.Text = world_node.CustomTerrain;
            }

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
            if (world_node.StartingCondition == "Default")
            {
                comboBox_startingcondition.Text = "Standard";
            }
            if (world_node.StartingCondition == "Minimal")
            {
                comboBox_startingcondition.Text = "Nichts";
            }
            if (world_node.StartingCondition == "Vulcan")
            {
                comboBox_startingcondition.Text = "Vulcan";
            }
            if (world_node.StartingCondition == "Venus")
            {
                comboBox_startingcondition.Text = "Venus";
            }
            if (world_node.StartingCondition == "BareBones")
            {
                comboBox_startingcondition.Text = "Etwas mehr als nichts";
            }

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
            CheckForProblems();
        }

        private void button_edit_deepminables_Click(object sender, EventArgs e)
        {
            FormEditMinables form = new FormEditMinables(world_node, true);
            form.Text = "Erze überschreiben (Deepminer)";
            form.ShowDialog();
            button_edit_deepminables.Text = "Abbaubare Deepminer Erze Überschreiben (" + world_node.DeepMineables.Count + ")";
            CheckForProblems();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            CheckForProblems();
        }

        private void button_atmosphere_Click(object sender, EventArgs e)
        {
            FormEditAtmosphere form = new FormEditAtmosphere(world_node);
            form.Text = "Atmosphäre bearbeiten";
            form.ShowDialog();
            button_atmosphere.Text = "Atmosphäre bearbeiten (" + world_node.Atmospherics.Count + ")";
            CheckForProblems();
        }

        private void button_kelvin_Click(object sender, EventArgs e)
        {
            FormEditKelvin form = new FormEditKelvin(world_node.Kelvin);
            form.Text = "Temperaturen bearbeiten";
            form.ShowDialog();
            button_kelvin.Text = "Temperaturen bearbeiten (" + world_node.Kelvin.Frames.Count + ")";
            CheckForProblems();
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
            if(form.ShowDialog() == DialogResult.Abort)
            {
                world_node.RemoveWeather();
            }
            
            button_weather.Text = "Wetter bearbeiten (" + (world_node.WeatherEvent.HasWeather() ? "Aktiv" : "Inaktiv") + ")";
            CheckForProblems();
        }

        private void CheckForProblems()
        {
            label_error.Text = "";

            bool hasOxygen = false;
            bool hasVolatiles = false;
            bool hasNitrous = false;

            decimal GasKonstante = (decimal)8.31446261815324;

            decimal mols = 0;
            decimal min_temp = 9999;
            decimal max_temp = 0;
            decimal pressure_min = 0;
            decimal pressure_max = 0;
            decimal min_temp_storm = 9999;
            decimal max_temp_storm = 0;
            decimal pressure_min_storm = 0;
            decimal pressure_max_storm = 0;


            foreach (Atmosphere atmos in world_node.Atmospherics)
            {
                mols += atmos.Quantity;

                if (atmos.Type == "Oxygen")
                {
                    hasOxygen = true;
                }
                if (atmos.Type == "Volatiles")
                {
                    hasVolatiles = true;
                }
                if (atmos.Type == "NitrousOxide")
                {
                    hasNitrous = true;
                }
            }

            if (mols > 0)
            {
                foreach (Kelvinframe frame in world_node.Kelvin.Frames)
                {
                    min_temp = min_temp_storm = Math.Min(min_temp, frame.value);
                    max_temp = max_temp_storm = Math.Max(max_temp, frame.value);
                }

                if (world_node.WeatherEvent.HasWeather())
                {
                    foreach (Kelvinframe frame in world_node.WeatherEvent.Kelvin.Frames)
                    {
                        min_temp_storm = Math.Min(min_temp, frame.value);
                        max_temp_storm = Math.Max(max_temp, frame.value);
                    }
                }

                label_temp.Text = "von " + min_temp + "K bis " + max_temp + "K (inkl. Sturm: " + min_temp_storm + "K bis " + max_temp_storm + "K)";

                pressure_min = pressure_min_storm = (mols * GasKonstante * min_temp) / 8000;
                pressure_max = pressure_max_storm = (mols * GasKonstante * max_temp) / 8000;



                if (world_node.WeatherEvent.HasWeather())
                {
                    pressure_min_storm = (mols * GasKonstante * min_temp_storm) / 8000;
                    pressure_max_storm = (mols * GasKonstante * max_temp_storm) / 8000;
                }

                label_temp.Text = "von " + Math.Round(min_temp) + " K bis " + Math.Round(max_temp) + " K\ninkl. Sturm: " + Math.Round(min_temp_storm) + " K bis " + Math.Round(max_temp_storm) + " K";
                label_press.Text = "von " + Math.Round(pressure_min) + " kPa bis " + Math.Round(pressure_max) + " kPa\ninkl. Sturm: " + Math.Round(pressure_min_storm) + " kPa bis " + Math.Round(pressure_max_storm, 1) + " kPa";
            } 
            else
            {
                label_temp.Text = "Vakuum";
                label_press.Text = "Vakuum";
            }

            if(mols > 0 && world_node.Kelvin.Frames.Count == 0)
            {
                label_error.Text += "Du hast eine Atmosphäre aber keine Temperatur eingegeben.\n\n";
            }

            foreach (Atmosphere atmos in world_node.Atmospherics)
            {
                if(atmos.Type == "Oxygen" && min_temp_storm < 60)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich Oxygen in Eis verwandelt (<60K). Dies kann zu Performanceproblemen führen.\n\n";
                    hasOxygen = true;
                }
                if (atmos.Type == "CarbonDioxide" && min_temp_storm < 225)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich CarbonDioxide in Eis verwandelt (<225K). Dies kann zu Performanceproblemen führen.\n\n";
                }
                if (atmos.Type == "Pollutant" && min_temp_storm < 180)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich Pollutant in Eis verwandelt (<180K). Dies kann zu Performanceproblemen führen.\n\n";
                }
                if (atmos.Type == "Volatiles" && min_temp_storm < 90)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich Volatiles in Eis verwandelt (<90K). Dies kann zu Performanceproblemen führen.\n\n";
                    hasVolatiles = true;
                }
                if (atmos.Type == "Hydrogen" && min_temp_storm < 273)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich Hydrogen in Eis verwandelt (<273K). Dies kann zu Performanceproblemen führen.\n\n";
                }
                if (atmos.Type == "Nitrogen" && min_temp_storm < 40)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich Nitrogen in Eis verwandelt (<40K). Dies kann zu Performanceproblemen führen.\n\n";
                }
                if (atmos.Type == "NitrousOxide" && min_temp_storm < 252)
                {
                    label_error.Text += "Du hast eine Temperatur welche ggf. dafür sorgt, dass sich NitrousOxide in Eis verwandelt (<252K). Dies kann zu Performanceproblemen führen.\n\n";
                    hasNitrous = true;
                }
            }

            if((hasOxygen || hasNitrous) && hasVolatiles) 
            {
                label_error.Text += "Du hast eine gefähliche Gasmischung ausgewählt. Dies kann zu einem Atmosphärenbrand führen der nie wieder gelöscht werden kann.\n\n";
            }

        }
    }
}
