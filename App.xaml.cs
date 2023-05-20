using calculatorApp.MVVM.Views;

namespace calculatorApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage( new CalculatorView());
	}
}
