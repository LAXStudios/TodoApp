using System.Collections.ObjectModel;

namespace TodoApp.Pages;

public partial class SettingsPage : ContentPage
{

    SettingsPageViewModel viewModel;
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
        this.BindingContext = viewModel;

        saveButton.IsEnabled = false;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        saveButton.IsEnabled = false;

        MainThread.BeginInvokeOnMainThread(async () => await viewModel.LoadSettings());
    }

    private void mySwitch_Toggled(object sender, ToggledEventArgs e)
    {
        saveButton.IsEnabled = true;
    }
}