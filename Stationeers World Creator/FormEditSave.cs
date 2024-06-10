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
    public partial class FormEditSave : Form
    {
        Savegame savegame { get; set; }

        public FormEditSave(Savegame savegame)
        {
            InitializeComponent();
            this.savegame = savegame;
        }

        private void FormEditSave_Load(object sender, EventArgs e)
        {

            if (savegame.GameVersion < new Version("0.2.4902.22241"))
            {
                DialogResult dr = MessageBox.Show("Diese Spielstandversion (" + savegame.GameVersion + ") ist älter als die vom Stationeers Editor unterstützte Version. Wenn du fortfahren möchtest, kann es zu Fehlern kommen, es könnte den Spielstand zerstören (mach ein Backup) oder die Software kann abstürzen.\n\nMöchtest du fortfahren?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    this.Close();
                }

            }

            if (!savegame.LoadWorld())
            {
                button_rooms.Enabled = false;
                MessageBox.Show("Die world.xml konnte nicht geladen werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            comboBox_difficulty.Items.Clear();
            foreach (string diff in Form1.difficultys)
            {
                comboBox_difficulty.Items.Add(diff);
            }
            comboBox_difficulty.Text = savegame.Difficulty;

            int i = 0;
            comboBox_world.Items.Clear();
            foreach (WorldCollection collection in Form1.worldCollections)
            {
                foreach (World world in collection.Worlds)
                {
                    if (i > 0)
                    {
                        comboBox_world.Items.Add(world.Id);
                    }
                    i++;
                }
            }
            comboBox_world.Text = savegame.WorldId;

            button_things.Text = "Gegenstände (" + savegame.Things.Count + ")";
            button_rockets.Text = "Raketen (" + savegame.Rockets.Count + ")";
            button_rooms.Text = "Räume (" + savegame.Rooms.Count + ")";
            button_networks.Text = "Gasnetzwerke / Tanks (" + savegame.Networks.Count + " / " + savegame.Tanks.Count + ")";
            button_player.Text = "Spieler (" + savegame.Player.Count + ")";

            textBox_seed.Text = savegame.Seed.ToString();
            checkBox_research.Checked = savegame.Research == "ResearchOn" ? true : false;

        }

        private void button_rooms_Click(object sender, EventArgs e)
        {
            FormEditRooms form = new FormEditRooms(savegame);
            form.Text = "Räume bearbeiten für " + savegame.SavegameName;
            form.ShowDialog();
        }

        private void button_rockets_Click(object sender, EventArgs e)
        {
            FormRocket form = new FormRocket(savegame);
            form.ShowDialog();
        }

        private void button_networks_Click(object sender, EventArgs e)
        {
            FormListNetworkTanks form = new FormListNetworkTanks(savegame);
            form.Text = "Netzwerk / Tank bearbeiten für " + savegame.SavegameName;
            form.ShowDialog();
        }

        private void button_things_Click(object sender, EventArgs e)
        {
            FormThingList form = new FormThingList(savegame);
            form.Text = "Gegenstände für " + savegame.SavegameName;
            form.ShowDialog();
        }

        private void textBox_seed_TextChanged(object sender, EventArgs e)
        {
            int newseed = 0;
            if (int.TryParse(textBox_seed.Text, out newseed))
            {
                textBox_seed.ForeColor = SystemColors.WindowText;
                savegame.Seed = newseed;
            }
            else
            {
                textBox_seed.ForeColor = Color.Red;
            }
        }

        private void checkBox_research_CheckedChanged(object sender, EventArgs e)
        {
            savegame.Research = checkBox_research.Checked ? "ResearchOn" : "ResearchOff";
        }

        private void comboBox_world_SelectedIndexChanged(object sender, EventArgs e)
        {
            savegame.WorldId = ((ComboBox)sender).Text;
        }

        private void comboBox_difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            savegame.Difficulty = ((ComboBox)sender).Text;
        }

        private void button_player_Click(object sender, EventArgs e)
        {
            FormPlayerEdit form = new FormPlayerEdit(savegame);
            form.Text = "Spielerliste für " + savegame.SavegameName;
            form.ShowDialog();
        }
    }
}
