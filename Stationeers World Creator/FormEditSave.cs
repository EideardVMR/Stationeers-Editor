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
            if(!savegame.LoadWorld())
            {
                button_rooms.Enabled = false;
                MessageBox.Show("Die world.xml konnte nicht geladen werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            if(savegame.GameVersion < new Version("0.2.4677.21598"))
            {
                DialogResult dr = MessageBox.Show("Diese Spielstandversion (" + savegame.GameVersion + ") ist älter als die vom Stationeers Editor unterstützte Version. Wenn du fortfahren möchtest, kann es zu Fehlern kommen, es könnte den Spielstand zerstören (mach ein Backup) oder die Software kann abstürzen.\n\nMöchtest du fortfahren?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr == DialogResult.No)
                {
                    this.Close();
                }

            }

            button_rooms.Text = "Räume (" + savegame.Rooms.Count + ")";

        }

        private void button_rooms_Click(object sender, EventArgs e)
        {
            FormEditRooms form = new FormEditRooms(savegame);
            form.Text = "Räume bearbeiten für " + savegame.WorldName;
            form.ShowDialog();
        }
    }
}
