using Interficie_Persistencia;
using Persistencia;
using Projecte.db;
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

namespace Projecte.Vistes
{
    /// <summary>
    /// Lógica de interacción para pageLogin.xaml
    /// </summary>
    public partial class pageLogin : Page
    {
        
        public pageLogin()
        {
            InitializeComponent();
            // Application.Current.MainWindow.WindowState = WindowState.Maximized

            txbUsuari.Text = "carlos123";
            txbPassword.Password = "clave123";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String usuari = txbUsuari.Text.ToString();
            String pwd = txbPassword.Password.ToString();

            ICapaPersistencia gBD = Persistance.get();

            short resultValidateUser = gBD.ValidateLogin(usuari, pwd);
            if (resultValidateUser == 1)
            {
                // Si retorna que l'usuari és un mecànic:
                MainWindow.NavigationFrame.Navigate(new pageMechanic());

            } else if(resultValidateUser == 2)
            {
                // Si retorna que l'usuari és un recepcionista:
                MainWindow.NavigationFrame.Navigate(new pageRecepcionista());

            }
            else
            {
                // Si retorna que no hi ha usuari:
                txbUsuari.Background = new SolidColorBrush(Colors.Salmon);
                txbPassword.Background = new SolidColorBrush(Colors.Salmon);
            }
        }
    }
}
