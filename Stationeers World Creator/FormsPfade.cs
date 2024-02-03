using Stationeers_World_Creator.Properties;
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
    public partial class FormsPfade : Form
    {
        string error = "";

        public FormsPfade()
        {
            InitializeComponent();
        }

        private void FormsPfade_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);




            textBox_game.Text = Form1.settings.stationeers_path;

            if ( Form1.settings.stationeers_mygames_path == null ||  Form1.settings.stationeers_mygames_path == "")
            {
                 //Form1.settings.stationeers_mygames_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Stationeers\\";
            }

            if ( Form1.settings.stationeers_editor_path == null ||  Form1.settings.stationeers_editor_path == "")
            {
                 //Form1.settings.stationeers_editor_path =  Form1.settings.stationeers_mygames_path + "Stationeers Editor\\";
            }

            if ( Form1.settings.stationeers_mods_path == null ||  Form1.settings.stationeers_mods_path == "")
            {
                 Form1.settings.stationeers_mods_path =  Form1.settings.stationeers_mygames_path + "mods\\";
            }

            if ( Form1.settings.stationeers_saves_path == null ||  Form1.settings.stationeers_saves_path == "")
            {
                 Form1.settings.stationeers_saves_path =  Form1.settings.stationeers_mygames_path + "saves\\";
            }

            textBox_saves.Text = Form1.settings.stationeers_saves_path;
            textBox_mods.Text = Form1.settings.stationeers_mods_path;
            textBox_editor.Text = Form1.settings.stationeers_editor_path;
            textBox_data.Text = Form1.settings.stationeers_mygames_path;
        }

        private bool CheckPath(string path)
        {
            if (path.EndsWith(Path.DirectorySeparatorChar.ToString())) { path = Path.Combine(path, ""); }

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!CheckPath(textBox_editor.Text))
            {
                MessageBox.Show("Der Ordner " + textBox_editor.Text + " konnte nicht erstellt werden. Fehler: " + error, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                //Form1.settings.stationeers_editor_path = textBox_editor.Text;
            }

            if (!CheckPath(textBox_saves.Text))
            {
                MessageBox.Show("Der Ordner " + textBox_saves.Text + " konnte nicht erstellt werden. Fehler: " + error, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form1.settings.stationeers_saves_path = textBox_saves.Text;
            }

            if (!CheckPath(textBox_mods.Text))
            {
                MessageBox.Show("Der Ordner " + textBox_mods.Text + " konnte nicht erstellt werden. Fehler: " + error, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form1.settings.stationeers_mods_path = textBox_mods.Text;
            }

            if (!CheckPath(textBox_data.Text))
            {
                MessageBox.Show("Der Ordner " + textBox_data.Text + " konnte nicht erstellt werden. Fehler: " + error, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Form1.settings.stationeers_mygames_path = textBox_data.Text;
            }

            Form1.settings.stationeers_path = textBox_game.Text;

            WorldCollection collection = new WorldCollection(true, Form1.settings.stationeers_path);
            if (!collection.LoadCollection())
            {
                MessageBox.Show("Spiel-Verzeichnis scheint nicht korrekt zu sein." + error, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                panel1.Visible = true;
                button2.Location = new Point(button2.Location.X, button2.Location.Y + panel1.Size.Height);
                this.Size = new Size(this.Size.Width, this.Size.Height + panel1.Height);
            } 
            else
            {
                panel1.Visible = false;
                button2.Location = new Point(button2.Location.X, button2.Location.Y - panel1.Size.Height);
                this.Size = new Size(this.Size.Width, this.Size.Height - panel1.Height);
            }
        }
    }
}
