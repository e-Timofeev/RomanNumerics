using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerics
{
    public class RomanConverter
    {
        /// <summary>
        /// Входные данные пользователя.
        /// </summary>
        public static string input = string.Empty;

        /// <summary>
        /// Итоговое число в десятичной С.С.
        /// </summary>
        private static int digital = 0;

        /// <summary>
        /// Для предотвращения переполнения стэка.
        /// </summary>
        private const int MAX_RECURSIVE_CALLS = 1000;

        /// <summary>
        /// Счетчик для вызова рукурсивного метода.
        /// </summary>
        private static int count = 0;

        /// <summary>
        /// Словарь основных римских чисел для перевода.
        /// </summary>
        private static Dictionary<int, string> pairs = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 300, "CCC" },
                { 100, "C" },
                { 90 , "XC" },
                { 50 , "L" },
                { 40 , "XL" },
                { 10 , "X" },
                { 9  , "IX" },
                { 5  , "V" },
                { 4  , "IV" },
                { 1  , "I" }
            };

        /// <summary>
        /// Преобразование целого числа в десятичной С.С в непозиционную римскую систему.
        /// </summary>
        /// <param name="s">Строковое представление числа</param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            count++;
            if (count < MAX_RECURSIVE_CALLS)
            {
                if (s != "")
                {
                    foreach (string c in pairs.Values)
                    {
                        if (s.Contains(c) & s.IndexOf(c) == 0)
                        {
                            digital += pairs.FirstOrDefault(v => v.Value == c).Key;
                            s = s.Remove(0, c.Length);
                        }
                    }
                    RomanToInt(s);
                }
                // проверим границы.
                if (digital > 3000)
                    throw new ArgumentOutOfRangeException("\nError: число в римской системе должно быть в диапазоне [1-3000]." +
                        $"\nЗаданное значение {digital} больше максимального MMM (3000).");
            }
            else
            {
                throw new StackOverflowException("\nError: переполнение стэка из-за слишком большего введенного значения.");
            }

            return digital;
        }

        /// <summary>
        /// Проверка введенного значения на корректность требованиям.
        /// </summary>
        /// <param name="s">Проверяемая строка</param>
        /// <returns></returns>
        public static bool CheckInputString(string s)
        {
            // проверим на пустую строку и разделители.
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentException("\nError: указана пустая строка или пробелы.");

            // проверим на наличие посторонних символов.
            foreach (char i in s.ToCharArray())
            {
                if (char.IsNumber(i))
                    throw new ArgumentException("\nError: присутствуют числовые значения.");
                if (char.IsPunctuation(i))
                    throw new ArgumentException("\nError: присутствуют знаки препинания.");
                if (char.IsSymbol(i))
                    throw new ArgumentException("\nError: присутствуют символы.");
                if (i >= 'а' && i <= 'я' || i >= 'А' && i <= 'Я')
                    throw new ArgumentException("\nError: присутствуют русские буквы.");
            }
            // если ошибок нет
            return true;
        }
    }
}
