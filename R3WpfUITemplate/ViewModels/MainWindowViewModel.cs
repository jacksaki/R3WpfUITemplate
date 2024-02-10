using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
using Wpf.Ui;
using Livet;
using R3;
using System.Diagnostics;

namespace R3WpfUITemplate.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public BindableReactiveProperty<string> ApplicationTitle { get; }

        public ObservableCollection<object> NavigationItems { get; } 

        public ObservableCollection<object> NavigationFooter { get; } 
        private string GetAssemblyTitle()
        {
            return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName;
        }
        public MainWindowViewModel(INavigationService navigationService)
        {
            this.ApplicationTitle = new BindableReactiveProperty<string>(GetAssemblyTitle());

            NavigationItems = new ObservableCollection<object>
            {
                new NavigationViewItem()
                {
                    Content = "Home",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                    TargetPageType = typeof(Views.Pages.DashboardPage)
                },
                new NavigationViewItem()
                {
                    Content = "Data",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
                    TargetPageType = typeof(Views.Pages.DataPage)
                }
            };
            RaisePropertyChanged(nameof(NavigationItems));
            NavigationFooter = new ObservableCollection<object>
            {
                new NavigationViewItem()
                {
                    Content = "Settings",
                    Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                    TargetPageType = typeof(Views.Pages.SettingsPage)
                }
            };
            RaisePropertyChanged(nameof(NavigationFooter));
        }
    }
}