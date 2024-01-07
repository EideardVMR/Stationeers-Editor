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
    public partial class FormEditRoomAtmosphaere : Form
    {
        Room room;
        bool disable_events = false;

        public FormEditRoomAtmosphaere(Room room)
        {
            InitializeComponent();
            this.room = room;
        }

        private void FormEditRoomAtmosphaere_Load(object sender, EventArgs e)
        {
            if (room.Volumen == 0)
            {
                MessageBox.Show("Leider wurden für diesen Raum keine Atmosphärendaten gefunden. Du kannst die Daten nicht ändern.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (room.Grids.Count != room._atmoNodes.Count)
            {
                MessageBox.Show("Leider konnten für diesen Raum nicht alle Atmosphärendaten ermittelt werden. Es kann sein, dass das Ergebnis nicht deinen Wünschen entspricht.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if(room.GasMole == 0)
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
            room.Oxygen = mols * ((double)numericUpDown_oxygen_gas.Value / 100);
            room.CarbonDioxide = mols * ((double)numericUpDown_carbondioxide_gas.Value / 100);
            room.Nitrogen = mols * ((double)numericUpDown_nitrogen_gas.Value / 100);
            room.NitrousOxide = mols * ((double)numericUpDown_nitrousoxide_gas.Value / 100);
            room.Pollutant = mols * ((double)numericUpDown_pollutant_gas.Value / 100);
            room.Volatiles = mols * ((double)numericUpDown_volatiles_gas.Value / 100);
            room.Steam = mols * ((double)numericUpDown_water_gas.Value / 100);

            room.LiquidOxygenLitre = (double)numericUpDown_oxygen_liquid.Value;
            room.LiquidNitrogenLitre = (double)numericUpDown_nitrogen_liquid.Value;
            room.LiquidPollutantLitre = (double)numericUpDown_pollutant_liquid.Value;
            room.LiquidNitrousOxideLitre = (double)numericUpDown_nitrousoxide_liquid.Value;
            room.LiquidVolatilesLitre = (double)numericUpDown_volatiles_liquid.Value;
            room.LiquidCarbonDioxideLitre = (double)numericUpDown_carbondioxide_liquid.Value;
            room.WaterLitre = (double)numericUpDown_water_liquid.Value;

            room.Temperature = (double)numericUpDown_temperature.Value;
            room.Pressure = (double)numericUpDown_pressure.Value;

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
            label_id.Text = room.Id.ToString();
            label_blocks.Text = room.Grids.Count.ToString();
            label_atmospherics.Text = room.Atmospheres.Count.ToString();
            label_volumen.Text = room.Volumen.ToString();

            numericUpDown_gas_mol.Value = Math.Round((decimal)room.GasMole, 2);

            numericUpDown_oxygen_gas.Value = Math.Round((decimal)room.OxygenPercent * 100, 2);
            numericUpDown_carbondioxide_gas.Value = Math.Round((decimal)room.CarbonDioxidePercent * 100, 2);
            numericUpDown_nitrogen_gas.Value = Math.Round((decimal)room.NitrogenPercent * 100, 2);
            numericUpDown_nitrousoxide_gas.Value = Math.Round((decimal)room.NitrousOxidePercent * 100, 2);
            numericUpDown_pollutant_gas.Value = Math.Round((decimal)room.PollutantPercent * 100, 2);
            numericUpDown_volatiles_gas.Value = Math.Round((decimal)room.VolatilesPercent * 100, 2);
            numericUpDown_water_gas.Value = Math.Round((decimal)room.SteamPercent * 100, 2);

            numericUpDown_oxygen_liquid.Value = Math.Round((decimal)room.LiquidOxygenLitre, 2);
            numericUpDown_carbondioxide_liquid.Value = Math.Round((decimal)room.LiquidCarbonDioxideLitre, 2);
            numericUpDown_nitrogen_liquid.Value = Math.Round((decimal)room.LiquidNitrogenLitre, 2);
            numericUpDown_nitrousoxide_liquid.Value = Math.Round((decimal)room.LiquidNitrousOxideLitre, 2);
            numericUpDown_pollutant_liquid.Value = Math.Round((decimal)room.LiquidPollutantLitre, 2);
            numericUpDown_volatiles_liquid.Value = Math.Round((decimal)room.LiquidVolatilesLitre, 2);
            numericUpDown_water_liquid.Value = Math.Round((decimal)room.WaterLitre, 2);

            if (room.Temperature == 0) { numericUpDown_temperature.Minimum = 0; }
            numericUpDown_temperature.Value = (decimal)room.Temperature;

            if(room.Pressure == 0) { numericUpDown_pressure.Minimum = 0; }
            numericUpDown_pressure.Value = (decimal)room.Pressure;

            label_temp.Text = "K (" + Math.Round(room.TemperatureCelsius, 2).ToString() + "°C)";

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
            room.RemoveGas();
            Print();
            disable_events = false;
        }
    }
}
