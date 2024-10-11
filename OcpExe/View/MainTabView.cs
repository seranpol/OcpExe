using OcpExe.Infrastructure;
using OcpExe.View.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace OcpExe.view
{
    [Register<IMainTabView>]
    internal class MainTabView : TabView, IMainTabView
    {
        private readonly MainTabItem[] _tabs;

        public MainTabView(IEnumerable<MainTabItem> tabs)
        {
            this.Height= Dim.Fill();
            this.Width = Dim.Fill();

            _tabs = tabs.ToArray();

            foreach (var tab in _tabs)
            {
                this.AddTab((Tab)tab,false);
            }

            this.SelectedTab = _tabs.First();
        }
    }

    internal interface IMainTabView
    {
    }
}
