using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Atmosphere
    {
        public XmlNode node = null;

        public string Type
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//Type");
                return d.InnerText;
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//Type");
                d.InnerText = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                XmlNode d = node.SelectSingleNode(".//Quantity");
                return decimal.Parse(d.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode d = node.SelectSingleNode(".//Quantity");
                d.InnerText = value.ToString();
            }
        }
    }
}
