namespace RiatPracticeNum1
{
    using System;
    using System.Collections.Generic;

    public static class StringManipulator
    {
        public delegate int SortSchema(string left, string right);

        /// <summary>
        /// 1) Метод принимает на вход массив строк и интерфейс, позволяющий сравнивать одну строку с другой. На выходе метода массив отсортированных строк. 
        /// Необходимо написать реализацию интерфейса сравнивающего две строки и использовать её в методе.
        /// </summary>
        public static string[] SortStrings(IComparer<string> comparer, params string[] mas)
        {
            Array.Sort(mas, comparer);
            return mas;
        }

        /// <summary>
        /// 2) После этого метод сортировки массива строк изменить так, чтобы он вместо интерфейса принимал Func. 
        /// Использовать новый метод с функой.
        /// </summary>
        public static string[] SortStrings(Func<string, string, int> comparer, params string[] mas)
        {
            for (var i = 0; i < mas.Length; ++i)
            {
                for (var j = i + 1; j < mas.Length; ++j)
                {
                    if (comparer(mas[i], mas[j]) > 0)
                    {
                        Swap(ref mas[i], ref mas[j]);
                    }
                }
            }

            return mas;
        }

        /// <summary>
        /// 3) После этого метод сортировки массива строк изменить так, чтобы он вместо интерфейса принимал делегат. 
        /// Использовать новый метод двумя способами, в первом в качестве делегата отправить метод, во втором делегатом отправить лямбда выражение.
        /// </summary>
        public static string[] SortStrings(SortSchema comparer, params string[] mas)
        {
            for (var i = 0; i < mas.Length; ++i)
            {
                for (var j = i + 1; j < mas.Length; ++j)
                {
                    if (comparer(mas[i], mas[j]) > 0)
                    {
                        Swap(ref mas[i], ref mas[j]);
                    }
                }
            }

            return mas;
        }

        public static void Swap<T>(ref T left, ref T right)
        {
            var buf = left;
            left = right;
            right = buf;
        }
    }
}
