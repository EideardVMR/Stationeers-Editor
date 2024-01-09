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
    public partial class FormEditRooms : Form
    {
        Savegame savegame { get; set; }
        public FormEditRooms(Savegame savegame)
        {
            InitializeComponent();
            this.savegame = savegame;
        }

        private void FormEditRooms_Load(object sender, EventArgs e)
        {
            ListRooms();
        }

        public void ListRooms()
        {

            listView1.Items.Clear();
            foreach (Room room in savegame.Rooms)
            {
                room.LoadAtmosphere();

                double sumgaspercent = (
                    Math.Round(room.OxygenPercent * 100, 0) +
                    Math.Round(room.NitrogenPercent * 100, 0) +
                    Math.Round(room.CarbonDioxidePercent * 100, 0) +
                    Math.Round(room.VolatilesPercent * 100, 0) +
                    Math.Round(room.PollutantPercent * 100, 0) +
                    Math.Round(room.SteamPercent * 100, 0) +
                    Math.Round(room.NitrousOxidePercent * 100, 0)
                );

                ListViewItem lvi = new ListViewItem();
                lvi.Text = room.Id.ToString();
                lvi.SubItems.Add((room.Grids.Count).ToString("N0"));
                lvi.SubItems[1].Text += room._atmoNodes.Count < room.Grids.Count ? " ( " + (room.Grids.Count - room._atmoNodes.Count) + " fehlen)" : (room._atmoNodes.Count > room.Grids.Count ? " (" + (room._atmoNodes.Count - room.Grids.Count) + " zuviel)" : "");
                lvi.SubItems.Add(room.Volumen.ToString("N0") + "L");
                if (room._atmoNodes.Count == 0)
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
                    lvi.SubItems.Add(Math.Round(room.OxygenPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(room.NitrogenPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(room.CarbonDioxidePercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(room.VolatilesPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(room.PollutantPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(room.SteamPercent * 100, 0) + "%");
                    lvi.SubItems.Add(Math.Round(room.NitrousOxidePercent * 100, 0) + "%");
                }
                lvi.SubItems.Add(room.Temperature.ToString("N0") + "K ( " + room.TemperatureCelsius.ToString("N0") + "°C)");
                lvi.SubItems.Add(room.Pressure.ToString("N0") + "kPa");
                listView1.Items.Add(lvi);


                if (room.Grids.Count != room._atmoNodes.Count)
                {
                    lvi.ForeColor = Color.Red;
                }
                else if (!Settings.SimilarValue(sumgaspercent, 100, 0.01) && sumgaspercent != 0)
                {
                    lvi.ForeColor = Color.Orange;
                }
                else
                {
                    lvi.ForeColor = Color.Green;
                }
            }

            foreach (ColumnHeader col in listView1.Columns)
            {
                col.Width = 60;
            }

            listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(10, ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumn(11, ColumnHeaderAutoResizeStyle.ColumnContent);



        }

        public int max = 100;
        public int current = 0;

        public void Threadtest()
        {
            for (int i = 0; i < max; i++)
            {
                Thread.Sleep(1000);
                current = i;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                FormEditRoomAtmosphaere form = new FormEditRoomAtmosphaere(savegame.Rooms[listView1.SelectedItems[0].Index]);
                form.Text = "Raumatmosphäre bearbeiten";
                form.ShowDialog();
                ListRooms();
            }
        }

        private void FormEditRooms_SizeChanged(object sender, EventArgs e)
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
    }
}
