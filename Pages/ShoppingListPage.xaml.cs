using TodoApp.ViewModel;

namespace TodoApp.Pages;

public partial class ShoppingListPage : ContentPage
{
	private ShoppingListViewModel shoppingList;
	public ShoppingListPage(ShoppingListViewModel shoppingList)
	{
		InitializeComponent();
		this.shoppingList = shoppingList;
		this.BindingContext = shoppingList;
	}
}