using OcpExe.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcpExe.View.Tabs.Network
{
    [Register<MainTabItem>]
    internal class Network : MainTabItem
    {
        public Network()
        {
            Text = "Network";
        }
    }
}
