namespace TodoApp.Pages;

public partial class LongTodoCreatePage : ContentPage
{
	public LongTodoCreateViewModel viewModel { get; set; }
	public LongTodoCreatePage(LongTodoCreateViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		this.BindingContext = viewModel;
	}
}