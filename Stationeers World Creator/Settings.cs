using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stationeers_World_Creator
{

    public class Settings
    {
        public const double GASCONSTANT = 8.31446261815324;

        private static Random random = new Random();

        public string stationeers_path {  get; set; }

        public string stationeers_mygames_path {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Stationeers\\";
            }
        }

        public string stationeers_editor_path { 
            get
            {
                return stationeers_mygames_path + "Stationeers Editor\\";
            }
        }

        public string stationeers_saves_path { get; set; }

        public string stationeers_mods_path { get; set; }

        public string SystemID { get; set; }

        public string AllowToSendStatisticsData { get; set; }

        public Settings()
        {
            AllowToSendStatisticsData = "Unknown";
        }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public static string RandomStringMitZahlen(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        public static bool SimilarValue(double val, double target, double deviation)
        {
            double min = target - (target * deviation);
            double max = target + (target * deviation);

            return val >= min && val <= max;
        }

        
    }
}
