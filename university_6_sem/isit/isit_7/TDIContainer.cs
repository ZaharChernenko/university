using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.IO;
using isit_7.storage;
using System.Runtime.InteropServices;
using System;

namespace isit_7
{
    public class TDContainerVars
    {
        public static readonly string CONF_FILENAME = "appsettings.json";
        public static readonly string CONF_UNIVERSITY_DATABASE = "university";
    }

    public class TDIContainer
    {
        public T GetService<T>() where T : class
        {
            return m_provider.GetRequiredService<T>();
        }

        public TDIContainer()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(TDContainerVars.CONF_FILENAME)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<SqlConnectionProvider>(new SqlConnectionProvider(configuration.GetConnectionString(TDContainerVars.CONF_UNIVERSITY_DATABASE)));
            services.AddSingleton<IUniversityRepository, TSQLUniversityRepository>();

            m_provider = services.BuildServiceProvider();
        }
        
        protected ServiceProvider m_provider;
    }
}
