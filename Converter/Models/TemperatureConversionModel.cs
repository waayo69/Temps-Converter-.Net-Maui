using System;

namespace Converter.Models
{
    internal class TemperatureConversionModel
    {
        // Convert Celsius to Kelvin
        public static double CelsiusToKelvin(double celsius) => celsius + 273.15;

        // Convert Celsius to Fahrenheit
        public static double CelsiusToFahrenheit(double celsius) => (celsius * 9 / 5) + 32;

        // Convert Celsius to Réaumur
        public static double CelsiusToReaumur(double celsius) => celsius * 4 / 5;

        // Convert Celsius to Rankine
        public static double CelsiusToRankine(double celsius) => (celsius + 273.15) * 9 / 5;
    }
}
