using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class SpaceMapPoint
    {
        int _id {  get; set; }
        string _templateId { get; set; }

        public SpaceMapPoint(XmlNode n) { 
        
            if (n.Attributes["Id"] != null) { _id = int.Parse(n.Attributes["Id"].Value); }

            if (n.Attributes["TemplateId"] != null) { _templateId = n.Attributes["TemplateId"].Value; }

        }

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public string TemplateId
        {
            get
            {
                return _templateId;
            }
        }

        public override string ToString()
        {
            return _templateId;
        }
    }

    public class Rocket
    {
        Savegame savegame {  get; set; }
        XmlNode node { get; set; }

        public Rocket (Savegame savegame, XmlNode node)
        {
            this.savegame = savegame;
            this.node = node;
        }

        public static string[] AvailableStates
        {
            get
            {
                return ["OnLaunchMount", "Launching", "InSpace", "Landing"];
            }
        }

        public static string[] AvailableModes
        {
            get
            {
                return ["None", "Mine", "Discover", "Survey"];
            }
        }

        List<SpaceMapPoint> _spaceMapPoints;
        public List<SpaceMapPoint> SpaceMapPoints
        {
            get
            {
                if(_spaceMapPoints != null) { return _spaceMapPoints; }

                _spaceMapPoints = new List<SpaceMapPoint>();
                foreach(XmlNode n in node.SelectNodes("//SpaceMap//StaticNode"))
                {
                    _spaceMapPoints.Add(new SpaceMapPoint(n));
                }
                foreach (XmlNode n in node.SelectNodes("//SpaceMap//SiteNode"))
                {
                    _spaceMapPoints.Add(new SpaceMapPoint(n));
                }

                return _spaceMapPoints;
            }
        }

        public SpaceMapPoint getSpaceMap(int id)
        {
            foreach(SpaceMapPoint p in _spaceMapPoints)
            {
                if(p.Id == id) { return p; }
            }
            return null;
        }

        public SpaceMapPoint getSpaceMap(string name)
        {
            foreach (SpaceMapPoint p in _spaceMapPoints)
            {
                if (p.TemplateId == name) { return p; }
            }
            return null;
        }

        int _id = -1;
        public int Id
        {
            get
            {
                if (_id != -1) { return _id; }

                XmlNode n = node.SelectSingleNode(".//ReferenceId");
                if (n == null) { return _id = -1; }
                return _id = int.Parse(n.InnerText);
            }
        }

        int _networkId = -1;
        public int NetworkID
        {
            get
            {
                if (_networkId != -1) { return _networkId; }

                XmlNode n = node.SelectSingleNode(".//RocketNetworkId");
                if (n == null) { return _networkId = -1; }
                return _networkId = int.Parse(n.InnerText);
            }
        }

        string _customName = "";
        public string Name
        {
            get
            {
                if (_customName != "") { return _customName; }

                XmlNode n = node.SelectSingleNode(".//CustomName");
                if (n == null) { return _customName = "Rocket " + Id; }

                if (n.InnerText != "") { return _customName = n.InnerText; }

                return _customName = "Rocket " + Id;
            }
        }

        string _rocketMode = "";
        /// <summary>
        /// None, Discover, Survey, Chart, Mine, Scanner
        /// </summary>
        public string RocketMode
        {
            get
            {
                if (_rocketMode != "") { return _rocketMode; }

                XmlNode n = node.SelectSingleNode(".//RocketMode");
                if (n == null) { return _rocketMode = ""; }
                return _rocketMode = n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//RocketMode");
                if (n == null) { return; }
                n.InnerText = value;
                _rocketMode = value;
                savegame.IsChanged = true;
            }
        }

        string _rocketState = "";
        /// <summary>
        /// OnLaunchMount, Launching, InSpace, Landing
        /// </summary>
        public string RocketState
        {
            get
            {
                if (_rocketState != "") { return _rocketState; }

                XmlNode n = node.SelectSingleNode(".//RocketState");
                if (n == null) { return _rocketState = ""; }
                return _rocketState = n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//RocketState");
                if (n == null) { return; }
                n.InnerText = value;
                _rocketState = value;
                savegame.IsChanged = true;
            }
        }

        double _progress = -1;
        public double Progress
        {
            get
            {
                if (_progress != -1) { return _progress; }

                XmlNode n = node.SelectSingleNode(".//Progress");
                if (n == null) { return _progress = -1; }
                return _progress = double.Parse(n.InnerText.Replace(".",","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Progress");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",",".");
                _progress = value;
                savegame.IsChanged = true;
            }
        }

        int _targetNodeId = -1;
        public int TargetNodeId
        {
            get
            {
                if (_targetNodeId != -1) { return _targetNodeId; }

                XmlNode n = node.SelectSingleNode(".//TargetNodeId");
                if (n == null) { return _targetNodeId = -1; }
                return _targetNodeId = int.Parse(n.InnerText);
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//TargetNodeId");
                if (n == null) { return; }
                n.InnerText = value.ToString();
                _targetNodeId = value;
                savegame.IsChanged = true;
            }
        }

    }
}
