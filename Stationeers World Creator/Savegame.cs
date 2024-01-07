using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Stationeers_World_Creator
{

    public class Savegame : IComparable<Savegame>
    {
        private string PathToSavegame { get; set; }

        public Savegame(string path) {
            PathToSavegame = path;
        }

        public int CompareTo(Savegame other)
        {
            if (this.DateTime < other.DateTime) return 1;
            if (this.DateTime > other.DateTime) return -1;

            return 0;
        }

        #region world_meta.xml
        XmlDocument xml_world_meta = null;
        public bool LoadMeta()
        {

            if (File.Exists(PathToSavegame + "world_meta.xml"))
            {
                xml_world_meta = new XmlDocument();
                xml_world_meta.Load(PathToSavegame + "world_meta.xml");

                return true;
            }

            return false;
        }

        Version _version = null;
        public Version GameVersion
        {
            get
            {
                if(_version != null) { return _version; }

                if (xml_world_meta == null)
                {
                    return new Version(0, 0);
                }

                XmlNode n = xml_world_meta.SelectSingleNode("//GameVersion");
                if (n == null)
                {
                    return _version = new Version(0, 0);
                }

                _version = new Version(n.InnerText);
                return _version;
            }
        }

        long _dateTime = -1;
        public long DateTime
        {
            get
            {
                if (_dateTime > -1) { return _dateTime; }

                if (xml_world_meta == null)
                {
                    return 0;
                }

                XmlNode n = xml_world_meta.SelectSingleNode("//DateTime");
                if (n == null)
                {
                    return _daysPast = 0;
                }

                return _dateTime = long.Parse(n.InnerText);
            }
        }

        int _daysPast = -1;
        public int DaysPast
        {
            get
            {
                if (_daysPast > -1) { return _daysPast; }

                if (xml_world_meta == null)
                {
                    return -1;
                }

                XmlNode n = xml_world_meta.SelectSingleNode("//DaysPast");
                if (n == null)
                {
                    return _daysPast = - 1;
                }
                return _daysPast = int.Parse(n.InnerText);
            }
        }

        string _worldname = null;
        public string WorldName
        {
            get
            {
                if (_worldname != null) { return _worldname; }

                if (xml_world_meta == null)
                {
                    return "[world_meta.xml] not loaded";
                }

                XmlNode n = xml_world_meta.SelectSingleNode("//WorldName");
                if (n == null)
                {
                    return _worldname = "NOT SET";
                }
                if (n.InnerText == String.Empty)
                {
                    return _worldname = "NOT SET";
                }
                return _worldname = n.InnerText;
            }
        }

        public string SavePath
        {
            get
            {
                return PathToSavegame;
            }
        }
        #endregion

        #region world.xml

        XmlDocument xml_world = null;

        public bool LoadWorld()
        {
            if (xml_world == null)
            {
                if (File.Exists(PathToSavegame + "world.xml"))
                {
                    xml_world = new XmlDocument();
                    xml_world.Load(PathToSavegame + "world.xml");

                    return true;
                }

                return false;
            }

            return true;
        }

        private List<Room> _rooms { get; set; }
        public List<Room> Rooms
        {
            get
            {
                if (_rooms != null) { return _rooms; }

                XmlNodeList nl = xml_world.SelectNodes("//Rooms//Room");
                if (nl == null) { return _rooms = new List<Room>(); }

                _rooms = new List<Room>();
                foreach (XmlNode node in nl)
                {
                    _rooms.Add(new Room(node, this));
                }

                _rooms.Sort();

                return _rooms;
            }
        }

        List<SavegameAtmosphere> _atmospheres = null;
        public List<SavegameAtmosphere> Atmospheres {
            get
            {
                if (_atmospheres != null) { return _atmospheres; }
                _atmospheres = new List<SavegameAtmosphere>();

                XmlNodeList nl = xml_world.SelectNodes("//Atmospheres//AtmosphereSaveData");
                foreach (XmlNode n in nl)
                {
                    _atmospheres.Add(new SavegameAtmosphere(n, this));
                }

                return _atmospheres;

            }
        }

        private bool _changed = false;
        public bool IsChanged
        {
            get { return _changed; }
            set { _changed = value; }
        }

        string _worldId = null;
        public string WorldId
        {
            get
            {
                if (_worldId != null) { return _worldId; }

                XmlNode n = xml_world.SelectSingleNode(".//WorldSetting");
                if (n == null) return _worldId = "[Unknown]";

                if (n.Attributes["Id"] == null) { return _worldId = "[Unknown]"; }

                return _worldId = n.Attributes["Id"].Value;
            }
        }

        string _difficulty = null;
        public string Difficulty
        {
            get
            {
                if (_difficulty != null) { return _difficulty; }

                XmlNode n = xml_world.SelectSingleNode(".//DifficultySetting");
                if (n == null) return _difficulty = "[Unknown]";

                if (n.Attributes["Id"] == null) { return _difficulty = "[Unknown]"; }

                return _difficulty = n.Attributes["Id"].Value;
            }
        }

        string _research = null;
        public string Research
        {
            get
            {
                if (_research != null) { return _research; }

                XmlNode n = xml_world.SelectSingleNode(".//ResearchKey");
                if (n == null) return _research = "[Unknown]";

                return _research = n.InnerText;
            }
        }

        int _seed = -1;
        public int Seed
        {
            get
            {
                if (_seed != -1) { return _seed; }

                XmlNode n = xml_world.SelectSingleNode(".//WorldSeed");
                if (n == null) return _seed = -1;

                return _seed = int.Parse(n.InnerText);
            }
        }

        public void Save()
        {
            if (xml_world != null)
            {
                xml_world.Save(PathToSavegame + "world.xml");
            }

            if (xml_world_meta != null)
            {
                xml_world_meta.Save(PathToSavegame + "world_meta.xml");
            }
        }

        #endregion
    }
}
