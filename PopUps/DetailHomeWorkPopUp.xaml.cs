namespace TodoApp.PopUps;

public partial class DetailHomeWorkPopUp
{
	DetailsPopUpViewModel viewModel;
	public DetailHomeWorkPopUp(DetailsPopUpViewModel viewModel, HomeWork homeWork)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		viewModel.Give(homeWork);
		this.BindingContext = viewModel;
	}
}