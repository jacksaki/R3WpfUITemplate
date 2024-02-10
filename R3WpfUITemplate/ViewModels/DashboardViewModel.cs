using Livet;
using R3;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace R3WpfUITemplate.ViewModels
{
    public partial class DashboardViewModel : ViewModel
    {
        public BindableReactiveProperty<int> Counter { get; }
        public ReactiveCommand<Unit> IncrementCommand { get; }
        public DashboardViewModel()
        {
            this.Counter = new BindableReactiveProperty<int>();
            this.Counter.Value = 0;
            this.IncrementCommand = new ReactiveCommand<Unit>();
            this.IncrementCommand.Subscribe(_ =>
            {
                this.Counter.Value ++;
            });
        }
    }
}
