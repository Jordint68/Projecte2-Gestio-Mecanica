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
    /// Lógica de interacción para pageGestioTicket.xaml
    /// </summary>
    public partial class pageGestioTicket : Page
    {
        ICapaPersistencia gBD;
        List<Client> lClients = new List<Client>(); 


        public pageGestioTicket()
        {
            InitializeComponent();

            gBD = Persistance.get();

            lClients = gBD.getClients();
        }
    }
}
