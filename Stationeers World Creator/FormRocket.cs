using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            label_state.Text = _rocket.RocketState.ToString();
            label_mode.Text = _rocket.RocketMode.ToString();

            SpaceMapPoint spm = _rocket.getSpaceMap(_rocket.CurrentNodeId);
            if (spm != null)
            {
                comboBox_position.Text = spm.TemplateId;
            }

            label_progress.Text = Math.Round((decimal)_rocket.Progress * 100).ToString();

            label_things.Text = _rocket.Things.Count.ToString();

            _eventsdisabled = false;
        }

        private void comboBox_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_eventsdisabled) { return; }
            if (_rocket == null) { return; }
            SpaceMapPoint spm = _rocket.getSpaceMap(((ComboBox)sender).Text);
            if (spm == null) { return; }
            _rocket.CurrentNodeId = spm.Id;
            PrintRocketData();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {

            if (_eventsdisabled) { return; }
            if (_rocket == null) { return; }
            _rocket.RocketState = "OnLaunchMount";
            _rocket.RocketMode = "None";
            _rocket.Progress = 0;
            _rocket.TargetNodeId = 0;
            _rocket.CurrentNodeId = _rocket.LandingpadID;

            _rocket.RocketTransformPosition = new Point3D(0,0,0);
            _rocket.ParentedPosition = new Point3D(0, 0, 0);
            _rocket.TargetPosition = new Point3D(0, 0, 0);
            _rocket.ParkLocation = new Point2D(0, 0);

            //Debug.WriteLine("------------------------------------------------");

            //Debug.WriteLine("State: " + _rocket.RocketState);
            //Debug.WriteLine("Mode: " + _rocket.RocketMode);
            //Debug.WriteLine("Progress: " + _rocket.Progress);
            //Debug.WriteLine("Target: " + _rocket.TargetNodeId);
            //Debug.WriteLine("Current Node: " + _rocket.CurrentNodeId);

            foreach (Thing thing in _rocket.Things)
            {
                if(thing.WorldPosition.Y > 4000)
                {
                    double x = (thing.WorldPosition.X - 1) + _rocket.LandingMount.WorldPosition.X;
                    double y = thing.WorldPosition.Y - 3993;
                    double z = (thing.WorldPosition.Z - 1) + _rocket.LandingMount.WorldPosition.Z;

                    //Debug.WriteLine( x.ToString().PadLeft(6) + ";" + y.ToString().PadLeft(6) + ";" + z.ToString().PadLeft(6) + " | " + thing.PrefabName + " | " + thing.Id);

                    thing.WorldPosition = new Point3D(x, y, z);
                    thing.RegisteredWorldPosition = new Point3D(x, y, z);

                }
            }

            PrintRocketData();
        }
    }
}
