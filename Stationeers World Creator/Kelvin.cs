using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Kelvin
    {
        XmlNode node = null;

        public Kelvin(XmlNode n) {
            node = n;
        }

        public string preWrapMode { 
            get
            {
                XmlNode n = node.SelectSingleNode(".//preWrapMode");
                if (n != null)
                {
                    return n.InnerText;
                }
                return "ClampForever";
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//preWrapMode");
                if (n != null)
                {
                    n.InnerText = value;
                    return;
                }

                XmlNode preWrapMode = node.OwnerDocument.CreateElement("preWrapMode");
                preWrapMode.InnerText = value;
                node.AppendChild(preWrapMode);
            }
        }

        public string postWrapMode
        {
            get
            {
                XmlNode n = node.SelectSingleNode(".//postWrapMode");
                if (n != null)
                {
                    return n.InnerText;
                }
                return "ClampForever";
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//postWrapMode");
                if (n != null)
                {
                    n.InnerText = value;
                    return;
                }

                XmlNode postWrapMode = node.OwnerDocument.CreateElement("postWrapMode");
                postWrapMode.InnerText = value;
                node.AppendChild(postWrapMode);

            }
        }

        public List<Kelvinframe> Frames
        {
            get { 
                List<Kelvinframe> frames = new List<Kelvinframe>();

                XmlNodeList nl = node.SelectNodes(".//keys//Keyframe");
                if(nl == null) { return new List<Kelvinframe>(); }
                foreach(XmlNode n in nl)
                {
                    frames.Add(new Kelvinframe(n));
                }

                return frames; 
            }
        }

        public void AddFrame(decimal time)
        {
            XmlNode keys = node.SelectSingleNode(".//keys");
            if(keys == null)
            {
                node.InnerText = String.Empty;
                keys = node.OwnerDocument.CreateElement("keys");
                node.AppendChild (keys);
            }

            XmlNode keyframe = node.OwnerDocument.CreateElement("Keyframe");
            keys.AppendChild(keyframe);

            Kelvinframe kelvinframe = new Kelvinframe(keyframe);
            kelvinframe.time = time;
            kelvinframe.value = 273;
            kelvinframe.inTangent = 0;
            kelvinframe.outTangent = 0;
            kelvinframe.inWeight = (decimal)0.333333343;
            kelvinframe.outWeight = (decimal)0.333333343;
            kelvinframe.weightedMode = "None";

        }

        public void RemoveFrame(Kelvinframe frame) {

            XmlNode n = node.SelectSingleNode(".//keys");
            if (n != null) {
                n.RemoveChild(frame.node);
            }

        }
    }
}
