namespace TodoApp.Pages;

public partial class LifeManagerPage : ContentPage
{
	private LifeManangerViewModel viewModel;
	public LifeManagerPage(LifeManangerViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		this.BindingContext = viewModel;
	}
}