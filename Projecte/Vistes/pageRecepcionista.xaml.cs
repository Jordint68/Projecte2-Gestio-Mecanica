using Interficie_Persistencia;
using Models;
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
    /// Lógica de interacción para pageRecepcionista.xaml
    /// </summary>
    public partial class pageRecepcionista : Page
    {
        ICapaPersistencia gBD;
        List<Ticket> tickets;
        List<Linies> linies;

        Ticket ticketSeleccionat;
        Linies liniaSeleccionada;

        public pageRecepcionista()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            gBD = Persistance.get();

            tickets = gBD.GetTickets();

            btnNovaLinia.IsEnabled = false;
            btnEsborrarLinia.IsEnabled = false;
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

            if (ticketSeleccionat != null)
            {
                linies = gBD.GetLinies(ticketSeleccionat.Id);
                dtgLinies.ItemsSource = linies;

                btnEsborrarLinia.IsEnabled = false;
                btnNovaLinia.IsEnabled = true;
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
            if (liniaSeleccionada != null)
            {
                btnEsborrarLinia.IsEnabled = true;
                btnNovaLinia.IsEnabled = true;
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
            recarregarDtg();
        }

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
            btnModificarLinia.IsEnabled = false;
            btnEsborrarLinia.IsEnabled = false;
        }

        private void btnModificarTicket_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationFrame.Navigate(new pageGestioTicket(ticketSeleccionat));
        }

        private void btnModificarLinia_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationFrame.Navigate(new PageGestioLinies(liniaSeleccionada));
        }

        private void btnNovaLinia_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationFrame.Navigate(new PageGestioLinies(ticketSeleccionat));
        }

        private void btnEsborrarLinia_Click(object sender, RoutedEventArgs e)
        {
            // Com s'elimina la linia, el nou preu de la linia és 0.
            gBD.actualitzarPreuTicket(ticketSeleccionat, liniaSeleccionada.Preu, 0);
            gBD.esborrarLinia(liniaSeleccionada.Id);
            recarregarDtg();
        }
        
        private void btnNouTicket_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.NavigationFrame.Navigate(new pageGestioTicket());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
