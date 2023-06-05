using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class NewHomeWorkViewModel : BaseViewModel
    {
        [ObservableProperty]
        DateTime currentDate;

        [ObservableProperty]
        string pageString;

        [ObservableProperty]
        string numberString;

        [ObservableProperty]
        string descriptionString;

        [ObservableProperty]
        string selected;

        private readonly IHomeWorkService _homeWorkService;

        public NewHomeWorkViewModel(IHomeWorkService homeWorkService) 
        {
            currentDate = DateTime.Now.AddDays(1);
            _homeWorkService = homeWorkService;
        }

        [RelayCommand]
        async Task Add()
        {
            if(string.IsNullOrWhiteSpace(Selected) || string.IsNullOrEmpty(Selected))
            {
                var toast = Toast.Make("Kein Fach Gewählt", CommunityToolkit.Maui.Core.ToastDuration.Short, 15);
                await toast.Show();
                return;
            }
            else
            {
                var homeWork = new HomeWork()
                {
                    Subject = Selected,
                    HomeWorkPage = PageString,
                    HomeWorkNumber = NumberString,
                    Description = DescriptionString,
                    HomeWorkDate = CurrentDate.ToString(),
                    IsDone = false,
                };
                await _homeWorkService.Add(homeWork);
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");
        }


    }
}
