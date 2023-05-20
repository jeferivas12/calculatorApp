
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace calculatorApp.MVVM.Models
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        private string _display;
        private string _subDisplay;

        
        public string Display
        {
            get { return _display; }
            set
            {
                if (_display != value)
                {
                    _display = value;                    
                    OnPropertyChanged();
                }
            }
        }

        public string SubDisplay
        {
            get { return _subDisplay; }
            set
            {
                if (_subDisplay != value)
                {
                    _subDisplay = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
