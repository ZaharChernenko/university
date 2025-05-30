﻿using isit_7.storage;
using isit_7.stored_procedures;
using isit_7.stored_procedures.isit_7.stored_procedures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows.Forms;

namespace isit_7
{
    public class TDIContainerVars
    {
        public static readonly string CONF_FILENAME = "appsettings.json";
        public static readonly string CONF_UNIVERSITY_DATABASE = "university";
    }

    public class TDIContainer
    {
        public T GetService<T>() where T : class
        {
            return mProvider.GetRequiredService<T>();
        }

        public TDIContainer()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(TDIContainerVars.CONF_FILENAME)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton<SqlConnectionProvider>(new SqlConnectionProvider(configuration.GetConnectionString(TDIContainerVars.CONF_UNIVERSITY_DATABASE)));
            services.AddSingleton<IUniversityRepository, TSQLUniversityRepository>();

            services.AddSingleton<TAddHoursModel, TAddHoursModel>();
            services.AddSingleton<TAddHoursTabPage, TAddHoursTabPage>();
            services.AddSingleton<TAddHoursController, TAddHoursController>();

            services.AddSingleton<TAddCashWhereEqualToModel, TAddCashWhereEqualToModel>();
            services.AddSingleton<TAddCashWhereEqualToTabPage, TAddCashWhereEqualToTabPage>();
            services.AddSingleton<TAddCashWhereEqualToController, TAddCashWhereEqualToController>();

            services.AddSingleton<TAddCashModel, TAddCashModel>();
            services.AddSingleton<TAddCashTabPage, TAddCashTabPage>();
            services.AddSingleton<TAddCashController, TAddCashController>();

            services.AddSingleton<TMathOperationsModel,  TMathOperationsModel>();
            services.AddSingleton<TMathOperationsTabPage, TMathOperationsTabPage>();
            services.AddSingleton<TMathOperationsController, TMathOperationsController>();

            services.AddSingleton<TAddCashWhere5Model, TAddCashWhere5Model>();
            services.AddSingleton<TAddCashWhere5TabPage, TAddCashWhere5TabPage>();
            services.AddSingleton<TAddCashWhere5Controller, TAddCashWhere5Controller>();
            
            services.AddSingleton<TAddCashWhereGreaterModel, TAddCashWhereGreaterModel>();
            services.AddSingleton<TAddCashWhereGreaterTabPage, TAddCashWhereGreaterTabPage>();
            services.AddSingleton<TAddCashWhereGreaterController, TAddCashWhereGreaterController>();

            services.AddSingleton<stored_procedures.TTabPage, stored_procedures.TTabPage>();
            services.AddSingleton<stored_procedures.TControllersAggregator, stored_procedures.TControllersAggregator>();

            services.AddSingleton<TMainForm, TMainForm>();
            services.AddSingleton<TMainControllersAggregator, TMainControllersAggregator>();

            services.AddSingleton<TApplication, TApplication>();
            
            mProvider = services.BuildServiceProvider();
        }
        
        protected ServiceProvider mProvider;
    }
}
