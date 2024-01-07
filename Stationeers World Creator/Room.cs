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
                    _volumen += atmo.Volumen;
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
            set
            {
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Temperature = value;
                }
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
            set
            {
                value = Math.Round(value, 2);

                double stepsize = 0;
                if (Pressure != 0)
                {
                    stepsize = GasMole - ((value * Volumen) / (Settings.GASCONSTANT * Temperature));
                } else
                {
                    stepsize = ((value * Volumen) / (Settings.GASCONSTANT * Temperature));
                }

                GasMole += stepsize;

                int lastUsedInc = stepsize < 0 ? 1 : 0;
                stepsize = Math.Abs(stepsize);

                while (true)
                {
                    if(Pressure == value)
                    {
                        break;
                    }

                    if(Pressure > value)
                    {
                        if(stepsize > GasMole) { stepsize = GasMole - 0.01; }

                        GasMole -= stepsize;
                        if(lastUsedInc == 1)
                        {
                            stepsize /= 2;
                        }
                        lastUsedInc = 0;
                    }

                    if (Pressure < value)
                    {
                        GasMole += stepsize;
                        if (lastUsedInc == 0)
                        {
                            stepsize /= 2;
                        }
                        lastUsedInc = 1;
                    }

                }

            }
        }

        public void RemoveGas()
        {
            
            foreach(SavegameAtmosphere atmo in _atmoNodes)
            {
                atmo.RemoveGas();
            }
            
            _molsgas = 0;

            _nitrogen = 0;
            _nitrousOxide = 0;
            _oxygen = 0;
            _pollutant = 0;
            _steam = 0;
            _volatiles = 0;
            _carbonDioxide = 0;
        }

        public void setTempPress(double temp, double press)
        {
            foreach (SavegameAtmosphere atmo in _atmoNodes)
            {
                atmo.setTempPress(temp, press);
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
                    _oxygen += atmo.Oxygen;
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

                _oxygen = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _oxygen += atmo.Oxygen;
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
                    _nitrogen += atmo.Nitrogen;
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

                _nitrogen = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _nitrogen += atmo.Nitrogen;
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
                    _carbonDioxide += atmo.CarbonDioxide;
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

                _carbonDioxide = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _carbonDioxide += atmo.CarbonDioxide;
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
                    _volatiles += atmo.Volatiles;
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

                _volatiles = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _volatiles += atmo.Volatiles;
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
                    _pollutant += atmo.Pollutant;
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

                _pollutant = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _pollutant += atmo.Pollutant;
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
                    _steam += atmo.Steam;
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

                _steam = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _steam += atmo.Steam;
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
                    _nitrousOxide += atmo.NitrousOxide;
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

                _nitrousOxide = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _nitrousOxide += atmo.NitrousOxide;
                }
            }
        }

        public double GasMole
        {
            get
            {
                return _oxygen + _volatiles + _nitrogen + _carbonDioxide + _pollutant + _steam + _nitrousOxide;
            }
            set
            {
                if(value < 0)
                {
                    return;
                }

                double currentTemp = Temperature;
                double currentMols = GasMole;
                double newMols = value;

                if (currentMols != 0)
                {
                    double percOxygen = Oxygen / currentMols;
                    double percNitrogen = Nitrogen / currentMols;
                    double percVolatiles = Volatiles / currentMols;
                    double percNitrousOxide = NitrousOxide / currentMols;
                    double percSteam = Steam / currentMols;
                    double percCarbonDioxide = CarbonDioxide / currentMols;
                    double percPollutant = Pollutant / currentMols;

                    Oxygen = percOxygen * newMols;
                    Nitrogen = percNitrogen * newMols;
                    Volatiles = percVolatiles * newMols;
                    NitrousOxide = percNitrousOxide * newMols;
                    Steam = percSteam * newMols;
                    CarbonDioxide = percCarbonDioxide * newMols;
                    Pollutant = percPollutant * newMols;

                    Temperature = currentTemp;

                }

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
                    _liquidOxygen += atmo.LiquidOxygen;
                }

                return _liquidOxygen;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidOxygen = tmp;
                }

                _liquidOxygen = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidOxygen += atmo.LiquidOxygen;
                }
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
                    _liquidNitrogen += atmo.LiquidNitrogen;
                }

                return _liquidNitrogen;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidNitrogen = tmp;
                }

                _liquidNitrogen = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidNitrogen += atmo.LiquidNitrogen;
                }
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
                    _liquidCarbonDioxide += atmo.LiquidCarbonDioxide;
                }

                return _liquidCarbonDioxide;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidCarbonDioxide = tmp;
                }

                _liquidCarbonDioxide = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidCarbonDioxide += atmo.LiquidCarbonDioxide;
                }
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
                    _liquidVolatiles += atmo.LiquidVolatiles;
                }

                return _liquidVolatiles;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidVolatiles = tmp;
                }

                _liquidVolatiles = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidVolatiles += atmo.LiquidVolatiles;
                }
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
                    _liquidPollutant += atmo.LiquidPollutant;
                }

                return _liquidPollutant;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidPollutant = tmp;
                }

                _liquidPollutant = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidPollutant += atmo.LiquidPollutant;
                }
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
                    _water += atmo.Water;
                }

                return _water;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.Water = tmp;
                }

                _water = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _water += atmo.Water;
                }
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
                    _liquidNitrousOxide += atmo.LiquidNitrousOxide;
                }

                return _liquidNitrousOxide;
            }
            set
            {
                double tmp = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidNitrousOxide = tmp;
                }

                _liquidNitrousOxide = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    _liquidNitrousOxide += atmo.LiquidNitrousOxide;
                }
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
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.LiquidOxygenLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidOxygenLitre = litre;
                }
            }
        }

        public double LiquidNitrogenLitre
        {
            get
            {
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.LiquidNitrogenLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidNitrogenLitre = litre;
                }
            }
        }

        public double LiquidCarbonDioxideLitre
        {
            get
            {
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.LiquidCarbonDioxideLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidCarbonDioxideLitre = litre;
                }
            }
        }

        public double LiquidVolatilesLitre
        {
            get
            {
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.LiquidVolatilesLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidVolatilesLitre = litre;
                }
            }
        }

        public double LiquidPollutantLitre
        {
            get
            {
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.LiquidPollutantLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidPollutantLitre = litre;
                }
            }
        }

        public double LiquidNitrousOxideLitre
        {
            get
            {
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.LiquidNitrousOxideLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.LiquidNitrousOxideLitre = litre;
                }
            }
        }

        public double WaterLitre
        {
            get
            {
                double litre = 0;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    litre += atmo.WaterLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmoNodes.Count;
                foreach (SavegameAtmosphere atmo in _atmoNodes)
                {
                    atmo.WaterLitre = litre;
                }
            }
        }

        public double OxygenPercent
        {
            get
            {
                return GasMole == 0 ? 0 : _oxygen / GasMole;
            }
        }

        public double NitrogenPercent
        {
            get
            {
                return GasMole == 0 ? 0 : _nitrogen / GasMole;
            }
        }

        public double CarbonDioxidePercent
        {
            get
            {
                return GasMole == 0 ? 0 : _carbonDioxide / GasMole;
            }
        }

        public double VolatilesPercent
        {
            get
            {
                return GasMole == 0 ? 0 : _volatiles / GasMole;
            }
        }

        public double PollutantPercent
        {
            get
            {
                return GasMole == 0 ? 0 : _pollutant / GasMole;
            }
        }

        public double WaterPercent
        {
            get
            {
                return LiquidMole == 0 ? 0 : _water / LiquidMole;
            }
        }

        public double SteamPercent
        {
            get
            {
                return GasMole == 0 ? 0 : _steam / GasMole;
            }
        }

        public double NitrousOxidePercent
        {
            get
            {
                return GasMole == 0 ? 0 : _nitrousOxide / GasMole;
            }
        }
    }
}
