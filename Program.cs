using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
namespace sky_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                //.ConfigureServices(services => AddSkyWalkingCore(services))
                .UseStartup<Startup>();

            return builder;
        }

        public static void AddSkyWalkingCore(IServiceCollection services)
        {
            //AddSkyWalkingCore
            var typeName = Assembly.CreateQualifiedName("SkyWalking.Agent.AspNetCore, Culture=neutral, PublicKeyToken=null", "SkyWalking.Agent.AspNetCore.ServiceCollectionExtensions");
            var type = Type.GetType(typeName);
            var method = type.GetMethod("AddSkyWalkingCore", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            method.Invoke(null, new object[] { services });
        }
    }
}
