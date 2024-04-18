using Interficie_Persistencia;
using Models;
using MongoDB.Bson;
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
    /// Lógica de interacción para pageMechanic.xaml
    /// </summary>
    public partial class pageMechanic : Page
    {
        ICapaPersistencia gBD;
        List<Ticket> tickets;
        List<Linies> linies;

        Ticket ticketSeleccionat;
        Linies liniaSeleccionada;

        public pageMechanic()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;

        }

        #region propdps 


        public Ticket elsTickets
        {
            get { return (Ticket)GetValue(elsTicketsProperty); }
            set { SetValue(elsTicketsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for elsTickets.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty elsTicketsProperty =
            DependencyProperty.Register("elsTickets", typeof(Ticket), typeof(pageMechanic), new PropertyMetadata(null));



        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gBD = Persistance.get();

            tickets = gBD.GetTicketsByEstat("obert");


            btnNouEstatLinia.IsEnabled = false;
            btnNouEstatTicket.IsEnabled = false;
            cboModificarLinia.IsEnabled = false;
            cboModificarTicket.IsEnabled = false;
            btnModificarLinia.IsEnabled = false;
            btnModificarTicket.IsEnabled = false;

            dtgTickets.ItemsSource = tickets; 
        }

        private void dtgTickets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ticketSeleccionat = (Ticket)dtgTickets.SelectedItem;

            if(ticketSeleccionat != null) {
                linies = gBD.GetLinies(ticketSeleccionat.Id);
                dtgLinies.ItemsSource = linies;

                btnNouEstatLinia.IsEnabled = false;
                btnNouEstatTicket.IsEnabled = true;
                cboModificarLinia.IsEnabled = false;
                cboModificarTicket.IsEnabled = true;
                btnModificarLinia.IsEnabled = false;
                btnModificarTicket.IsEnabled = true;

                cboModificarTicket.ItemsSource = ticketSeleccionat.getEstatsDisponibles();
                cboModificarTicket.SelectedItem = ticketSeleccionat.Estat;
                cboModificarLinia.ItemsSource = null;
            }
            
        }

        private void dtgLinies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            liniaSeleccionada = (Linies)dtgLinies.SelectedItem;
            if(liniaSeleccionada != null)
            {
                btnNouEstatLinia.IsEnabled = true;
                btnNouEstatTicket.IsEnabled = false;
                cboModificarLinia.IsEnabled = true;
                cboModificarTicket.IsEnabled = false;
                btnModificarLinia.IsEnabled = true;
                btnModificarTicket.IsEnabled = false;

                cboModificarLinia.ItemsSource = liniaSeleccionada.getEstatsDisponibles();
                cboModificarLinia.SelectedItem = liniaSeleccionada.Estat;
                cboModificarTicket.ItemsSource = null;
            }

        }

        private void btnNouEstatLinia_Click(object sender, RoutedEventArgs e)
        {
            String newValue = (String)cboModificarLinia.SelectedItem;
            gBD.modificarEstatLinia(liniaSeleccionada.Id, newValue);
            recarregarDtg();        }

        private void btnNouEstatTicket_Click(object sender, RoutedEventArgs e)
        {
            String newValue = (String)cboModificarTicket.SelectedItem;
            gBD.modificarEstatTicket(ticketSeleccionat.Id, newValue);
            recarregarDtg();
        }

        private void recarregarDtg()
        {
            dtgTickets.ItemsSource = null;
            dtgLinies.ItemsSource = null;
            dtgTickets.ItemsSource = gBD.GetTicketsByEstat("obert");
        }

        private void btnModificarTicket_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationFrame.Navigate(new pageGestioTicket());
        }

        private void btnModificarLinia_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
