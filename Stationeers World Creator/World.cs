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
    public class World
    {
        public WorldCollection collection;
        public XmlNode node;
        public XmlNode lang_ger_name_node;
        public XmlNode lang_eng_name_node;
        public XmlNode lang_ger_desc_node;
        public XmlNode lang_eng_desc_node;

        public World(WorldCollection collection, XmlNode n)
        {
            this.collection = collection;
            this.node = n;
        }

        public string Id
        {
            get
            {
                return node.Attributes["Id"].Value;
            }
            set
            {
                node.Attributes["Id"].Value = value;
                NameKey = "NewWorldArea" + value;
                DescriptionKey = value + "Desc";
            }
        }

        public string NameKey
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//Name");
                if (n != null)
                {
                   return n.Attributes["Key"].Value;
                }

                return null;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Name");
                if (n != null)
                {
                    n.Attributes["Key"].Value = value;

                    if (lang_eng_name_node != null)
                    {
                        n = lang_eng_name_node.SelectSingleNode(".//Key");
                        if (n != null)
                        {
                            n.InnerText = value;
                        }
                    }

                    if (lang_ger_name_node != null)
                    {
                        n = lang_ger_name_node.SelectSingleNode(".//Key");
                        if (n != null) {
                            n.InnerText = value;
                        }
                    }

                }
            }
        }

        public string DescriptionKey
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//Description");
                if (n != null)
                {
                    return n.Attributes["Key"].Value;
                }

                return null;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Description");
                if (n != null)
                {
                    n.Attributes["Key"].Value = value;

                    if (lang_eng_desc_node != null)
                    {
                        n = lang_eng_desc_node.SelectSingleNode(".//Key");
                        if (n != null)
                        {
                            n.InnerText = value;
                        }
                    }

                    if (lang_ger_desc_node != null)
                    {
                        n = lang_ger_desc_node.SelectSingleNode(".//Key");
                        if (n != null)
                        {
                            n.InnerText = value;
                        }
                    }
                }
            }
        }

        public int BedRockLevel
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//BedrockLevel");
                if (n == null) { return 0; }
                return int.Parse(n.InnerText);
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//BedrockLevel");
                n.InnerText = value.ToString();
            }
        }

        public bool HasLava
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//HasLava");
                if (n == null) { return false; }
                if (n.InnerText == "true") { return true; }
                return false;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//HasLava");
                n.InnerText = value ? "true" : "false";
            }
        }

        public int LavaLevel
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//LavaLevel");
                if (n == null) { return 0; }
                return int.Parse(n.InnerText);
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LavaLevel");
                if (n != null)
                {
                    n.InnerText = value.ToString();
                }
            }
        }

        public string NameEng
        {
            get
            {
                if(lang_eng_name_node == null) { return "[not found]"; }
                XmlNode n = lang_eng_name_node.SelectSingleNode(".//Value");
                if (n == null) { return "[no eng value]"; }
                return n.InnerText;
            }
            set
            {
                if (lang_eng_name_node != null) { 
                    XmlNode n = lang_eng_name_node.SelectSingleNode(".//Value");
                    if (n != null) { 
                        n.InnerText = value.ToString();
                    }
                }
            }
        }

        public string NameGer
        {
            get {
                if(lang_ger_name_node == null) { return NameEng; }

                XmlNode n = lang_ger_name_node.SelectSingleNode(".//Value");
                if (n == null) { return "[no ger value]"; }
                return n.InnerText;
            }
            set
            {
                if (lang_ger_name_node != null)
                {
                    XmlNode n = lang_ger_name_node.SelectSingleNode(".//Value");
                    if (n != null)
                    {
                        n.InnerText = value.ToString();
                    }
                }
            }

        }

        public string DescriptionEng
        {
            get
            {
                if (lang_eng_desc_node == null) { return "[not found]"; }
                XmlNode n = lang_eng_desc_node.SelectSingleNode(".//Value");
                if (n == null) { return "[no eng value]"; }
                return n.InnerText;
            }
            set
            {
                if (lang_eng_desc_node != null)
                {
                    XmlNode n = lang_eng_desc_node.SelectSingleNode(".//Value");
                    if (n != null)
                    {
                        n.InnerText = value.ToString();
                    }
                }
            }
        }

        public string DescriptionGer
        {
            get
            {
                if (lang_ger_desc_node == null) { return DescriptionEng; }

                XmlNode n = lang_ger_desc_node.SelectSingleNode(".//Value");
                if (n == null) { return "[no ger value]"; }
                return n.InnerText;
            }
            set
            {
                if (lang_ger_desc_node != null)
                {
                    XmlNode n = lang_ger_desc_node.SelectSingleNode(".//Value");
                    if (n != null)
                    {
                        n.InnerText = value.ToString();
                    }
                }
            }
        }

        public decimal Gravity
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//Gravity");
                if (n == null) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Gravity");
                if (n != null)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public List<Mineable> Mineables
        {
            get
            {
                XmlNodeList nl = node.SelectNodes(".//MineablesOverride//MineableData");
                if(nl == null) { return new List<Mineable>() { }; }

                List<Mineable> list = new List<Mineable>();
                foreach(XmlNode n in nl)
                {
                    Mineable m = new Mineable();
                    m.node = n;

                    list.Add(m);
                }

                return list;
            }
        }

        public List<Mineable> DeepMineables
        {
            get
            {
                XmlNodeList nl = node.SelectNodes(".//DeepMineablesOverride//DeepMineableData");
                if (nl == null) { return new List<Mineable>() { }; }

                List<Mineable> list = new List<Mineable>();
                foreach (XmlNode n in nl)
                {
                    Mineable m = new Mineable();
                    m.node = n;

                    list.Add(m);
                }

                return list;
            }
        }

        public string StartingCondition
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//StartingCondition");
                if (n == null) { return "Default"; }
                return n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//StartingCondition");
                n.InnerText = value;
            }
        }

        public decimal TimeScale
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//CelestialConstants");
                if (n == null) { return 0; }
                if(n.Attributes["TimeScale"] == null) { return 0; }

                return decimal.Parse(n.Attributes["TimeScale"].Value.Replace(".",","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//CelestialConstants");
                n.Attributes["TimeScale"].Value = value.ToString().Replace(",", ".");
            }
        }

        public List<Atmosphere> Atmospherics
        {
            get
            {
                XmlNodeList nl = node.SelectNodes(".//AtmosphereComposition//SpawnGas");
                if (nl == null) { return new List<Atmosphere>() { }; }

                List<Atmosphere> list = new List<Atmosphere>();
                foreach (XmlNode n in nl)
                {
                    Atmosphere a = new Atmosphere();
                    a.node = n;

                    list.Add(a);
                }

                return list;
            }
        }
        public Kelvin Kelvin
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//Kelvin");
                return new Kelvin(n);
            }
        }

        public WeatherEvent WeatherEvent
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherEvent");
                return new WeatherEvent(n);
            }
        }

        public bool RemoveMinable(Mineable minable)
        {
            XmlNode n = node.SelectSingleNode(".//MineablesOverride");
            if (n == null) { return false; }

            n.RemoveChild(minable.node);
            return true;

        }
        public void AddMinable(string ore)
        {
            Mineable minable = new Mineable();

            XmlNode MineableData = node.OwnerDocument.CreateElement("MineableData");
            XmlNode DisplayName = node.OwnerDocument.CreateElement("DisplayName");
            XmlNode OrePrefabName = node.OwnerDocument.CreateElement("OrePrefabName");
            XmlNode VisualizerPrefabName = node.OwnerDocument.CreateElement("VisualizerPrefabName");
            XmlNode GoggleVisualizerPrefabName = node.OwnerDocument.CreateElement("GoggleVisualizerPrefabName");
            XmlNode Rarity = node.OwnerDocument.CreateElement("Rarity");
            XmlNode MiningTime = node.OwnerDocument.CreateElement("MiningTime");
            XmlNode VoxelType = node.OwnerDocument.CreateElement("VoxelType");
            XmlNode VeinSize = node.OwnerDocument.CreateElement("VeinSize");
            XmlNode MaxDropQuantity = node.OwnerDocument.CreateElement("MaxDropQuantity");
            XmlNode MinDropQuantity = node.OwnerDocument.CreateElement("MinDropQuantity");
            XmlNode MaxVeinAttempts = node.OwnerDocument.CreateElement("MaxVeinAttempts");
            XmlNode MinVeinAttempts = node.OwnerDocument.CreateElement("MinVeinAttempts");

            MineableData.AppendChild(DisplayName);
            MineableData.AppendChild(OrePrefabName);
            MineableData.AppendChild(VisualizerPrefabName);
            MineableData.AppendChild(GoggleVisualizerPrefabName);
            MineableData.AppendChild(Rarity);
            MineableData.AppendChild(MiningTime);
            MineableData.AppendChild(VoxelType);
            MineableData.AppendChild(VeinSize);
            MineableData.AppendChild(MaxDropQuantity);
            MineableData.AppendChild(MinDropQuantity);
            MineableData.AppendChild(MaxVeinAttempts);
            MineableData.AppendChild(MinVeinAttempts);

            XmlNode n = node.SelectSingleNode(".//MineablesOverride");
            if (n == null)
            {
                n = node.OwnerDocument.CreateElement("MineablesOverride");
                node.AppendChild(n);
            }
            n.AppendChild(MineableData);

            minable.node = MineableData;
            minable.DisplayName = ore;
            minable.Rarity = 10;
            minable.MiningTime = 1;
            minable.VeinSize = 1;
            minable.MinDropQuantity = 2;
            minable.MaxDropQuantity = 6;
            minable.MinVeinAttempts = 20;
            minable.MaxVeinAttempts = 40;

        }
        public bool RemoveDeepMinable(Mineable minable)
        {
            XmlNode n = node.SelectSingleNode(".//DeepMineablesOverride");
            if (n == null) { return false; }

            n.RemoveChild(minable.node);
            return true;

        }
        public void AddDeepMinable(string ore)
        {
            Mineable minable = new Mineable();

            XmlNode DeepMineableData = node.OwnerDocument.CreateElement("DeepMineableData");
            XmlNode DisplayName = node.OwnerDocument.CreateElement("DisplayName");
            XmlNode OrePrefabName = node.OwnerDocument.CreateElement("OrePrefabName");
            XmlNode VisualizerPrefabName = node.OwnerDocument.CreateElement("VisualizerPrefabName");
            XmlNode GoggleVisualizerPrefabName = node.OwnerDocument.CreateElement("GoggleVisualizerPrefabName");
            XmlNode Rarity = node.OwnerDocument.CreateElement("Rarity");
            XmlNode MiningTime = node.OwnerDocument.CreateElement("MiningTime");
            XmlNode VoxelType = node.OwnerDocument.CreateElement("VoxelType");
            XmlNode VeinSize = node.OwnerDocument.CreateElement("VeinSize");
            XmlNode MaxDropQuantity = node.OwnerDocument.CreateElement("MaxDropQuantity");
            XmlNode MinDropQuantity = node.OwnerDocument.CreateElement("MinDropQuantity");
            XmlNode MaxVeinAttempts = node.OwnerDocument.CreateElement("MaxVeinAttempts");
            XmlNode MinVeinAttempts = node.OwnerDocument.CreateElement("MinVeinAttempts");

            DeepMineableData.AppendChild(DisplayName);
            DeepMineableData.AppendChild(OrePrefabName);
            DeepMineableData.AppendChild(VisualizerPrefabName);
            DeepMineableData.AppendChild(GoggleVisualizerPrefabName);
            DeepMineableData.AppendChild(Rarity);
            DeepMineableData.AppendChild(MiningTime);
            DeepMineableData.AppendChild(VoxelType);
            DeepMineableData.AppendChild(VeinSize);
            DeepMineableData.AppendChild(MaxDropQuantity);
            DeepMineableData.AppendChild(MinDropQuantity);
            DeepMineableData.AppendChild(MaxVeinAttempts);
            DeepMineableData.AppendChild(MinVeinAttempts);

            XmlNode n = node.SelectSingleNode(".//DeepMineablesOverride");
            if(n == null )
            {
                n = node.OwnerDocument.CreateElement("DeepMineablesOverride");
                node.AppendChild(n);
            }
            n.AppendChild(DeepMineableData);

            minable.node = DeepMineableData;
            minable.DisplayName = ore;
            minable.Rarity = 10;
            minable.MiningTime = 1;
            minable.VeinSize = 1;
            minable.MinDropQuantity = 2;
            minable.MaxDropQuantity = 6;
            minable.MinVeinAttempts = 20;
            minable.MaxVeinAttempts = 40;


        }
        public void AddAtmosphere(string gas)
        {
            Atmosphere minable = new Atmosphere();

            XmlNode SpawnGas = node.OwnerDocument.CreateElement("SpawnGas");
            XmlNode Type = node.OwnerDocument.CreateElement("Type");
            XmlNode Quantity = node.OwnerDocument.CreateElement("Quantity");

            SpawnGas.AppendChild(Type);
            SpawnGas.AppendChild(Quantity);

            XmlNode n = node.SelectSingleNode(".//AtmosphereComposition");
            if (n == null)
            {
                n = node.OwnerDocument.CreateElement("AtmosphereComposition");
                node.AppendChild(n);
            }
            n.AppendChild(SpawnGas);

            minable.node = SpawnGas;
            minable.Type = gas;
            minable.Quantity = 10;
        }
        public bool RemoveAtmosphere(Atmosphere atmo)
        {
            XmlNode n = node.SelectSingleNode(".//AtmosphereComposition");
            if (n == null) { return false; }

            n.RemoveChild(atmo.node);
            return true;
        }

        public bool CreateWeather()
        {
            XmlNode weatherevent = node.OwnerDocument.CreateElement("WeatherEvent");
            node.AppendChild(weatherevent);
            return true;
        }

        // Todo: <CelestialBodies> in World.xml <Axis Value="180" /> in 360° Steps je 1 Tag
    }
}
