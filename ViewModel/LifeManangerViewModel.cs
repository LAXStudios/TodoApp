using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class LifeManangerViewModel : BaseViewModel
    {
        public LifeManangerViewModel() { }

        [RelayCommand]
        async Task ShoopingList()
        {
            await Shell.Current.GoToAsync(nameof(ShoppingListPage));
        }
    }
}
