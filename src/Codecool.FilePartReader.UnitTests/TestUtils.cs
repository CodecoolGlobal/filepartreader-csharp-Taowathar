using System;
using System.IO;

namespace Codecool.FilePartReader.UnitTests
{
    public class TestUtils
    {
        public static readonly string TestFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent?.Parent?.Parent?.Parent?.FullName + "/data/test.txt";

        /// <summary>
        /// Normalizes Unix, Windows, OSX line endings
        /// </summary>
        /// <param name="s">String to normalize.</param>
        /// <returns>Normalized string.</returns>
        public static string NormalizeLineEnds(string s)
        {
            return s.Replace("\r\n", "\n").Replace('\r', '\n');
        }
    }
}