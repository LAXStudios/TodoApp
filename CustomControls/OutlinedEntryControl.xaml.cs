using Microsoft.Maui;
using System.Runtime.InteropServices;
using CommunityToolkit.Maui.Core.Platform;

namespace TodoApp.CustomControls;

public partial class OutlinedEntryControl : Grid
{
	public OutlinedEntryControl()
	{
		InitializeComponent();
        //txtEntry.Unfocus();
	}

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
       propertyName: nameof(Text),
       returnType: typeof(string),
       declaringType: typeof(OutlinedEntryControl),
       defaultValue: null,
       defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TitleBackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(TitleBackgroundColor),
        returnType: typeof(Color),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: Microsoft.Maui.Graphics.Colors.Transparent,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty KeyBoardProperty = BindableProperty.Create(
        propertyName: nameof(KeyBoard),
        returnType: typeof(Keyboard),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: Keyboard.Default,
        defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty HasContentProperty = BindableProperty.Create(
        propertyName: nameof(HasContent),
        returnType: typeof(bool),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: false,
        defaultBindingMode: BindingMode.TwoWay);

    public bool HasContent
    {
        get => (bool)GetValue(HasContentProperty);
        set 
        { 
            SetValue(HasContentProperty, value); 
            OnPropertyChanged(nameof(HasContent));
        }
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set { SetValue(TextProperty, value); }
    }

    public Color TitleBackgroundColor
    {
        get => (Color)GetValue(TitleBackgroundColorProperty);
        set { SetValue(TitleBackgroundColorProperty, value); }
    }

    public Keyboard KeyBoard
    {
        get => (Keyboard)GetValue(KeyBoardProperty);
        set { SetValue(KeyBoardProperty, value); }
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
      propertyName: nameof(Placeholder),
      returnType: typeof(string),
      declaringType: typeof(OutlinedEntryControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }

    CancellationTokenSource token = new();

    private async void txtEntry_Focused(object sender, FocusEventArgs e)
    {

        lblPlaceholder.FontSize = 11;
        await lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
    }

    private void txtEntry_Unfocused(object sender, FocusEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Text)  || HasContent)
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(0, -20, 80, easing: Easing.Linear);
        }
        else
        {
            lblPlaceholder.FontSize = 15;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        txtEntry.Focus();
    }
}