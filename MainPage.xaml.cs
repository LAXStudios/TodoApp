namespace TodoApp;

public partial class MainPage : ContentPage
{
	private MainPageViewModel mainPageVM;
	public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();
		mainPageVM = mainPageViewModel;
		this.BindingContext = mainPageViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MainThread.BeginInvokeOnMainThread(async () => await mainPageVM.LoadData());
    }
}

