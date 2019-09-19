using global::XDroidFFmpeg.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;

namespace XDroidFFmpeg
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init(Action<HostBuilderContext, IServiceCollection> nativeConfigureServices)
        {
            var systemDir = FileSystem.AppDataDirectory;
            var configFile = "XDroidFFmpeg.appsettings.json";
            ExtractSaveResource(systemDir, configFile);
            var fullConfig = Path.Combine(systemDir, configFile);

            var host = new HostBuilder()
                            .ConfigureHostConfiguration(c =>
                            {
                                c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                                c.AddJsonFile(fullConfig);
                            })
                            .ConfigureServices((c, x) =>
                            {
                                nativeConfigureServices(c, x);
                                ConfigureServices(c, x);
                            })
                            .Build();

            ServiceProvider = host.Services;
        }


        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            if (ctx.HostingEnvironment.IsDevelopment())
            {

            }
        }

        static void ExtractSaveResource(string location, string filename)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFilestream = a.GetManifestResourceStream(filename))
            {
                if (resFilestream != null)
                {
                    var full = Path.Combine(location, filename);

                    using (var stream = File.Create(full))
                    {
                        resFilestream.CopyTo(stream);
                    }

                }
            }


        }
    }
}

