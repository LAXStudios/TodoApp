using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isDeveloperMode;

        [ObservableProperty]
        ObservableCollection<string> items = new();

        [ObservableProperty]
        string newItemText;

        private ISettingsService settingsService;
        public SettingsPageViewModel(ISettingsService settingsService)
        {
            this.settingsService = settingsService;

            Items.Add("Mathe");
            Items.Add("Deutsch");
            Items.Add("Englisch");


            //VisualStateManager.GoToState(SaveButton, "Disable");
        }

        [RelayCommand]
        Task Save()
        {
            settingsService.Set<bool>(nameof(IsDeveloperMode), IsDeveloperMode);
            return Task.CompletedTask;
        }

        [RelayCommand]
        Task SaveSubjects()
        {
            // settingsService.Set<List<string>>(nameof(Subjects), Subjects);

            return Task.CompletedTask;
        }

        [RelayCommand]
        async Task AboutPage()
        {
            await Shell.Current.GoToAsync(nameof(AboutPage));
        }

        [RelayCommand]
        Task ToogledDevSwitch()
        {
            if(IsDeveloperMode == true)
            {
                IsDeveloperMode = false;
            }
            else
            {
                IsDeveloperMode = true;
            }

            return Task.CompletedTask;
        }

        public async Task LoadSettings()
        {
            IsDeveloperMode = await settingsService.Get<bool>(nameof(IsDeveloperMode), false);
        }
    }
}