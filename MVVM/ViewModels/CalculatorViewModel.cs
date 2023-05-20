using calculatorApp.MVVM.Models;
using System.Windows.Input;


namespace calculatorApp.MVVM.ViewModels
{
    public class CalculatorViewModel
    {
        public CalculatorModel Model { get; set; }
        public ICommand NumberButtonCommand { get; set; }
        public ICommand OperationButtonCommand { get; set; }
        public ICommand EqualsButtonCommand { get; set; }
        public ICommand ClearButtonCommand { get; set; }

        

        private double _currentResult;
        public double _lastNumber;
        private string _currentOperator;

        public CalculatorViewModel()
        {
            Model = new CalculatorModel();
            NumberButtonCommand = new Command<string>(HandleNumberButton);
            OperationButtonCommand = new Command<string>(HandleOperationButton);
            EqualsButtonCommand = new Command(HandleEqualsButton);
            ClearButtonCommand = new Command(HandleClearButton);
        }

        private void HandleNumberButton(string number)
        {
            
            Model.Display += number;
            Model.SubDisplay += number;
            
        }

        private void HandleOperationButton(string operation)
        {
            if (!string.IsNullOrEmpty(_currentOperator))
            {
                HandleEqualsButton();
            }

            _currentResult = double.Parse(Model.Display);
            _currentOperator = operation;
            Model.SubDisplay += operation;
            Model.Display = string.Empty;

        }

        private void HandleEqualsButton()
        {
            if (!string.IsNullOrEmpty(Model.Display))
            {
                double secondNumber = double.Parse(Model.Display); 
                double result = PerformOperation(_currentResult, secondNumber, _currentOperator);
                Model.Display = result.ToString();
                _currentResult = result;
                _currentOperator = string.Empty;
            }
        }

        private void HandleClearButton()
        {
            Model.Display = string.Empty;
            Model.SubDisplay = string.Empty;
            _currentResult = 0;
            _currentOperator = string.Empty;
            _lastNumber= 0;
        }

        private double PerformOperation(double firstNumber, double secondNumber, string operation)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                case "%":
                    result = firstNumber % secondNumber;
                    break;
            }
            return result;
        }
    }
}
