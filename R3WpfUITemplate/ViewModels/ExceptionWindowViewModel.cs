using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Livet;
namespace R3WpfUITemplate.ViewModels
{
    public class ExceptionWindowViewModel : ViewModel
    {
        public ExceptionWindowViewModel(Exception ex, bool canContinue) : base()
        {

        }

        public bool CanContinue
        {
            get;
        }
        public Exception Exception
        {
            get;
        }

        public string ErrorText
        {
            get
            {
                if (this.Exception is AggregateException)
                {
                    return string.Join("\r\n\r\n", ((AggregateException)this.Exception).InnerExceptions.Select(x => $"{x.Message}\r\n\r\n{x.StackTrace}"));
                }
                else
                {
                    return $"{this.Exception.Message}\r\n\r\n{this.Exception.StackTrace}";
                }
            }
        }

        public void Continue()
        {
            this.DialogResult = true;
        }
        public void Quit()
        {
            this.DialogResult = false;
        }


        public bool? DialogResult
        {
            get;
            set;
        }
    }
}
