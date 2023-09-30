using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.ViewModel
{
    public partial class SettingsPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        bool isDeveloperMode;

        private ISettingsService settingsService;
        public SettingsPageViewModel(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
            //VisualStateManager.GoToState(SaveButton, "Disable");
        }

        [RelayCommand]
        Task Save()
        {
            settingsService.Set<bool>(nameof(IsDeveloperMode), IsDeveloperMode);
            return Task.CompletedTask;
        }

        public async Task LoadSettings()
        {
            IsDeveloperMode = await settingsService.Get<bool>(nameof(IsDeveloperMode), false);
        }
    }
}
