namespace RiatPracticeNum1.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /*
    По практике РиАТ
    По заданию нужно сделать следующее. 

    1) Реализовать метод, который принимает на вход массив строк и интерфейс, позволяющий сравнивать одну строку с другой. На выходе метода массив отсортированных строк. 
    Необходимо написать реализацию интерфейса сравнивающего две строки и заиспользовать её в методе. 

    2) После этого метод сортировки массива строк изменить так, чтобы он вместо интерфейса принимал Func. 
    Использовать новый метод с функой. 

    3) После этого метод сортировки массива строк изменить так, чтобы он вместо интерфейса принимал делегат. 
    Использовать новый метод двумя способами, в первом в качестве делегата отправить метод, во втором делегатом отправить лямбда выражение. 
    */

    [TestClass]
    public class UnitTest1
    {
        private readonly string[] _masUnsorted = { "z_ImLast", "a_ImFirst", "middleElement" };

        [TestMethod]
        public void SortStringsViaInterface()
        {
            var masResult = StringManipulator.SortStrings(new StringAscendingComparer(), _masUnsorted);
            
            var masExpected = _masUnsorted.OrderBy(x => x);
            Assert.IsTrue(masExpected.SequenceEqual(masResult), "Строки отсиротированы не корректно");
        }

        [TestMethod]
        public void SortStringsViaFunc()
        {
            var comparer = new Func<string, string, int>((x, y) => string.CompareOrdinal(x, y));

            var masResult = StringManipulator.SortStrings(comparer, _masUnsorted);

            var masExpected = _masUnsorted.OrderBy(x => x);
            Assert.IsTrue(masExpected.SequenceEqual(masResult), "Строки отсиротированы не корректно");
        }

        [TestMethod]
        public void SortStringsViaDelegate()
        {
            var comparer = new StringManipulator.SortSchema(delegate (string x, string y)
            {
                return string.CompareOrdinal(x, y);
            });

            var masResult = StringManipulator.SortStrings(comparer, _masUnsorted);

            var masExpected = _masUnsorted.OrderBy(x => x);
            Assert.IsTrue(masExpected.SequenceEqual(masResult), "Строки отсиротированы не корректно");
        }

        [TestMethod]
        public void SortStringsViaLamda()
        {
            var masResult = StringManipulator.SortStrings(new StringManipulator.SortSchema((x, y) => string.CompareOrdinal(x, y)), _masUnsorted);

            var masExpected = _masUnsorted.OrderBy(x => x);
            Assert.IsTrue(masExpected.SequenceEqual(masResult), "Строки отсиротированы не корректно");
        }
    }
}
