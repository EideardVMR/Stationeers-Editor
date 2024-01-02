using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Mineable
    {
        public XmlNode node = null;

        public string DisplayName { 
            get {
                XmlNode d = node.SelectSingleNode(".//DisplayName");
                return d.InnerText;
            } 
            set
            {
                string[] x = ["Iron", "Gold", "Coal", "Copper", "Uranium", "Silver", "Nickel", "Lead", "Silicon", "Cobalt"];
                if (x.Contains(value))
                {

                    XmlNode d = node.SelectSingleNode(".//DisplayName");
                    d.InnerText = value;

                    d = node.SelectSingleNode(".//OrePrefabName");
                    d.InnerText = "Item" + value + "Ore";

                    d = node.SelectSingleNode(".//VisualizerPrefabName");
                    d.InnerText = "AsteroidOre" + value;

                    d = node.SelectSingleNode(".//GoggleVisualizerPrefabName");
                    d.InnerText = "VisualizerGoggleOre" + value;

                    d = node.SelectSingleNode(".//VoxelType");
                    d.InnerText = value;

                } else
                {
                    XmlNode d = node.SelectSingleNode(".//DisplayName");
                    d.InnerText = value;

                    d = node.SelectSingleNode(".//OrePrefabName");
                    d.InnerText = "Item" + value;

                    d = node.SelectSingleNode(".//VisualizerPrefabName");
                    d.InnerText = "AsteroidOre" + value;

                    d = node.SelectSingleNode(".//GoggleVisualizerPrefabName");
                    d.InnerText = "VisualizerGoggleOre" + value;

                    d = node.SelectSingleNode(".//VoxelType");
                    d.InnerText = value;
                }
            }
        }
        public string OrePrefabName { 
            get
            {
                XmlNode d = node.SelectSingleNode(".//OrePrefabName");
                return d.InnerText;
            } 
        }
        public string VisualizerPrefabName {
            get
            {
                XmlNode d = node.SelectSingleNode(".//VisualizerPrefabName");
                return d.InnerText;
            }
        }
        public string GoggleVisualizerPrefabName {
            get
            {
                XmlNode d = node.SelectSingleNode(".//GoggleVisualizerPrefabName");
                return d.InnerText;
            }
        }
        public string VoxelType {
            get
            {
                XmlNode d = node.SelectSingleNode(".//VoxelType");
                return d.InnerText;
            }
        }
        public int Rarity
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//Rarity");
                return int.Parse(d.InnerText);
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//Rarity");
                d.InnerText = value.ToString();
            }
        }
        public decimal MiningTime
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//MiningTime");
                return decimal.Parse(d.InnerText.Replace(".",","));
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//MiningTime");
                d.InnerText = value.ToString().Replace(",",".");
            }
        }
        public int VeinSize
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//VeinSize");
                return int.Parse(d.InnerText);
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//VeinSize");
                d.InnerText = value.ToString();
            }
        }
        public int MaxDropQuantity
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//MaxDropQuantity");
                return int.Parse(d.InnerText);
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//MaxDropQuantity");
                d.InnerText = value.ToString();
            }
        }
        public int MinDropQuantity
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//MinDropQuantity");
                return int.Parse(d.InnerText);
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//MinDropQuantity");
                d.InnerText = value.ToString();
            }
        }
        public int MaxVeinAttempts
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//MaxVeinAttempts");
                return int.Parse(d.InnerText);
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//MaxVeinAttempts");
                d.InnerText = value.ToString();
            }
        }
        public int MinVeinAttempts
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//MinVeinAttempts");
                return int.Parse(d.InnerText);
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//MinVeinAttempts");
                d.InnerText = value.ToString();
            }
        }
    }
}
