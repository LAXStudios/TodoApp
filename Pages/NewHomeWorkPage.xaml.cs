namespace TodoApp.Pages;

public partial class NewHomeWorkPage : ContentPage
{
	NewHomeWorkViewModel viewModel;
	public NewHomeWorkPage(NewHomeWorkViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		this.BindingContext = viewModel;
	}
}