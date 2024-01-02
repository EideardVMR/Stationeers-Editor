using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class StationeersColor
    {
        XmlNode node = null;
        public StationeersColor(XmlNode n) {
            node = n;
        }

        public int r
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//r");
                if (n != null)
                {
                    decimal c = decimal.Parse(n.InnerText.Replace(".", ","));
                    return (int)(c*255);
                }
                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//r");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("r");
                    node.AppendChild(n);
                }

                n.InnerText = ((float)value / 255f).ToString().Replace(",", ".");
            }
        }

        public int g
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//g");
                if (n != null)
                {
                    decimal c = decimal.Parse(n.InnerText.Replace(".", ","));
                    return (int)(c * 255);
                }
                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//g");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("g");
                    node.AppendChild(n);
                }

                n.InnerText = ((float)value / 255f).ToString().Replace(",", ".");
            }
        }

        public int b
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//b");
                if (n != null)
                {
                    decimal c = decimal.Parse(n.InnerText.Replace(".", ","));
                    return (int)(c * 255);
                }
                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//b");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("b");
                    node.AppendChild(n);
                }

                n.InnerText = ((float)value / 255f).ToString().Replace(",", ".");
            }
        }

        public int a
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//a");
                if (n != null)
                {
                    decimal c = decimal.Parse(n.InnerText.Replace(".", ","));
                    return (int)(c * 255);
                }
                return 0;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//a");
                if (n == null)
                {
                    n = node.OwnerDocument.CreateElement("a");
                    node.AppendChild(n);
                }

                n.InnerText = ((float)value / 255f).ToString().Replace(",",".");
                
            }
        }

    }
}
