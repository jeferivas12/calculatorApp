using calculatorApp.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace calculatorApp.MVVM.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
        BindingContext = new CalculatorViewModel();
    }
}