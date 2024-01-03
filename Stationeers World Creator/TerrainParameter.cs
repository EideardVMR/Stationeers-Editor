using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_World_Creator
{
    public class TerrainParameter
    {
        public string TwoDimensions { get; set; }
        public string Frequency { get; set; }
        public string Amplitude { get; set; }
        public string Size { get; set; }

        public TerrainParameter(string twodim, string freq, string ampl)
        {
            TwoDimensions = twodim;
            Frequency = freq;
            Amplitude = ampl;
        }

        public TerrainParameter(string twodim, string freq, string ampl, string size) {
        
            TwoDimensions = twodim;
            Frequency = freq;
            Amplitude = ampl;
            Size = size;
        }

        public bool Compare(TerrainParameter para)
        {
            return
                para.TwoDimensions == this.TwoDimensions &&
                para.Frequency == this.Frequency &&
                para.Amplitude == this.Amplitude &&
                para.Size == this.Size;
        }
    }
}
