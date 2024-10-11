using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OcpExe.Program;

namespace OcpExe.Infrastructure
{
    internal class DependencyInitializer
    {
        public ServiceProvider Initialize()
        {
            var services = new ServiceCollection();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attributes = type.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    Type attributeType = attribute.GetType();

                    // Check if the attribute is a generic type and matches Foo<T>
                    if (attributeType.IsGenericType &&
                        attributeType.GetGenericTypeDefinition() == typeof(Register<>))
                    {

                        services.Add(new ServiceDescriptor(attributeType.GetGenericArguments().Single(), type, ServiceLifetime.Transient));
                    }
                }
            }

            return services.BuildServiceProvider();
        }
    }
    internal class Register : Attribute { }
    internal class Register<TInterface> : Register
    {
        public Register()
        {
            InterfaceType = typeof(TInterface);
        }

        public Type InterfaceType { get; }
    }
}
