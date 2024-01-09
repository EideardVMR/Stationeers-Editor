using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Stationeers_World_Creator
{
    public class Player
    {
        Savegame savegame { get; set; }

        Thing _human {  get; set; }

        Thing _lung { get; set; }

        Thing _brain {  get; set; }

        public Player(Savegame savegame, int id)
        {
            this.savegame = savegame;

            foreach(Thing thing in savegame.Things)
            {
                if(thing.Id == id)
                {
                    _human = thing;
                    continue;
                }
                if(thing.ParentReferenceId == id)
                {
                    if(thing.PrefabName == "OrganLungs")
                    {
                        _lung = thing;
                        continue;
                    }
                    if (thing.PrefabName == "OrganBrain")
                    {
                        _brain = thing;
                        continue;
                    }
                }
            }

        }

        public bool IsLoaded
        {
            get { return _human != null && _lung != null && _brain != null; }
        }

        public Thing Human { get { return _human; } }
        public Thing Lung { get { return _lung; } }
        public Thing Brain { get { return _brain; } }

        public string Name { get { return _human.Name; } }

        public string State {  
            get { return _human.State; } 
            set { _human.State = value; }
        }

        public double Hydration { 
            get { return _human.Hydration / 5; } 
            set { _human.Hydration = value * 5; }
        }

        public double Nutrition { 
            get { return _human.Nutrition / 50; } 
            set { _human.Nutrition = value * 50; }
        }

        public double BruteDamage { 
            get { return _human.BruteDamage / 200; } 
            set { _human.BruteDamage = value * 200; }
        }

        public double HydrationDamage { 
            get { return _human.HydrationDamage / 200; } 
            set { _human.HydrationDamage = value * 200; }
        }

        public double StarvationDamage { 
            get { return _human.StarvationDamage / 200; }
            set { _human.StarvationDamage = value * 200; }
        }

        public double BurnDamage { 
            get { return _lung.BurnDamage / 200; } 
            set { _lung.BurnDamage = value * 200; }
        }

        public double ToxicDamage { 
            get { return _lung.ToxicDamage / 200; }
            set { _lung.ToxicDamage = value * 200; }
        }

        public double StunDamage { 
            get { return _human.StunDamage / 100; } 
            set { // Auf _human und _brain
                _human.StunDamage = value * 100;
                _brain.StunDamage = value * 100;
            } }

        public double OxygenDamage
        {
            get { return _human.OxygenDamage / 100; }
            set
            { // Auf _human und _brain
                _human.OxygenDamage = value * 100;
                _brain.OxygenDamage = value * 100;
            }
        }

    }
}
