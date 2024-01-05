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

            Init();
            Print();
        }

        public void Init()
        {


            numericUpDown_oxygen_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };
            numericUpDown_carbondioxide_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };
            numericUpDown_nitrogen_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };
            numericUpDown_nitrousoxide_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };
            numericUpDown_pollutant_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };
            numericUpDown_volatiles_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };
            numericUpDown_water_gas.ValueChanged += (object o, EventArgs s) =>
            {
                CalcGases();
            };

            numericUpDown_oxygen_liquid.Value = (decimal)room.LiquidOxygenLitre;
            numericUpDown_carbondioxide_liquid.Value = (decimal)room.LiquidCarbonDioxideLitre;
            numericUpDown_nitrogen_liquid.Value = (decimal)room.LiquidOxygenLitre;
            numericUpDown_nitrousoxide_liquid.Value = (decimal)room.LiquidNitrousOxideLitre;
            numericUpDown_pollutant_liquid.Value = (decimal)room.LiquidPollutantLitre;
            numericUpDown_volatiles_liquid.Value = (decimal)room.LiquidVolatilesLitre;
            numericUpDown_water_liquid.Value = (decimal)room.WaterLitre;

            numericUpDown_temperature.Value = (decimal)room.Temperature;
            numericUpDown_pressure.Value = (decimal)room.Pressure;
        }

        private void CalcGases()
        {
            decimal sum =
                numericUpDown_oxygen_gas.Value +
                numericUpDown_carbondioxide_gas.Value +
                numericUpDown_nitrogen_gas.Value +
                numericUpDown_nitrousoxide_gas.Value +
                numericUpDown_pollutant_gas.Value +
                numericUpDown_volatiles_gas.Value +
                numericUpDown_water_gas.Value;

            label_sum.Text = sum.ToString("N0") +"%";
            if(sum != 100)
            {
                label_sum.BackColor = Color.Red;
                label_sum.ForeColor = Color.White;
                return;
            }

            label_sum.BackColor = Color.Green;
            label_sum.ForeColor = Color.White;

            

            room.Oxygen = room.GasMole * ((double)numericUpDown_oxygen_gas.Value / 100);
            room.CarbonDioxide = room.GasMole * ((double)numericUpDown_carbondioxide_gas.Value / 100);
            room.Nitrogen = room.GasMole * ((double)numericUpDown_nitrogen_gas.Value / 100);
            room.NitrousOxide = room.GasMole * ((double)numericUpDown_nitrousoxide_gas.Value / 100);
            room.Pollutant = room.GasMole * ((double)numericUpDown_pollutant_gas.Value / 100);
            room.Volatiles = room.GasMole * ((double)numericUpDown_volatiles_gas.Value / 100);
            room.Steam = room.GasMole * ((double)numericUpDown_water_gas.Value / 100);


            numericUpDown_temperature.Value = (decimal)room.Temperature;
            numericUpDown_pressure.Value = (decimal)room.Pressure;
        }

        public void Print()
        {
            label_id.Text = room.Id.ToString();
            label_blocks.Text = room.Grids.Count.ToString();
            label_atmospherics.Text = room.Atmospheres.Count.ToString();
            label_volumen.Text = room.Volumen.ToString();

            numericUpDown_oxygen_gas.Value = (decimal)room.OxygenPercent * 100;
            numericUpDown_carbondioxide_gas.Value = (decimal)room.CarbonDioxidePercent * 100;
            numericUpDown_nitrogen_gas.Value = (decimal)room.NitrogenPercent * 100;
            numericUpDown_nitrousoxide_gas.Value = (decimal)room.NitrousOxidePercent * 100;
            numericUpDown_pollutant_gas.Value = (decimal)room.PollutantPercent * 100;
            numericUpDown_volatiles_gas.Value = (decimal)room.VolatilesPercent * 100;
            numericUpDown_water_gas.Value = (decimal)room.SteamPercent * 100;

            numericUpDown_oxygen_liquid.Value = (decimal)room.LiquidOxygenLitre;
            numericUpDown_carbondioxide_liquid.Value = (decimal)room.LiquidCarbonDioxideLitre;
            numericUpDown_nitrogen_liquid.Value = (decimal)room.LiquidOxygenLitre;
            numericUpDown_nitrousoxide_liquid.Value = (decimal)room.LiquidNitrousOxideLitre;
            numericUpDown_pollutant_liquid.Value = (decimal)room.LiquidPollutantLitre;
            numericUpDown_volatiles_liquid.Value = (decimal)room.LiquidVolatilesLitre;
            numericUpDown_water_liquid.Value = (decimal)room.WaterLitre;

            numericUpDown_temperature.Value = (decimal)room.Temperature;
            numericUpDown_pressure.Value = (decimal)room.Pressure;

            label_temp.Text = "K (" + room.TemperatureCelsius.ToString() + "°C)";

            CalcGases();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
