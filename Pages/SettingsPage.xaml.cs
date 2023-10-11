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

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MainThread.BeginInvokeOnMainThread(async () => await viewModel.LoadSettings());
    }
}