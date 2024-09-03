using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();

                // Current directory is Persistence assembly
                // Goes up to ETicaretAPI and combines the path with the given option which directs to Presentation layer
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ETicaretAPI.API"));

                // Add appsettings.json file to config. manager
                configurationManager.AddJsonFile("appsettings.json");

                // Retrieve the connection string from appsettings file
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
