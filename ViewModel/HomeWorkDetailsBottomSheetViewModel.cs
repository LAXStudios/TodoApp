using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class HomeWorkDetailsBottomSheetViewModel : BaseViewModel
    {
        [ObservableProperty]
        HomeWork homeWorkClass;



        string ssubject;

        [ObservableProperty]
        string subject;

        public void Give(HomeWork homeWork)
        {
            HomeWorkClass = new();
            HomeWorkClass = homeWork;
            ssubject = homeWork.Subject;
            Subject = ssubject;
        }
    }
}
