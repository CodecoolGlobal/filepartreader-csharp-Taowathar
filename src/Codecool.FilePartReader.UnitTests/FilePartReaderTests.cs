using System;
using System.IO;
using NUnit.Framework;

namespace Codecool.FilePartReader.UnitTests
{
/// <summary>
    /// When testing a class you should test only that specific class(unit), not the others
    /// the class may depending on
    /// </summary>
    [TestFixture]
    public class FilePartReaderTest
    {
        private FilePartReader _filePartReader;

        [SetUp]
        public void Setup()
        {
            _filePartReader = new FilePartReader();
        }

        [Test]
        public void Setup_FromLineSmallerThan1_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("", 0, 1));
        }

        [Test]
        public void Setup_ToLineSmallerThanFromLine_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _filePartReader.Setup("", 5, 3));
        }

        [Test]
        public void Setup_AssertEqual()
        {
            _filePartReader.Setup("../../../../../Data/test.txt", 1, 10);
            Assert.AreEqual(1, _filePartReader.FromLine);
            Assert.AreEqual(10, _filePartReader.ToLine);
        }

        [Test]
        public void Read_AssertEqual()
        {
            string text = @"All gathering days creeping.
Saying night heaven divided Seas darkness yielding divide.
In spirit Whales to unto from. There.
Creature greater great Fly moving. Bring.
Fly itself divide forth she'd to. The.
Every lesser don't land.
Upon there fowl male.
Divided. Face greater good subdue isn't land.
To shall forth in two.
Moved rule isn't moveth grass a meat third.
There creature second whose light all gathering.
Moved forth, she'd yielding together.
Cattle second under creeping god, whose firmament.
Said fowl female together spirit.
Day After saw one To rule.
Creeping. Whales brought you're.
Moveth days.
Fruit Shall earth have.
Sore was I ere I saw Eros
Warsaw was raw
Xanax";
            _filePartReader.Setup("../../../../../Data/test.txt", 1, 10);
            Assert.AreEqual(text, _filePartReader.Read());
        }

        [Test]
        public void ReadLines_ReadTheVeryFirstLine_AssertEqual()
        {
            string text = "All gathering days creeping.";

            _filePartReader.Setup("../../../../../Data/test.txt", 1, 1);
            Assert.AreEqual(text, _filePartReader.ReadLines());
        }

        [Test]
        public void ReadLines_ReadMultipleLines_AssertEqual()
        {
            string text = @"All gathering days creeping.
Saying night heaven divided Seas darkness yielding divide.
In spirit Whales to unto from. There.
Creature greater great Fly moving. Bring.
Fly itself divide forth she'd to. The.
Every lesser don't land.
Upon there fowl male.";
            _filePartReader.Setup("../../../../../Data/test.txt", 1, 7);
            Assert.AreEqual(text, _filePartReader.ReadLines());
        }

        [Test]
        public void ReadLines_ReadLast5Lines_AssertEqual()
        {
            string text = @"Moveth days.
Fruit Shall earth have.
Sore was I ere I saw Eros
Warsaw was raw
Xanax";
            _filePartReader.Setup("../../../../../Data/test.txt", 17, 21);
            Assert.AreEqual(text, _filePartReader.ReadLines());
        }
    }
}