using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WindowsFileChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Order> list = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            list = new ObservableCollection<Order>();
            try
            {
                var myList = MainProgram.StartProgram();
                lblInfo.Content = "Połączono z bazą, naciśnij by odświeżyć";
                list = myList.Orders;
                gridComparedOrderList.ItemsSource = list;
                btnConnect.Content = "Odśwież";
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(gridComparedOrderList.ItemsSource);
                view.Filter = FiltrUzytkownika;
            }
            catch
            {
                lblInfo.Content = "Błąd! Nie udało się połączyć z bazą";
            }  
        }
        public void StatusUpdate(string text)
        {
            lblInfo.Content = text;
        }
        private bool FiltrUzytkownika(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((Order)item).OrderNumber.Contains(txtFilter.Text, StringComparison.OrdinalIgnoreCase);
        }
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(gridComparedOrderList.ItemsSource).Refresh();
        }

        private void menuItemHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aplikacja do podglądu stanu plików WH i Ultima dla nadchodzących zleceń.\nAutor - Tomasz Oczkowicz \n2022 v1.1", "O programie");
        }

        private void menuItemFileExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuItemFileSetup_Click(object sender, RoutedEventArgs e)
        {
            PropertiesWindow propertiesWindow = new PropertiesWindow();
            propertiesWindow.ShowDialog();

        }
    }
}
