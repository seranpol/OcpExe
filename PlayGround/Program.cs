using Microsoft.Extensions.DependencyInjection;
using PlayGround.View;

namespace PlayGround;

internal class Program
{
    static void Main(string[] args)
    {
        // name: genhdi

         var serviceDescriptors = Bootstrap.GetServices();
        var serviceProvider = serviceDescriptors.BuildServiceProvider();

        var main = serviceProvider.GetRequiredService<MainView>();
    }
}


//[RegisterSingle<Singleton>]
//interface IFoo { }

//[RegisterMany<Transient>]
//interface IBar { }

//[RegisterSingle<Transient>]
//interface IBaz { }

//class Foo : IFoo { }

//class Bar : IBar { }


//class Baz : IBaz
//{
//    public Baz()
//    {
            
//    }
//}

//class LifeTime { }

//sealed class Transient : LifeTime { }

//sealed class Scoped : LifeTime { }

//sealed class Singleton : LifeTime { }

//abstract class Register<TlifeTime> : Attribute where TlifeTime : LifeTime
//{ 
//}



//// if multiple implements RegisterSingle it leads to a compile error
//class RegisterSingle<TLifeTime> : Register<TLifeTime> where TLifeTime : LifeTime { }


//class RegisterMany<TLifeTime> : Register<TLifeTime> where TLifeTime : LifeTime { }
