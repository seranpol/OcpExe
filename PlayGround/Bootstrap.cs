using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Bootstrap
    {
        static ServiceCollection _services = new ServiceCollection();

        public static void Register(Type type)
        {
            _services.AddTransient(type, type);
        }

        public static ServiceCollection GetServices() => _services;
    }
}
