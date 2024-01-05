using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(XmlNode node)
        {
            XmlNode nx = node.SelectSingleNode(".//x");
            XmlNode ny = node.SelectSingleNode(".//y");
            XmlNode nz = node.SelectSingleNode(".//z");

            X = double.Parse(nx.InnerText.Replace(".",","));
            Y = double.Parse(ny.InnerText.Replace(".", ",")); 
            Z = double.Parse(nz.InnerText.Replace(".", ","));
        }

        public bool Equals(Point3D p2)
        {
            return this.X == p2.X && this.Y == p2.Y && this.Z == p2.Z;
        }

        public Point3D Multiply(double multiplier)
        {
            Point3D p = new Point3D(X, Y, Z);
            p.X *= multiplier;
            p.Y *= multiplier;
            p.Z *= multiplier;
            return p;
        }

        public override string ToString()
        {
            return X.ToString() + "," + Y.ToString() + "," + Z.ToString();
        }
    }

    public class Room : IComparable<Room>
    {

        XmlNode node = null;
        Savegame savegame = null;

        double _molsgas = 0;
        double _molsliquid = 0;

        public List<SavegameAtmosphere> _unusedNodes = new List<SavegameAtmosphere>();
        public List<SavegameAtmosphere> _atmoNodes = null;

        public Room(XmlNode n, Savegame s) {
            node = n;
            savegame = s;
        }

        public int CompareTo(Room other)
        {
            if (this.Id < other.Id) return -1;
            if (this.Id > other.Id) return 1;

            return 0;
        }

        public double items_maximum = 0;
        public double items_completed = 0;

        public void LoadAtmosphere()
        {

            if(_atmoNodes != null) { return; }
            _atmoNodes = new List<SavegameAtmosphere>();

            //Debug.WriteLine("---------- LoadAtmosphere " + savegame.Atmospheres.Count);

            foreach (SavegameAtmosphere atmo in savegame.Atmospheres)
            {
                if(atmo.ThingReferenceId > 0)
                {
                    //Debug.WriteLine(atmo.Position.ToString() + " - " + atmo.Volumen + " -- Is Thingbound");
                    _unusedNodes.Add(atmo);
                    continue;
                }

                if (atmo.NetworkReferenceId > 0)
                {
                    _unusedNodes.Add(atmo);
                    //Debug.WriteLine(atmo.Position.ToString() + " - " + atmo.Volumen + " -- Is Networkbound");
                    continue;
                }

                if (atmo.Volumen != 8000)
                {
                    _unusedNodes.Add(atmo);
                    //Debug.WriteLine(atmo.Position.ToString() + " - " + atmo.Volumen + " -- Is Unknown", ErrorBlinkStyle.AlwaysBlink);
                    continue; 
                }

                foreach(Point3D point in Grids)
                {
                    //Debug.Write(atmo.Position.Multiply(10).ToString() + " - " + point.ToString());

                    if (!atmo.Position.Multiply(10).Equals(point)) {
                        //Debug.WriteLine(" -- Failed");
                        continue; }

                    //Debug.WriteLine(" -- OK");
                    _atmoNodes.Add(atmo);

                    if (_oxygen == -1) { _oxygen = 0; }
                    if (_nitrogen == -1) { _nitrogen = 0; }
                    if (_carbonDioxide == -1) { _carbonDioxide = 0; }
                    if (_volatiles == -1) { _volatiles = 0; }
                    if (_pollutant == -1) { _pollutant = 0; }
                    if (_steam == -1) { _steam = 0; }
                    if (_nitrousOxide == -1) { _nitrousOxide = 0; }
                    if (_liquidOxygen == -1) { _liquidOxygen = 0; }
                    if (_liquidNitrogen == -1) { _liquidNitrogen = 0; }
                    if (_liquidCarbonDioxide == -1) { _liquidCarbonDioxide = 0; }
                    if (_liquidVolatiles == -1) { _liquidVolatiles = 0; }
                    if (_liquidPollutant == -1) { _liquidPollutant = 0; }
                    if (_water == -1) { _water = 0; }
                    if (_liquidNitrousOxide == -1) { _liquidNitrousOxide = 0; }

                    _oxygen = atmo.Oxygen;
                    _nitrogen = atmo.Nitrogen;
                    _carbonDioxide = atmo.CarbonDioxide;
                    _volatiles = atmo.Volatiles;
                    _pollutant = atmo.Pollutant;
                    _steam = atmo.Steam;
                    _nitrousOxide = atmo.NitrousOxide;
                    _liquidOxygen = atmo.LiquidOxygen;
                    _liquidNitrogen = atmo.LiquidNitrogen;
                    _liquidCarbonDioxide = atmo.LiquidCarbonDioxide;
                    _liquidVolatiles = atmo.LiquidVolatiles;
                    _liquidPollutant = atmo.LiquidPollutant;
                    _water = atmo.Water;
                    _liquidNitrousOxide = atmo.LiquidNitrousOxide;

                }

            }

        }

        public List<SavegameAtmosphere> Atmospheres
        {
            get
            {
                if (_atmoNodes == null) { return new List<SavegameAtmosphere>(); }
                return _atmoNodes;
            }
        }

        int _id = -1;
        public int Id
        {
            get
            {
                if(_id != -1) { return _id; }

                XmlNode n = node.SelectSingleNode(".//RoomId");
                if (n == null) return -1;

                _id = int.Parse(n.InnerText);

                return _id;
            }
        }

        List<Point3D> _grids = null;
        public List<Point3D> Grids
        {
            get
            {
                if(_grids != null) { return _grids; }

                XmlNodeList nl = node.SelectNodes(".//Grids//Grid");
                if (nl == null) { return new List<Point3D>(); }

                _grids = new List<Point3D>();
                foreach (XmlNode n in nl)
                {
                    _grids.Add(new Point3D(n));
                }

                return _grids;
            }
        }

        double _volumen = -1;
        public double Volumen
        {
            get
            {
                if(_volumen > -1 ) { return _volumen; }
                _volumen = 0;

                foreach(SavegameAtmosphere atmo in _atmoNodes)
                {
                    _volumen = atmo.Volumen;
                }

                return _volumen;
            }
        }

        public double Temperature
        {
            get
            {
                List<double> temperatures = new List<double>();

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    temperatures.Add(atmo.Temperature);
                }

                if(temperatures.Count == 0) {  return 0; }

                return temperatures.Average();

            }
        }

        public double Pressure
        {
            get
            {
                List<double> pressures = new List<double>();

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    pressures.Add(atmo.Pressure);
                }

                if (pressures.Count == 0) { return 0; }

                return pressures.Average();

            }
        }

        public double TemperatureCelsius
        {
            get
            {
                return Temperature - 273.15;

            }
        }

        double _oxygen = -1;
        public double Oxygen {
            get
            {
                if (_oxygen > -1) { return _oxygen; }
                _oxygen = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _oxygen = atmo.Oxygen;
                }

                return _oxygen;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Oxygen = tmp;
                }
            }
        }

        double _nitrogen = -1;
        public double Nitrogen
        {
            get
            {
                if (_nitrogen > -1) { return _nitrogen; }
                _nitrogen = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _nitrogen = atmo.Nitrogen;
                }

                return _nitrogen;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Nitrogen = tmp;
                }
            }
        }

        double _carbonDioxide = -1;
        public double CarbonDioxide
        {
            get
            {
                if (_carbonDioxide > -1) { return _carbonDioxide; }
                _carbonDioxide = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _carbonDioxide = atmo.CarbonDioxide;
                }

                return _carbonDioxide;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.CarbonDioxide = tmp;
                }
            }
        }

        double _volatiles = -1;
        public double Volatiles
        {
            get
            {
                if (_volatiles > -1) { return _volatiles; }
                _volatiles = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _volatiles = atmo.Volatiles;
                }

                return _volatiles;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Volatiles = tmp;
                }
            }
        }

        double _pollutant = -1;
        public double Pollutant
        {
            get
            {
                if (_pollutant > -1) { return _pollutant; }
                _pollutant = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _pollutant = atmo.Pollutant;
                }

                return _pollutant;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Pollutant = tmp;
                }
            }
        }

        double _steam = -1;
        public double Steam
        {
            get
            {
                if (_steam > -1) { return _steam; }
                _steam = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _steam = atmo.Steam;
                }

                return _steam;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Steam = tmp;
                }
            }
        }

        double _nitrousOxide = -1;
        public double NitrousOxide
        {
            get
            {
                if (_nitrousOxide > -1) { return _nitrousOxide; }
                _nitrousOxide = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _nitrousOxide = atmo.NitrousOxide;
                }

                return _nitrousOxide;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.NitrousOxide = tmp;
                }
            }
        }

        public double GasMole
        {
            get
            {
                return _oxygen + _volatiles + _nitrogen + _carbonDioxide + _pollutant + _steam + _nitrousOxide;
            }
        }

        double _liquidOxygen = -1;
        public double LiquidOxygen
        {
            get
            {
                if (_liquidOxygen > -1) { return _liquidOxygen; }
                _liquidOxygen = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidOxygen = atmo.LiquidOxygen;
                }

                return _liquidOxygen;
            }
        }

        double _liquidNitrogen = -1;
        public double LiquidNitrogen
        {
            get
            {
                if (_liquidNitrogen > -1) { return _liquidNitrogen; }
                _liquidNitrogen = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidNitrogen = atmo.LiquidNitrogen;
                }

                return _liquidNitrogen;
            }
        }

        double _liquidCarbonDioxide = -1;
        public double LiquidCarbonDioxide
        {
            get
            {
                if (_liquidCarbonDioxide > -1) { return _liquidCarbonDioxide; }
                _liquidCarbonDioxide = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidCarbonDioxide = atmo.LiquidCarbonDioxide;
                }

                return _liquidCarbonDioxide;
            }
        }

        double _liquidVolatiles = -1;
        public double LiquidVolatiles
        {
            get
            {
                if (_liquidVolatiles > -1) { return _liquidVolatiles; }
                _liquidVolatiles = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidVolatiles = atmo.LiquidVolatiles;
                }

                return _liquidVolatiles;
            }
        }

        double _liquidPollutant = -1;
        public double LiquidPollutant
        {
            get
            {
                if (_liquidPollutant > -1) { return _liquidPollutant; }
                _liquidPollutant = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidPollutant = atmo.LiquidPollutant;
                }

                return _liquidPollutant;
            }
        }

        double _water = -1;
        public double Water
        {
            get
            {
                if (_water > -1) { return _water; }
                _water = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _water = atmo.Water;
                }

                return _water;
            }
        }

        double _liquidNitrousOxide = -1;
        public double LiquidNitrousOxide
        {
            get
            {
                if (_liquidNitrousOxide > -1) { return _liquidNitrousOxide; }
                _liquidNitrousOxide = 0;

                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidNitrousOxide = atmo.LiquidNitrousOxide;
                }

                return _liquidNitrousOxide;
            }
        }

        public double LiquidMole
        {
            get
            {
                return _liquidOxygen + _liquidVolatiles + _liquidNitrogen + _liquidCarbonDioxide + _liquidPollutant + _water + _liquidNitrousOxide;
            }
        }

        public double LiquidOxygenLitre
        {
            get
            {
                return LiquidOxygen / 33.3;
            }
        }

        public double LiquidNitrogenLitre
        {
            get
            {
                return LiquidNitrogen / 28.7;
            }
        }

        public double LiquidCarbonDioxideLitre
        {
            get
            {
                return LiquidCarbonDioxide / 25;
            }
        }

        public double LiquidVolatilesLitre
        {
            get
            {
                return LiquidVolatiles / 25;
            }
        }

        public double LiquidPollutantLitre
        {
            get
            {
                return LiquidPollutant / 25;
            }
        }

        public double LiquidNitrousOxideLitre
        {
            get
            {
                return LiquidPollutant / 38.5;
            }
        }

        public double WaterLitre
        {
            get
            {
                return Water / 55.6;
            }
        }

        public double OxygenPercent
        {
            get
            {
                if((GasMole + LiquidMole) == 0) return 0;
                return (_oxygen + _liquidOxygen) / (GasMole + LiquidMole);
            }
        }

        public double NitrogenPercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_nitrogen + _liquidNitrogen) / (GasMole + LiquidMole);
            }
        }

        public double CarbonDioxidePercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_carbonDioxide +_liquidCarbonDioxide) / (GasMole + LiquidMole);
            }
        }

        public double VolatilesPercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_volatiles + _liquidVolatiles) / (GasMole + LiquidMole);
            }
        }

        public double PollutantPercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_pollutant + _liquidPollutant) / (GasMole + LiquidMole);
            }
        }

        public double WaterPercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_water + _steam) / (GasMole + LiquidMole);
            }
        }

        public double SteamPercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_water + _steam) / (GasMole + LiquidMole);
            }
        }

        public double NitrousOxidePercent
        {
            get
            {
                if ((GasMole + LiquidMole) == 0) return 0;
                return (_nitrousOxide + _liquidNitrousOxide) / (GasMole + LiquidMole);
            }
        }
    }
}
