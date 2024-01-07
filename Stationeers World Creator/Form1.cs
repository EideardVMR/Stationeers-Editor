using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;

namespace Stationeers_World_Creator
{
    public partial class Form1 : Form
    {
        public static string MyGames = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Stationeers\\";
        public static string MyStationeersEditor = MyGames + "Stationeers Editor\\";
        public static Settings settings = new Settings();
        public static List<string> difficultys = new List<string>();
        public static List<WorldCollection> worldCollections = new List<WorldCollection>();
        
        XmlDocument modconfig = new XmlDocument();
        Savegames savegames;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(MyStationeersEditor);

            LoadSettings();

            textBox_stationeers_path.Text = settings.stationeers_path;

            toolStripStatusLabel1.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ScanForUpdate();
        }

        private void ScanForUpdate()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.stationeers.eideard.de/update/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            APIResponse resp = JsonSerializer.Deserialize<APIResponse>(content);


            if (resp != null)
            {
                Version newVersion = new Version(resp.data[0].currentVersion);

                if (Assembly.GetExecutingAssembly().GetName().Version < newVersion)
                {
                    DialogResult dr = MessageBox.Show("Es ist eine neue Version vorhanden (" + newVersion.ToString() + ").\nSoll ich dich zur Downloadseite leiten?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("explorer", "https://stationeers.eideard.de/StationeersEditor");
                    }

                    toolStripStatusLabel1.Text = "Neue Version verfügbar!!!";
                }
            }
        }

        #region Online Requests
        /*
        private void LoadWorldList()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.stationeers.eideard.de/worlds/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            APIResponse resp = JsonSerializer.Deserialize<APIResponse>(content);


            if (resp != null)
            {
                public_worlds = resp.data;

                listBox1.Items.Clear();
                foreach (Worlds respItem in resp.data)
                {
                    listBox1.Items.Add(respItem.NewID + " von " + respItem.Creator);
                }
            }

        }

        private void LoadSingleWorld(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.stationeers.eideard.de/worlds/?WorldID=" + id);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            APIResponse resp = JsonSerializer.Deserialize<APIResponse>(content);

            if (resp.state != "OK")
            {
                DialogResult dr = MessageBox.Show("Daten konnten leider nicht abgerufen werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resp.count == 0)
            {
                DialogResult dr = MessageBox.Show("Für diese ID konnten keine Daten gefunden werden.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (resp != null)
                {
                    selected_public_world = resp.data[0];

                    textBox_id.Text = selected_public_world.WorldID.ToString();
                    label_worldID.Text = selected_public_world.NewID.ToString();
                    label_worldCreator.Text = selected_public_world.Creator.ToString();
                    if (XO.IsLoadValid())
                    {
                        button_add.Enabled = true;
                    }
                }
            }
        }
        */
        #endregion


        //############################################################################################################################################################
        // Methoden
        //############################################################################################################################################################

        private bool LoadCollections()
        {
            worldCollections.Clear();
            listView_collections.Items.Clear();
            listView_worlds.Groups.Clear();
            listView_worlds.Items.Clear();

            if (!File.Exists(textBox_stationeers_path.Text + "\\modconfig.xml"))
            {
                MessageBox.Show("An diesem Pfad konnten nicht die passenden Ressourcen gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            modconfig.Load(textBox_stationeers_path.Text + "\\modconfig.xml");

            WorldCollection collection = new WorldCollection(true, textBox_stationeers_path.Text);
            if (collection.LoadCollection())
            {
                worldCollections.Add(collection);

                label_check_ws.Text = "gefunden";
                label_check_lang.Text = collection.LangCount + " gefunden";
                label_check_ws_header.BackColor = Color.Green;
                label_check_ws.BackColor = Color.Green;
                label_check_lang_header.BackColor = Color.Green;
                label_check_lang.BackColor = Color.Green;

            }
            else
            {
                MessageBox.Show("An diesem Pfad konnten nicht die passenden Ressourcen gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_stationeers_path.Enabled = true;
                button_start.Enabled = true;
                button_save.Enabled = false;

                label_check_ws.Text = "nicht gefunden";
                label_check_lang.Text = "nicht gefunden";
                label_check_ws_header.BackColor = Color.Red;
                label_check_ws.BackColor = Color.Red;
                label_check_lang_header.BackColor = Color.Red;
                label_check_lang.BackColor = Color.Red;
                return false;
            }

            Directory.CreateDirectory(MyGames + "mods");
            string[] mods = Directory.GetDirectories(MyGames + "mods");
            foreach (string mod in mods)
            {
                collection = new WorldCollection(false, mod);
                collection.modconfig = modconfig;
                if (collection.LoadCollection())
                {
                    worldCollections.Add(collection);
                }
            }

            ListCollections();
            ListWorlds();

            return true;
        }

        private void ListCollections()
        {
            listView_collections.Items.Clear();
            foreach (WorldCollection collection in worldCollections)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = collection.Name;
                lvi.SubItems.Add(collection.Author);
                lvi.SubItems.Add(collection.Version);
                lvi.SubItems.Add(collection.getWorlds().Count.ToString());
                lvi.SubItems.Add(collection.Active ? "Aktiv" : "Inaktiv");
                listView_collections.Items.Add(lvi);
            }

            listView_collections.Enabled = true;
        }
        private void ListWorlds()
        {
            listView_worlds.Groups.Clear();
            listView_worlds.Items.Clear();
            foreach (WorldCollection collection in worldCollections)
            {
                collection.lvg = new ListViewGroup();
                collection.lvg.Header = collection.Name;
                listView_worlds.Groups.Add(collection.lvg);

                foreach (World world in collection.Worlds)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = world.Id;
                    lvi.SubItems.Add(world.NameGer);
                    lvi.Group = collection.lvg;

                    listView_worlds.Items.Add(lvi);
                }
            }

            listView_worlds.Enabled = true;
        }
        private void ListSavegames()
        {
            listView_savegames.Items.Clear();
            foreach (Savegame save in savegames.Saves)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = save.WorldName;
                lvi.SubItems.Add(save.GameVersion.ToString());
                lvi.SubItems.Add(save.DaysPast.ToString());
                lvi.SubItems.Add(save.SavePath.Replace(MyGames, "[..]\\"));
                lvi.SubItems.Add(save.IsChanged ? "Ja" : "Nein");

                listView_savegames.Items.Add(lvi);
            }
        }

        void LoadSettings()
        {
            if (File.Exists(MyStationeersEditor + "settings.json"))
            {
                string json = File.ReadAllText(MyStationeersEditor + "settings.json");
                settings = JsonSerializer.Deserialize<Settings>(json);
            }

            if (settings.stationeers_path == null || settings.stationeers_path.Length == 0)
            {
                settings.stationeers_path = "C:\\Steam\\steamapps\\common\\Stationeers";
            }
        }

        void SaveSettings()
        {
            string tmp = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(MyStationeersEditor + "settings.json", tmp);
        }

        void LoadDifficultys()
        {
            difficultys.Clear();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(textBox_stationeers_path.Text + "\\rocketstation_Data\\StreamingAssets\\Data\\difficultySettings.xml");

            XmlNodeList nl = xmlDocument.SelectNodes("//DifficultySettings//DifficultySetting");
            foreach(XmlNode n in nl)
            {
                difficultys.Add(n.Attributes["Id"].Value);
            }

        }

        //############################################################################################################################################################
        // Events
        //############################################################################################################################################################

        #region KontextMenü Kollektion Events
        private void contextMenuStrip_collection_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView_collections.SelectedItems.Count > 0)
            {
                bool isRW = listView_collections.SelectedItems[0].Index != 0;

                collectionToolStripMenuItem.Text = listView_collections.SelectedItems[0].Text;
                collectionToolStripMenuItem.Visible = true;
                toolStripSeparator2.Visible = true;
                kollektionBearbeitenToolStripMenuItem.Enabled = isRW;
                kollektionLöschenToolStripMenuItem.Enabled = isRW;
                kollektionErstellenToolStripMenuItem.Enabled = true;
                kollektionAktivierenToolStripMenuItem.Enabled = isRW;
                kollektionDeaktivierenToolStripMenuItem.Enabled = isRW;
            }
            else
            {
                collectionToolStripMenuItem.Visible = false;
                toolStripSeparator2.Visible = false;
                kollektionBearbeitenToolStripMenuItem.Enabled = false;
                kollektionLöschenToolStripMenuItem.Enabled = false;
                kollektionErstellenToolStripMenuItem.Enabled = true;
                kollektionAktivierenToolStripMenuItem.Enabled = false;
                kollektionDeaktivierenToolStripMenuItem.Enabled = false;
            }
        }


        private void kollektionAktivierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_collections.SelectedItems.Count == 0) { return; }
            WorldCollection wc = worldCollections[listView_collections.SelectedItems[0].Index];
            wc.ActivateCollection();

            ListCollections();
        }

        private void kollektionDeaktivierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_collections.SelectedItems.Count == 0) { return; }
            WorldCollection wc = worldCollections[listView_collections.SelectedItems[0].Index];
            wc.DeactivateCollection();

            ListCollections();
        }

        private void kollektionErstellenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorldCollection newcollection = new WorldCollection(false, null);
            newcollection.InitNewCollection();
            FormNewCollection form = new FormNewCollection(newcollection);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (newcollection.CreateCollection())
                {
                    newcollection.modconfig = modconfig;
                    worldCollections.Add(newcollection);
                }
                else
                {
                    MessageBox.Show("Kollektion konnte nicht erstellt werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ListCollections();
            ListWorlds();
        }
        private void kollektionBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_collections.SelectedItems.Count == 0) { return; }
            if (listView_collections.SelectedItems[0].Index == 0) { MessageBox.Show("Diese Kollektion kann nicht bearbeitet werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            WorldCollection wc = worldCollections[listView_collections.SelectedItems[0].Index];
            FormNewCollection form = new FormNewCollection(wc);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                if (wc.CreateCollection())
                {

                }
                else
                {
                    MessageBox.Show("Kollektion konnte nicht erstellt werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ListCollections();
            ListWorlds();
        }

        private void kollektionLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_collections.SelectedItems.Count == 0) { return; }
            WorldCollection wc = worldCollections[listView_collections.SelectedItems[0].Index];
            if (wc.RemoveCollection())
            {
                DialogResult dr = MessageBox.Show("Diese Kollektion wird JETZT unwiederbringlich gelöscht!!! Bist du dir sicher?", "ACHTUNG", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    worldCollections.Remove(wc);
                }
            }

            ListCollections();
            ListWorlds();
        }
        private void listView_collections_DoubleClick(object sender, EventArgs e)
        {
            kollektionBearbeitenToolStripMenuItem_Click(sender, e);
        }
        #endregion

        #region KontextMenü Welten Events
        private void contextMenuStrip_welten_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (listView_worlds.SelectedItems.Count > 0)
            {
                weltToolStripMenuItem.Text = listView_worlds.SelectedItems[0].Text;
                weltToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = true;
                weltBearbeitenToolStripMenuItem.Visible = true;
                weltEntfernenToolStripMenuItem.Visible = true;
                weltKopierenToolStripMenuItem.Visible = true;


                foreach (WorldCollection collection in worldCollections)
                {
                    foreach (World world in collection.getWorlds())
                    {
                        if (world.Id == listView_worlds.SelectedItems[0].Text)
                        {
                            if (collection.IsDefault)
                            {
                                weltBearbeitenToolStripMenuItem.Enabled = false;
                                weltEntfernenToolStripMenuItem.Enabled = false;
                                weltKopierenToolStripMenuItem.Enabled = true;
                            }
                            else
                            {
                                weltBearbeitenToolStripMenuItem.Enabled = true;
                                weltEntfernenToolStripMenuItem.Enabled = true;
                                weltKopierenToolStripMenuItem.Enabled = true;
                            }

                            weltKopierenToolStripMenuItem.DropDownItems.Clear();
                            ToolStripMenuItem tsmi = new ToolStripMenuItem();
                            tsmi.Text = "In folgende Kollektion:";
                            tsmi.Enabled = false;
                            weltKopierenToolStripMenuItem.DropDownItems.Add(tsmi);

                            ToolStripSeparator tss = new ToolStripSeparator();
                            weltKopierenToolStripMenuItem.DropDownItems.Add(tss);

                            foreach (WorldCollection collection2 in worldCollections)
                            {
                                if (!collection2.IsDefault)
                                {
                                    tsmi = new ToolStripMenuItem();
                                    tsmi.Text = collection2.Name;
                                    tsmi.Click += (object s, EventArgs e) =>
                                    {
                                        if (!collection2.CopyWorldIn(world))
                                        {
                                            MessageBox.Show("Welt konnte nicht kopiert werden. ID ist identisch.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        ListWorlds();
                                    };
                                    weltKopierenToolStripMenuItem.DropDownItems.Add(tsmi);
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                weltToolStripMenuItem.Text = "Bitte wähle eine Welt aus...";
                weltToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = false;
                weltBearbeitenToolStripMenuItem.Visible = false;
                weltEntfernenToolStripMenuItem.Visible = false;
                weltKopierenToolStripMenuItem.Visible = false;
            }

        }

        private void weltBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (listView_worlds.SelectedItems.Count > 0)
            {

                foreach (WorldCollection collection in worldCollections)
                {
                    foreach (World world in collection.getWorlds())
                    {
                        if (world.Id == listView_worlds.SelectedItems[0].Text)
                        {
                            if (!collection.IsDefault)
                            {

                                Form_Edit_World form = new Form_Edit_World(world);
                                DialogResult dr = form.ShowDialog();
                                ListWorlds();
                                break;

                            }
                        }
                    }
                }

            }

        }

        private void listView_worlds_DoubleClick(object sender, EventArgs e)
        {
            weltBearbeitenToolStripMenuItem_Click(sender, e);
        }

        private void weltEntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_worlds.SelectedItems.Count > 0)
            {
                foreach (WorldCollection collection in worldCollections)
                {
                    int i = 0;
                    foreach (World world in collection.getWorlds())
                    {
                        if (world.Id == listView_worlds.SelectedItems[0].Text)
                        {
                            if (collection.RemoveWorld(i))
                            {
                                ListWorlds();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Löschen war nicht möglich", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        i++;
                    }
                }

            }
        }
        #endregion

        #region Settings Events
        private void textBox_stationeers_path_TextChanged(object sender, EventArgs e)
        {
            settings.stationeers_path = textBox_stationeers_path.Text;
            SaveSettings();
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            if (textBox_stationeers_path.Enabled == true)
            {

                if (LoadCollections())
                {
                    textBox_stationeers_path.Enabled = false;
                    //button_start.Enabled = false;
                    button_start.Text = "Stop";
                    button_save.Enabled = true;
                    tabControl1.Enabled = true;
                    savegames = new Savegames(MyGames + "saves\\");
                    savegames.LoadSavegames();
                    ListSavegames();
                    LoadDifficultys();
                }
            }
            else
            {
                if (MessageBox.Show("Alle nicht gespeicherten Änderungen gehen verloren! Bist du sicher?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    textBox_stationeers_path.Enabled = true;
                    button_start.Text = "Start";
                    button_save.Enabled = false;
                    tabControl1.Enabled = false;
                }
            }
        }
        #endregion

        #region Sonstige Events
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "https://www.youtube.com/@EideardVMR");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "https://stationeers.eideard.de");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            ScanForUpdate();
        }

        #endregion

        private void button_save_Click(object sender, EventArgs e)
        {
            foreach (WorldCollection collection in worldCollections)
            {
                if (collection.IsDefault) { continue; }
                collection.Save();
            }

            savegames.SaveAll();

            modconfig.Save(textBox_stationeers_path.Text + "\\modconfig.xml");
        }

        private void listView_savegames_DoubleClick(object sender, EventArgs e)
        {
            if(listView_savegames.SelectedItems.Count > 0)
            {
                FormEditSave form = new FormEditSave(savegames.Saves[listView_savegames.SelectedItems[0].Index]);
                form.Text = "Savegame bearbeiten für " + savegames.Saves[listView_savegames.SelectedItems[0].Index].WorldName;
                form.ShowDialog();
                ListSavegames();
            }
        }
    }
}
