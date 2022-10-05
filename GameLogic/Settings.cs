using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public static class Settings
    {
        public static int length { get; set; } = 3;
        public static int x { get; set; } = 30;
        public static int y { get; set; } = 15;
        public static bool speedMode { get; set; } = false;
        public static bool collisionWalls { get; set; } = false;
        public static bool collisionTail { get; set; } = false;

        public static void ApplySettings(string[] line)
        {
            ConvertParametersOfSettingsFromString(line);
        }

        public static void ConvertParametersOfSettingsFromString(string[] line)
        {
            if (line == null)
                return;

            length = Convert.ToInt32(line[0]);
            string[] div = line[1].Split('x');
            x = Convert.ToInt32(div[0]);
            y = Convert.ToInt32(div[1]);

            speedMode = Convert.ToBoolean(line[2]);
            collisionWalls = Convert.ToBoolean(line[3]);
            collisionTail = Convert.ToBoolean(line[4]);
        }

    }
}
