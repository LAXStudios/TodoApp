namespace TodoApp.PopUps.BottomSheets;

public partial class HomeWorkDetailsButtomSheet : BottomSheet
{
	HomeWorkDetailsBottomSheetViewModel viewmodel;
	public HomeWorkDetailsButtomSheet(HomeWorkDetailsBottomSheetViewModel viewmodel)
	{
		InitializeComponent();
		this.viewmodel = viewmodel;
		this.BindingContext = viewmodel;
	}
}