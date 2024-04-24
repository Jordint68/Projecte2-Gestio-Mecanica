using Interficie_Persistencia;
using Models;
using Projecte.db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
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
    /// Lógica de interacción para pageGestioTicket.xaml
    /// </summary>
    public partial class pageGestioTicket : Page
    {
        ICapaPersistencia gBD;
        Ticket ticketEditable = new Ticket();
        List<Client> lClients = new List<Client>();
        List<Vehicle> lVehicles = new List<Vehicle>();
        


        public pageGestioTicket()
        {
            InitializeComponent();

            gBD = Persistance.get();

            establirCamps(false);
        }

        public pageGestioTicket(Ticket ticket)
        {
            InitializeComponent();

            gBD = Persistance.get();

            ticketEditable = ticket;

            establirCamps(true);

        }

        private void establirCamps(Boolean editMode)
        {
            lClients = gBD.getClients();
            

            List<String> strClients = new List<String>();
            foreach (Client c in lClients)
            {
                strClients.Add(c.NIF1 + " | " + c.FullName);
            }

            txbPreuFinal.IsReadOnly = true;
            cboClients.ItemsSource = strClients;
            

            cboClients.SelectedValue = ticketEditable.ClientProv;
            cboVehicles.SelectedValue = ticketEditable.Vehicle;
            

            if (editMode)
            {

                cboEstats.ItemsSource = ticketEditable.getEstatsDisponibles();
                lVehicles = gBD.getVehiclesByClient(ticketEditable.ClientProv.NIF1);
                btnAfegirNouTicket.Visibility = Visibility.Collapsed;
                btnDesarCanvis.Visibility = Visibility.Visible;
                cboClients.IsReadOnly = true;
                cboVehicles.IsReadOnly = true;
                List<String> strVehicles = new List<String>();
                foreach (Vehicle v in lVehicles)
                {
                    strVehicles.Add(v.Id + " | " + v.Marca.Model);
                }
                cboVehicles.ItemsSource = strVehicles;

            } else
            {
                cboEstats.ItemsSource = ticketEditable.getEstatsDisponiblesPerCreacio();
                btnEsborrarTicket.Visibility = Visibility.Collapsed;
                btnAfegirNouTicket.Visibility = Visibility.Visible;
                btnDesarCanvis.Visibility = Visibility.Collapsed;
                cboVehicles.IsEnabled = false;
            }
        }


        private void cboClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboVehicles.IsEnabled = true;
            int indClientSeleccionat = cboClients.SelectedIndex;
            lVehicles = gBD.getVehiclesByClient(lClients.ElementAt(indClientSeleccionat).NIF1);


            List<String> strVehicles = new List<String>();
            foreach (Vehicle v in lVehicles)
            {
                strVehicles.Add(v.Id + " | " + v.Marca.Model);
            }

            cboVehicles.ItemsSource = strVehicles;
        }

        // Si el mètode retorna null significa que hi ha algun valor incorrecte
        // i no es pot crear el ticket
        private Ticket recollirDades()
        {   
            int indClientSeleccionat = cboClients.SelectedIndex;
            int indVehicleSeleccionat = cboVehicles.SelectedIndex;
            if (indClientSeleccionat < 0)
            {
                cboClients.Background = new SolidColorBrush(Colors.Salmon);
            }
            if(indVehicleSeleccionat < 0)
            {
                cboVehicles.Background = new SolidColorBrush(Colors.Salmon);
            }

            Client client = lClients.ElementAt(indClientSeleccionat);
            if (client == null)
            {
                cboClients.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }

            Vehicle vehicle = lVehicles.ElementAt(indVehicleSeleccionat);
            if (vehicle == null)
            {
                cboVehicles.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }
            String observacions = txbObservacions.Text.ToString();
            if (observacions == null || observacions.Equals(""))
            {
                txbObservacions.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }
            String estat = (String)cboEstats.SelectedValue;
            if(estat == null || estat.Equals(""))
            {
                estat = "obert";
            }

            DateTime data = DateTime.Now;
            return new Ticket(client, vehicle, observacions, estat, data);
        }

        private void btnAfegirNouTicket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = recollirDades();
            if (ticket != null)
            {
                gBD.afegirNouTicket(ticket);
                tornar();
            }
        }

        private async void btnEsborrarTicket_Click(object sender, RoutedEventArgs e)
        {

            if (await gBD.esborrarTicket(ticketEditable.Id))
            {
                tornar();
            }
        }

        private void btnDesarCanvis_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = recollirDades();
            ticket.Id = ticketEditable.Id;
            if (ticket != null)
            {
                gBD.actualitarTicket(ticket);
                tornar();
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            tornar();
        }

        private void tornar()
        {
            if (MainWindow.NavigationFrame.CanGoBack)
            {
                MainWindow.NavigationFrame.GoBack();
            }
        }
    }
}
