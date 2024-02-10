using Wpf.Ui.Controls;
using R3WpfUITemplate.ViewModels;
namespace R3WpfUITemplate.Views.Pages
{
    public partial class DataPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }
        public DataPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            this.DataContext = viewModel;
            InitializeComponent();
        }
    }
}

