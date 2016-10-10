namespace RiatPracticeNum1
{
    using System.Collections.Generic;

    /// <summary>
    /// Реализация интерфейса сравнивающего 2 строки
    /// </summary>
    public class StringAscendingComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal(x, y);
        }
    }
}
