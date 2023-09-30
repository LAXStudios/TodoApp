namespace TodoApp.CustomControls;

public partial class NavigationBarControl : Grid
{
	public NavigationBarControl()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}