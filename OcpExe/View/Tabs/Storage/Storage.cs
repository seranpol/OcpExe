using OcpExe.Infrastructure;
using OcpExe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace OcpExe.View.Tabs.Storage
{
    [Register<MainTabItem>]
    internal class Storage : MainTabItem
    {
        TextField _textField = new();
        

        public Storage()
        {
            this.Text = "Storage";

            _textField.Width = Dim.Fill();
            _textField.Height = Dim.Fill();

            _textField.Text = "fjdækfjdskjfds";

            this.View = _textField;

            var executer = new CommandExecuter();
            var output = executer.Execute("");
            _textField.Text = output;
        }
    }
}
