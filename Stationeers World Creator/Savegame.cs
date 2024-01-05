using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Stationeers_World_Creator
{

    public class SavegameAtmosphere 
    {
        XmlNode node {  get; set; }
        public SavegameAtmosphere(XmlNode node) { 
            this.node = node;
        }

        public double GasMols
        {
            get
            {
                return Oxygen + Volatiles + Nitrogen + CarbonDioxide + Pollutant + Steam + NitrousOxide;
            }
        }
        public double LiquidMole
        {
            get
            {
                return LiquidOxygen + LiquidVolatiles + LiquidNitrogen + LiquidCarbonDioxide + LiquidPollutant + Water + LiquidNitrousOxide;
            }
        }

        public double Temperature
        {
            get
            {
                double preEnergy = 0;
                preEnergy += (Oxygen + LiquidOxygen) / 0.047393;
                preEnergy += (Nitrogen + LiquidNitrogen) / 0.048544;
                preEnergy += (CarbonDioxide + LiquidCarbonDioxide) / 0.035461;
                preEnergy += (Volatiles + LiquidVolatiles) / 0.04902;
                preEnergy += (Pollutant + LiquidPollutant) / 0.040323;
                preEnergy += (Steam + Water) / 0.013889;
                preEnergy += (NitrousOxide + LiquidNitrousOxide) / 0.026882;

                if (preEnergy == 0) { return 0; }

                return Energy / preEnergy;
            }
        }

        public double TemperatureCelsius
        {
            get
            {
                return Temperature - 273.15;
            }
        }
        public double Pressure
        {
            get
            {
                if(Volumen == 0) { return 0; }
                return ((GasMols + LiquidMole) * Settings.GASCONSTANT * Temperature) / Volumen;
            }
        }

        double _volumen = -1;
        public double Volumen
        {
            get
            {
                if (_volumen != -1) { return _volumen; }

                XmlNode n = node.SelectSingleNode(".//Volume");
                if(n == null) { return _volumen = 0; }
                _volumen = double.Parse(n.InnerText.Replace(".", ","));

                return _volumen;
            }
        }

        double _energy = -1;
        public double Energy
        {
            get
            {
                if (_energy != -1) { return _energy; }

                XmlNode n = node.SelectSingleNode(".//Energy");
                if (n == null) { return _energy = 0; }
                _energy = double.Parse(n.InnerText.Replace(".", ","));

                return _energy;
            }
        }

        double _networkReferenceId = -1;
        public double NetworkReferenceId
        {
            get
            {
                if (_networkReferenceId != -1) { return _networkReferenceId; }

                XmlNode n = node.SelectSingleNode(".//ThingReferenceId");
                if (n == null) { return _networkReferenceId = 0; }
                _networkReferenceId = double.Parse(n.InnerText.Replace(".", ","));

                return _networkReferenceId;
            }
        }

        double _thingReferenceId = -1;
        public double ThingReferenceId
        {
            get
            {
                if (_thingReferenceId != -1) { return _thingReferenceId; }

                XmlNode n = node.SelectSingleNode(".//ThingReferenceId");
                if (n == null) { return _thingReferenceId = 0; }
                _thingReferenceId = double.Parse(n.InnerText.Replace(".", ","));

                return _thingReferenceId;
            }
        }

        Point3D _position = null;
        public Point3D Position
        {
            get
            {
                if (_position != null) { return _position; }

                XmlNode n = node.SelectSingleNode(".//Position");
                if (n == null) { return _position = null; }
                _position = new Point3D(n);

                return _position;
            }
        }


        double _oxygen = -1;
        public double Oxygen
        {
            get
            {
                if (_oxygen != -1) { return _oxygen; }

                XmlNode n = node.SelectSingleNode(".//Oxygen");
                if (n == null) { return _oxygen = 0; }
                _oxygen = double.Parse(n.InnerText.Replace(".", ","));

                return _oxygen;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Oxygen");
                n.InnerText = value.ToString().Replace(",",".");
                _oxygen = value;
            }
        }

        double _nitrogen = -1;
        public double Nitrogen
        {
            get
            {
                if (_nitrogen != -1) { return _nitrogen; }

                XmlNode n = node.SelectSingleNode(".//Nitrogen");
                if (n == null) { return _nitrogen = 0; }
                _nitrogen = double.Parse(n.InnerText.Replace(".", ","));

                return _nitrogen;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Nitrogen");
                n.InnerText = value.ToString().Replace(",", ".");
                _nitrogen = value;
            }
        }

        double _carbonDioxide = -1;
        public double CarbonDioxide
        {
            get
            {
                if (_carbonDioxide != -1) { return _carbonDioxide; }

                XmlNode n = node.SelectSingleNode(".//CarbonDioxide");
                if (n == null) { return _carbonDioxide = 0; }
                _carbonDioxide = double.Parse(n.InnerText.Replace(".", ","));

                return _carbonDioxide;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//CarbonDioxide");
                n.InnerText = value.ToString().Replace(",", ".");
                _carbonDioxide = value;
            }
        }

        double _volatiles = -1;
        public double Volatiles
        {
            get
            {
                if (_volatiles != -1) { return _volatiles; }

                XmlNode n = node.SelectSingleNode(".//Volatiles");
                if (n == null) { return _volatiles = 0; }
                _volatiles = double.Parse(n.InnerText.Replace(".", ","));

                return _volatiles;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Volatiles");
                n.InnerText = value.ToString().Replace(",", ".");
                _volatiles = value;
            }
        }

        double _pollutant = -1;
        public double Pollutant
        {
            get
            {
                if (_pollutant != -1) { return _pollutant; }

                XmlNode n = node.SelectSingleNode(".//Chlorine");
                if (n == null) { return _pollutant = 0; }
                _pollutant = double.Parse(n.InnerText.Replace(".", ","));

                return _pollutant;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Chlorine");
                n.InnerText = value.ToString().Replace(",", ".");
                _pollutant = value;
            }
        }

        double _steam = -1;
        public double Steam
        {
            get
            {
                if (_steam != -1) { return _steam; }

                XmlNode n = node.SelectSingleNode(".//Steam");
                if (n == null) { return _steam = 0; }
                _steam = double.Parse(n.InnerText.Replace(".", ","));

                return _steam;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Steam");
                n.InnerText = value.ToString().Replace(",", ".");
                _steam = value;
            }
        }

        double _nitrousOxide = -1;
        public double NitrousOxide
        {
            get
            {
                if (_nitrousOxide != -1) { return _nitrousOxide; }

                XmlNode n = node.SelectSingleNode(".//NitrousOxide");
                if (n == null) { return _nitrousOxide = 0; }
                _nitrousOxide = double.Parse(n.InnerText.Replace(".", ","));

                return _nitrousOxide;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//NitrousOxide");
                n.InnerText = value.ToString().Replace(",", ".");
                _nitrousOxide = value;
            }
        }

        double _liquidOxygen = -1;
        public double LiquidOxygen
        {
            get
            {
                if (_liquidOxygen != -1) { return _liquidOxygen; }

                XmlNode n = node.SelectSingleNode(".//LiquidOxygen");
                if (n == null) { return _liquidOxygen = 0; }
                _liquidOxygen = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidOxygen;
            }
        }

        double _liquidNitrogen = -1;
        public double LiquidNitrogen
        {
            get
            {
                if (_liquidNitrogen != -1) { return _liquidNitrogen; }

                XmlNode n = node.SelectSingleNode(".//LiquidNitrogen");
                if (n == null) { return _liquidNitrogen = 0; }
                _liquidNitrogen = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidNitrogen;
            }
        }

        double _liquidCarbonDioxide = -1;
        public double LiquidCarbonDioxide
        {
            get
            {
                if (_liquidCarbonDioxide != -1) { return _liquidCarbonDioxide; }

                XmlNode n = node.SelectSingleNode(".//LiquidCarbonDioxide");
                if (n == null) { return _liquidCarbonDioxide = 0; }
                _liquidCarbonDioxide = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidCarbonDioxide;
            }
        }

        double _liquidVolatiles = -1;
        public double LiquidVolatiles
        {
            get
            {
                if (_liquidVolatiles != -1) { return _liquidVolatiles; }

                XmlNode n = node.SelectSingleNode(".//LiquidVolatiles");
                if (n == null) { return _liquidVolatiles = 0; }
                _liquidVolatiles = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidVolatiles;
            }
        }

        double _liquidPollutant = -1;
        public double LiquidPollutant
        {
            get
            {
                if (_liquidPollutant != -1) { return _liquidPollutant; }

                XmlNode n = node.SelectSingleNode(".//LiquidPollutant");
                if (n == null) { return _liquidPollutant = 0; }
                _liquidPollutant = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidPollutant;
            }
        }

        double _water = -1;
        public double Water
        {
            get
            {
                if (_water != -1) { return _water; }

                XmlNode n = node.SelectSingleNode(".//Water");
                if (n == null) { return _water = 0; }
                _water = double.Parse(n.InnerText.Replace(".", ","));

                return _water;
            }
        }

        double _liquidNitrousOxide = -1;
        public double LiquidNitrousOxide
        {
            get
            {
                if (_liquidNitrousOxide != -1) { return _liquidNitrousOxide; }

                XmlNode n = node.SelectSingleNode(".//LiquidNitrousOxide");
                if (n == null) { return _liquidNitrousOxide = 0; }
                _liquidNitrousOxide = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidNitrousOxide;
            }
        }

    }

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
                    _atmospheres.Add(new SavegameAtmosphere(n));
                }

                return _atmospheres;

            }
        }


        #endregion
    }
}
