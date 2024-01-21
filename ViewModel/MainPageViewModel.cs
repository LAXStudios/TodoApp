using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Animations;

namespace TodoApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        List<Todo> todos;

        [ObservableProperty]
        ObservableCollection<Todo> cacheList;

        private readonly ILiteDBService liteDB;

        private readonly ISettingsService settingsService;

        public MainPageViewModel(ILiteDBService liteDB, ISettingsService settingsService)
        {
            Todos = new List<Todo>();
            cacheList = new ObservableCollection<Todo>();
            this.liteDB = liteDB;
            this.settingsService = settingsService;

            Labels = "Pre Alpha | laxstudios";
        }

        [ObservableProperty]
        bool showEntry = false;

        [ObservableProperty]
        string labels;

        [ObservableProperty]
        bool isRefreshing = false;

        [ObservableProperty]
        string titleLabel;

        [ObservableProperty]
        bool isDeveloperMode;

        [ObservableProperty]
        bool isFinishedVisibleBool;

        string title
        {
            get { return Todos.Count() > 1 ? "Todos" : "Todo"; }
        }

        bool isFinishedVisible
        {
            get { return CacheList.Count > 0 ? true : false; }
        }

        public async Task LoadData()
        {
            List<Todo> result = await liteDB.GetAll();
            Todos = result;
            TitleLabel = title;
            IsFinishedVisibleBool = isFinishedVisible;
            IsDeveloperMode = await settingsService.Get<bool>(nameof(IsDeveloperMode), false);
        }

        [RelayCommand]
        public async Task Settings()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }

        [RelayCommand]
        async Task UpdateBool(Todo todo)
        {
            //await liteDB.Update(todo);

            CacheList.Add(todo);
            await liteDB.Delete(todo.Id);

            Labels = nameof(UpdateBoolCommand);
            await LoadData();
        }

        [RelayCommand]
        async Task Delete(Todo todo)
        {
            await liteDB.Delete(todo.Id);
            await LoadData();
        }

        [RelayCommand]
        async Task OnRefresh()
        {
            IsRefreshing = true;
            await LoadData();
            IsRefreshing = false;
        }

        [RelayCommand]
        async Task LongTodoCreate()
        {
            await Shell.Current.GoToAsync(nameof(LongTodoCreatePage));
        }

        [RelayCommand]
        async void AddTodo(Entry input)
        {
            if (input.Text == string.Empty || input.Text == null || input.Text == " ")
            {
                var toast = Toast.Make("No Input", CommunityToolkit.Maui.Core.ToastDuration.Short, 15);
                await toast.Show();
                return;
            }

            var todo = new Todo()
            {
                Title = input.Text,
                IsDone = false
            };
            await liteDB.Save(todo);
            await LoadData();
            input.Text = String.Empty;
        }

        [RelayCommand]
        static void UnFocus(StackLayout stacklayout)
        {
            if (stacklayout.IsFocused == false)
            {
                stacklayout.Focus();
            }
        }

        [RelayCommand]
        Task DeleteCacheList()
        {
            CacheList.Clear();

            return Task.CompletedTask;
        }

        public async Task SaveCollection()
        {
            foreach (var item in Todos)
            {
                await liteDB.Delete(item.Id);
                await liteDB.Save(item);
            }
            await LoadData();
        }
    }
}
