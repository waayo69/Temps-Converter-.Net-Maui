using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Converter.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Converter.ViewModels
{
    public class TemperatureViewModel : INotifyPropertyChanged
    {
        // Fields to store temperature input, selected units, and conversion result
        private string _inputTemperature;
        private string _selectedSourceUnit = "Celsius";
        private string _selectedTargetUnit = "Fahrenheit";
        private string _result;

        // Event to notify UI of property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // Constructor initializes command and temperature units list
        public TemperatureViewModel()
        {
            // Command to perform the conversion
            ConvertCommand = new Command(ConvertTemperature);

            // List of available temperature units
            TemperatureUnits = new ObservableCollection<string>
            {
                "Celsius",
                "Kelvin",
                "Fahrenheit",
                "Réaumur",
                "Rankine"
            };
        }

        // Observable collection to hold temperature units for pickers
        public ObservableCollection<string> TemperatureUnits { get; }

        // Input temperature entered by the user
        public string InputTemperature
        {
            get => _inputTemperature;
            set
            {
                if (_inputTemperature != value)
                {
                    _inputTemperature = value;
                    OnPropertyChanged(); // Notify UI of change
                }
            }
        }

        // Selected source temperature unit
        public string SelectedSourceUnit
        {
            get => _selectedSourceUnit;
            set
            {
                if (_selectedSourceUnit != value)
                {
                    _selectedSourceUnit = value;
                    OnPropertyChanged(); // Notify UI of change
                }
            }
        }

        // Selected target temperature unit
        public string SelectedTargetUnit
        {
            get => _selectedTargetUnit;
            set
            {
                if (_selectedTargetUnit != value)
                {
                    _selectedTargetUnit = value;
                    OnPropertyChanged(); // Notify UI of change
                }
            }
        }

        // Result of the temperature conversion
        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(); // Notify UI of change
                }
            }
        }

        // Command bound to the Convert button
        public ICommand ConvertCommand { get; }

        // Method to perform temperature conversion
        private void ConvertTemperature()
        {
            if (double.TryParse(InputTemperature, out double inputTemp))
            {
                // Convert the input temperature using the selected units
                double convertedTemp = ConvertTemperature(inputTemp, SelectedSourceUnit, SelectedTargetUnit);
                // Format and set the result
                Result = $"{convertedTemp:F2} {SelectedTargetUnit}";
            }
            else
            {
                // Handle invalid input
                Result = "Invalid input. Please enter a numeric value.";
            }
        }

        // Helper method to convert temperature between units
        private double ConvertTemperature(double value, string sourceUnit, string targetUnit)
        {
            // Convert source unit to Celsius
            double valueInCelsius = sourceUnit switch
            {
                "Celsius" => value,
                "Kelvin" => value - 273.15,
                "Fahrenheit" => (value - 32) * 5 / 9,
                "Réaumur" => value * 5 / 4,
                "Rankine" => (value - 491.67) * 5 / 9,
                _ => value
            };

            // Convert Celsius to target unit
            return targetUnit switch
            {
                "Celsius" => valueInCelsius,
                "Kelvin" => TemperatureConversionModel.CelsiusToKelvin(valueInCelsius),
                "Fahrenheit" => TemperatureConversionModel.CelsiusToFahrenheit(valueInCelsius),
                "Réaumur" => TemperatureConversionModel.CelsiusToReaumur(valueInCelsius),
                "Rankine" => TemperatureConversionModel.CelsiusToRankine(valueInCelsius),
                _ => valueInCelsius
            };
        }

        // Method to notify the UI of property changes
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
