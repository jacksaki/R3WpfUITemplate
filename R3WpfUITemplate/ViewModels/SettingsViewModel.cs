using Livet;
using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Ui.Controls;
using Wpf.Ui.Appearance;
using System.Reflection.Metadata;
using Windows.System.Implementation.FileExplorer;
using System.Diagnostics;
using Windows.Devices.SmartCards;

namespace R3WpfUITemplate.ViewModels
{
    public partial class SettingsViewModel : ViewModel, INavigationAware
    {
        private bool _isInitialized = false;

        public BindableReactiveProperty<string> AppVersion
        {
            get;
        }

        public BindableReactiveProperty<Wpf.Ui.Appearance.ApplicationTheme> CurrentApplicationTheme { get; } 

        public void OnNavigatedTo()
        {
        }

        public void OnNavigatedFrom() { }

        private string GetAssemblyVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
                ?? string.Empty;
        }
        private string GetAssemblyTitle() {
            return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName;
        }
        public string AssemblyTitle
        {
            get;
        }
        public ReactiveCommand<string> ChangeThemeCommand { get; }
        public SettingsViewModel()
        {
            this.AssemblyTitle = GetAssemblyTitle();
            this.AppVersion = new BindableReactiveProperty<string>($"{GetAssemblyTitle()} - {GetAssemblyVersion()}");
            this.CurrentApplicationTheme = new BindableReactiveProperty<ApplicationTheme>(Wpf.Ui.Appearance.ApplicationTheme.Unknown);
            this.CurrentApplicationTheme.Value = Wpf.Ui.Appearance.ApplicationThemeManager.GetAppTheme();
            this.ChangeThemeCommand = new ReactiveCommand<string>();
            this.ChangeThemeCommand.Subscribe<string>((parameter)=>{
                switch (parameter)
                {
                    case "theme_light":
                        if (CurrentApplicationTheme.Value == Wpf.Ui.Appearance.ApplicationTheme.Light)
                        {
                            break;
                        }
                        Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Light);
                        CurrentApplicationTheme.Value = Wpf.Ui.Appearance.ApplicationTheme.Light;
                        break;
                    default:
                        if (CurrentApplicationTheme.Value == Wpf.Ui.Appearance.ApplicationTheme.Dark)
                        {
                            break;
                        }
                        Wpf.Ui.Appearance.ApplicationThemeManager.Apply(Wpf.Ui.Appearance.ApplicationTheme.Dark);
                        CurrentApplicationTheme.Value = Wpf.Ui.Appearance.ApplicationTheme.Dark;
                        break;
                }
            });
        }
    }
}
