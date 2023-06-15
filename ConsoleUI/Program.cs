using Autofac;
using ConsoleUI.Modules;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule<RepoServiceModule>();

        var container = builder.Build();


        using(var scope = container.BeginLifetimeScope())
        {
            var service = scope.Resolve<Program>();
            
            var service = new
        }
    }
}