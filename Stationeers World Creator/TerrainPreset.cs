using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_World_Creator
{
    public class TerrainPreset
    {
        public string Name { get; set; }

        public List<TerrainParameter> TerrainPresetList;

        public TerrainPreset(string name)
        {
            TerrainPresetList = new List<TerrainParameter>();
            Name = name;
        }

        public void AddParameter(string twodim, string freq, string ampl)
        {
            TerrainPresetList.Add(new TerrainParameter(twodim, freq, ampl));
        }

        public void AddParameter(string twodim, string freq, string ampl, string size)
        {
            TerrainPresetList.Add(new TerrainParameter(twodim, freq, ampl, size));
        }

        public bool Compare(TerrainPreset ps)
        {
            if (TerrainPresetList.Count != ps.TerrainPresetList.Count) return false;

            for (int i = 0; i < TerrainPresetList.Count; i++)
            {
                if (!TerrainPresetList[i].Compare(ps.TerrainPresetList[i])) return false;
            }

            return true;
        }
    }
}
