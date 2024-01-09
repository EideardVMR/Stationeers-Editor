using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_World_Creator
{


    public class Network
    {
        Savegame savegame { get; set; }
        int _id { get; set; }

        List<SavegameAtmosphere> _atmospheres {  get; set; }

        public Network(int id, Savegame save) 
        { 
            _id = id;
            savegame = save;
        }

        public int Id
        {
            get { return _id; }
        }

        double _volume = -1;
        public double Volumen
        {
            get
            {
                if(_volume != -1) {  return _volume; }
                _volume = 0;
                LoadAtmosphere();
                foreach(SavegameAtmosphere atmos in _atmospheres)
                {
                    _volume += atmos.Volumen;
                }

                return _volume;
            }
        }

        #region Atmophärendaten
        public List<SavegameAtmosphere> Atmospheres
        {
            get
            {
                if (_atmospheres == null) { return new List<SavegameAtmosphere>(); }
                return _atmospheres;
            }
        }

        public void LoadAtmosphere()
        {

            if (_atmospheres != null) { return; }
            _atmospheres = new List<SavegameAtmosphere>();

            foreach (SavegameAtmosphere atmo in savegame.Atmospheres)
            {

                if (atmo.NetworkReferenceId == _id)
                {

                    _atmospheres.Add(atmo);

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

        public double Temperature
        {
            get
            {
                List<double> temperatures = new List<double>();

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    temperatures.Add(atmo.Temperature);
                }

                if (temperatures.Count == 0) { return 0; }

                return temperatures.Average();

            }
            set
            {
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                }
                else
                {
                    stepsize = ((value * Volumen) / (Settings.GASCONSTANT * Temperature));
                }

                GasMole += stepsize;

                int lastUsedInc = stepsize < 0 ? 1 : 0;
                stepsize = Math.Abs(stepsize);

                while (true)
                {
                    if (Pressure == value)
                    {
                        break;
                    }

                    if (Pressure > value)
                    {
                        if (stepsize > GasMole) { stepsize = GasMole - 0.01; }

                        GasMole -= stepsize;
                        if (lastUsedInc == 1)
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

            foreach (SavegameAtmosphere atmo in _atmospheres)
            {
                atmo.RemoveGas();
            }

            //_molsgas = 0;

            _nitrogen = 0;
            _nitrousOxide = 0;
            _oxygen = 0;
            _pollutant = 0;
            _steam = 0;
            _volatiles = 0;
            _carbonDioxide = 0;
        }

        public double TemperatureCelsius
        {
            get
            {
                return Temperature - 273.15;

            }
        }

        double _oxygen = -1;
        public double Oxygen
        {
            get
            {
                if (_oxygen > -1) { return _oxygen; }
                _oxygen = 0;

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _oxygen += atmo.Oxygen;
                }

                return _oxygen;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.Oxygen = tmp;
                }

                _oxygen = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _nitrogen += atmo.Nitrogen;
                }

                return _nitrogen;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.Nitrogen = tmp;
                }

                _nitrogen = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _carbonDioxide += atmo.CarbonDioxide;
                }

                return _carbonDioxide;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.CarbonDioxide = tmp;
                }

                _carbonDioxide = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _volatiles += atmo.Volatiles;
                }

                return _volatiles;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.Volatiles = tmp;
                }

                _volatiles = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _pollutant += atmo.Pollutant;
                }

                return _pollutant;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.Pollutant = tmp;
                }

                _pollutant = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _steam += atmo.Steam;
                }

                return _steam;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.Steam = tmp;
                }

                _steam = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _nitrousOxide += atmo.NitrousOxide;
                }

                return _nitrousOxide;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.NitrousOxide = tmp;
                }

                _nitrousOxide = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                if (value < 0)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _liquidOxygen += atmo.LiquidOxygen;
                }

                return _liquidOxygen;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.LiquidOxygen = tmp;
                }

                _liquidOxygen = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _liquidNitrogen += atmo.LiquidNitrogen;
                }

                return _liquidNitrogen;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.LiquidNitrogen = tmp;
                }

                _liquidNitrogen = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _liquidCarbonDioxide += atmo.LiquidCarbonDioxide;
                }

                return _liquidCarbonDioxide;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.LiquidCarbonDioxide = tmp;
                }

                _liquidCarbonDioxide = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _liquidVolatiles += atmo.LiquidVolatiles;
                }

                return _liquidVolatiles;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.LiquidVolatiles = tmp;
                }

                _liquidVolatiles = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _liquidPollutant += atmo.LiquidPollutant;
                }

                return _liquidPollutant;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.LiquidPollutant = tmp;
                }

                _liquidPollutant = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _water += atmo.Water;
                }

                return _water;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.Water = tmp;
                }

                _water = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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

                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    _liquidNitrousOxide += atmo.LiquidNitrousOxide;
                }

                return _liquidNitrousOxide;
            }
            set
            {
                double tmp = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    atmo.LiquidNitrousOxide = tmp;
                }

                _liquidNitrousOxide = 0;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.LiquidOxygenLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.LiquidNitrogenLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.LiquidCarbonDioxideLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.LiquidVolatilesLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.LiquidPollutantLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.LiquidNitrousOxideLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
                foreach (SavegameAtmosphere atmo in _atmospheres)
                {
                    litre += atmo.WaterLitre;
                }
                return litre;
            }
            set
            {
                double litre = value / _atmospheres.Count;
                foreach (SavegameAtmosphere atmo in _atmospheres)
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
        #endregion

    }
}
