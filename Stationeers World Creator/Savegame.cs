using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
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
            if (this.Timestamp < other.Timestamp) return 1;
            if (this.Timestamp > other.Timestamp) return -1;

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
        public long Timestamp
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

        string _savegamename = null;
        public string SavegameName
        {
            get
            {
                if (_savegamename != null) { return _savegamename; }

                string parent = Path.GetDirectoryName(PathToSavegame);
                return Path.GetFileName(parent);
                
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

        List<Thing> _things = null;
        public List<Thing> Things
        {
            get
            {
                if(_things != null) { return _things; }

                XmlNodeList nl = xml_world.SelectNodes("//Things//ThingSaveData");
                if(nl == null) return _things = new List<Thing>();
                _things = new List<Thing>();
                foreach (XmlNode n in nl)
                {
                    _things.Add(new Thing(this,n));
                }

                return _things;
            }
        }

        List<Network> _network = null;
        public List<Network> Networks
        {
            get
            {
                if (_network != null) { return _network; }

                XmlNodeList nl = xml_world.SelectNodes("//PipeNetworks//NetworkId");
                if (nl == null) return _network = new List<Network>();
                _network = new List<Network>();
                foreach (XmlNode n in nl)
                {
                    _network.Add(new Network(int.Parse(n.InnerText), this));
                }

                return _network;
            }
        }

        List<Tank> _tanks= null;
        public List<Tank> Tanks
        {
            get
            {
                if (_tanks != null) { return _tanks; }

                _tanks = new List<Tank>();
                List<string> tankHashes = new List<string>();
                tankHashes.Add("DynamicGasCanisterNitrousOxide");
                tankHashes.Add("ItemGasCanisterFuel");
                tankHashes.Add("DynamicGasCanisterVolatiles");
                tankHashes.Add("StructureTankSmallInsulated");
                tankHashes.Add("DynamicGasCanisterCarbonDioxide");
                tankHashes.Add("DynamicGasTankAdvancedWater");
                tankHashes.Add("DynamicGasCanisterPollutants");
                tankHashes.Add("ItemLiquidCanisterSmart");
                tankHashes.Add("ItemGasCanisterPollutants");
                tankHashes.Add("ItemGasCanisterEmpty");
                tankHashes.Add("StructureTankSmall");
                tankHashes.Add("StructureTankBigInsulated");
                tankHashes.Add("ItemGasCanisterOxygen");
                tankHashes.Add("DynamicGasCanisterRocketFuel");
                tankHashes.Add("StructureLiquidTankBig");
                tankHashes.Add("ItemGasCanisterCarbonDioxide");
                tankHashes.Add("DynamicLiquidCanisterEmpty");
                tankHashes.Add("ItemGasCanisterSmart");
                tankHashes.Add("StructureLiquidTankSmallInsulated");
                tankHashes.Add("DynamicMKIILiquidCanisterWater");
                tankHashes.Add("DynamicGasCanisterWater");
                tankHashes.Add("DynamicGasCanisterAir");
                tankHashes.Add("ItemGasCanisterNitrousOxide");
                tankHashes.Add("DynamicMKIILiquidCanisterEmpty");
                tankHashes.Add("DynamicGasCanisterFuel");
                tankHashes.Add("DynamicGasCanisterOxygen");
                tankHashes.Add("ItemLiquidCanisterEmpty");
                tankHashes.Add("DynamicGasCanisterEmpty");
                tankHashes.Add("ItemGasCanisterWater");
                tankHashes.Add("DynamicGasCanisterNitrogen");
                tankHashes.Add("DynamicGasTankAdvanced");
                tankHashes.Add("ItemGasCanisterNitrogen");
                tankHashes.Add("StructureLiquidTankSmall");
                tankHashes.Add("StructureTankBig");
                tankHashes.Add("ItemGasCanisterVolatiles");
                tankHashes.Add("StructureLiquidTankBigInsulated");
                //tankHashes.Add("Landingpad_GasCylinderTankPiece");
                tankHashes.Add("StructureCapsuleTankGas");
                tankHashes.Add("StructureMediumRocketGasFuelTank");
                tankHashes.Add("StructureMediumRocketLiquidFuelTank");
                tankHashes.Add("StructureCapsuleTankLiquid");
                foreach (Thing thing in Things)
                {
                    if (tankHashes.Contains(thing.PrefabName))
                    {
                        _tanks.Add(new Tank(this, thing));
                    }
                }

                return _tanks;
            }
        }

        List<Player> _player = null;
        public List<Player> Player
        {
            get
            {
                if (_player != null) { return _player; }
                _player = new List<Player>();
                foreach (Thing thing in Things)
                {
                    if (thing.Type == "HumanSaveData")
                    {
                        _player.Add(new Player(this, thing.Id));
                    }
                }

                return _player;
            }
        }

        List<Rocket> _rockets = null;
        public List<Rocket> Rockets
        {
            get
            {
                if (_rockets != null) { return _rockets; }

                XmlNodeList nl = xml_world.SelectNodes("//Rockets//RocketSaveData");
                if (nl == null) return _rockets = new List<Rocket>();
                _rockets = new List<Rocket>();
                foreach (XmlNode n in nl)
                {
                    _rockets.Add(new Rocket(this, n));
                }

                return _rockets;
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
            set
            {
                XmlNode n = xml_world.SelectSingleNode(".//WorldSetting");
                if (n == null) return;
                if (n.Attributes["Id"] == null) { return; }
                n.Attributes["Id"].Value = value.ToString();
                _worldId = value;
                IsChanged = true;
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
            set
            {
                XmlNode n = xml_world.SelectSingleNode(".//DifficultySetting");
                if (n == null) return;
                if (n.Attributes["Id"] == null) { return; }
                n.Attributes["Id"].Value = value.ToString();
                _difficulty = value;
                IsChanged = true;
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
            set
            {
                XmlNode n = xml_world.SelectSingleNode(".//ResearchKey");
                if (n == null) return;
                n.InnerText = value.ToString(); 
                _research = value;
                IsChanged = true;
            }
        }

        bool _seedChanged = false;
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
            set
            {
                XmlNode n = xml_world.SelectSingleNode(".//WorldSeed");
                if (n == null) return;
                n.InnerText = value.ToString();
                if(value != _seed && !_seedChanged) { _seedChanged = true; IsChanged = true; }
                _seed = value;
            }
        }

        public void Save()
        {
            string path = Form1.MyStationeersEditor + "Backups\\Saves\\" + SavegameName + "\\";

            Directory.CreateDirectory(path);
            ZipFile.CreateFromDirectory(PathToSavegame, path + DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss") + ".zip");

            if (xml_world != null)
            {
                xml_world.Save(PathToSavegame + "world.xml");

                if (_seedChanged)
                {
                    _seedChanged = false;
                    File.Delete(PathToSavegame + "world.bin");
                }
            }

            if (xml_world_meta != null)
            {
                xml_world_meta.Save(PathToSavegame + "world_meta.xml");
            }

            IsChanged = false;
        }

        #endregion
    }
}
