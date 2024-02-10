using Wpf.Ui.Controls;
using R3WpfUITemplate.ViewModels;
namespace R3WpfUITemplate.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public ViewModels.DashboardViewModel ViewModel { get; }

        public DashboardPage(ViewModels.DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
