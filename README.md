# NumbersToText
Convert numbers to text on Macedonian
----------------------------------------------

This library 'ConvertNumbers.cs' can convert any long number and decimal number into text on Macedonian language. 
The names of the big numbers greater than 10^6 are used according 'Old European name (Long form') for naming big numbers. 

Some examples:
10^3 = "илјада", 10^6 = "милион", 10^9 = "милијарда", 10^12 = "билион", 10^15 = "билијарда", 10^18 = "трилион", 10^21 = "трилијарда", 10^24 = "квадрилион", 10^7 = "квадрилијарда", ...

There are 2 main methods that can be used:
1. ConvertNumbers.ToTextMK(number) where number can be of type long, or
2. ConvertNumbers.DecimalToTextMK(number) where number can be of type decimal

The challenge part was to modify the words in some cases, because there are many cases on Macedonian where the words change depending which numbers needs to be read.

Some output examples of the application:
201
двесте и еден

201005
двесте и една илјада и пет

202123
двесте и две илјади сто дваесет и три

10000001
десет милиони и еден

121000
сто дваесет и една илјада

123000
сто дваесет и три илјади

-809645
минус осумстотини и девет илјади шестотини четириесет и пет

9223372036854775807
девет трилиони двесте дваесет и три билијарди триста седумдесет и два билиони триесет и шест милијарди осумстотини педесет и четири милиони седумстотини седумдесет и пет илјади осумстотини и седум

1.5
едно цело и пет десеттинки

0.03
три стотинки

50.008
педесет цели и осум илјадинки

602546.00312400201
шестотини и две илјади петстотини четириесет и шест цели и триста и дванаесет милиони четиристотини илјади двесте и една сто-милијардинка
----------------------------------------------

You can freely use the library for our needs if you like it.

You can contact me: tashkoskim@yahoo.com


