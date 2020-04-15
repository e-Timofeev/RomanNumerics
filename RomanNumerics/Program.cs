using System;

namespace RomanNumerics
{
    class Program
    {        
        /// <summary>
        /// Точка входа.
        /// </summary>
        static void Main()
        {            
            Console.Title = "Перевод римских цифр в арабский эквивалент";
            Console.Write("Введите число в римской системе счисления: ");
            RomanConverter.input = Console.ReadLine().ToUpper();

            try
            {
                if (RomanConverter.CheckInputString(RomanConverter.input))
                    Console.WriteLine(RomanConverter.RomanToInt(RomanConverter.input));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            // задержка экрана
            Console.ReadLine();
        }   
    }
}
