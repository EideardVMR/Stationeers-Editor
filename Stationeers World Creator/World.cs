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

        public static TerrainPreset MarsPreset;
        public static TerrainPreset EuropaPreset;
        public static TerrainPreset VulcanPreset;
        public static TerrainPreset VenusPreset;
        public static TerrainPreset FlatPreset;
        public static TerrainPreset MountainsPreset;
        public static TerrainPreset IslandsPreset;

        public World(WorldCollection collection, XmlNode n)
        {
            this.collection = collection;
            this.node = n;

            MarsPreset = new TerrainPreset("Mars");
            MarsPreset.AddParameter("true", "0.1", "2.0");
            MarsPreset.AddParameter("true", "0.01", "5.0", "4");
            MarsPreset.AddParameter("false", "0.1", "1.0", "4");

            EuropaPreset = new TerrainPreset("Europa");
            EuropaPreset.AddParameter("true", "0.01", "3", "4");
            EuropaPreset.AddParameter("true", "0.01", "5", "4");
            EuropaPreset.AddParameter("true", "0.01", "2", "4");
            EuropaPreset.AddParameter("true", "0.1", "2", "4");
            EuropaPreset.AddParameter("true", "0.3", "1.5", "4");
            EuropaPreset.AddParameter("false", "0.1", "1", "4");
            EuropaPreset.AddParameter("true", "0.01", "2.5", "3");
            EuropaPreset.AddParameter("true", "0.05", "3.5", "4");

            VulcanPreset = new TerrainPreset("Vulcan");
            VulcanPreset.AddParameter("false", "0.1", "30", "-10");
            VulcanPreset.AddParameter("true", "0.01", "3", "4");
            VulcanPreset.AddParameter("true", "0.01", "5", "4");
            VulcanPreset.AddParameter("true", "0.01", "2", "4");
            VulcanPreset.AddParameter("true", "0.1", "2", "4");
            VulcanPreset.AddParameter("true", "0.3", "1.5", "4");
            VulcanPreset.AddParameter("false", "0.1", "1", "4");

            VenusPreset = new TerrainPreset("Venus");
            VenusPreset.AddParameter("true", "0.017", "3", "4");
            VenusPreset.AddParameter("true", "0.01", "3.5", "4");
            VenusPreset.AddParameter("true", "0.01", "4.5", "4");
            VenusPreset.AddParameter("true", "0.09", "1", "1");
            VenusPreset.AddParameter("true", "0.01", "3.5", "2");
            VenusPreset.AddParameter("true", "0.05", "2.5", "4");
            VenusPreset.AddParameter("true", "0.07", "1", "1");

            FlatPreset = new TerrainPreset("Flatland");
            FlatPreset.AddParameter("true", "0", "0");

            MountainsPreset = new TerrainPreset("Mountains");
            MountainsPreset.AddParameter("true", "0.1", "2.0");
            MountainsPreset.AddParameter("true", "0.01", "5.0", "4");
            MountainsPreset.AddParameter("true", "0.1", "1.0", "4");

            IslandsPreset = new TerrainPreset("Islands");
            IslandsPreset.AddParameter("true", "0.01", "-2.0");
            IslandsPreset.AddParameter("true", "0.005", "-5.0", "4");
            IslandsPreset.AddParameter("true", "0.05", "-3.0", "4");
            IslandsPreset.AddParameter("true", "0.01", "5.0", "4");

        }

        public string GameMode
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//GameMode");
                if(n == null)
                {
                    n = node.OwnerDocument.CreateElement("GameMode");
                    node.AppendChild(n);
                    n.InnerText = "Survival";
                }

                return n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//GameMode");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("GameMode");
                    node.AppendChild(n);
                    n.InnerText = "Survival";
                }

                n.InnerText = value;
            }
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
                if(n == null) {
                    n = node.OwnerDocument.CreateElement("StartingCondition");
                    node.AppendChild(n);    
                }
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

        public bool RemoveWeather()
        {
            XmlNode n = node.SelectSingleNode(".//WeatherEvent");
            if (n == null) { return true; }

            node.RemoveChild(n);
            return true;
        }

        public string CustomTerrain
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//CustomTerrainParameters");
                if(n == null) { return "None"; }
                XmlNodeList paras = n.SelectNodes(".//Parameter");

                TerrainPreset tps = new TerrainPreset("FoundPS");
                foreach(XmlNode param in paras)
                {
                    XmlNode td = param.SelectSingleNode(".//TwoDimensions");
                    XmlNode fq = param.SelectSingleNode(".//Frequency");
                    XmlNode ampl = param.SelectSingleNode(".//Amplitude"); 
                    XmlNode size = param.SelectSingleNode(".//Size");

                    if (size != null)
                    {
                        tps.AddParameter(td.InnerText, fq.InnerText, ampl.InnerText, size.InnerText);
                    }
                    else
                    {
                        tps.AddParameter(td.InnerText, fq.InnerText, ampl.InnerText);
                    }
                }

                if(tps.Compare(MarsPreset))
                {
                    return MarsPreset.Name;
                }

                if (tps.Compare(EuropaPreset))
                {
                    return EuropaPreset.Name;
                }

                if (tps.Compare(VulcanPreset))
                {
                    return VulcanPreset.Name;
                }

                if (tps.Compare(VenusPreset))
                {
                    return VenusPreset.Name;
                }

                if (tps.Compare(MountainsPreset))
                {
                    return MountainsPreset.Name;
                }

                if (tps.Compare(IslandsPreset))
                {
                    return IslandsPreset.Name;
                }

                if (tps.Compare(FlatPreset))
                {
                    return FlatPreset.Name;
                }

                return "FullCustom";
            }
            set
            {
                if(value == "None")
                {
                    XmlNode no = node.SelectSingleNode(".//CustomTerrainParameters");
                    if (no != null)
                    {
                        node.RemoveChild(no);
                    }
                    return;
                }

                TerrainPreset tps = null;
                if(value == MarsPreset.Name) {
                    tps = MarsPreset;
                } 
                else if (value == EuropaPreset.Name)
                {
                    tps = EuropaPreset;
                }
                else if (value == VulcanPreset.Name)
                {
                    tps = VulcanPreset;
                }
                else if (value == VenusPreset.Name)
                {
                    tps = VenusPreset;
                }
                else if (value == MountainsPreset.Name)
                {
                    tps = MountainsPreset;
                }
                else if (value == IslandsPreset.Name)
                {
                    tps = IslandsPreset;
                }
                else if (value == FlatPreset.Name)
                {
                    tps = FlatPreset;
                }
                else
                {
                    return;
                }

                XmlNode n = node.SelectSingleNode(".//CustomTerrainParameters");
                if (n != null)
                {
                    node.RemoveChild(n);
                }

                XmlNode CustomTerrainParameters = node.OwnerDocument.CreateElement("CustomTerrainParameters");

                foreach (TerrainParameter tp in tps.TerrainPresetList)
                {
                    XmlNode Parameter = node.OwnerDocument.CreateElement("Parameter");
                    CustomTerrainParameters.AppendChild(Parameter);

                    XmlNode TwoDimensions = node.OwnerDocument.CreateElement("TwoDimensions");
                    TwoDimensions.InnerText = tp.TwoDimensions;
                    Parameter.AppendChild(TwoDimensions);

                    XmlNode Frequency = node.OwnerDocument.CreateElement("Frequency");
                    Frequency.InnerText = tp.Frequency;
                    Parameter.AppendChild(Frequency);

                    XmlNode Amplitude = node.OwnerDocument.CreateElement("Amplitude");
                    Amplitude.InnerText = tp.Amplitude;
                    Parameter.AppendChild(Amplitude);

                    if(tp.Size != null && tp.Size != "" && tp.Size != String.Empty) { 
                        XmlNode Size = node.OwnerDocument.CreateElement("Size");
                        Size.InnerText = tp.Size;
                        Parameter.AppendChild(Size);
                    }
                }

                node.AppendChild(CustomTerrainParameters);

            }
        }

        // Todo: <CelestialBodies> in World.xml <Axis Value="180" /> in 360° Steps je 1 Tag
    }
}
