using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class SavegameAtmosphere
    {
        XmlNode node { get; set; }
        Savegame savegame { get; set; }
        public SavegameAtmosphere(XmlNode node, Savegame save)
        {
            this.node = node;
            this.savegame = save;
        }

        public double GasMols
        {
            get
            {
                return Oxygen + Volatiles + Nitrogen + CarbonDioxide + Pollutant + Steam + NitrousOxide;
            }
        }
        public double LiquidMole
        {
            get
            {
                return LiquidOxygen + LiquidVolatiles + LiquidNitrogen + LiquidCarbonDioxide + LiquidPollutant + Water + LiquidNitrousOxide;
            }
        }
        public double LiquidLitre
        {
            get
            {
                return LiquidOxygenLitre + LiquidVolatilesLitre + LiquidNitrogenLitre + LiquidCarbonDioxideLitre + LiquidPollutantLitre + WaterLitre + LiquidNitrousOxideLitre;
            }
        }

        public double Temperature
        {
            get
            {
                double preEnergy = 0;
                preEnergy += (Oxygen + LiquidOxygen) / 0.047393;
                preEnergy += (Nitrogen + LiquidNitrogen) / 0.048544;
                preEnergy += (CarbonDioxide + LiquidCarbonDioxide) / 0.035461;
                preEnergy += (Volatiles + LiquidVolatiles) / 0.04902;
                preEnergy += (Pollutant + LiquidPollutant) / 0.040323;
                preEnergy += (Steam + Water) / 0.013889;
                preEnergy += (NitrousOxide + LiquidNitrousOxide) / 0.026882;

                if (preEnergy == 0) { return 0; }

                double tmp = Math.Round(Energy / preEnergy, 2);

                return tmp;
            }
            set
            {
                double newEnergy = Energy;
                double stepsize = 1000000;

                value = Math.Round(value, 2);

                if (value == Temperature)
                {
                    return;
                }
                if (value > Temperature)
                {
                    newEnergy += stepsize;
                }
                if (value < Temperature)
                {
                    newEnergy -= stepsize;
                }

                int last_inttype = 1;

                while (true)
                {
                    double preEnergy = 0;
                    preEnergy += (Oxygen + LiquidOxygen) / 0.047393;
                    preEnergy += (Nitrogen + LiquidNitrogen) / 0.048544;
                    preEnergy += (CarbonDioxide + LiquidCarbonDioxide) / 0.035461;
                    preEnergy += (Volatiles + LiquidVolatiles) / 0.04902;
                    preEnergy += (Pollutant + LiquidPollutant) / 0.040323;
                    preEnergy += (Steam + Water) / 0.013889;
                    preEnergy += (NitrousOxide + LiquidNitrousOxide) / 0.026882;

                    double calcTemp = Math.Round(newEnergy / preEnergy, 2);

                    if (calcTemp == value)
                    {
                        Energy = newEnergy;
                        break;
                    }

                    if (calcTemp < value)
                    {
                        newEnergy += stepsize;
                        if (last_inttype == 1)
                        {
                            stepsize /= 2;
                        }
                        last_inttype = 0;
                    }

                    if (calcTemp > value)
                    {
                        newEnergy -= stepsize;
                        if (last_inttype == 0)
                        {
                            stepsize /= 2;
                        }
                        last_inttype = 1;
                    }

                }
            }
        }

        public double TemperatureCelsius
        {
            get
            {
                return Temperature - 273.15;
            }
        }
        public double Pressure
        {
            get
            {
                if (Volumen == 0) return 0;
                return Math.Round((GasMols * Settings.GASCONSTANT * Temperature) / (Volumen - LiquidLitre), 2);
            }
            set
            {
                value = Math.Round((double)value, 2);

                double currentTemp = Temperature;
                double newMols = (value * (Volumen - LiquidLitre)) / (Settings.GASCONSTANT * Temperature);
                double currentMols = GasMols;

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

        public void RemoveGas()
        {
            Oxygen = 0;
            Nitrogen = 0;
            Pollutant = 0;
            Steam = 0;
            CarbonDioxide = 0;
            Volatiles = 0;
            NitrousOxide = 0;
        }

        public void setTempPress(double temp, double press)
        {

            press = Math.Round(press, 2);
            temp = Math.Round(temp, 2);

            double newMols = (press * (Volumen - LiquidLitre)) / (Settings.GASCONSTANT * temp);
            double currentMols = GasMols;

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





            double newEnergy = Energy;
            double stepsize = 1000000;

            if (press == Temperature)
            {
                return;
            }
            if (press > Temperature)
            {
                newEnergy += stepsize;
            }
            if (press < Temperature)
            {
                newEnergy -= stepsize;
            }

            int last_inttype = 1;

            while (true)
            {
                double preEnergy = 0;
                preEnergy += (Oxygen + LiquidOxygen) / 0.047393;
                preEnergy += (Nitrogen + LiquidNitrogen) / 0.048544;
                preEnergy += (CarbonDioxide + LiquidCarbonDioxide) / 0.035461;
                preEnergy += (Volatiles + LiquidVolatiles) / 0.04902;
                preEnergy += (Pollutant + LiquidPollutant) / 0.040323;
                preEnergy += (Steam + Water) / 0.013889;
                preEnergy += (NitrousOxide + LiquidNitrousOxide) / 0.026882;

                double calcTemp = Math.Round(newEnergy / preEnergy, 2);

                if (calcTemp == press)
                {
                    Energy = newEnergy;
                    break;
                }

                if (calcTemp < press)
                {
                    newEnergy += stepsize;
                    if (last_inttype == 1)
                    {
                        stepsize /= 2;
                    }
                    last_inttype = 0;
                }

                if (calcTemp > press)
                {
                    newEnergy -= stepsize;
                    if (last_inttype == 0)
                    {
                        stepsize /= 2;
                    }
                    last_inttype = 1;
                }

            }


        }

        double _volumen = -1;
        public double Volumen
        {
            get
            {
                if (_volumen != -1) { return _volumen; }

                XmlNode n = node.SelectSingleNode(".//Volume");
                if (n == null) { return _volumen = 0; }
                _volumen = double.Parse(n.InnerText.Replace(".", ","));

                return _volumen;
            }
        }

        double _energy = -1;
        public double Energy
        {
            get
            {
                if (_energy != -1) { return _energy; }

                XmlNode n = node.SelectSingleNode(".//Energy");
                if (n == null) { return _energy = 0; }
                _energy = double.Parse(n.InnerText.Replace(".", ","));

                return _energy;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Energy");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_energy != value) { savegame.IsChanged = true; }
                _energy = value;
            }
        }

        double _networkReferenceId = -1;
        public double NetworkReferenceId
        {
            get
            {
                if (_networkReferenceId != -1) { return _networkReferenceId; }

                XmlNode n = node.SelectSingleNode(".//ThingReferenceId");
                if (n == null) { return _networkReferenceId = 0; }
                _networkReferenceId = double.Parse(n.InnerText.Replace(".", ","));

                return _networkReferenceId;
            }
        }

        double _thingReferenceId = -1;
        public double ThingReferenceId
        {
            get
            {
                if (_thingReferenceId != -1) { return _thingReferenceId; }

                XmlNode n = node.SelectSingleNode(".//ThingReferenceId");
                if (n == null) { return _thingReferenceId = 0; }
                _thingReferenceId = double.Parse(n.InnerText.Replace(".", ","));

                return _thingReferenceId;
            }
        }

        Point3D _position = null;
        public Point3D Position
        {
            get
            {
                if (_position != null) { return _position; }

                XmlNode n = node.SelectSingleNode(".//Position");
                if (n == null) { return _position = null; }
                _position = new Point3D(n);

                return _position;
            }
        }


        double _oxygen = -1;
        public double Oxygen
        {
            get
            {
                if (_oxygen != -1) { return _oxygen; }

                XmlNode n = node.SelectSingleNode(".//Oxygen");
                if (n == null) { return _oxygen = 0; }
                _oxygen = double.Parse(n.InnerText.Replace(".", ","));

                return _oxygen;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Oxygen");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_oxygen != value) { savegame.IsChanged = true; }
                _oxygen = value;
            }
        }

        double _nitrogen = -1;
        public double Nitrogen
        {
            get
            {
                if (_nitrogen != -1) { return _nitrogen; }

                XmlNode n = node.SelectSingleNode(".//Nitrogen");
                if (n == null) { return _nitrogen = 0; }
                _nitrogen = double.Parse(n.InnerText.Replace(".", ","));

                return _nitrogen;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Nitrogen");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_nitrogen != value) { savegame.IsChanged = true; }
                _nitrogen = value;
            }
        }

        double _carbonDioxide = -1;
        public double CarbonDioxide
        {
            get
            {
                if (_carbonDioxide != -1) { return _carbonDioxide; }

                XmlNode n = node.SelectSingleNode(".//CarbonDioxide");
                if (n == null) { return _carbonDioxide = 0; }
                _carbonDioxide = double.Parse(n.InnerText.Replace(".", ","));

                return _carbonDioxide;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//CarbonDioxide");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_carbonDioxide != value) { savegame.IsChanged = true; }
                _carbonDioxide = value;
            }
        }

        double _volatiles = -1;
        public double Volatiles
        {
            get
            {
                if (_volatiles != -1) { return _volatiles; }

                XmlNode n = node.SelectSingleNode(".//Volatiles");
                if (n == null) { return _volatiles = 0; }
                _volatiles = double.Parse(n.InnerText.Replace(".", ","));

                return _volatiles;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Volatiles");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_volatiles != value) { savegame.IsChanged = true; }
                _volatiles = value;
            }
        }

        double _pollutant = -1;
        public double Pollutant
        {
            get
            {
                if (_pollutant != -1) { return _pollutant; }

                XmlNode n = node.SelectSingleNode(".//Chlorine");
                if (n == null) { return _pollutant = 0; }
                _pollutant = double.Parse(n.InnerText.Replace(".", ","));

                return _pollutant;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Chlorine");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_pollutant != value) { savegame.IsChanged = true; }
                _pollutant = value;
            }
        }

        double _steam = -1;
        public double Steam
        {
            get
            {
                if (_steam != -1) { return _steam; }

                XmlNode n = node.SelectSingleNode(".//Steam");
                if (n == null) { return _steam = 0; }
                _steam = double.Parse(n.InnerText.Replace(".", ","));
                return _steam;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Steam");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_steam != value) { savegame.IsChanged = true; }
                _steam = value;
            }
        }

        double _nitrousOxide = -1;
        public double NitrousOxide
        {
            get
            {
                if (_nitrousOxide != -1) { return _nitrousOxide; }

                XmlNode n = node.SelectSingleNode(".//NitrousOxide");
                if (n == null) { return _nitrousOxide = 0; }
                _nitrousOxide = double.Parse(n.InnerText.Replace(".", ","));

                return _nitrousOxide;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//NitrousOxide");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_nitrousOxide != value) { savegame.IsChanged = true; }
                _nitrousOxide = value;
            }
        }

        double _liquidOxygen = -1;
        public double LiquidOxygen
        {
            get
            {
                if (_liquidOxygen != -1) { return _liquidOxygen; }

                XmlNode n = node.SelectSingleNode(".//LiquidOxygen");
                if (n == null) { return _liquidOxygen = 0; }
                _liquidOxygen = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidOxygen;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LiquidOxygen");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_liquidOxygen != value) { savegame.IsChanged = true; }
                _liquidOxygen = value;
            }
        }

        double _liquidNitrogen = -1;
        public double LiquidNitrogen
        {
            get
            {
                if (_liquidNitrogen != -1) { return _liquidNitrogen; }

                XmlNode n = node.SelectSingleNode(".//LiquidNitrogen");
                if (n == null) { return _liquidNitrogen = 0; }
                _liquidNitrogen = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidNitrogen;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LiquidNitrogen");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_liquidNitrogen != value) { savegame.IsChanged = true; }
                _liquidNitrogen = value;
            }
        }

        double _liquidCarbonDioxide = -1;
        public double LiquidCarbonDioxide
        {
            get
            {
                if (_liquidCarbonDioxide != -1) { return _liquidCarbonDioxide; }

                XmlNode n = node.SelectSingleNode(".//LiquidCarbonDioxide");
                if (n == null) { return _liquidCarbonDioxide = 0; }
                _liquidCarbonDioxide = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidCarbonDioxide;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LiquidCarbonDioxide");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_liquidCarbonDioxide != value) { savegame.IsChanged = true; }
                _liquidCarbonDioxide = value;
            }
        }

        double _liquidVolatiles = -1;
        public double LiquidVolatiles
        {
            get
            {
                if (_liquidVolatiles != -1) { return _liquidVolatiles; }

                XmlNode n = node.SelectSingleNode(".//LiquidVolatiles");
                if (n == null) { return _liquidVolatiles = 0; }
                _liquidVolatiles = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidVolatiles;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LiquidVolatiles");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_liquidVolatiles != value) { savegame.IsChanged = true; }
                _liquidVolatiles = value;
            }
        }

        double _liquidPollutant = -1;
        public double LiquidPollutant
        {
            get
            {
                if (_liquidPollutant != -1) { return _liquidPollutant; }

                XmlNode n = node.SelectSingleNode(".//LiquidPollutant");
                if (n == null) { return _liquidPollutant = 0; }
                _liquidPollutant = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidPollutant;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LiquidPollutant");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_liquidPollutant != value) { savegame.IsChanged = true; }
                _liquidPollutant = value;
            }
        }

        double _water = -1;
        public double Water
        {
            get
            {
                if (_water != -1) { return _water; }

                XmlNode n = node.SelectSingleNode(".//Water");
                if (n == null) { return _water = 0; }
                _water = double.Parse(n.InnerText.Replace(".", ","));

                return _water;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//Water");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_water != value) { savegame.IsChanged = true; }
                _water = value;
            }
        }

        double _liquidNitrousOxide = -1;
        public double LiquidNitrousOxide
        {
            get
            {
                if (_liquidNitrousOxide != -1) { return _liquidNitrousOxide; }

                XmlNode n = node.SelectSingleNode(".//LiquidNitrousOxide");
                if (n == null) { return _liquidNitrousOxide = 0; }
                _liquidNitrousOxide = double.Parse(n.InnerText.Replace(".", ","));

                return _liquidNitrousOxide;
            }
            set
            {
                XmlNode n = node.SelectSingleNode(".//LiquidNitrousOxide");
                n.InnerText = value.ToString().Replace(",", ".");
                if (_liquidNitrousOxide != value) { savegame.IsChanged = true; }
                _liquidNitrousOxide = value;
            }
        }

        public double LiquidOxygenLitre
        {
            get
            {
                return LiquidOxygen / 33.3;
            }
            set
            {
                LiquidOxygen = value * 33.3;
            }
        }

        public double LiquidNitrogenLitre
        {
            get
            {
                return LiquidNitrogen / 28.7;
            }
            set
            {
                LiquidNitrogen = value * 28.7;
            }
        }

        public double LiquidCarbonDioxideLitre
        {
            get
            {
                return LiquidCarbonDioxide / 25;
            }
            set
            {
                LiquidCarbonDioxide = value * 25;
            }
        }

        public double LiquidVolatilesLitre
        {
            get
            {
                return LiquidVolatiles / 25;
            }
            set
            {
                LiquidVolatiles = value * 25;
            }
        }

        public double LiquidPollutantLitre
        {
            get
            {
                return LiquidPollutant / 25;
            }
            set
            {
                LiquidPollutant = value * 25;
            }
        }

        public double LiquidNitrousOxideLitre
        {
            get
            {
                return LiquidNitrousOxide / 38.5;
            }
            set
            {
                LiquidNitrousOxide = value * 38.5;
            }
        }

        public double WaterLitre
        {
            get
            {
                return Water / 55.6;
            }
            set
            {
                Water = value * 55.6;
            }
        }

    }

}
