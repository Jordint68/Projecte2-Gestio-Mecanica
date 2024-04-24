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
    /// Lógica de interacción para PageGestioLinies.xaml
    /// </summary>
    public partial class PageGestioLinies : Page
    {
        ICapaPersistencia gBD;
        Linies liniaEditable = new Linies();
        List<Serveis> lServeis = new List<Serveis>();

        Ticket ticketPare = new Ticket();

        public PageGestioLinies(Ticket ticket)
        {
            InitializeComponent();

            gBD = Persistance.get();

            ticketPare = ticket;

            establirCamps(false);
        }

        public PageGestioLinies(Linies linia)
        {
            InitializeComponent();

            gBD = Persistance.get();

            liniaEditable = linia;

            establirCamps(true);
        }

        private void establirCamps(Boolean editMode)
        {

            if (editMode)
            {
                btnAfegirNouTicket.Visibility = Visibility.Collapsed;
                btnDesarCanvis.Visibility = Visibility.Visible;
                cboEstats.ItemsSource = liniaEditable.getEstatsDisponibles();
            }
            else
            {
                lServeis = gBD.obtenirServeis();
                List<String> strServeis = new List<String>();
                foreach(Serveis s in lServeis) {
                    strServeis.Add(s.Tipus + " | " + s.Descripcio);
                }
                cboServeis.ItemsSource = strServeis;
                cboServeis.SelectedIndex = 0;
                cboEstats.ItemsSource = liniaEditable.getEstatsDisponiblesPerCreacio();
                btnEsborrarTicket.Visibility = Visibility.Collapsed;
                btnAfegirNouTicket.Visibility = Visibility.Visible;
                btnDesarCanvis.Visibility = Visibility.Collapsed;
            }

            cboEstats.SelectedIndex = 0;
        }

        private Linies recollirDades()
        {
            Serveis servei = lServeis.ElementAt(cboServeis.SelectedIndex);
            if(servei == null)
            {
                cboServeis.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }

            String descripcio = txbDescripcio.Text;
            if(descripcio == null || descripcio.Equals(""))
            {
                txbDescripcio.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }
            String estat = (String)cboEstats.SelectedValue;
            if (estat == null || estat.Equals(""))
            {
                cboEstats.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }

            // Faig la conversió a Decimal per a poder valorar correctament si
            // s'usa un valor vàlid
            String sDescompte = txbDescompte.Text;
            Decimal descompte = 0;
            if (sDescompte == null || sDescompte.Equals(""))
            {
                // Si l'usuari deixa el camp buit s'assumeix un descompte del 0 %
                sDescompte = "0";
            } else
            {
                if(Decimal.TryParse(sDescompte, out descompte))
                {
                    descompte = descompte / 100;

                    if(descompte < 0 || descompte > 1)
                    {
                        // Un percentatge no pot ser mai menor a 0 o major 1 !!!
                        txbDescompte.Background = new SolidColorBrush(Colors.Salmon);
                        return null;
                    }
                } else
                {
                    txbDescompte.Background = new SolidColorBrush(Colors.Salmon);
                    return null;
                }
            }

            // Faig la conversió a Decimal per a poder valorar correctament si
            // s'usa un valor vàlid
            String sPreu = txbPreu.Text;
            Decimal preu = 0;
            if (sPreu == null || sPreu.Equals(""))
            {
                txbPreu.Background = new SolidColorBrush(Colors.Salmon);
                return null;
            }
            else
            {
                if (Decimal.TryParse(sPreu, out preu))
                {
                    // El preu no ha de ser negatiu ni igual a 0.
                    if (preu <= 0)
                    {
                        txbPreu.Background = new SolidColorBrush(Colors.Salmon);
                        return null;
                    }
                }
                else
                {
                    txbPreu.Background = new SolidColorBrush(Colors.Salmon);
                    return null;
                }
            }


            return new Linies(ticketPare.Id, servei.Id, descripcio, preu, estat, descompte, "");
        }

        private void btnAfegirNouTicket_Click(object sender, RoutedEventArgs e)
        {
            Linies linia = recollirDades();
            if (linia != null)
            {
                // Com s'afegeix una linia nova, el preu antic és 0.
                gBD.actualitzarPreuTicket(ticketPare, 0, linia.Preu);
                gBD.afegirNovaLinia(linia);
                tornar();
            }
        }

        private async void btnEsborrarTicket_Click(object sender, RoutedEventArgs e)
        {
            if (await gBD.esborrarTicket(liniaEditable.Id))
            {
                tornar();
            }
        }

        private void btnDesarCanvis_Click(object sender, RoutedEventArgs e)
        {
            Linies linia = recollirDades();
            linia.Id = liniaEditable.Id;
            if (linia != null)
            {
                gBD.actualitzarLinia(linia);
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
