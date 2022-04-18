using Microsoft.Win32;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace LabelMakerApplication
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Image im;
        MainWindow mw;
        public SettingsWindow()
        {
            InitializeComponent();
            TextBoxCompanyName.Text = Properties.Settings.Default.CompanyName;
            TextBoxPathToLogo.Text = Properties.Settings.Default.PathToLogoImg;
            im = null;
            mw = null;
        }

        public SettingsWindow(Image logoImage, MainWindow main)
        {
            InitializeComponent();
            TextBoxCompanyName.Text = Properties.Settings.Default.CompanyName;
            TextBoxPathToLogo.Text = Properties.Settings.Default.PathToLogoImg;
            im = logoImage;
            mw = main;
        }

        private void ButtonSaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.CompanyName = TextBoxCompanyName.Text;
            Properties.Settings.Default.PathToLogoImg = TextBoxPathToLogo.Text;
            
            try
            {
                im.Source = null;
                im.Source = new BitmapImage(new Uri(TextBoxPathToLogo.Text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                mw.Title = TextBoxCompanyName.Text;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            this.Close();
        }

        private void ButtonCancelSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonFileDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            if (ofp.ShowDialog() == true)
                TextBoxPathToLogo.Text = ofp.FileName;
        }
    }
}
