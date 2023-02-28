// Link for names of big numbers - different conventions:
// https://simple.wikipedia.org/wiki/Names_of_large_numbers

namespace Convert_numbers_2_MKwords
{
    public static class ConvertNumbers
    {
        private static string[] numbersBasic = { "нула", "еден", "два", "три", "четири", "пет", "шест", "седум", "осум", "девет", "десет", "единаесет", "дванаесет", "тринаесет", "четиринаесет", "петнаесет", "шестнаесет", "седумнаесет", "осумнаесет", "деветнаесет" };
        private static string[] numbers10s = { "", "десет", "дваесет", "триесет", "четириесет", "педесет", "шеесет", "седумдесет", "осумдесет", "деведесет" };
        private static string[] numbers100s = { "", "сто", "двесте", "триста", "четиристотини", "петстотини", "шестотини", "седумстотини", "осумстотини", "деветстотини" };
        // Old European name (Long form) for naming big numbers - 10^3, 10^6, 10^9, 10^12, 10^15, ...
        private static string[] numbersBigger = { "", "илјада", "милион", "милијарда", "билион", "билијарда", "трилион", "трилијарда", "квадрилион", "квадрилијарда", "квинтилион", "квинтилијарда", "секстилион", "секстилијарда", "септилион", "септилијарда", "октилион", "октилијарда", "нонилион", "нонилијарда", "децилион", "децилијарда", "ундецилион", "ундецилијарда", "дуодецилион", "дуодецилијарда", "тредецилион", "тредецилијарда", "кватуордецилион", "кватуордецилијарда", "квиндецилион", "квиндецилијарда" };
        // American name (Short form) for naming big numbers - 10^3, 10^6, 10^9, 10^12, 10^15, ...
        //private static string[] numbersBigger = { "", "илјада", "милион", "билион", "трилион", "квадрилион", "квинтилион", "секстилион", "септилион", "октилион", "нонилион", "децилион", "ундецилион", "дуодецилион", "трејдецилион", "кватуордецилион", "квиндецилион", "сексдецилион", "септемдецилион", "октодецилион", "новемдецилион", "вигинтилион", "унвигинтилион" };

        // Used for the changes that needs to be done in some cases for the number 1 and 2
        private static bool specificChange = false;

        // Convert long numbers to Macedonian text
        public static string ToTextMK(long br)
        {
            string numberText = "";

            if (br >= 0 && br < 20) 
            {
                numberText = numbersBasic[br];
            }
            else if (br >= 10 && br < 100) 
            {
                long baseNo = 10;
                long pom = br / baseNo;
                numberText += numbers10s[pom];
                br %= baseNo;
                if (br > 0)
                    numberText += " и " + ToTextMK(br);
            }
            else if (br >= 100 && br < 1000)
            {
                long baseNo = 100;
                long pom = br / baseNo;
                numberText += numbers100s[pom];
                br %= baseNo;
                if (br > 0)
                {
                    long lastDigit = br % 10;
                    if (br <= 20 || lastDigit == 0)
                        numberText += " и ";
                    else
                        numberText += " ";
                    numberText += ToTextMK(br);
                }
            }
            else if (br >= 1000 && br < 1000000000000000000)
            {
                long baseNo = FindBase(br);
                long pom = br / baseNo;
                int index = GetIndexArray(baseNo);
                string pomBaseNo = numbersBigger[index];

                if (br<(2*baseNo))
                {
                    if (pomBaseNo.Substring(pomBaseNo.Length - 1, 1) == "а")
                    {
                        specificChange = true;
                    }
                    numberText += $"{ToTextMK(pom)} {pomBaseNo}";
                }
                else
                {
                    if(pomBaseNo.Substring(pomBaseNo.Length-1, 1) == "а")
                    {
                        pomBaseNo = pomBaseNo.Substring(0, pomBaseNo.Length - 1) + "и";
                        specificChange = true;
                    }
                    else
                    {
                        long lastDigit = pom % 10;
                        if(lastDigit != 1)
                            pomBaseNo = pomBaseNo + "и";
                    }
                    numberText += $"{ToTextMK(pom)} {pomBaseNo}";
                    
                }

                // Used for the changes that needs to be done in some cases for the number 1 and 2
                if (specificChange)
                {
                    specificChange = false;

                    if((numberText.Contains("еден")) && (numberText.Substring(numberText.Length - 1, 1) == "и"))
                    {
                        numberText = numberText.Substring(0, numberText.Length - 1) + "а";
                    }
                    numberText = numberText.Replace("еден ", "една ");
                    numberText = numberText.Replace("два ", "две ");
                }

                br %= baseNo;
                if (br > 0)
                {
                    long lastDigit = br % 10;
                    if (br <= 20 || lastDigit == 0) 
                        numberText += " и ";
                    else
                        numberText += " ";
                    numberText += ToTextMK(br);
                }
            } 
            // I have done this separately because it was very slow if the baseNo is calculated for bigger numbers
            else if (br >= 1000000000000000000 && br < 2000000000000000000)
            {
                long baseNo = 1000000000000000000; // FindBase(br);
                long pom = br / baseNo;
                numberText += $"{ToTextMK(pom)} {numbersBigger[6]}";
                br %= baseNo;
                if (br > 0)
                {
                    long lastDigit = br % 10;
                    if (br <= 20 || lastDigit == 0)
                        numberText += " и ";
                    else
                        numberText += " ";
                    numberText += ToTextMK(br);
                }
            }
            else if (br >= 2000000000000000000 && br <= 9223372036854775807)
            {
                long baseNo = 1000000000000000000; // FindBase(br);
                long pom = br / baseNo;
                numberText += $"{ToTextMK(pom)} {numbersBigger[6]}и";
                br %= baseNo;
                if (br > 0)
                {
                    long lastDigit = br % 10;
                    if (br <= 20 || lastDigit == 0)
                        numberText += " и ";
                    else
                        numberText += " ";
                    numberText += ToTextMK(br);
                }
            }
            // long can store:  -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807

            if (br < 0)
            {
                numberText = "минус " + ToTextMK(Math.Abs(br));
            }

            return numberText;
        }

        // Convert decimal numbers to Macedonian text
        // Document used for creating the decimal numbers:
        // https://repository.ukim.mk/bitstream/20.500.12188/2055/1/Mathematical%20terminology-on%20the%20names%20of%20fractions%20in%20Macedonian%20language.pdf
        public static string DecimalToTextMK(decimal br)
        {
            string decimalText = "";

            if (br < 0)
            {
                decimalText = "минус ";
                br = Math.Abs(br);
            }

            // Split the decimal number into 2 parts in 'noParts'
            string pomNos = br.ToString();
            pomNos = pomNos.Replace(',', '.');
            string[] noParts = pomNos.Split('.');

            // Find how many zeros the right side of the decimal point has
            long zeros = 1;
            for (int i = 0; i < noParts[1].Length; i++)
            {
                zeros *= 10;
            }

            // Left side of the decimal point
            long wholePart = int.Parse(noParts[0]);
            // Right side of the decinal point
            long decimalPart = int.Parse(noParts[1]);

            // Find the text for the left side (only if it is bigger than 0)
            if(wholePart > 0)
            {
                decimalText += ToTextMK(wholePart);
                
                string specCase1 = decimalText.Substring(decimalText.Length - 3);
                if(specCase1 == "ден")
                {
                    decimalText = decimalText.Substring(0, decimalText.Length - 3) + "дно";
                    decimalText += " цело";
                }
                else if(specCase1 == "два")
                {
                    decimalText = decimalText.Substring(0, decimalText.Length - 3) + "две";
                    decimalText += " цели";
                }else
                {
                    decimalText += " цели";
                }

                decimalText += " и ";
            }

            // Find the text for the right side and add to the previous left text
            decimalText += ToTextMK(decimalPart);

            // This additional text should be modified first and added at the end of the name of the calculated 10s
            string addText = "тинки";
            string specCase2 = decimalText.Substring(decimalText.Length - 3);
            if (specCase2 == "ден")
            {
                decimalText = decimalText.Substring(0, decimalText.Length - 3) + "дна";
                addText = "тинка";
            }
            else if (specCase2 == "два")
            {
                decimalText = decimalText.Substring(0, decimalText.Length - 3) + "две";
            }
            
            if(zeros>=1000)
            {
                addText = addText.TrimStart('т');                 
            }

            // This is special case only for reading the 10s after the decimal point
            string zerosText = ToTextMK(zeros);
            zerosText = zerosText.Replace(' ', '-');
            if(zerosText.Contains("еден-") || zerosText.Contains("една-"))
            {
                zerosText = zerosText.Replace("еден-", "");
                zerosText = zerosText.Replace("една-", "");
            }
            
            if (zerosText.EndsWith('а'))
            {
                zerosText = zerosText.TrimEnd('а');
            }
            decimalText += " " + zerosText + addText;
            decimalText = decimalText.Replace("ии", "и");

            return decimalText;
        }

        // For ex. for the number 13241, this should return 1000
        private static long FindBase(long number)
        {
            long baseNumber = 1;
            while (baseNumber * 1000 <= number)
            {
                baseNumber *= 1000;
            }
            return baseNumber;
        }

        // This index is used only in the array with big numbers
        private static int GetIndexArray(long number)
        {
            int index = 0;
            while (number > 0)
            {
                index++;
                number /= 10;
            }
            return index/3;
        }
    }
}
