﻿using System;

namespace ConversionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a whole number");
            string number = Console.ReadLine();
            number = Convert.ToDouble(number).ToString();

            Console.WriteLine("The number in word format is \n{0}" + ConvertToWords(number));
             
            Console.ReadKey();
        }
        
        private static string ConvertToWords(string numb)
        {
            string val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";

            int decimalPlace = numb.IndexOf(".");
            if (decimalPlace > 0)
            {
            wholeNo = numb.Substring(0, decimalPlace);
            points = numb.Substring(decimalPlace + 1);
                if (Convert.ToInt32(points) > 0)
                {
                    andStr = "and";  
                    pointStr = ConvertDecimals(points);
                }
            }
            val = string.Format("{0} {1}{2}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr);

            return val;
        }

        private static string ConvertWholeNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
               
                if (dblAmt > 0)
                {
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;
                    string place = "";
                    switch (numDigits)
                    {
                        case 1:
                            word = ones(Number);
                            isDone = true;
                            break;

                        case 2:
                            word = tens(Number);
                            isDone = true;
                            break;

                        case 3:
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;

                        case 4:
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;

                        case 7:
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;

                        case 10:
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;

                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }
                        
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return word.Trim();
        }

        private static string tens(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static string ones(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = "";
            switch (_Number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static string ConvertDecimals(string number)
        {
            string convertDecimal = "", onlyDigit = "", englishOnes = "";
            for (int i = 0; i < number.Length; i++)
            {
                onlyDigit = number[i].ToString();
                if (onlyDigit.Equals("0"))
                {
                    englishOnes = "Zero";
                }
                else
                {
                    englishOnes = ones(onlyDigit);
                }
                convertDecimal += " " + englishOnes;
            }
            return convertDecimal;
        }
    }
}