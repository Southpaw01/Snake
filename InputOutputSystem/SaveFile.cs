using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputOutputSystem
{
    static public class SaveFile
    {
        static string path = "Settings.txt";

        static public void SaveSettingsToTextFile(string[] line)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < line.Length; i++)
                {
                    sw.WriteLine(line[i]);
                }
            }
        }
    }
}
