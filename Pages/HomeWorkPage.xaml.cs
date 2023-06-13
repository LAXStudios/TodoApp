namespace TodoApp.Pages;

public partial class HomeWorkPage : ContentPage
{
	private HomeWorkViewModel viewModel;
	public HomeWorkPage(HomeWorkViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MainThread.BeginInvokeOnMainThread(async () => await viewModel.LoadData());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        HomeWorkDetailsBottomSheetViewModel vm = new();
        var page = new HomeWorkDetailsButtomSheet(vm);
        page.ShowAsync(Window);
    }
}