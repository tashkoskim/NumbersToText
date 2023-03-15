# NumbersToText
## Convert numbers to text on Macedonian

This library **'ConvertNumbers.cs'** can convert any long number and decimal number into text on Macedonian language.   
The names of the big numbers greater than 10^6 are used according **'Old European name (Long form)'** for naming big numbers. You can read more about [names of large numbers](https://simple.wikipedia.org/wiki/Names_of_large_numbers).    

- Some examples of names according this naming convention:
```bigNumbers
10^3 = "илјада", 10^6 = "милион", 10^9 = "милијарда", 10^12 = "билион", 10^15 = "билијарда", 10^18 = "трилион", 10^21 = "трилијарда", 10^24 = "квадрилион", 10^27 = "квадрилијарда", ...  
```

## Main methods
There are 2 main methods that can be used:   
| Methods                          | Input parameter type    | Returns |
| :------------------------------- | :---------------------- | :-------|
| `ConvertNumbers.ToTextMK`        | `long`                  | `string`|
| `ConvertNumbers.DecimalToTextMK` | `decimal`               | `string`|

The challenge part was to modify the words in some cases, because there are many cases on Macedonian where the words change depending which numbers needs to be read.

## Output examples
Example output text for the method `ToTextMK(long n)`:   
```output1
> 201
двесте и еден

> 201005
двесте и една илјада и пет

> 202123
двесте и две илјади сто дваесет и три

> 10000001
десет милиони и еден

> 121000
сто дваесет и една илјада

> 123000
сто дваесет и три илјади

> -809645
минус осумстотини и девет илјади шестотини четириесет и пет

> 9223372036854775807
девет трилиони двесте дваесет и три билијарди триста седумдесет и два билиони триесет и шест милијарди осумстотини педесет и четири милиони седумстотини седумдесет и пет илјади осумстотини и седум
```   
Example output text for the method `DecimalToTextMK(decimal n)`:  
```output1
> 1.5
едно цело и пет десеттинки

> 0.03
три стотинки

> 50.008
педесет цели и осум илјадинки

> 602546.00312400201
шестотини и две илјади петстотини четириесет и шест цели и триста и дванаесет милиони четиристотини илјади двесте и една сто-милијардинка
```
----------------------------------------------

You can freely use the library for your needs if you like it.

You can contact me: tashkoskim@yahoo.com


