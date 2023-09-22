using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MitsubishiElectric.Widgets.Services;
using MitsubishiElectric.Widgets.Services.Attributes;
using MitsubishiElectric.Widgets.Services.Exceptions;
using MitsubishiElectric.Widgets.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MitsubishiElectric.Widgets.ConsoleClient
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);            

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<WidgetRunner>();
                    services.AddTransient<ICanvas, Canvas>();
                    services.AddTransient<IRenderer, Renderer>();
                    services.AddTransient<IWidgetFactory, WidgetFactory>();
                })                
                .Build();

            var svc = ActivatorUtilities.CreateInstance<WidgetRunner>(host.Services);
            svc.Run();            
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())                
                .AddEnvironmentVariables();
        }
    }
}