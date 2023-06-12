using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class DetailsPopUpViewModel : BaseViewModel
    {
        [ObservableProperty]
        HomeWork homeWork;

        public DetailsPopUpViewModel() 
        {
            
        }

        public void Give(HomeWork homeWork)
        {
            HomeWork = homeWork;
        }
    }
}
