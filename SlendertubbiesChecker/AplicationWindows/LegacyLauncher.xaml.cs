using SlendertubbiesChecker.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SlendertubbiesChecker.AplicationWindows
{
    /// <summary>
    /// Interaction logic for Install.xaml
    /// </summary>
    public partial class LegacyLauncher : Window
    {
        public LegacyLauncher()
        {
            InitializeComponent();

            VersionDisplay.Text = "Version " + MiscLauncherFunctionLibrary.GetLauncherVersion();

            if (!LauncherFilesOperations.DoesFileExists("Slendertubbies/Slendertubbies.exe"))
            {
                PlaySteam.Visibility = Visibility.Collapsed;
            }
            if (!LauncherFilesOperations.DoesFileExists("Slendertubbies_Legacy/Slendertubbies.exe"))
            {
                Launch.Visibility = Visibility.Collapsed;
            }
        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            LauncherFilesOperations.PlayGameLegacy();
            System.Windows.Application.Current.Shutdown();
        }

        private void PlaySteam_Click(object sender, RoutedEventArgs e)
        {
            LauncherFilesOperations.PlayGame();
            System.Windows.Application.Current.Shutdown();
        }

        private void Exit_App(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
