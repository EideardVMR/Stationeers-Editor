using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stationeers_World_Creator
{
    public partial class FormNewCollection : Form
    {
        WorldCollection collection;

        public FormNewCollection(WorldCollection collection)
        {
            InitializeComponent();
            this.collection = collection;
        }

        private void FormNewCollection_Load(object sender, EventArgs e)
        {
            textBox_name.Text = collection.Name;
            textBox_author.Text = collection.Author;
            textBox_version.Text = collection.Version;
            richTextBox_description.Text = collection.Description;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button_abort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            if (!collection.IsCreated)
            {
                string tmp = textBox_name.Text;
                Regex regex = new Regex("[^a-zA-Z]"); // Alle Zeichen außer Buchstaben entfernen
                tmp = regex.Replace(tmp, "");

                if (Directory.Exists(Form1.settings.stationeers_mods_path + tmp))
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Name der Kollektion - existiert bereits";
                    button_save.Enabled = false;
                    return;
                } else
                {
                    label1.ForeColor = SystemColors.ControlText;
                    label1.Text = "Name der Kollektion";
                    button_save.Enabled = true;
                }

            }

            collection.Name = textBox_name.Text;
        }

        private void textBox_author_TextChanged(object sender, EventArgs e)
        {
            collection.Author = textBox_author.Text;    
        }

        private void textBox_version_TextChanged(object sender, EventArgs e)
        {
            collection.Version = textBox_version.Text;
        }

        private void richTextBox_description_TextChanged(object sender, EventArgs e)
        {
            collection.Description = richTextBox_description.Text;
        }

        private bool CheckInput()
        {
            bool ok = true;
            Regex regex = new Regex("[0-9].[0-9].[0-9]");
            if (!regex.IsMatch(collection.Version))
            {
                textBox_version.BackColor = Color.Red;
                ok = false;
            }
            else
            {
                textBox_version.BackColor = SystemColors.Window;
            }

            if (collection.Name.Length < 5)
            {
                textBox_name.BackColor = Color.Red;
                ok = false;
            }
            else
            {
                textBox_name.BackColor = SystemColors.Window;
            }

            if (collection.Author.Length < 2)
            {
                textBox_author.BackColor = Color.Red;
                ok = false;
            }
            else
            {
                textBox_author.BackColor = SystemColors.Window;
            }

            if (!collection.Description.Contains("Erstellt mit Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)"))
            {
                collection.Description += "Erstellt mit Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)";
                richTextBox_description.Text = collection.Description;
            }

            return ok;
        }
    }
}
