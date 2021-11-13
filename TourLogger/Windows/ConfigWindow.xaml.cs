using System.IO;
using System.Windows;
using Newtonsoft.Json;
using TourLogger.Models;
using TourLogger.Utils;

namespace TourLogger.Windows
{
    public partial class ConfigWindow : Window
    {
        private DataWriter _dw;

        public ConfigWindow()
        {
            InitializeComponent();
            _dw = new DataWriter();

            var config =
                JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText($"./Userdata/config.dat"));

            if (config != null)
            {
                chk_Experimental.IsChecked = config.UsingExperimental;
            }
        }

        private void Chk_Experimental_OnClick(object sender, RoutedEventArgs e)
        {
            if (chk_Experimental.IsChecked == true)
            {
                MessageBox.Show(
                "By enabling the experimental channel, you acknowledge that nothing that comes with it is final and subject to change.\n" +
                            "Not to mention that it could *potentially* bork something. (Actually not, but if it does, then oof.).\n" +
                            "This channel is basically for the very prudent that just can't wait any longer and want to use future features already.",
                "Attention!",
                MessageBoxButton.OK);
            }
        }

        private void bt_Close_Click(object sender, RoutedEventArgs e)
        {
            _dw.WriteConfigFile(chk_Experimental.IsChecked);
            Close();
        }
    }
}