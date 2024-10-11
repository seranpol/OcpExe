using PlayGround.View.Level_1_A;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround.View
{
    internal partial class MainView
    {
        private readonly MainTabView mainTabView;

        public MainView(MainTabView mainTabView)
        {
            this.mainTabView = mainTabView;
        }
    }
}
