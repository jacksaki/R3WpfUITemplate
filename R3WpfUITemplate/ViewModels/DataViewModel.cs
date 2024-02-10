using System.Windows.Media;
using Wpf.Ui.Controls;
using R3WpfUITemplate.Models;
using Livet;
using System.Collections.Generic;
using System;
namespace R3WpfUITemplate.ViewModels
{
    public partial class DataViewModel : ViewModel, INavigationAware
    {
        public IEnumerable<DataColor> Colors;
        public void OnNavigatedFrom() { }
        public void OnNavigatedTo()
        {
        }

        public DataViewModel()
        {
            var random = new Random();
            var colorCollection = new List<DataColor>();

            for (int i = 0; i < 8192; i++)
                colorCollection.Add(
                    new DataColor
                    {
                        Color = new SolidColorBrush(
                            Color.FromArgb(
                                (byte)200,
                                (byte)random.Next(0, 250),
                                (byte)random.Next(0, 250),
                                (byte)random.Next(0, 250)
                            )
                        )
                    }
                );
            Colors = colorCollection;
        }
    }
}
