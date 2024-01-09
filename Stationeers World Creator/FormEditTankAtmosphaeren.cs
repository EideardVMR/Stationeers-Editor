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
    public partial class FormEditTankAtmosphaere : Form
    {
        Tank tank;
        bool disable_events = false;

        public FormEditTankAtmosphaere(Tank tank)
        {
            InitializeComponent();
            this.tank = tank;
        }

        private void FormEditRoomAtmosphaere_Load(object sender, EventArgs e)
        {
            if (tank.Volumen == 0)
            {
                MessageBox.Show("Leider wurden für diesen Raum keine Atmosphärendaten gefunden. Du kannst die Daten nicht ändern.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            Print();
            Init();
        }



        public void Init()
        {

            numericUpDown_oxygen_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_carbondioxide_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_nitrogen_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_nitrousoxide_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_pollutant_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_volatiles_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_water_gas.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };

            numericUpDown_oxygen_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_carbondioxide_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_nitrogen_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_nitrousoxide_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_pollutant_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_volatiles_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };
            numericUpDown_water_liquid.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CheckConfiguration();
            };

            numericUpDown_temperature.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                //room.Temperature = (double)((NumericUpDown)o).Value;
                //room.setTempPress((double)numericUpDown_temperature.Value, (double)numericUpDown_pressure.Value);
                CalcGases();
            };
            numericUpDown_pressure.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                //room.Pressure = (double)((NumericUpDown)o).Value;
                //room.setTempPress((double)numericUpDown_temperature.Value, (double)numericUpDown_pressure.Value);
                CalcGases();
            };
            /*
            numericUpDown_gas_mol.ValueChanged += (object o, EventArgs s) =>
            {
                if (disable_events) { return; }
                CalcGases();
            };
            numericUpDown_liquid_mol.ValueChanged += (object o, EventArgs s) =>
            {
                if(disable_events) { return; }
                CalcGases();
            };
            */

            button_check.Click += (object o, EventArgs e) =>
            {
                if(tank.GasMole == 0)
                {
                    numericUpDown_gas_mol.Value = 1;
                }

                CalcGases();
                numericUpDown_temperature.Enabled = true;
                numericUpDown_pressure.Enabled = true;
            };


        }

        private void CheckConfiguration()
        {
            CheckConfiguration(false);
        }
        private void CheckConfiguration(bool checkonly)
        {
            if (!checkonly)
            {
                numericUpDown_temperature.Enabled = false;
                numericUpDown_pressure.Enabled = false;
            }

            decimal sum =
                numericUpDown_oxygen_gas.Value +
                numericUpDown_carbondioxide_gas.Value +
                numericUpDown_nitrogen_gas.Value +
                numericUpDown_nitrousoxide_gas.Value +
                numericUpDown_pollutant_gas.Value +
                numericUpDown_volatiles_gas.Value +
                numericUpDown_water_gas.Value;

            if (sum != 100)
            {
                button_check.BackColor = Color.Red;
                button_check.ForeColor = Color.White;
                button_check.Text = "Du hast nur " + sum.ToString("N2") + "% vergeben.";
                button_check.Enabled = false;

                numericUpDown_temperature.Enabled = false;
                numericUpDown_pressure.Enabled = false;

                return;
            }

            button_check.BackColor = SystemColors.ActiveCaption;
            button_check.ForeColor = Color.Black;
            button_check.Enabled = true;
            button_check.Text = "Bestätigen";
        }

        private void CalcGases()
        {
            numericUpDown_pressure.Minimum = 1;
            numericUpDown_temperature.Minimum = 1;

            disable_events = true;

            //room.GasMole = (double)numericUpDown_gas_mol.Value;

            double mols = (double)numericUpDown_gas_mol.Value;
            tank.Oxygen = mols * ((double)numericUpDown_oxygen_gas.Value / 100);
            tank.CarbonDioxide = mols * ((double)numericUpDown_carbondioxide_gas.Value / 100);
            tank.Nitrogen = mols * ((double)numericUpDown_nitrogen_gas.Value / 100);
            tank.NitrousOxide = mols * ((double)numericUpDown_nitrousoxide_gas.Value / 100);
            tank.Pollutant = mols * ((double)numericUpDown_pollutant_gas.Value / 100);
            tank.Volatiles = mols * ((double)numericUpDown_volatiles_gas.Value / 100);
            tank.Steam = mols * ((double)numericUpDown_water_gas.Value / 100);

            tank.LiquidOxygenLitre = (double)numericUpDown_oxygen_liquid.Value;
            tank.LiquidNitrogenLitre = (double)numericUpDown_nitrogen_liquid.Value;
            tank.LiquidPollutantLitre = (double)numericUpDown_pollutant_liquid.Value;
            tank.LiquidNitrousOxideLitre = (double)numericUpDown_nitrousoxide_liquid.Value;
            tank.LiquidVolatilesLitre = (double)numericUpDown_volatiles_liquid.Value;
            tank.LiquidCarbonDioxideLitre = (double)numericUpDown_carbondioxide_liquid.Value;
            tank.WaterLitre = (double)numericUpDown_water_liquid.Value;

            tank.Temperature = (double)numericUpDown_temperature.Value;
            tank.Pressure = (double)numericUpDown_pressure.Value;

            //numericUpDown_temperature.Value = (decimal)room.Temperature;
            //numericUpDown_pressure.Value = (decimal)room.Pressure;

            //numericUpDown_gas_mol.Value = Math.Round((decimal)room.GasMole, 2);
            //numericUpDown_liquid_mol.Value = Math.Round((decimal)room.LiquidMole, 2);

            //label_temp.Text = "K (" + Math.Round(room.TemperatureCelsius, 2).ToString() + "°C)";

            Print();

            disable_events = false;
        }

        public void Print()
        {
            label_id.Text = tank.Id.ToString();
            label_atmospherics.Text = tank.Atmospheres.Count.ToString();
            label_volumen.Text = tank.Volumen.ToString();
            label_blocks.Text = tank.Name;

            numericUpDown_gas_mol.Value = Math.Round((decimal)tank.GasMole, 2);

            numericUpDown_oxygen_gas.Value = Math.Round((decimal)tank.OxygenPercent * 100, 2);
            numericUpDown_carbondioxide_gas.Value = Math.Round((decimal)tank.CarbonDioxidePercent * 100, 2);
            numericUpDown_nitrogen_gas.Value = Math.Round((decimal)tank.NitrogenPercent * 100, 2);
            numericUpDown_nitrousoxide_gas.Value = Math.Round((decimal)tank.NitrousOxidePercent * 100, 2);
            numericUpDown_pollutant_gas.Value = Math.Round((decimal)tank.PollutantPercent * 100, 2);
            numericUpDown_volatiles_gas.Value = Math.Round((decimal)tank.VolatilesPercent * 100, 2);
            numericUpDown_water_gas.Value = Math.Round((decimal)tank.SteamPercent * 100, 2);

            numericUpDown_oxygen_liquid.Value = Math.Round((decimal)tank.LiquidOxygenLitre, 2);
            numericUpDown_carbondioxide_liquid.Value = Math.Round((decimal)tank.LiquidCarbonDioxideLitre, 2);
            numericUpDown_nitrogen_liquid.Value = Math.Round((decimal)tank.LiquidNitrogenLitre, 2);
            numericUpDown_nitrousoxide_liquid.Value = Math.Round((decimal)tank.LiquidNitrousOxideLitre, 2);
            numericUpDown_pollutant_liquid.Value = Math.Round((decimal)tank.LiquidPollutantLitre, 2);
            numericUpDown_volatiles_liquid.Value = Math.Round((decimal)tank.LiquidVolatilesLitre, 2);
            numericUpDown_water_liquid.Value = Math.Round((decimal)tank.WaterLitre, 2);

            if (tank.Temperature == 0) { numericUpDown_temperature.Minimum = 0; }
            numericUpDown_temperature.Value = (decimal)tank.Temperature;

            if(tank.Pressure == 0) { numericUpDown_pressure.Minimum = 0; }
            numericUpDown_pressure.Value = (decimal)tank.Pressure;

            label_temp.Text = "K (" + Math.Round(tank.TemperatureCelsius, 2).ToString() + "°C)";

            CheckConfiguration(true);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_removegas_Click(object sender, EventArgs e)
        {
            disable_events = true;
            numericUpDown_pressure.Minimum = 0;
            numericUpDown_pressure.Value = 0;
            tank.RemoveGas();
            Print();
            disable_events = false;
        }
    }
}
