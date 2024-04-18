using Interficie_Persistencia;
using MongoDB.Driver.Core.Configuration;
using Persistencia;
using Projecte.Vistes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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

namespace Projecte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ICapaPersistencia IPersistance;
        

        public static Frame NavigationFrame;

        public MainWindow()
        {
            InitializeComponent();

            //Application.Current.MainWindow.WindowState = WindowState.Maximized;

            NavigationFrame = ContentFrame;
            ContentFrame.Navigate(new pageLogin());
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
