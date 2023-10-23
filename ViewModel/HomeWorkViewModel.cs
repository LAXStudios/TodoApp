using CommunityToolkit.Maui.Converters;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Pages;
using CommunityToolkit.Maui.Views;
using Mopups.Services;
using TodoApp.PopUps;
using TodoApp.Model;
using TodoApp.PopUps.BottomSheets;

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
            _homeWorkService = homeWorkService;
        }

        [RelayCommand]
        async Task Delete(HomeWork homeWork)
        {
            await _homeWorkService.Delete(homeWork.Id);
            await LoadData();
        }

        [RelayCommand]
        async Task New()
        {
            await Shell.Current.GoToAsync(nameof(NewHomeWorkPage));
        }

        [ObservableProperty]
        bool isRefreshing;

        public async Task LoadData()
        {
            List<HomeWork> resuslt = await _homeWorkService.GetAllHomeWork();
            foreach (var item in resuslt)
            {
                string page = string.Empty;
                string number = string.Empty;
                if(item.HomeWorkPage != null && item.HomeWorkNumber != null)
                {
                    page = $"S.{item.HomeWorkPage}";
                    number = $"Nr.{item.HomeWorkNumber}";
                }else
                {
                    item.Combine = item.Description;
                }
                //string page = item.HomeWorkPage == string.Empty ? string.Empty : $"S. {item.HomeWorkPage}";
                //string number = item.HomeWorkNumber == string.Empty ? string.Empty : $"Nr. {item.HomeWorkNumber}";
                if(page != string.Empty)
                {
                    item.Combine = page + " " + number;
                }
                else
                {
                    //item.Combine = item.Description;
                }
            }
            HomeWorkList = resuslt;
        }

        [RelayCommand]
        async Task Refresh()
        {
            IsRefreshing = true;
            await LoadData();
            IsRefreshing = false;
        }

        [RelayCommand]
        Task Details(HomeWork homeWork)
        {
            HomeWorkDetailsBottomSheetViewModel vm = new();
            vm.Give(homeWork);

            return Task.CompletedTask;
        }
    }
}
