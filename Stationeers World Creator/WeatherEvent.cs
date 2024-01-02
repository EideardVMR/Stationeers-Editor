using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class WeatherEvent
    {
        XmlNode node = null;

        public WeatherEvent(XmlNode node) { 
        
            this.node = node;

        }

        public bool HasWeather()
        {
            if (node == null) { return false; }
            return node.HasChildNodes;
        }

        public string Id
        {
            get
            {
                if (node.Attributes["Id"] == null)
                {
                    return null;
                }

                return node.Attributes["Id"].Value;
            }
            set 
            {
                if (node.Attributes["Id"] == null)
                {
                    XmlAttribute attr = node.OwnerDocument.CreateAttribute("Id");
                    node.Attributes.Append(attr);
                }

                StationeersColor color = this.FogColor;
                if (value == "WeatherVenusStorm") {
                    color.a = 255;
                    color.r = 153;
                    color.g = 102;
                    color.b = 26;
                }
                if (value == "WeatherDustStorm")
                {
                    color.a = 255;
                    color.r = 164;
                    color.g = 124;
                    color.b = 106;
                }
                if (value == "WeatherSnowStorm")
                {
                    color.a = 255;
                    color.r = 209;
                    color.g = 232;
                    color.b = 255;
                }
                if (value == "WeatherAshStorm")
                {
                    color.a = 255;
                    color.r = 34;
                    color.g = 34;
                    color.b = 34;
                }

                node.Attributes["Id"].Value = value;
            }
        }

        public int WeatherMinimumStartTime
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMinimumStartTime");
                if(n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMinimumStartTime");
                if(n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherMinimumStartTime");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public int WeatherMaximumStartTime
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMaximumStartTime");
                if (n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMaximumStartTime");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherMaximumStartTime");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public int WeatherMinimumDuration
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMinimumDuration");
                if (n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMinimumDuration");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherMinimumDuration");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public int WeatherMaximumDuration
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMaximumDuration");
                if (n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMaximumDuration");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherMaximumDuration");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public int WeatherMinimumCooldownDuration
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMinimumCooldownDuration");
                if (n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMinimumCooldownDuration");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherMinimumCooldownDuration");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public int WeatherMaximumCooldownDuration
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMaximumCooldownDuration");
                if (n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherMaximumCooldownDuration");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherMaximumCooldownDuration");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public int WeatherWorldStartCooldownDuration
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//WeatherWorldStartCooldownDuration");
                if (n != null)
                {
                    return int.Parse(n.InnerText);
                }

                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//WeatherWorldStartCooldownDuration");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("WeatherWorldStartCooldownDuration");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }

        public StationeersColor FogColor
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//FogColor");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("FogColor");
                    node.AppendChild(n);
                }
                return new StationeersColor(n);
            }
        }

        public Kelvin Kelvin { 
            get {
                XmlNode n = node.SelectSingleNode(".//WeatherKelvin");
                if(n == null) {
                    n = node.OwnerDocument.CreateElement("WeatherKelvin");
                    node.AppendChild(n);
                }
                return new Kelvin(n);
            } 
        }
    }
}
