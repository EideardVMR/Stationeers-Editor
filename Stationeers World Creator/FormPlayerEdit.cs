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
    public partial class FormPlayerEdit : Form
    {
        Savegame savegame;
        Player _player;
        bool _disableEvents = false;

        public FormPlayerEdit(Savegame savegame)
        {
            InitializeComponent();
            this.savegame = savegame;
        }

        private void FormPlayerEdit_Load(object sender, EventArgs e)
        {
            foreach (Player player in savegame.Player)
            {
                if (player.IsLoaded)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.Text = player.Name;
                    lvi.SubItems.Add(player.State);
                    lvi.SubItems.Add(Math.Round(player.Nutrition * 100, 0).ToString() + "%");
                    lvi.SubItems.Add(Math.Round(player.Hydration * 100, 0).ToString() + "%");
                    lvi.SubItems.Add(Math.Round(player.StarvationDamage * 100, 0).ToString() + "%");
                    lvi.SubItems.Add(Math.Round(player.HydrationDamage * 100, 0).ToString() + "%");
                    lvi.SubItems.Add(Math.Round(player.BurnDamage * 100, 0).ToString() + "%");
                    lvi.SubItems.Add(Math.Round(player.ToxicDamage * 100, 0).ToString() + "%");

                    listView1.Items.Add(lvi);
                }

            }
        }

        public void PrintPlayer()
        {
            _disableEvents = true;
            comboBox1.Text = _player.State;
            numericUpDown_essen.Value = (decimal)Math.Round(_player.Nutrition * 100, 0);
            numericUpDown_trinken.Value = (decimal)Math.Round(_player.Hydration * 100, 0);
            numericUpDown_starvation.Value = (decimal)Math.Round(_player.StarvationDamage * 100, 0);
            numericUpDown_hydration.Value = (decimal)Math.Round(_player.HydrationDamage * 100, 0);
            numericUpDown_lung.Value = (decimal)Math.Round(_player.BurnDamage * 100, 0);
            numericUpDown_toxic.Value = (decimal)Math.Round(_player.ToxicDamage * 100, 0);

            _disableEvents = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            _player.State = comboBox1.Text;
            PrintPlayer();
        }

        private void numericUpDown_essen_ValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if (_player == null) { return; }
            _player.Nutrition = (double)((NumericUpDown)sender).Value / 100;
            PrintPlayer();
        }

        private void numericUpDown_trinken_ValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if (_player == null) { return; }
            _player.Hydration = (double)((NumericUpDown)sender).Value / 100;
            PrintPlayer();
        }

        private void numericUpDown_starvation_ValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if (_player == null) { return; }
            _player.StarvationDamage = (double)((NumericUpDown)sender).Value / 100;
            PrintPlayer();
        }

        private void numericUpDown_hydration_ValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if (_player == null) { return; }
            _player.HydrationDamage = (double)((NumericUpDown)sender).Value / 100;
            PrintPlayer();
        }

        private void numericUpDown_lung_ValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if (_player == null) { return; }
            _player.BurnDamage = (double)((NumericUpDown)sender).Value / 100;
            PrintPlayer();
        }

        private void numericUpDown_toxic_ValueChanged(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if (_player == null) { return; }
            _player.ToxicDamage = (double)((NumericUpDown)sender).Value / 100;
            PrintPlayer();
        }

        private void button_restore_Click(object sender, EventArgs e)
        {
            if (_disableEvents) { return; }
            if(_player == null) { return; }
            _player.State = "Alive";
            _player.Nutrition = 1;
            _player.Hydration = 1;
            _player.StarvationDamage = 0;
            _player.HydrationDamage = 0;
            _player.BurnDamage = 0;
            _player.ToxicDamage = 0;
            _player.OxygenDamage = 0;
            PrintPlayer();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedIndices.Count > 0)
            {
                _player = savegame.Player[listView1.SelectedItems[0].Index];
                PrintPlayer();
                label8.Visible = false;
            }
            else
            {
                _player = null;
                label8.Visible = true;
            }
        }
    }
}
