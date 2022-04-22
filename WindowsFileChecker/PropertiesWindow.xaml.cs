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

namespace WindowsFileChecker
{
    /// <summary>
    /// Interaction logic for PropertiesWindow.xaml
    /// </summary>
    public partial class PropertiesWindow : Window
    {
        public PropertiesWindow()
        {
            InitializeComponent();
            CreateBinding();
        }
        public void CreateBinding()
        {
            WhConfig whConfig = new WhConfig();
            LoadConfigHelper.LoadConfigData(ref whConfig);
            txtBase.Text = whConfig.GetBase();
            txtServer.Text = whConfig.GetServer();
            txtLogin.Text = whConfig.GetUser();
            txtPass.Password = whConfig.GetPass();
            txtWhDir.Text = whConfig.GetWhPath();
            txtUltimaDir.Text = whConfig.GetUltimaPath();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            WhConfig whConfig = new WhConfig(txtServer.Text, txtBase.Text, txtPass.Password, txtLogin.Text, txtWhDir.Text, txtUltimaDir.Text);
            try
            {
                SaveConfigHelper.SaveConfigData(whConfig);
                MessageBox.Show("Dane zapisane prawidłowo","Zapis");
            }
            catch 
            {
                MessageBox.Show("Błąd zapisu - niepoprawne dane lub brak dostępu do scieżki","Zapis");
            }
            Close();
        }
    }
}
