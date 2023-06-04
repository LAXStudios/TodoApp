using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
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
}
