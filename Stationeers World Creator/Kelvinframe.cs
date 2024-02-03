using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Kelvinframe
    {
        public XmlNode node = null;
        public Kelvinframe(XmlNode n)
        {
            node = n;
        }

        public decimal time
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./time");
                if(n == null) { return 0; }
                if(n.InnerText == String.Empty) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".",","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./time");
                if(n== null)
                {
                    n = node.OwnerDocument.CreateElement("time");
                    node.AppendChild(n);
                }

                if(value >= 0 &&  value <= 1)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public decimal value
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./value");
                if (n == null) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./value");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("value");
                    node.AppendChild(n);
                }

                if (value >= 0)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public decimal inTangent
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./inTangent");
                if (n == null) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./inTangent");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("inTangent");
                    node.AppendChild(n);
                }

                if (value <= 0)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public decimal outTangent
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./outTangent");
                if (n == null) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./outTangent");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("outTangent");
                    node.AppendChild(n);
                }

                if (value <= 0)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public decimal inWeight
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./inWeight");
                if (n == null) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./inWeight");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("inWeight");
                    node.AppendChild(n);
                }

                if (value >= 0)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public decimal outWeight
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./outWeight");
                if (n == null) { return 0; }
                return decimal.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./outWeight");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("outWeight");
                    node.AppendChild(n);
                }

                if (value >= 0)
                {
                    n.InnerText = value.ToString().Replace(",", ".");
                }
            }
        }

        public string weightedMode
        {
            get
            {
                XmlNode n = node.SelectSingleNode("./weightedMode");
                if (n == null) { return "None"; }
                return n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./weightedMode");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("weightedMode");
                    node.AppendChild(n);
                }

                n.InnerText = value.ToString();
            }
        }
    }
}
