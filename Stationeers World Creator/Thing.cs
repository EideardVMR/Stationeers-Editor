using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Thing
    {
        Savegame savegame;
        XmlNode node;

        
        public Thing(Savegame save, XmlNode n)
        {
            node = n;
            savegame = save;
        }

        public XmlNode Node
        {
            get { return node; }
        }

        string _type = "";
        public string Type
        {
            get
            {
                if(_type != "") { return _type; }
                if(node.Attributes["xsi:type"] == null) { return _type = ""; }
                return _type = node.Attributes["xsi:type"].Value;
            }
        }

        
        int _id = -1;
        public int Id
        {
            get
            {
                if (_id != -1) { return _id; }

                XmlNode n = node.SelectSingleNode("./ReferenceId");
                if(n == null) { return _id = -1; }
                return _id = int.Parse(n.InnerText);
            }
        }

        string _prefabName = "";
        public string PrefabName
        {
            get
            {
                if (_prefabName != "") { return _prefabName; }

                XmlNode n = node.SelectSingleNode("./PrefabName");
                if (n == null) { return _prefabName = ""; }
                return _prefabName = n.InnerText;
            }
        }

        string _customName = "";
        public string Name
        {
            get
            {
                if (_customName != "") { return _customName; }

                XmlNode n = node.SelectSingleNode("./CustomName");
                if (n == null) { return _customName = PrefabName; }
                
                if(n.InnerText != "") { return _customName = n.InnerText; }
                
                return _customName = PrefabName;
            }
        }

        int _parentReferenceId = -1;
        public int ParentReferenceId
        {
            get
            {
                if (_parentReferenceId != -1) { return _parentReferenceId; }

                XmlNode n = node.SelectSingleNode("./ParentReferenceId");
                if (n == null) { return _parentReferenceId = -1; }
                return _parentReferenceId = int.Parse(n.InnerText);
            }
        }
        
        double _oxygenDamage = -1;
        public double OxygenDamage
        {
            get
            {
                if (_oxygenDamage != -1) { return _oxygenDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Oxygen");
                if (n == null) { return _oxygenDamage = -1; }
                return _oxygenDamage = double.Parse(n.InnerText.Replace(".",","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Oxygen");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _oxygenDamage = value;
            }
        }

        double _hydrationDamage = -1;
        public double HydrationDamage
        {
            get
            {
                if (_hydrationDamage != -1) { return _hydrationDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Hydration");
                if (n == null) { return _hydrationDamage = -1; }
                return _hydrationDamage = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Hydration");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _hydrationDamage = value;
            }
        }

        double _starvationDamage = -1;
        public double StarvationDamage
        {
            get
            {
                if (_starvationDamage != -1) { return _starvationDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode(".//Starvation");
                if (n == null) { return _starvationDamage = -1; }
                return _starvationDamage = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Starvation");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _starvationDamage = value;
            }
        }

        double _stunDamage = -1;
        public double StunDamage
        {
            get
            {
                if (_stunDamage != -1) { return _stunDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Stun");
                if (n == null) { return _stunDamage = -1; }
                return _stunDamage = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Stun");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _stunDamage = value;
            }
        }

        double _burnDamage = -1;
        public double BurnDamage
        {
            get
            {
                if (_burnDamage != -1) { return _burnDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Burn");
                if (n == null) { return _burnDamage = -1; }
                return _burnDamage = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Burn");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _burnDamage = value;
            }
        }

        double _bruteDamage = -1;
        public double BruteDamage
        {
            get
            {
                if (_bruteDamage != -1) { return _bruteDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Brute");
                if (n == null) { return _bruteDamage = -1; }
                return _bruteDamage = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Brute");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _bruteDamage = value;
            }
        }

        double _toxicDamage = -1;
        public double ToxicDamage
        {
            get
            {
                if (_toxicDamage != -1) { return _toxicDamage; }

                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Toxic");
                if (n == null) { return _toxicDamage = -1; }
                return _toxicDamage = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./DamageState");
                n = n.SelectSingleNode("./Toxic");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _toxicDamage = value;
            }
        }

        double _nutrition = -1;
        public double Nutrition
        {
            get
            {
                if (_nutrition != -1) { return _nutrition; }

                XmlNode n = node.SelectSingleNode("./Nutrition");
                if (n == null) { return _nutrition = -1; }
                return _nutrition = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./Nutrition");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",",".");
                _nutrition = value;
            }
        }

        double _hydration = -1;
        public double Hydration
        {
            get
            {
                if (_hydration != -1) { return _hydration; }

                XmlNode n = node.SelectSingleNode("./Hydration");
                if (n == null) { return _hydration = -1; }
                return _hydration = double.Parse(n.InnerText.Replace(".", ","));
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./Hydration");
                if (n == null) { return; }
                n.InnerText = value.ToString().Replace(",", ".");
                _hydration = value;
            }
        }

        string _state = "";
        public string State
        {
            get
            {
                if (_state != "") { return _state; }

                XmlNode n = node.SelectSingleNode("./State");
                if (n == null) { return _state = ""; }
                return _state = n.InnerText;
            }
            set
            {
                XmlNode n = node.SelectSingleNode("./State");
                if (n == null) { return; }
                n.InnerText = value;
                _state = value;
            }
        }

    }
}
