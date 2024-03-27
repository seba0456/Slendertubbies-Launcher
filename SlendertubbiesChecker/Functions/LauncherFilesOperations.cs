using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SlendertubbiesChecker.Functions
{
    internal class LauncherFilesOperations
    {
       
        public static void PlayGame()
        {
            Directory.SetCurrentDirectory(@"Slendertubbies");
            Process.Start("Slendertubbies.exe");
        }

        public static void PlayGameLegacy()
        {
            Directory.SetCurrentDirectory(@"Slendertubbies_Legacy");
            Process.Start("Slendertubbies.exe");
        }

        public static bool DoesFileExists(string sciezkaRelatywna)
        {
            return File.Exists(sciezkaRelatywna);
        }

        internal static string CheckLocalVersion(string FilePatch)
        {
            string z;
            try
            {
                using (TextReader reader = File.OpenText(FilePatch))
                {
                    z = reader.ReadLine();

                }

            }
            catch (Exception)
            {
                z = ("Invalid");
            }
            return z;
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string @default,
                                                  System.Text.StringBuilder retVal, int size, string filePath);

        public static bool bIsLegacyLauncher()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "launcher_config.ini");
            string section = "Settings";
            string key = "bLegacyLauncher";

            if (File.Exists(filePath))
            {
                var value = new System.Text.StringBuilder(255);
                GetPrivateProfileString(section, key, "False", value, value.Capacity, filePath);

                bool boolValue;
                if (!bool.TryParse(value.ToString(), out boolValue))
                {
                    Console.WriteLine("Unable to read value as a bool type.");
                    return false;
                }

                return boolValue;
            }
            else
            {
                Console.WriteLine("launcher_config.ini file does not exist.");
                return false;
            }
        }
    }
}
