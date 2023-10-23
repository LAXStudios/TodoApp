using static System.Net.Mime.MediaTypeNames;

namespace TodoApp.CustomControls;

public partial class NavigationBarControl : Grid
{

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
       propertyName: nameof(Title),
       returnType: typeof(string),
       declaringType: typeof(OutlinedEntryControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set { SetValue(TitleProperty, value); }
    }

    public NavigationBarControl()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}