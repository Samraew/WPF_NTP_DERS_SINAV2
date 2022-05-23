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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_NTP_DERS_SINAV2.Views;

namespace WPF_NTP_DERS_SINAV2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Islemler_Click(object sender, RoutedEventArgs e)
        {
            IslemlerPage ısmPage = new IslemlerPage();
            frame_islemler.Navigate(ısmPage);

        }

        private void Button_Musteriler_Click(object sender, RoutedEventArgs e)
        {
            MusterilerPage mstPage = new MusterilerPage();
            frame_islemler.Navigate(mstPage);
        }

        private void Button_Personeller_Click(object sender, RoutedEventArgs e)
        {
            PersonelPage prsPage = new PersonelPage();
            frame_islemler.Navigate(prsPage);
        }

        private void Button_Hizmetler_Click(object sender, RoutedEventArgs e)
        {
            HizmetlerPage hzmPage = new HizmetlerPage();
            frame_islemler.Navigate(hzmPage);
        }
    }
}
