using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_World_Creator
{

    public class Savegames
    {
        private string PathToSavegames { get; set; }
        private List<Savegame> MySavegames { get; set; }

        public Savegames(string path) {
            PathToSavegames = path;
            MySavegames = new List<Savegame>();
        }

        public void LoadSavegames()
        {
            foreach(string save in Directory.GetDirectories(PathToSavegames))
            {
                Savegame sg = new Savegame(save + "\\");
                if (sg.LoadMeta())
                {
                    MySavegames.Add(sg);
                }
            }

            MySavegames.Sort();

        }

        public List<Savegame> Saves
        {
            get
            {
                if (MySavegames != null)
                {
                    return MySavegames;
                }
                return new List<Savegame>();
            }
        }

        public void SaveAll()
        {
            foreach (Savegame sg in MySavegames)
            {
                if (sg.IsChanged)
                {
                    sg.Save();
                }
            }
        }
    }
}
