using Interficie_Persistencia;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projecte.db
{
    internal class Persistance
    {
        public static ICapaPersistencia get()
        {
            String capa = ConfigurationManager.AppSettings["capa"];
            String url = ConfigurationManager.AppSettings["url"];
            String db = ConfigurationManager.AppSettings["db"];
            String ruta = ConfigurationManager.AppSettings["rutadll"];

            Object[] x = new Object[] { url, db };
            //var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            Assembly library1Assembly = Assembly.LoadFrom(ruta);

            Type? type = library1Assembly.GetType(capa);

            //Type type = Type.GetType(capa);
            return (ICapaPersistencia)(Activator.CreateInstance( type , x ));
        }
    }
}
