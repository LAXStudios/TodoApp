using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [RelayCommand]
        static void Frame(CheckBox cb)
        {
            if (cb.IsChecked == false)
            {
                cb.IsChecked = true;
            }
            else
            {
                cb.IsChecked = false;
            }
        }
    }
}
