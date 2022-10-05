namespace InputOutputSystem
{
    public class ReadFile
    {
        public static string path = "Settings.txt";
        public static int n = 5; // Количество параметров

        static public string[] ReadSettingsFromTextFile()
        {
            string[] line = new string[n];

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    for (int i = 0; i < n; i++)
                    {
                        line[i] = sr.ReadLine();
                    }
                }

                return line;
            }
            catch
            {
                return null;
            }
        }
    }
}