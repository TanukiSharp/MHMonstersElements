using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MHMonstersElements
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string Path;

        static App()
        {
            Path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }
    }
}
