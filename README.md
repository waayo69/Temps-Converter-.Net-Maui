# Temperature Converter App

This is a temperature conversion application built using .NET MAUI. It allows users to convert temperatures between various units, including Celsius, Kelvin, Fahrenheit, Réaumur, and Rankine. The application is structured using the MVVM (Model-View-ViewModel) pattern.

## Features

- **Multi-unit Conversion**: Supports temperature conversion between Celsius, Kelvin, Fahrenheit, Réaumur, and Rankine.
- **Interactive UI**: User-friendly interface to input temperature, select source and target units, and view results.
- **Validation**: Handles invalid inputs with clear error messages.

## Project Structure

### Folders and Files

- `Models/TemperatureConversionModel.cs`:
  Contains static methods to handle temperature conversions from Celsius to other units.

- `ViewModels/TemperatureViewModel.cs`:
  Implements the core logic for temperature conversion, binding properties for the UI, and command execution.

- `MainPage.xaml` and `MainPage.xaml.cs`:
  Defines the user interface and connects it with the `TemperatureViewModel`.

## How to Run the Project

1. **Requirements**:
   - Install [.NET SDK](https://dotnet.microsoft.com/).
   - Install the required development tools for MAUI.

2. **Clone the Repository**:
   ```bash
   git clone <your-repo-url>
   cd TemperatureConverter
   ```

3. **Build and Run**:
   - Open the project in Visual Studio or your preferred IDE.
   - Set up the appropriate platform target (e.g., Android, iOS, Windows).
   - Build and run the project.

## How to Use

1. Launch the application.
2. Enter the temperature value in the input field.
3. Select the source and target units using the dropdown pickers.
4. Tap the **Convert** button to view the result.

## Code Highlights

### TemperatureConversionModel.cs
This file contains the conversion logic:
```csharp
public static double CelsiusToKelvin(double celsius) => celsius + 273.15;
public static double CelsiusToFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
```

### TemperatureViewModel.cs
This file binds the UI with the logic:
```csharp
public ICommand ConvertCommand { get; }
private void ConvertTemperature()
{
    if (double.TryParse(InputTemperature, out double inputTemp))
    {
        double convertedTemp = ConvertTemperature(inputTemp, SelectedSourceUnit, SelectedTargetUnit);
        Result = $"{convertedTemp:F2} {SelectedTargetUnit}";
    }
    else
    {
        Result = "Invalid input. Please enter a numeric value.";
    }
}
```

## Screenshots
![App Screenshot Placeholder](https://via.placeholder.com/400x300)

## Contributing

Feel free to fork this repository and submit pull requests for new features or bug fixes.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

