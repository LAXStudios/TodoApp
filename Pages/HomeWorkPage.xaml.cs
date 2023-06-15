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
        var collectionView = (Label)sender;
        var item = (HomeWork)collectionView.BindingContext;
        var page = new HomeWorkDetailsButtomSheet(item);
        page.ShowAsync(Window);
    }
}