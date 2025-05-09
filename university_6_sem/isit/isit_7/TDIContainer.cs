using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.IO;
using isit_7.storage;


namespace isit_7
{
    public class TDIContainer
    {
        public T GetService<T>() where T : class
        {
            return m_provider.GetRequiredService<T>();
        }

        // через двоеточие инициализируется только базовый класс,
        // а не все элементы класса, как в C++
        public TDIContainer()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(
                 new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
            );
            services.AddSingleton<IExamStorage, TExamSQLStorage>();

            m_provider = services.BuildServiceProvider();
        }
        
        protected ServiceProvider m_provider;
    }
}
