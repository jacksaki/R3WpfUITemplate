using Livet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using R3WpfUITemplate.ViewModels;
using R3WpfUITemplate.Views;
using R3WpfUITemplate.Views.Pages;
using R3WpfUITemplate.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R3WpfUITemplate.Models;
using Wpf.Ui;
using System.IO;

namespace R3WpfUITemplate
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

#pragma warning disable CA1416 // プラットフォームの互換性を検証
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<IThemeService, ThemeService>();
            services.AddSingleton<ITaskBarService, TaskBarService>();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<INavigationWindow, MainWindow>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<DashboardPage>();
            services.AddSingleton<DashboardViewModel>();

            services.AddSingleton<DataPage>();
            services.AddSingleton<DataViewModel>();

            services.AddSingleton<SettingsPage>();
            services.AddSingleton<SettingsViewModel>();
        }
#pragma warning restore CA1416 // プラットフォームの互換性を検証


        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetService<MainWindowViewModel>();
            mainWindow.Show();
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
        }

        private System.Diagnostics.Process GetOtherProcess()
        {
            var processes = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            return processes.Where(x => x.Id != System.Diagnostics.Process.GetCurrentProcess().Id).FirstOrDefault();
        }
        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            using (var vm = new ExceptionWindowViewModel(e.Exception, false))
            {
                var window = new Views.ExceptionWindow();
                window.DataContext = vm;
                if (window.ShowDialog() == true)
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    Current.Shutdown(-1);
                    System.Environment.Exit(1);
                }
            }
        }

        //集約エラーハンドラ
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            using (var vm = new ViewModels.ExceptionWindowViewModel((Exception)e.ExceptionObject, false))
            {
                var window = new Views.ExceptionWindow();
                window.DataContext = vm;
                window.ShowDialog();
                Current.Shutdown(-1);
                System.Environment.Exit(1);
            }
        }
    }
}
