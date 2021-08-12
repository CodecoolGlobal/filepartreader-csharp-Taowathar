using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;

namespace Codecool.FilePartReader
{
    /// <summary>
    /// Uses a FilePartReader to open a file and analyze different aspects of it
    /// </summary>
    public class FileWordAnalyzer
    {
        private readonly FilePartReader _filePartReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWordAnalyzer"/> class.
        /// </summary>
        /// <param name="filePartReader">File part reader instance.</param>
        public FileWordAnalyzer(FilePartReader filePartReader)
        {
            _filePartReader = filePartReader;
        }

        /// <summary>
        /// Gets the lines configured from FilePartReader and creates a list
        /// of lines out of them, and sorts into natural order
        /// </summary>
        /// <returns>The list of lines ordered in natural order</returns>
        public List<string> GetWordsOrderedAlphabetically()
        {
            List<string> result = new List<string>();
            string text = _filePartReader.ReadLines();
            string[] words = text.Split(' ', '\n', '\r');
            foreach (var word in words)
            {
                if (word != string.Empty)
                {
                    result.Add(word.Trim('.'));
                }
            }

            result.Sort();
            return result;
        }

        /// <summary>
        /// Returns the lines containing the given sub-string
        /// </summary>
        /// <param name="subString">SubString the sub-string we are looking for in the file</param>
        /// <returns>The lines containing the sub-string.OrderBy(x =&gt; x, StringComparer.OrdinalIgnoreCase);</returns>
        public List<string> GetWordsContainingSubstring(string subString)
        {
            List<string> result = new List<string>();
            List<string> words = GetWordsOrderedAlphabetically();
            foreach (var word in words)
            {
                if (word.Contains(subString))
                {
                    result.Add(word);
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the lines (not only words) which are palindrome. Doesn't care
        /// of the capital - non-capital character differences
        /// </summary>
        /// <returns>All the lines which are palindrome as a list</returns>
        public List<string> GetStringsWhichPalindromes()
        {
            List<string> result = new List<string>();
            string text = _filePartReader.ReadLines();
            string[] lines = text.Split("\r\n");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                string reverseLine = String.Empty;
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    reverseLine += line[i];
                }

                if (string.Equals(line.Replace(" ", string.Empty), reverseLine.Replace(" ", String.Empty), StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(line);
                }
            }

            return result;
        }
    }
}
