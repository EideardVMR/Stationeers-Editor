using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationeers_World_Creator
{
    public partial class FormRocket : Form
    {
        bool _eventsdisabled = true;
        Savegame savegame;
        Rocket _rocket;
        public FormRocket(Savegame save)
        {
            InitializeComponent();
            savegame = save;
        }

        private void FormRocket_Load(object sender, EventArgs e)
        {
            foreach (string x in Rocket.AvailableStates)
            {
                comboBox_state.Items.Add(x);
            }

            foreach (string x in Rocket.AvailableModes)
            {
                comboBox_mode.Items.Add(x);
            }

            foreach (Rocket rocket in savegame.Rockets)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = rocket.Id.ToString();
                lvi.SubItems.Add(rocket.Name);
                lvi.SubItems.Add(rocket.TargetNodeId.ToString());
                lvi.SubItems.Add(rocket.RocketMode);

                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                _rocket = savegame.Rockets[listView1.SelectedItems[0].Index];
                PrintRocketData();
                label_blocker.Visible = false;
            }
            else
            {
                _rocket = null;
                label_blocker.Visible = true;
            }
        }

        private void PrintRocketData()
        {
            _eventsdisabled = true;
            comboBox_position.Items.Clear();
            foreach (SpaceMapPoint spaceMapPoint in _rocket.SpaceMapPoints)
            {
                comboBox_position.Items.Add(spaceMapPoint);
            }

            comboBox_state.Text = _rocket.RocketState.ToString();
            comboBox_mode.Text = _rocket.RocketMode.ToString();

            SpaceMapPoint spm = _rocket.getSpaceMap(_rocket.TargetNodeId);
            if (spm != null)
            {
                comboBox_position.Text = spm.TemplateId;
            }

            numericUpDown_progress.Value = Math.Round((decimal)_rocket.Progress * 100);

            _eventsdisabled = false;
        }

        private void comboBox_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_eventsdisabled) { return;  }
            if(_rocket == null) { return; }
            _rocket.RocketState = ((ComboBox)sender).Text;
            PrintRocketData();
        }

        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_eventsdisabled) { return; }
            if (_rocket == null) { return; }
            _rocket.RocketMode = ((ComboBox)sender).Text;
            PrintRocketData();
        }

        private void comboBox_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_eventsdisabled) { return; }
            if (_rocket == null) { return; }
            SpaceMapPoint spm = _rocket.getSpaceMap(((ComboBox)sender).Text);
            if (spm == null) { return; }
            _rocket.TargetNodeId = spm.Id;
            PrintRocketData();
        }

        private void numericUpDown_progress_ValueChanged(object sender, EventArgs e)
        {
            if (_eventsdisabled) { return; }
            if (_rocket == null) { return; }
            _rocket.Progress = (double)((NumericUpDown)sender).Value / 100;
            PrintRocketData();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            if (_eventsdisabled) { return; }
            if (_rocket == null) { return; }
            _rocket.RocketState = "OnLaunchMount";
            _rocket.RocketMode = "None";
            _rocket.Progress = 0;
            PrintRocketData();
        }
    }
}
