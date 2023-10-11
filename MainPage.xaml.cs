namespace TodoApp;

public partial class MainPage : ContentPage
{
	private MainPageViewModel mainPageVM;
	public MainPage(MainPageViewModel mainPageViewModel)
	{
		InitializeComponent();
		mainPageVM = mainPageViewModel;
		this.BindingContext = mainPageViewModel;

        this.Appearing += (sender, e) =>
        {
            MainThread.BeginInvokeOnMainThread(async () => await mainPageVM.LoadData());
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MainThread.BeginInvokeOnMainThread(async () => await mainPageVM.LoadData());
    }
}

