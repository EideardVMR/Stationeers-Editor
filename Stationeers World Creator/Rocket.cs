using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        int index = 0;

        public Rocket (Savegame savegame, XmlNode node, int i)
        {
            this.savegame = savegame;
            this.node = node;
            this.index = i;
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

        int _landingpadID = -1;
        public int LandingpadID
        {
            get
            {
                if (_landingpadID != -1) { return _landingpadID; }

                int i = 0;
                foreach (XmlNode n in node.SelectNodes("//SpaceMap//LaunchPadNode"))
                {
                    if (i == index) { 
                        return _landingpadID = int.Parse(n.Attributes["Id"].Value);
                    }
                    i++;
                }

                return -1;
            }

        }

        Point3D _rocketTransformPosition = null;
        public Point3D RocketTransformPosition
        {
            get
            {
                if (_rocketTransformPosition != null) { return _rocketTransformPosition; }

                XmlNode n = node.SelectSingleNode("./RocketTransformPosition");
                if(n == null) { return _rocketTransformPosition = null; }
                _rocketTransformPosition = new Point3D(n);

                return _rocketTransformPosition;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./RocketTransformPosition/x");
                if (n == null) { return; }
                n.InnerText = value.X.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./RocketTransformPosition/y");
                if (n == null) { return; }
                n.InnerText = value.Y.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./RocketTransformPosition/z");
                if (n == null) { return; }
                n.InnerText = value.Z.ToString().Replace(",", ".");
            }

        }

        Point3D _parentedPosition = null;
        public Point3D ParentedPosition
        {
            get
            {
                if (_parentedPosition != null) { return _parentedPosition; }

                XmlNode n = node.SelectSingleNode("./ParentedPosition");
                if (n == null) { return _parentedPosition = null; }
                _parentedPosition = new Point3D(n);

                return _parentedPosition;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./ParentedPosition/x");
                if (n == null) { return; }
                n.InnerText = value.X.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./ParentedPosition/y");
                if (n == null) { return; }
                n.InnerText = value.Y.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./ParentedPosition/z");
                if (n == null) { return; }
                n.InnerText = value.Z.ToString().Replace(",", ".");
            }

        }

        Point3D _targetPosition = null;
        public Point3D TargetPosition
        {
            get
            {
                if (_targetPosition != null) { return _targetPosition; }

                XmlNode n = node.SelectSingleNode("./TargetPosition");
                if (n == null) { return _targetPosition = null; }
                _targetPosition = new Point3D(n);

                return _targetPosition;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./TargetPosition/x");
                if (n == null) { return; }
                n.InnerText = value.X.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./TargetPosition/y");
                if (n == null) { return; }
                n.InnerText = value.Y.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./TargetPosition/z");
                if (n == null) { return; }
                n.InnerText = value.Z.ToString().Replace(",", ".");
            }

        }

        Point2D _parkLocation = null;
        public Point2D ParkLocation
        {
            get
            {
                if (_parkLocation != null) { return _parkLocation; }

                XmlNode n = node.SelectSingleNode("./ParkLocation");
                if (n == null) { return _parkLocation = null; }
                _parkLocation = new Point2D(n);

                return _parkLocation;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./ParkLocation/x");
                if (n == null) { return; }
                n.InnerText = value.X.ToString().Replace(",", ".");
                n = node.SelectSingleNode("./ParkLocation/y");
                if (n == null) { return; }
                n.InnerText = value.Y.ToString().Replace(",", ".");
            }

        }

        Thing _landingMount = null;
        public Thing LandingMount
        {
            get
            {
                if (_landingMount != null) { return _landingMount; }

                foreach (Thing thing in savegame.Things)
                {
                    if (thing.LinkedNodeId == LandingpadID)
                    {
                        return _landingMount = thing;
                    }
                }

                return null;
            }
        }

        List<Thing> _things = null;
        public List<Thing> Things
        {
            get
            {
                if (_things != null) { return _things; }


                double maxY = -10000;
                double minY = 10000;
                double maxX = -10000;
                double minX = 10000;
                double maxZ = -10000;
                double minZ = 10000;

                var fuselage = new List<Thing>();
                foreach (Thing thing in savegame.Things)
                {
                    if (thing.RocketNetworkId == NetworkID)
                    {
                        fuselage.Add(thing);
                        maxY = Math.Max(thing.WorldPosition.Y, maxY);
                        minY = Math.Min(thing.WorldPosition.Y, minY);
                        maxX = Math.Max(thing.WorldPosition.X, maxX);
                        minX = Math.Min(thing.WorldPosition.X, minX);
                        maxZ = Math.Max(thing.WorldPosition.Z, maxZ);
                        minZ = Math.Min(thing.WorldPosition.Z, minZ);
                    }
                }
                maxY += 0.5;
                maxX += 0.5;
                minX -= 0.5;
                maxZ += 0.5;
                minZ -= 0.5;

                //Debug.WriteLine("("+minY+";"+maxY+ ") - ("+minX+";"+maxX+ ") - ("+minZ+";"+maxZ+")");

                var infuselage = new List<Thing>();
                foreach (Thing thing in savegame.Things)
                {
                    if(
                        thing.WorldPosition.Y >= minY && thing.WorldPosition.Y <= maxY &&
                        thing.WorldPosition.X >= minX && thing.WorldPosition.X <= maxX &&
                        thing.WorldPosition.Z >= minZ && thing.WorldPosition.Z <= maxZ
                    )
                    {
                        infuselage.Add(thing);
                    }
                }

                _things = new List<Thing>();
                _things.AddRange(fuselage);
                _things.AddRange(infuselage);
                _things = _things.Distinct().ToList();

                /*
                foreach (Thing thing in _things)
                {
                    Debug.WriteLine(thing.WorldPosition.X.ToString().PadLeft(6) + ";" + thing.WorldPosition.Y.ToString().PadLeft(6) + ";" + thing.WorldPosition.Z.ToString().PadLeft(6) + " | " + thing.PrefabName);
                }
                */

                return _things;
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

                XmlNode n = node.SelectSingleNode("./ReferenceId");
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

                XmlNode n = node.SelectSingleNode("./RocketNetworkId");
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

                XmlNode n = node.SelectSingleNode("./CustomName");
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

                XmlNode n = node.SelectSingleNode("./RocketMode");
                if (n == null) { return _rocketMode = ""; }
                return _rocketMode = n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./RocketMode");
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

                XmlNode n = node.SelectSingleNode("./RocketState");
                if (n == null) { return _rocketState = ""; }
                return _rocketState = n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./RocketState");
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

                XmlNode n = node.SelectSingleNode("./Progress");
                if (n == null) { return _progress = -1; }
                return _progress = double.Parse(n.InnerText.Replace(".",","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./Progress");
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

                XmlNode n = node.SelectSingleNode("./TargetNodeId");
                if (n == null) { return _targetNodeId = -1; }
                return _targetNodeId = int.Parse(n.InnerText);
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./TargetNodeId");
                if (n == null) { return; }
                n.InnerText = value.ToString();
                _targetNodeId = value;
                savegame.IsChanged = true;
            }
        }

        int _currentNodeId = -1;
        public int CurrentNodeId
        {
            get
            {
                if (_currentNodeId != -1) { return _currentNodeId; }

                XmlNode n = node.SelectSingleNode("./CurrentNodeId");
                if (n == null) { return _currentNodeId = -1; }
                return _currentNodeId = int.Parse(n.InnerText);
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./CurrentNodeId");
                if (n == null) { return; }
                n.InnerText = value.ToString();
                _currentNodeId = value;
                savegame.IsChanged = true;
            }
        }

    }
}
