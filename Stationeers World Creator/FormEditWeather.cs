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

namespace Stationeers_World_Creator
{
    public partial class FormEditWeather : Form
    {
        WeatherEvent weatherEvent;

        public FormEditWeather(WeatherEvent weather)
        {
            weatherEvent = weather;
            InitializeComponent();
        }

        private void FormEditWeather_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            numericUpDown_start_min.Value = weatherEvent.WeatherMinimumStartTime;
            numericUpDown_start_max.Value = weatherEvent.WeatherMaximumStartTime;

            numericUpDown_dur_min.Value = weatherEvent.WeatherMinimumDuration;
            numericUpDown_dur_max.Value = weatherEvent.WeatherMaximumDuration;

            numericUpDown_cd_min.Value = weatherEvent.WeatherMinimumCooldownDuration;
            numericUpDown_cd_max.Value = weatherEvent.WeatherMaximumCooldownDuration;

            numericUpDown_start_cd.Value = weatherEvent.WeatherWorldStartCooldownDuration;

            button_kelvin.Text = "Temperaturen bearbeiten (" + weatherEvent.Kelvin.Frames.Count + ")";

            button_Color.BackColor = Color.FromArgb(weatherEvent.FogColor.a, weatherEvent.FogColor.r, weatherEvent.FogColor.g, weatherEvent.FogColor.b);

            if(button_Color.BackColor.GetBrightness() > 0.5)
            {
                button_Color.ForeColor = Color.Black;
            } else
            {
                button_Color.ForeColor = Color.White;
            }

            BtnColor();

        }

        private void BtnColor()
        {
            button_WeatherAshStorm.BackColor = weatherEvent.Id == "WeatherAshStorm" ? Color.YellowGreen : Color.RosyBrown;
            button_WeatherDustStorm.BackColor = weatherEvent.Id == "WeatherDustStorm" ? Color.YellowGreen : Color.RosyBrown;
            button_WeatherSnowStorm.BackColor = weatherEvent.Id == "WeatherSnowStorm" ? Color.YellowGreen : Color.RosyBrown;
            button_WeatherVenusStorm.BackColor = weatherEvent.Id == "WeatherVenusStorm" ? Color.YellowGreen : Color.RosyBrown;
        }

        private void numericUpDown_start_min_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherMinimumStartTime = (int)numericUpDown_start_min.Value;
            Init();
        }

        private void numericUpDown_start_max_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherMaximumStartTime = (int)numericUpDown_start_max.Value;
            Init();
        }

        private void numericUpDown_dur_min_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherMinimumDuration = (int)numericUpDown_dur_min.Value;
            Init();
        }

        private void numericUpDown_dur_max_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherMaximumDuration = (int)numericUpDown_dur_max.Value;
            Init();
        }

        private void numericUpDown_cd_min_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherMinimumCooldownDuration = (int)numericUpDown_cd_min.Value;
            Init();
        }

        private void numericUpDown_cd_max_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherMaximumCooldownDuration = (int)numericUpDown_cd_max.Value;
            Init();
        }

        private void numericUpDown_start_cd_ValueChanged(object sender, EventArgs e)
        {
            weatherEvent.WeatherWorldStartCooldownDuration = (int)numericUpDown_start_cd.Value;
            Init();
        }

        private void button_kelvin_Click(object sender, EventArgs e)
        {
            FormEditKelvin form = new FormEditKelvin(weatherEvent.Kelvin);
            form.ShowDialog();
            button_kelvin.Text = "Temperaturen bearbeiten (" + weatherEvent.Kelvin.Frames.Count + ")";
            Init();
        }

        private void button_Color_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialog1.ShowDialog();
            if(dr == DialogResult.OK)
            {
                weatherEvent.FogColor.a = colorDialog1.Color.A;
                weatherEvent.FogColor.r = colorDialog1.Color.R;
                weatherEvent.FogColor.g = colorDialog1.Color.G;
                weatherEvent.FogColor.b = colorDialog1.Color.B;
            }

            Init();
        }

        private void button_WeatherDustStorm_Click(object sender, EventArgs e)
        {
            weatherEvent.Id = "WeatherDustStorm";
            Init();
        }

        private void button_WeatherSnowStorm_Click(object sender, EventArgs e)
        {
            weatherEvent.Id = "WeatherSnowStorm";
            Init();
        }

        private void button_WeatherAshStorm_Click(object sender, EventArgs e)
        {
            weatherEvent.Id = "WeatherAshStorm";
            Init();
        }

        private void button_WeatherVenusStorm_Click(object sender, EventArgs e)
        {
            weatherEvent.Id = "WeatherVenusStorm";
            Init();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
