// Convert numbers to text on Macedonian
// Martin Tashkoski - tashkoskim@yahoo.com

using Convert_numbers_2_MKwords;
using System.Globalization;
using System.Text;

string input = string.Empty;
string numberText = string.Empty;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine(">>> Convert numbers to text on Macedonian <<<");
Console.WriteLine("----------------------------------------------");

do
{
    Console.WriteLine("Write a number, or write 'E' for exit and press ENTER!");
    Console.Write("> ");
    input = Console.ReadLine();
    input = input.Replace(',', '.');

    if (long.TryParse(input, out long number))
    {
        numberText = ConvertNumbers.ToTextMK(number);
    }
    else if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalResult) && (input.Contains('.') || input.Contains(',')))
    {
        numberText = ConvertNumbers.DecimalToTextMK(decimalResult);
    }
    else
    {
        numberText = "/";
    }

    Console.WriteLine(numberText);
    Console.WriteLine();
} while (input.ToUpper() != "E");





