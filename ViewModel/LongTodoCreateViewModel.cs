using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    [QueryProperty(nameof(TodoTitle), nameof(TodoTitle))]
    public partial class LongTodoCreateViewModel : BaseViewModel
    {
        [ObservableProperty]
        Color currentColor;

        [ObservableProperty]
        bool sc1, sc2, sc3, sc4, sc5 = false;

        [ObservableProperty]
        string title, text;

        [ObservableProperty]
        string todoTitle;

        ILiteDBService liteDBService;

        public LongTodoCreateViewModel(ILiteDBService liteDBService)
        {
            Sc1 = true;
            Text = string.Empty;

            this.liteDBService = liteDBService;
        }

        [RelayCommand]
        async Task SaveNewExtendedTodo()
        {
            var extended = new ExtendedTodoModel { Text = Text };
            var todo = new Todo
            {
                IsExtendedTodo = true,
                Title = Title,
                IsDone = false,
                ExtendedTodo = extended,
            };

            await liteDBService.Save(todo);
            await Shell.Current.GoToAsync(nameof(MainPage));
        }

        [RelayCommand]
        async Task Blue()
        {
            CurrentColor = LongColors.Blue;
            Sc1 = true;
            Sc2 = false;
            Sc3 = false;
            Sc4 = false;
            Sc5 = false;
        }

        [RelayCommand]
        async Task Purple()
        {
            CurrentColor = LongColors.Purple;
            Sc1 = false;
            Sc2 = true;
            Sc3 = false;
            Sc4 = false;
            Sc5 = false;
        }

        [RelayCommand]
        async Task Yellow()
        {
            CurrentColor = LongColors.Yellow;
            Sc1 = false;
            Sc2 = false;
            Sc3 = true;
            Sc4 = false;
            Sc5 = false;
        }

        [RelayCommand]
        async Task Green()
        {
            CurrentColor = LongColors.Green;
            Sc1 = false;
            Sc2 = false;
            Sc3 = false;
            Sc4 = true;
            Sc5 = false;
        }

        [RelayCommand]
        async Task Orange()
        {
            CurrentColor = LongColors.Orange;
            Sc1 = false;
            Sc2 = false;
            Sc3 = false;
            Sc4 = false;
            Sc5 = true;
        }
    }
}
