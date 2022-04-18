using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabelMakerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private PrintPreview printWindow = new PrintPreview();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                this.Title = Properties.Settings.Default.CompanyName;

            }
            catch (Exception ex)
            {
                // do nothing
                Console.WriteLine(ex.ToString());

            }
            if (File.Exists(Properties.Settings.Default.PathToLogoImg))
            {
                try
                {

                    ImageLogo.Source = new BitmapImage(new Uri(Properties.Settings.Default.PathToLogoImg));
                }
                catch (Exception ex)
                {
                    // do nothing
                    Console.WriteLine(ex.ToString());

                }
            }

        }

        private void ButtonPrintPreview_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyInputs())
            {
                DesignPageToPrint(TextBoxSerialNumber.Text);
                printWindow.Show();                
            }
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyInputs())
            {
                int significantFigures = TextBoxSerialNumber.Text.Length;
                int serialNumber = Convert.ToInt32(TextBoxSerialNumber.Text);

                var pd = new PrintDialog();

                PrintDocument printDoc = new PrintDocument();
                
                if (pd.ShowDialog() == true)
                {
                    while (serialNumber > 0)
                    {
                        DesignPageToPrint(serialNumber.ToString("D" + significantFigures.ToString()));

                        pd.PrintVisual(printWindow, "WindowToPrint");
                        serialNumber--;
                    }
                }
            }
        }

        private bool VerifyInputs()
        {
            if (String.IsNullOrWhiteSpace(TextBoxBatchNumber.Text))
                return ShowErrorLabel();
            else if (String.IsNullOrWhiteSpace(TextBoxProductNumber.Text))
                return ShowErrorLabel();
            else if (String.IsNullOrWhiteSpace(TextBoxSerialNumber.Text))
                return ShowErrorLabel();
            else if (String.IsNullOrWhiteSpace(TextBoxProductionDate.Text))
                return ShowErrorLabel();
            else if (String.IsNullOrWhiteSpace(TextBoxExpiryDate.Text))
                return ShowErrorLabel();

            return HideErrorLabel();
        }

        private bool ShowErrorLabel()
        {
            LabelError.Visibility = Visibility.Visible;
            return false;
        }
        
        private bool HideErrorLabel()
        {
            LabelError.Visibility = Visibility.Hidden;
            return true;
        }


        private void DesignPageToPrint(string serialNumber)
        {
            printWindow.LabelBatchSerialNumber.Content = TextBoxBatchNumber.Text + "/" + serialNumber;
            printWindow.LabelExpiryDate.Content = TextBoxExpiryDate.Text;
            printWindow.LabelProductNumber.Content = TextBoxProductNumber.Text;
            printWindow.LabelProductionDate.Content = TextBoxProductionDate.Text;            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            printWindow.canClose = true;
            printWindow.Close();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow(ImageLogo, this);
            sw.Show();
        }
    }
}
