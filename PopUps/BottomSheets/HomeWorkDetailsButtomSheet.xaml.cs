using System.Globalization;

namespace TodoApp.PopUps.BottomSheets;

public partial class HomeWorkDetailsButtomSheet
{
	HomeWork homeWork;
	public HomeWorkDetailsButtomSheet(HomeWork homeWork)
	{
        InitializeComponent();
        //this.viewmodel = viewmodel;
        this.BindingContext = this;
		this.homeWork = homeWork;

        lblSubject.Text = homeWork.Subject;
		lblDate.Text = homeWork.DisplayDate;
		lblSiteNumber.Text = homeWork.Combine;

        picker.SelectedItem = homeWork.Subject;
        etyPage.Text = homeWork.HomeWorkPage;
		etyNumber.Text = homeWork.HomeWorkNumber;
		etyDescription.Text = homeWork.Description;
		picDate.Date = homeWork.dateTime;

	}

    private async void Save_Clicked(object sender, EventArgs e)
    {
        DateTime dt = new();
        dt = picDate.Date;
        string newCurrentDate = Convert.ToString($"{dt.Day}.{(dt.Month <= 9 ? "0" + dt.Month : dt.Month)}.{dt.Year}");

        IHomeWorkService homeWorkService = new HomeWorkService();
		var newHomeWork = new HomeWork
		{
			Subject = picker.SelectedItem.ToString(),
			HomeWorkPage = etyPage.Text,
			HomeWorkNumber = etyNumber.Text,
			Description = etyDescription.Text,
			DisplayDate = newCurrentDate,
			dateTime = picDate.Date,
		};
		//Naja, geht besser
		await homeWorkService.Delete(homeWork.Id);
		await homeWorkService.Add(newHomeWork);


    }
}