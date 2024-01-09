using Microsoft.VisualBasic.Devices;
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
    public partial class FormListNetworkTanks : Form
    {
        Savegame savegame;
        public FormListNetworkTanks(Savegame savegame)
        {
            InitializeComponent();
            this.savegame = savegame;
            ListNetworks();
            ListTanks();
            SizeColumns();
        }

        public void ListTanks()
        {
            foreach (Tank tank in savegame.Tanks)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = tank.Id.ToString();
                lvi.Group = listView1.Groups[1];
                lvi.SubItems.Add(tank.Name);
                lvi.SubItems.Add(tank.Volumen.ToString("N0") + "L");

                if (tank.Atmospheres.Count == 0)
                {
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                }
                else
                {
                    lvi.SubItems.Add(Math.Round(tank.OxygenPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(tank.NitrogenPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(tank.CarbonDioxidePercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(tank.VolatilesPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(tank.PollutantPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(tank.SteamPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(tank.NitrousOxidePercent * 100, 0) + "%");
                }
                lvi.SubItems.Add(tank.Temperature.ToString("N0") + "K ( " + tank.TemperatureCelsius.ToString("N0") + "°C)");
                lvi.SubItems.Add(tank.Pressure.ToString("N0") + "kPa");

                listView1.Items.Add(lvi);
            }
        }

        public void ListNetworks()
        {
            foreach (Network network in savegame.Networks)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = network.Id.ToString();
                lvi.Group = listView1.Groups[0];
                lvi.SubItems.Add("-");
                lvi.SubItems.Add(network.Volumen.ToString("N0") + "L");

                if (network.Atmospheres.Count == 0)
                {
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                }
                else
                {
                    lvi.SubItems.Add(Math.Round(network.OxygenPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(network.NitrogenPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(network.CarbonDioxidePercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(network.VolatilesPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(network.PollutantPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(network.SteamPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(network.NitrousOxidePercent * 100, 0) + "%");
                }
                lvi.SubItems.Add(network.Temperature.ToString("N0") + "K ( " + network.TemperatureCelsius.ToString("N0") + "°C)");
                lvi.SubItems.Add(network.Pressure.ToString("N0") + "kPa");

                listView1.Items.Add(lvi);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (listView1.SelectedItems[0].Group == listView1.Groups[0])
                {
                    FormEditNetworkAtmosphaere form = new FormEditNetworkAtmosphaere(savegame.Networks[listView1.SelectedItems[0].Index]);
                    form.Text = "Atmosphäre bearbeiten für " + savegame.Networks[listView1.SelectedItems[0].Index].Id;
                    form.ShowDialog();
                }
                else
                {
                    FormEditTankAtmosphaere form = new FormEditTankAtmosphaere(savegame.Tanks[listView1.SelectedItems[0].Index - listView1.Groups[0].Items.Count]);
                    form.Text = "Atmosphäre bearbeiten für " + savegame.Tanks[listView1.SelectedItems[0].Index - listView1.Groups[0].Items.Count].Name;
                    form.ShowDialog();
                }
            }
        }

        private void SizeColumns()
        {
            foreach (ColumnHeader col in listView1.Columns)
            {
                col.Width = 60;
            }

            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(10, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(11, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void FormListNetworkTanks_SizeChanged(object sender, EventArgs e)
        {
            SizeColumns();
        }
    }
}
