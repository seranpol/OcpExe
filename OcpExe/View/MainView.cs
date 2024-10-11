using OcpExe.Infrastructure;
using OcpExe.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace OcpExe.View
{
    [Register<IMainView>]
    internal class MainView : Window, IMainView
    {
        private readonly IMainTabView _mainTabView;

        public MainView(IMainTabView mainTabView)
        {
            Title = "OcpExe";

            _mainTabView = mainTabView;

            var main = (Terminal.Gui.View)_mainTabView;
            main.Width = Dim.Fill();
            Add(main);
        }
    }

    internal interface IMainView
    {
    }
}
