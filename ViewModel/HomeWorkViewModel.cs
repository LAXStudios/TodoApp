using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Pages;

namespace TodoApp.ViewModel
{
    public partial class HomeWorkViewModel : BaseViewModel
    {

        private readonly IHomeWorkService _homeWorkService;

        [ObservableProperty]
        List<HomeWork> homeWorkList;
        public HomeWorkViewModel(IHomeWorkService homeWorkService)
        {
            homeWorkList = new List<HomeWork>();
            //HomeWorkList.Add(new HomeWork { HomeWorkPage = "30", HomeWorkNumber = "3", HomeWorkDate = DateTime.Today, Subject = HomeWork.TypeSubject.Math.ToString() });
            _homeWorkService = homeWorkService;
        }

        [RelayCommand]
        async Task Delete(HomeWork homeWork)
        {

        }

        [RelayCommand]
        async Task New()
        {
            await Shell.Current.GoToAsync(nameof(NewHomeWorkPage));
        }

        public async Task LoadData()
        {
            List<HomeWork> resuslt = await _homeWorkService.GetAllHomeWork();
            HomeWorkList = resuslt;
        }
    }
}
