using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Stationeers_World_Creator
{
    public class WorldCollection
    {
        public List<World> Worlds = new List<World>();

        public ListViewGroup lvg = new ListViewGroup();

        #region Private Variabeln
        private bool isDefault = false;
        private string collection_path = string.Empty;
        private string collection_id = string.Empty;
        private string path_worldsetting_xml = string.Empty;
        private string path_lang_files = string.Empty;
        private bool _error = false;

        private XmlDocument xml_worldssetting = null;
        private XmlDocument xml_about = null;
        public XmlDocument modconfig = null;

        private List<XmlDocument> xml_languages = new List<XmlDocument>();
        private List<string> paths_languages = new List<string>();
        #endregion

        #region Propertys
        public bool Error { get { return _error; } }
        public int LangCount { get { return xml_languages.Count; } }
        public string Name { 
            get { 
                if(isDefault)
                {
                    return "Rocketworks";
                } else {
                    XmlNode node = xml_about.SelectSingleNode("//Name");
                    if(node == null)
                    {
                        node = xml_about.CreateElement("Name");
                        node.InnerText = "Defaultname";
                        xml_about.AppendChild(node);
                    }
                    return node.InnerText;
                }
            } 
            set { 
                if(!isDefault)
                {
                    XmlNode node = xml_about.SelectSingleNode("//Name");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Name");
                        node.InnerText = value;
                        xml_about.AppendChild(node);
                    } else { 
                        node.InnerText = value;
                    }
                    
                }
            } 
        }
        public string Author
        {
            get
            {
                if (isDefault)
                {
                    return "Rocketworks";
                }
                else
                {
                    XmlNode node = xml_about.SelectSingleNode("//Author");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Author");
                        node.InnerText = "Stationeers Editor by Eideard";
                        xml_about.AppendChild(node);
                    }
                    return node.InnerText;
                }
            }
            set
            {
                if (!isDefault)
                {
                    XmlNode node = xml_about.SelectSingleNode("//Author");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Author");
                        node.InnerText = value;
                        xml_about.AppendChild(node);
                    }
                    else
                    {
                        node.InnerText = value;
                    }

                }
            }
        }
        public string Version
        {
            get
            {
                if (isDefault)
                {
                    return "Rocketworks";
                }
                else
                {
                    XmlNode node = xml_about.SelectSingleNode("//Version");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Version");
                        node.InnerText = "0.0.0";
                        xml_about.AppendChild(node);
                    }
                    return node.InnerText;
                }
            }
            set
            {
                if (!isDefault)
                {
                    XmlNode node = xml_about.SelectSingleNode("//Version");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Version");
                        node.InnerText = value;
                        xml_about.AppendChild(node);
                    }
                    else
                    {
                        node.InnerText = value;
                    }

                }
            }
        }
        public string Description
        {
            get
            {
                if (isDefault)
                {
                    return "Rocketworks";
                }
                else
                {
                    XmlNode node = xml_about.SelectSingleNode("//Description");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Description");
                        node.InnerText = "Created with Stationeers Editor by Eideard";
                        xml_about.AppendChild(node);
                    }
                    return node.InnerText;
                }
            }
            set
            {
                if (!isDefault)
                {
                    XmlNode node = xml_about.SelectSingleNode("//Description");
                    if (node == null)
                    {
                        node = xml_about.CreateElement("Description");
                        node.InnerText = value;
                        xml_about.AppendChild(node);
                    }
                    else
                    {
                        node.InnerText = value;
                    }

                }
            }
        }
        public bool IsDefault { get { return isDefault; } }
        public string CollectionPath { get { return collection_path; } }
        #endregion

        public WorldCollection(bool isDefault, string path) 
        {
            this.isDefault = isDefault;
            this.collection_path = path;

            if(isDefault)
            {
                path_worldsetting_xml = path + "\\rocketstation_Data\\StreamingAssets\\Data\\worldsettings.xml";
                path_lang_files = path + "\\rocketstation_Data\\StreamingAssets\\Language\\";
            } 
            else
            {
                path_worldsetting_xml = path + "\\GameData\\worldsettings.xml";
                path_lang_files = path + "\\GameData\\Language\\";
            }
        }

        public bool LoadCollection()
        {
            if (!File.Exists(path_worldsetting_xml))
            {
                return false;
            }

            if (!isDefault && !File.Exists(collection_path + "\\About\\About.xml"))
            {
                return false;
            }

            if (!Directory.Exists(path_lang_files))
            {
                Directory.CreateDirectory(path_lang_files);
            }

            Worlds.Clear();

            xml_worldssetting = new XmlDocument();
            xml_worldssetting.Load(path_worldsetting_xml);

            if (!isDefault)
            {
                xml_about = new XmlDocument();
                xml_about.Load(collection_path + "\\About\\About.xml");
                collection_id = collection_path.Split("\\").Last<string>();
            }

            xml_languages.Clear();
            paths_languages.Clear();
            string[] files = Directory.GetFiles(path_lang_files);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Extension == ".xml" && fi.Name.Split("_").Length == 1 && fi.Name != "SPDAOverride.xml")
                {
                    paths_languages.Add(fi.FullName);
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(fi.FullName);
                    xml_languages.Add(xdoc);
                }
            }           

            return true;
        }

        public void InitNewCollection()
        {
            
            xml_about = new XmlDocument();
            xml_about.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><ModMetadata xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">  <Name></Name>\r\n  <Author>" + Environment.UserName + "</Author>\r\n  <Version>0.0.0</Version>\r\n  <Description>\n\n Erstellt mit Stationeers Editor (https://stationeers.eideard.de/StationeersEditor)</Description></ModMetadata>");

            xml_worldssetting = new XmlDocument();
            xml_worldssetting.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><GameData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><WorldSettings></WorldSettings></GameData>");

        }

        public bool CreateCollection()
        {
            if(collection_path == null)
            {

                Regex regex = new Regex("[^a-zA-Z]"); // Alle Zeichen außer Buchstaben entfernen
                string dirname = regex.Replace(Name, "");

                collection_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Stationeers\\mods\\" + dirname;
                path_worldsetting_xml = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Stationeers\\mods\\" + dirname + "\\GameData\\worldsettings.xml";
                path_lang_files = collection_path + "\\GameData\\Language\\";
                Directory.CreateDirectory(collection_path + "\\About");
                Directory.CreateDirectory(path_lang_files);
                xml_about.Save(collection_path + "\\About\\About.xml");
                xml_worldssetting.Save(path_worldsetting_xml);

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Language xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Name>English</Name>\r\n  <Code>EN</Code>\r\n  <Font>font_english</Font>\r\n  <Interface>\r\n  </Interface>\r\n</Language>");
                xml_languages.Add(xmldoc);
                xmldoc.Save(path_lang_files + "english.xml");
                paths_languages.Add(path_lang_files + "english.xml");

                xmldoc = new XmlDocument();
                xmldoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Language xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n    <Name>German</Name>\r\n  <Code>DE</Code>\r\n  <Font>font_extended</Font>\r\n  <Interface>\r\n  </Interface>\r\n</Language>");
                xml_languages.Add(xmldoc);
                paths_languages.Add(path_lang_files + "german.xml");
                xmldoc.Save(path_lang_files + "german.xml");

                Bitmap bitmap = new Bitmap(Properties.Resources.logo);
                bitmap.Save(collection_path + "\\About\\Preview.png");
                bitmap.Save(collection_path + "\\About\\thumb.png");

                return LoadCollection();
            }

            return true;
        }

        public bool RemoveCollection()
        {
            if(isDefault) {  return false; }
            try
            {
                Directory.Delete(collection_path, true);
            } catch ( Exception ex ) {
                return false;
            }

            return true;
        }

        public void ActivateCollection()
        {
            if (isDefault) { return; }
            XmlNodeList nl = modconfig.SelectNodes("//Mods//ModData");
            foreach(XmlNode n in nl)
            {
                XmlNode idn = n.SelectSingleNode("LocalPath");
                XmlNode enabled = n.SelectSingleNode("IsEnabled");
                if (idn != null) {
                    if (idn.InnerText == collection_path)
                    {
                        n.ParentNode.RemoveChild(n);
                        enabled.InnerText = "true";
                        break;
                    }
                }
            }

            XmlNode moddata = modconfig.CreateElement("ModData");
            XmlNode Id = modconfig.CreateElement("Id");
            XmlNode IsEnabled = modconfig.CreateElement("IsEnabled");
            XmlNode LocalPath = modconfig.CreateElement("LocalPath");

            Id.InnerText = "0";
            IsEnabled.InnerText = "true";
            LocalPath.InnerText = collection_path;
                
            moddata.AppendChild(Id);
            moddata.AppendChild(IsEnabled); 
            moddata.AppendChild(LocalPath);

            XmlNode mods = modconfig.SelectSingleNode("//Mods");
            mods.PrependChild(moddata);

        }

        public void DeactivateCollection()
        {
            if (isDefault) { return; }
            XmlNodeList nl = modconfig.SelectNodes("//Mods//ModData");
            foreach (XmlNode n in nl)
            {
                XmlNode idn = n.SelectSingleNode("LocalPath");
                XmlNode enabled = n.SelectSingleNode("IsEnabled");
                if (idn != null)
                {
                    if (idn.InnerText == collection_path)
                    {
                        enabled.InnerText = "false";
                        break;
                    }
                }
            }

        }

        public bool Active
        {
            get
            {
                if (isDefault) { return true; }
                XmlNodeList nl = modconfig.SelectNodes("//Mods//ModData");
                bool found = false;
                foreach (XmlNode n in nl)
                {
                    XmlNode idn = n.SelectSingleNode("LocalPath");
                    XmlNode enabled = n.SelectSingleNode("IsEnabled");
                    if (idn != null)
                    {
                        if (idn.InnerText == collection_path)
                        {
                            return enabled.InnerText == "true";
                        }
                    }
                }

                return false;
            }
        }

        public List<World> getWorlds()
        {

            if (Worlds.Count == 0)
            {
                XmlNodeList nl = xml_worldssetting.SelectSingleNode("//WorldSettings").ChildNodes;
                if (nl != null)
                {

                    int j = 0;
                    foreach (XmlNode node in nl)
                    {
                        World world = new World(this, node);

                        int i = 0;
                        foreach (string file in paths_languages)
                        {
                            FileInfo fi = new FileInfo(file);
                            if (fi.Name == "english.xml")
                            {
                                XmlNodeList lang_nl = xml_languages[i].SelectNodes("//Interface//Record");
                                foreach (XmlNode lang_node in lang_nl)
                                {
                                    XmlNode lang_key_node = lang_node.SelectSingleNode(".//Key");

                                    if(lang_key_node != null && lang_key_node.InnerText == world.NameKey)
                                    {
                                        world.lang_eng_name_node = lang_node;
                                    }
                                    if (lang_key_node != null && lang_key_node.InnerText == world.DescriptionKey)
                                    {
                                        world.lang_eng_desc_node = lang_node;
                                    }
                                }
                            }
                            if (fi.Name == "german.xml")
                            {
                                XmlNodeList lang_nl = xml_languages[i].SelectNodes("//Interface//Record");
                                foreach (XmlNode lang_node in lang_nl)
                                {
                                    XmlNode lang_key_node = lang_node.SelectSingleNode(".//Key");
                                    if (lang_key_node != null && lang_key_node.InnerText == world.NameKey)
                                    {
                                        world.lang_ger_name_node = lang_node;
                                    }
                                    if (lang_key_node != null && lang_key_node.InnerText == world.DescriptionKey)
                                    {
                                        world.lang_ger_desc_node = lang_node;
                                    }
                                }
                            }
                            i++;
                        }


                        Worlds.Add(world);
                        j++;
                    }
                }
            }

            return Worlds;
        }

        public bool RemoveWorld(int index)
        {
            if (isDefault) { return false; }

            Worlds[index].lang_eng_name_node.ParentNode.RemoveChild(Worlds[index].lang_eng_name_node);
            Worlds[index].lang_ger_name_node.ParentNode.RemoveChild(Worlds[index].lang_ger_name_node);
            Worlds[index].lang_eng_desc_node.ParentNode.RemoveChild(Worlds[index].lang_eng_desc_node);
            Worlds[index].lang_ger_desc_node.ParentNode.RemoveChild(Worlds[index].lang_ger_desc_node);

            XmlNode node = xml_worldssetting.SelectSingleNode("//WorldSettings");
            node.RemoveChild(Worlds[index].node);
            Worlds.Remove(Worlds[index]);

            return true;
        }

        public bool CopyWorldIn(World world)
        {
            XmlNode newWorldNode = xml_worldssetting.ImportNode(world.node, true);
            World newWorld = new World(this, newWorldNode);

            newWorld.Id = collection_id + newWorld.Id;
            if (!newWorld.Id.Contains("bySSE"))
            {
                newWorld.Id += "bySSE";
            }

            foreach(World w in Worlds)
            {
                if(w.Id == newWorld.Id)
                {
                    return false;
                }
            }

            // Sprachen ermitteln
            int i = 0;
            foreach (string file in paths_languages)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Name == "english.xml")
                {

                    XmlNode lang_nl = xml_languages[i].SelectSingleNode("//Interface");
                    XmlNode record = null;
                    XmlNode key = null;
                    XmlNode val = null;

                    record = xml_languages[i].CreateElement("Record");

                    key = xml_languages[i].CreateElement("Key");
                    key.InnerText = newWorld.NameKey;
                    record.AppendChild(key);

                    val = xml_languages[i].CreateElement("Value");
                    val.InnerText = world.NameEng;
                    record.AppendChild(val);

                    lang_nl.AppendChild(record);
                    newWorld.lang_eng_name_node = record;

                    record = xml_languages[i].CreateElement("Record");

                    key = xml_languages[i].CreateElement("Key");
                    key.InnerText = newWorld.DescriptionKey;
                    record.AppendChild(key);

                    val = xml_languages[i].CreateElement("Value");
                    val.InnerText = world.DescriptionEng;
                    record.AppendChild(val);

                    lang_nl.AppendChild(record);
                    newWorld.lang_eng_desc_node = record;

                }
                if (fi.Name == "german.xml")
                {

                    XmlNode lang_nl = xml_languages[i].SelectSingleNode("//Interface");
                    XmlNode record = null;
                    XmlNode key = null;
                    XmlNode val = null;

                    record = xml_languages[i].CreateElement("Record");

                    key = xml_languages[i].CreateElement("Key");
                    key.InnerText = newWorld.NameKey;
                    record.AppendChild(key);

                    val = xml_languages[i].CreateElement("Value");
                    val.InnerText = world.NameGer;
                    record.AppendChild(val);

                    lang_nl.AppendChild(record);
                    newWorld.lang_ger_name_node = record;

                    record = xml_languages[i].CreateElement("Record");

                    key = xml_languages[i].CreateElement("Key");
                    key.InnerText = newWorld.DescriptionKey;
                    record.AppendChild(key);

                    val = xml_languages[i].CreateElement("Value");
                    val.InnerText = world.DescriptionGer;
                    record.AppendChild(val);

                    lang_nl.AppendChild(record);
                    newWorld.lang_ger_desc_node = record;

                }
                i++;
            }


            correktAllSpaceIDs(newWorld);

            xml_worldssetting.SelectSingleNode("//WorldSettings").AppendChild(newWorldNode);
            Worlds.Add(newWorld);

            return true;
        }

        public static void correktAllSpaceIDs( World world )
        {
            XmlNode spacemap = world.node.SelectSingleNode(".//SpaceMap");
            spacemap.Attributes["Id"].Value += world.Id;


            XmlNode entry = world.node.SelectSingleNode(".//SpaceMap//Entry");
            entry.Attributes["Id"].Value += world.Id;

            XmlNodeList entrycons = entry.SelectNodes(".//Connection");
            foreach(XmlNode con in entrycons)
            {
                con.Attributes["Id"].Value += world.Id;
            }

            XmlNodeList spacenodes = world.node.SelectNodes(".//SpaceMap//Node");

            foreach (XmlNode spacenode in spacenodes)
            {
                XmlNodeList nodecons = spacenode.SelectNodes(".//Connection");
                foreach (XmlNode con in nodecons)
                {
                    con.Attributes["Id"].Value += world.Id;
                }
            }

        }

        public bool Save()
        {
            if(isDefault) { return false; }

            Debug.WriteLine(path_worldsetting_xml);

            xml_worldssetting.Save(path_worldsetting_xml);

            int i = 0;
            foreach(XmlDocument lang in xml_languages)
            {
                lang.Save(paths_languages[i]);
                i++;
            }

            return true;
        }

    }
}
