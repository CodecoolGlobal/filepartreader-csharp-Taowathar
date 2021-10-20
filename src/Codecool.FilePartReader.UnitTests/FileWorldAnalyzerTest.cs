using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Codecool.FilePartReader.UnitTests
{
    [TestFixture]
    class FileWorldAnalyzerTest
    {
        private FileWordAnalyzer _fileWordAnalyzer;
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            _filePartReader = new FilePartReader();
            _filePartReader.Setup("../../../../../Data/test.txt", 1, 5);
            _fileWordAnalyzer = new FileWordAnalyzer(_filePartReader);
        }

        [Test]
        public void GetWordsOrderedAlphabetically_AssertEqual()
        {

            var sortedWords = new List<string>(new string[] {"All", "Bring", "Creature", "creeping", "darkness", "days", "divide", "divide", "divided", "Fly", "Fly", "forth", "from", "gathering", "great", "greater", "heaven", "In", "itself", "moving", "night", "Saying", "Seas", "she'd", "spirit", "The", "There", "to", "to", "unto", "Whales", "yielding"});
            Console.WriteLine(_fileWordAnalyzer.GetWordsOrderedAlphabetically());
            Assert.AreEqual(sortedWords, _fileWordAnalyzer.GetWordsOrderedAlphabetically());
        }

        [Test]
        public void GetWordsContainingSubstring_AssertEqual()
        {
            var words = new List<string>(new string[] {"divide", "divide", "divided"});
            Assert.AreEqual(words, _fileWordAnalyzer.GetWordsContainingSubstring("div"));
        }

        [Test]
        public void GetStringsWhichPalindromes_AssertEqual()
        {
            _filePartReader.Setup("../../../../../Data/test.txt", 19, 21);
            _fileWordAnalyzer = new FileWordAnalyzer(_filePartReader);
            var lines = new List<string>(new string[] { "Sore was I ere I saw Eros", "Warsaw was raw", "Xanax" });
            Assert.AreEqual(lines, _fileWordAnalyzer.GetStringsWhichPalindromes());
        }

        [Test]
        public void WordsArePalindrome_AssertEqual()
        {
            _filePartReader.Setup("../../../../../Data/test.txt", 19, 21);
            _fileWordAnalyzer = new FileWordAnalyzer(_filePartReader);
            var lines = new List<string>(new string[] { "ere", "Xanax" });
            Assert.AreEqual(lines, _fileWordAnalyzer.WordsArePalindrome());
        }
    }
}
