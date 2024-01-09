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
    public partial class FormThingList : Form
    {
        Savegame savegame;
        Dictionary<string, int> thinglist = new Dictionary<string, int>();


        public FormThingList(Savegame save)
        {
            InitializeComponent();
            savegame = save;
        }

        private void FormThingList_Load(object sender, EventArgs e)
        {
            LoadThings();
        }

        public void LoadThings()
        {

            foreach (Thing thing in savegame.Things)
            {
                if (thinglist.ContainsKey(thing.PrefabName))
                {
                    thinglist[thing.PrefabName]++;
                }
                else
                {
                    thinglist.Add(thing.PrefabName, 1);
                }
            }

            PrintThings();
        }

        public void PrintThings()
        {
            var sorted = thinglist.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            listView1.Items.Clear();

            int i = 0;
            foreach (var kvp in sorted)
            {
                if (textBox1.Text == "" || kvp.Key.Contains(textBox1.Text))
                {
                    if(kvp.Key != "Character" && kvp.Key != "OrganLungs" && kvp.Key != "OrganBrain")
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = kvp.Key;
                        lvi.SubItems.Add(kvp.Value.ToString());
                        listView1.Items.Add(lvi);
                    }
                }

                i++;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PrintThings();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemNameToolStripMenuItem.Enabled = false;
            entfernenToolStripMenuItem.Enabled = listView1.SelectedItems.Count > 0;
        }

        private void entfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                for(int i = 0; i < savegame.Things.Count; i++)
                {
                    if (savegame.Things[i].PrefabName == listView1.SelectedItems[0].Text)
                    {
                        savegame.Things.Remove(savegame.Things[i]);
                        i--;
                    }
                }

                PrintThings();
            }

        }
    }
}
