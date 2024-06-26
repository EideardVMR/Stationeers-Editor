using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Stationeers_World_Creator
{
    public partial class Form1 : Form
    {
        //public static string MyGames = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Stationeers\\";
        //public static string MyStationeersEditor = MyGames + "Stationeers Editor\\";
        public static Settings settings = new Settings();
        public static List<string> difficultys = new List<string>();
        public static List<WorldCollection> worldCollections = new List<WorldCollection>();

        XmlDocument modconfig = new XmlDocument();
        Savegames savegames;

        public Form1()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadSettings();

            WorldCollection collection = new WorldCollection(true, settings.stationeers_path);
            if (
                collection.LoadCollection() &&
                Directory.Exists(settings.stationeers_mygames_path) &&
                Directory.Exists(settings.stationeers_mods_path) &&
                Directory.Exists(settings.stationeers_saves_path)
            )
            {
                button_start_Click(sender, e);  
            }

            //FormsPfade form = new FormsPfade();
            //if(form.ShowDialog() != DialogResult.OK) { this.Close(); return; }

            textBox_stationeers_path.Text = settings.stationeers_path;

            toolStripStatusLabel1.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ScanForUpdate();

            SendStatistics();
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
                    DialogResult dr = MessageBox.Show("Es ist eine neue Version vorhanden (" + newVersion.ToString() + ").\nSoll ich die Datei runterladen?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (dr == DialogResult.Yes)
                    {
                        //System.Diagnostics.Process.Start("explorer", "https://stationeers.eideard.de/StationeersEditor");
                        using (WebClient webClient = new WebClient())
                        {
                            try
                            {
                                webClient.DownloadFile(resp.data[0].downloadPath, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Stationeers Editor-" + resp.data[0].currentVersion + ".exe"));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Datei konnte nicht runtergeladen werden:\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    toolStripStatusLabel1.Text = "Neue Version verf�gbar!!!";
                }
            }
        }


        //############################################################################################################################################################
        // Methoden
        //############################################################################################################################################################

        private bool LoadCollections()
        {
            worldCollections.Clear();
            listView_collections.Items.Clear();
            listView_worlds.Groups.Clear();
            listView_worlds.Items.Clear();

            if (!File.Exists(settings.stationeers_path + "\\modconfig.xml"))
            {
                if(!File.Exists(settings.stationeers_path + "\\rocketstation.exe"))
                {
                    MessageBox.Show("An diesem Pfad konnten nicht die passenden Ressourcen (modconfig.xml oder rocketstation.exe) gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

                try
                {
                    using (StreamWriter sw = File.CreateText(settings.stationeers_path + "\\modconfig.xml"))
                    {

                        sw.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<ModConfig xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Mods>\r\n    <ModData>\r\n      <Id>1</Id>\r\n      <IsEnabled>true</IsEnabled>\r\n    </ModData>\r\n  </Mods>\r\n</ModConfig>");

                    }
                } 
                catch (Exception ex)
                {
                    MessageBox.Show("Ressourcendatei (modconfig.xml) wurde nicht gefunden und konnte nicht erstellt werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            }

            modconfig.Load(settings.stationeers_path + "\\modconfig.xml");

            WorldCollection collection = new WorldCollection(true, settings.stationeers_path);
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
                MessageBox.Show("An diesem Pfad konnten nicht die passenden Ressourcen (worldsettings.xml) gefunden werden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string[] mods = Directory.GetDirectories(settings.stationeers_mods_path);
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
                lvi.Text = save.SavegameName;
                lvi.SubItems.Add(save.GameVersion.ToString());
                lvi.SubItems.Add(save.DaysPast.ToString());
                lvi.SubItems.Add(save.SavePath.Replace(settings.stationeers_mygames_path, "[..]\\"));
                lvi.SubItems.Add(save.IsChanged ? "Ja" : "Nein");

                listView_savegames.Items.Add(lvi);
            }
        }

        void LoadSettings()
        {
            Directory.CreateDirectory(settings.stationeers_editor_path);

            if (File.Exists(settings.stationeers_editor_path + "settings.json"))
            {
                string json = File.ReadAllText(settings.stationeers_editor_path + "settings.json");
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
            File.WriteAllText(settings.stationeers_editor_path + "settings.json", tmp);
        }

        void LoadDifficultys()
        {
            difficultys.Clear();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(settings.stationeers_path + "\\rocketstation_Data\\StreamingAssets\\Data\\difficultySettings.xml");

            XmlNodeList nl = xmlDocument.SelectNodes("//DifficultySettings//DifficultySetting");
            foreach (XmlNode n in nl)
            {
                difficultys.Add(n.Attributes["Id"].Value);
            }

        }

        void SendStatistics()
        {

            if (settings.AllowToSendStatisticsData == "Unknown")
            {
                DialogResult dr = MessageBox.Show("Hallo,\nich freue mich, dass du dieses kleine Projekt gefunden hast und nutzt.\nIch w�rde gerne wissen wie " +
                    "frequentiert meine Software genutzt wird und m�chte daher ein " +
                    "paar Daten erheben. Mich w�rde es freuen, wenn du mich unterst�tzen w�rdest und dem zustimmst.\n\n" +
                    "Aktuell erhobene Daten:\n" +
                    "- Ein Nutzungscounter (wie oft wird die Software genutzt)\n\n" +
                    "Du als Person, bleibst vollst�ndig Anonym!",
                    "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    settings.AllowToSendStatisticsData = "Yes";
                    if (settings.SystemID.Length != 200)
                    {
                        settings.SystemID = Settings.RandomStringMitZahlen(200);
                    }
                    SaveSettings();
                }
                else
                {
                    settings.AllowToSendStatisticsData = "No";
                    SaveSettings();
                }

            }

            toolStripStatusLabel_Statistics.Text = "Statistikdaten �bermitteln: Inaktiv";
            toolStripStatusLabel_Statistics.BackColor = Color.Brown;

            if (settings.AllowToSendStatisticsData != "Yes") { return; }

            toolStripStatusLabel_Statistics.Text = "Statistikdaten �bermitteln: Aktiv";
            toolStripStatusLabel_Statistics.BackColor = Color.ForestGreen;

            if (settings.SystemID.Length != 200)
            {
                settings.SystemID = Settings.RandomStringMitZahlen(200);
                SaveSettings();
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://api.stationeers.eideard.de/usageinfo/" + settings.SystemID);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

        }

        //############################################################################################################################################################
        // Events
        //############################################################################################################################################################

        #region KontextMen� Kollektion Events
        private void contextMenuStrip_collection_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (listView_collections.SelectedItems.Count > 0)
            {
                bool isRW = listView_collections.SelectedItems[0].Index != 0;

                collectionToolStripMenuItem.Text = listView_collections.SelectedItems[0].Text;
                collectionToolStripMenuItem.Visible = true;
                toolStripSeparator2.Visible = true;
                kollektionBearbeitenToolStripMenuItem.Enabled = isRW;
                kollektionL�schenToolStripMenuItem.Enabled = isRW;
                kollektionErstellenToolStripMenuItem.Enabled = true;
                kollektionAktivierenToolStripMenuItem.Enabled = isRW;
                kollektionDeaktivierenToolStripMenuItem.Enabled = isRW;
            }
            else
            {
                collectionToolStripMenuItem.Visible = false;
                toolStripSeparator2.Visible = false;
                kollektionBearbeitenToolStripMenuItem.Enabled = false;
                kollektionL�schenToolStripMenuItem.Enabled = false;
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

        private void kollektionL�schenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_collections.SelectedItems.Count == 0) { return; }
            WorldCollection wc = worldCollections[listView_collections.SelectedItems[0].Index];
            if (wc.RemoveCollection())
            {
                DialogResult dr = MessageBox.Show("Diese Kollektion wird JETZT unwiederbringlich gel�scht!!! Bist du dir sicher?", "ACHTUNG", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        #region KontextMen� Welten Events
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
                weltToolStripMenuItem.Text = "Bitte w�hle eine Welt aus...";
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
                            else
                            {
                                MessageBox.Show("Welt kann nicht bearbeitet werden, Bitte erstelle eine Kopie der Welt in einer neuen Kollektion. Mit rechter Maustaste in der Liste der Kollektionen kannst du eine Kollektion erstellen bzw. rechte Maustaste in den Welten kannst du eine Kopie einer Standardwelt in der neuen Kollektion erstellen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show("L�schen war nicht m�glich", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
        private void button_start_Click(object sender, EventArgs e)
        {
            if (textBox_stationeers_path.Enabled == true)
            {

                if (settings.stationeers_mods_path == null || settings.stationeers_mods_path == "")
                {
                    settings.stationeers_mods_path = settings.stationeers_mygames_path + "mods\\";
                }

                if (settings.stationeers_saves_path == null || settings.stationeers_saves_path == "")
                {
                    settings.stationeers_saves_path = settings.stationeers_mygames_path + "saves\\";
                }

                if (Directory.Exists(settings.stationeers_mods_path))
                {
                    try
                    {
                        Directory.CreateDirectory(settings.stationeers_mods_path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Der Ordner " + settings.stationeers_mods_path + " konnte nicht erstellt werden. Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (Directory.Exists(settings.stationeers_saves_path))
                {
                    try
                    {
                        Directory.CreateDirectory(settings.stationeers_saves_path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Der Ordner " + settings.stationeers_saves_path + " konnte nicht erstellt werden. Fehler: " + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                SaveSettings();

                if (LoadCollections())
                {
                    textBox_stationeers_path.Enabled = false;
                    //button_start.Enabled = false;
                    button_start.Text = "Stop";
                    button_save.Enabled = true;
                    tabControl1.Enabled = true;
                    savegames = new Savegames(settings.stationeers_saves_path);
                    savegames.LoadSavegames();
                    ListSavegames();
                    LoadDifficultys();
                }
            }
            else
            {
                if (MessageBox.Show("Alle nicht gespeicherten �nderungen gehen verloren! Bist du sicher?", "Warnung", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

            modconfig.Save(settings.stationeers_path + "\\modconfig.xml");
            ListSavegames();
        }

        private void listView_savegames_DoubleClick(object sender, EventArgs e)
        {
            if (listView_savegames.SelectedItems.Count > 0)
            {
                FormEditSave form = new FormEditSave(savegames.Saves[listView_savegames.SelectedItems[0].Index]);
                form.Text = "Savegame bearbeiten f�r " + savegames.Saves[listView_savegames.SelectedItems[0].Index].WorldName;
                form.ShowDialog();
                ListSavegames();
            }
        }

        private void listView_savegames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_savegames.SelectedItems.Count > 0)
            {
                Savegame savegame = savegames.Saves[listView_savegames.SelectedItems[0].Index];

                backupsToolStripMenuItem.DropDownItems.Clear();
                savegameNameToolStripMenuItem.Text = savegame.SavegameName;

                string backupPath = settings.stationeers_editor_path + "Backups\\Saves\\" + savegame.SavegameName + "\\";

                if (Directory.Exists(backupPath))
                {
                    backupsToolStripMenuItem.Enabled = true;
                    foreach (string path in Directory.GetFiles(backupPath))
                    {
                        FileInfo fileInfo = new FileInfo(path);

                        ToolStripMenuItem tsmi = new ToolStripMenuItem();
                        tsmi.Text = fileInfo.Name;
                        tsmi.Click += (object s, EventArgs e) =>
                        {

                            try
                            {
                                RecursiveDelete(new DirectoryInfo(savegame.SavePath));
                                Directory.CreateDirectory(savegame.SavePath);
                                ZipFile.ExtractToDirectory(path, savegame.SavePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        backupsToolStripMenuItem.DropDownItems.Add(tsmi);
                    }
                }
                else
                {
                    backupsToolStripMenuItem.Enabled = false;
                }

                if (savegame.IsChanged)
                {
                    zur�cksetzenToolStripMenuItem.Enabled = true;
                }
                else
                {
                    zur�cksetzenToolStripMenuItem.Enabled = false;
                }
            }
        }

        public static void RecursiveDelete(DirectoryInfo baseDir)
        {
            if (!baseDir.Exists)
                return;

            foreach (var dir in baseDir.EnumerateDirectories())
            {
                RecursiveDelete(dir);
            }
            baseDir.Delete(true);
        }

        private void toolStripStatusLabel_Statistics_Click(object sender, EventArgs e)
        {
            settings.AllowToSendStatisticsData = "Unknown";
            SendStatistics();
        }

        private void zur�cksetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView_savegames.SelectedItems.Count > 0)
            {
                Savegame savegame = savegames.Saves[listView_savegames.SelectedItems[0].Index];
                savegame.Reload();
                ListSavegames();
            }
        }
    }
}
