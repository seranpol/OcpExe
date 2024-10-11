using Microsoft.Extensions.DependencyInjection;
using OcpExe.Infrastructure;
using OcpExe.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace OcpExe
{
    internal class BootStrapper : Toplevel
    {
        public BootStrapper()
        {
            var sp = new DependencyInitializer().Initialize();
            var main = sp.GetRequiredService<IMainView>();

            //Application.Run<MainView>();
            Application.Run(((Window)main));

            Application.Shutdown();
        }
    }
}
