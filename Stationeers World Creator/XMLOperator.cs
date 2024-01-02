using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Stationeers_World_Creator
{
    public class XMLOperator
    {
        /*
        public List<string> default_worlds
        {
            get {
                return new List<string>() { "LowEarthOrbit", "Moon", "Mars", "Europa", "Mimas", "Vulcan", "Space", "Venus" };
            }
        }

        public string path_worldsettings = "";

        private string mainpath = "";
        private string backuppath = "";

        private XmlDocument worldsetting = null;
        private string path_worldsetting = "\\rocketstation_Data\\StreamingAssets\\Data\\worldsettings.xml";
        private List<XmlDocument> languages = new List<XmlDocument>();
        private List<string> path_languages = new List<string>();

        private bool error = false;

        public bool Error {
            get {  return error; }
        }

        public int LangCount {  get { return languages.Count; } }

        public XMLOperator(string stationeerspath, string backuppath)
        {
            SetStationeersPath(stationeerspath, backuppath);
            LoadXML();
        }

        public void SetStationeersPath(string stationeerspath, string backuppath)
        {
            mainpath = stationeerspath;
            this.backuppath = backuppath;
        }

        public bool LoadXML()
        {
            if (!File.Exists(mainpath + path_worldsetting))
            {
                error = true;
                return false;
            }

            if (worldsetting == null)
            {
                worldsetting = new XmlDocument();
                worldsetting.Load(mainpath + path_worldsetting);
            }

            if (languages.Count == 0)
            {
                string[] files = Directory.GetFiles(mainpath + "\\rocketstation_Data\\StreamingAssets\\Language\\");
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Extension == ".xml" && fi.Name.Split("_").Length == 1 && fi.Name != "SPDAOverride.xml")
                    {
                        path_languages.Add(fi.FullName);
                        XmlDocument xdoc = new XmlDocument();
                        xdoc.Load(fi.FullName);
                        languages.Add(xdoc);
                    }
                }
            }

            return true;
        }

        public bool IsLoadValid()
        {
            if (!File.Exists(mainpath + path_worldsetting)) { return false; }

            return true;
        }


        public List<World> getWorlds()
        {

            List<XOWorld> worlds = new List<XOWorld>();

            if(worldsetting == null)
            {
                error = true;
                return worlds;
            }

            XmlNodeList nodeList = worldsetting.SelectNodes("//WorldSettings//World");
            int i = 0;
            foreach (XmlNode node in nodeList)
            {
                XOWorld tmp = getWorldInfo(i);
                if (tmp != null)
                {
                    worlds.Add(tmp);
                }
                i++;
            }

            return worlds;
        }

        public World getWorld(int index)
        {
            XmlNode node = getWorldXMLNode(index);
            if (node == null) { return null; }

            XOWorld tmp = new XOWorld();
            tmp.index = index;
            tmp.id = node.Attributes["Id"].Value;
            tmp.type = default_worlds.Contains(node.Attributes["Id"].Value) ? "default" : "custom";

            int i = 0;
            foreach (XmlDocument langdoc in languages)
            {
                FileInfo fi = new FileInfo(path_languages[i]);
                if(fi.Name != "english.xml") { i++;  continue; }

                XmlNodeList langnodes = langdoc.SelectNodes("//Interface//Record");
                foreach (XmlNode recordnode in langnodes)
                {
                    XmlNode keynode = recordnode.SelectSingleNode("Key");
                    XmlNode valnode = recordnode.SelectSingleNode("Value");

                    if (node.Attributes["Id"].Value + "Name" == keynode.InnerText)
                    {
                        tmp.name = valnode.InnerText;
                    }
                    if (node.Attributes["Id"].Value + "Desc" == keynode.InnerText)
                    {
                        tmp.beschreibung = valnode.InnerText;
                    }
                    if ("NewWorldArea" + node.Attributes["Id"].Value == keynode.InnerText)
                    {
                        tmp.worldname = valnode.InnerText;
                    }
                }
                i++;
            }

            return tmp;
        }
        
        public XmlNode getWorldXMLNode(int index)
        {
            XmlNode node = worldsetting.SelectSingleNode("//WorldSettings//World[" + (index + 1) + "]");
            return node;
        }
        public World getWorldNode(int index)
        {
            World wn = new World(getWorldXMLNode(index));
            return wn;
        }

        public void RemoveWorld(int index)
        {
            XmlNode worldnode = getWorldXMLNode(index);
            worldnode.ParentNode.RemoveChild(worldnode);

            int i = 0;
            foreach(XmlDocument langdoc in languages)
            {

                XmlNodeList langnodes = langdoc.SelectNodes("//Interface//Record");
                foreach(XmlNode recordnode in langnodes)
                {
                    XmlNode keynode = recordnode.SelectSingleNode("Key");
                    if (
                        worldnode.Attributes["Id"].Value + "Name" == keynode.InnerText || 
                        worldnode.Attributes["Id"].Value + "Desc" == keynode.InnerText ||
                        "NewWorldArea" + worldnode.Attributes["Id"].Value == keynode.InnerText
                    ) {
                        recordnode.ParentNode.RemoveChild(recordnode);
                        Debug.WriteLine("Remove " + keynode.InnerText + " from " + path_languages[i]);
                    }
                }
                i++;
            }
        }

        public void AddWorld(Worlds world)
        {
            // Welt hinzufügen
            XmlDocument newdoc = new XmlDocument();
            newdoc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><GameData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><WorldSettings>" + world.XMLData + "</WorldSettings></GameData>");
            XmlNode newnode = newdoc.SelectSingleNode("//WorldSettings//World[1]");
            newnode = worldsetting.ImportNode(newnode, true);
            XmlNode node = worldsetting.SelectSingleNode("//WorldSettings");
            node.AppendChild(newnode);

            int i = 0;
            foreach (XmlDocument langdoc in languages)
            {

                XmlNode interfnode = langdoc.SelectSingleNode("//Interface");
                XmlNode record = null;
                XmlNode key = null;
                XmlNode val = null;

                if(interfnode == null)
                {
                    Debug.WriteLine("Interface nicht gefunden in " + path_languages[i]);
                    continue;
                }

                // Name
                record = langdoc.CreateElement("Record");
                
                key = langdoc.CreateElement("Key");
                key.InnerText = newnode.Attributes["Id"].Value + "Name";
                record.AppendChild(key);

                val = langdoc.CreateElement("Value");
                val.InnerText = world.NewID + " by " + world.Creator;
                record.AppendChild(val);

                interfnode.AppendChild(record);

                // Beschreibung
                record = langdoc.CreateElement("Record");

                key = langdoc.CreateElement("Key");
                key.InnerText = newnode.Attributes["Id"].Value + "Desc";
                record.AppendChild(key);

                val = langdoc.CreateElement("Value");
                val.InnerText = "Dies ist eine selbsterstelle Welt von " + world.Creator + " welche mit dem Tool von Eideard erstellt wurde. https://stationeers.eideard.de/";
                record.AppendChild(val);

                interfnode.AppendChild(record);

                // Weltname
                record = langdoc.CreateElement("Record");

                key = langdoc.CreateElement("Key");
                key.InnerText = "NewWorldArea" + newnode.Attributes["Id"].Value;
                record.AppendChild(key);

                val = langdoc.CreateElement("Value");
                val.InnerText = world.NewID + " by " + world.Creator;
                record.AppendChild(val);

                interfnode.AppendChild(record);

                i++;
            }
        }

        public void Save()
        {
            string data_path = backuppath + DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") + "\\Data\\";
            string lang_path = backuppath + DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") + "\\Languages\\";
            Directory.CreateDirectory(data_path);
            Directory.CreateDirectory(lang_path);

            File.Copy(mainpath + path_worldsetting, data_path + "worldsettings.xml");
            foreach (string lang_file in path_languages)
            {
                FileInfo fi = new FileInfo(lang_file);
                File.Copy(fi.FullName, lang_path + fi.Name);
            }
            
            worldsetting.Save(mainpath + path_worldsetting);

            int i = 0;
            foreach (XmlDocument langdoc in languages)
            {
                langdoc.Save(path_languages[i]);
                i++;
            }
            
        }

        
        */
    }
}
