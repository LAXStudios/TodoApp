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
            DateTime dt = new();

            string dayString = null;

            dt = CurrentDate;

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayString = "Mo";
                    break;
                case DayOfWeek.Tuesday:
                    dayString = "Di";
                    break;
                case DayOfWeek.Wednesday:
                    dayString = "Mi";
                    break;
                case DayOfWeek.Thursday:
                    dayString = "Do";
                    break;
                case DayOfWeek.Friday:
                    dayString = "Fr";
                    break;
                case DayOfWeek.Saturday:
                    dayString = "Sa";
                    break;
                case DayOfWeek.Sunday:
                    dayString = "So";
                    break;
            }

            string newCurrentDate = Convert.ToString($"Bis {dayString} den: {dt.Day}.{(dt.Month <= 9 ? "0" + dt.Month : dt.Month)}.{dt.Year}");

            if (string.IsNullOrWhiteSpace(Selected) || string.IsNullOrEmpty(Selected))
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
                    DisplayDate = newCurrentDate,
                    dateTime = CurrentDate,
                    IsDone = false,
                };
                await _homeWorkService.Add(homeWork);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
