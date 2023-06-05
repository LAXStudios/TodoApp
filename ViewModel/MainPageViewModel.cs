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

namespace TodoApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        List<Todo> todos;

        private readonly ILiteDBService liteDB;

        public MainPageViewModel(ILiteDBService liteDB)
        {
            Todos = new List<Todo>();
            this.liteDB = liteDB;
        }

        [ObservableProperty]
        bool showEntry = false;

        [ObservableProperty]
        string label = "Version: Pre alpha | LAXStudios©";

        [ObservableProperty]
        bool isRefreshing = false;

        public async Task LoadData()
        {
            List<Todo> result = await liteDB.GetAll();
            Todos = result;
        }

        [RelayCommand]
        async Task UpdateBool(Todo todo)
        {
            //todo.IsDone = true;
            await liteDB.Update(todo);
            await LoadData();
        }

        [RelayCommand]
        async Task Delete(Todo todo)
        {
            Label = todo.Title;
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
        public async Task CreateUnderList()
        {
            Label = "Dobble";
        }
    }
}
