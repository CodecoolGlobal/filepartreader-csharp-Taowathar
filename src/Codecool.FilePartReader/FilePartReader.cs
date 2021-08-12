using System;
using System.IO;
using System.Text;

namespace Codecool.FilePartReader
{
    /// <summary>
    /// Parses the file's content into String
    /// </summary>
    public class FilePartReader
    {
        /// <summary>
        /// Gets file path.
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Gets line to start from.
        /// </summary>
        public int FromLine { get; private set; }

        /// <summary>
        /// Gets line to read to.
        /// </summary>
        public int ToLine { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FilePartReader"/> class.
        /// </summary>
        public FilePartReader()
        {
        }

        /// <summary>
        /// Setup or fail as soon as you can approach: if something is wrong throw an exception.
        /// </summary>
        /// <param name="filePath">FilePath file name with full path</param>
        /// <param name="fromLine">FromLine line number where we start getting lines</param>
        /// <param name="toLine">ToLine number of last line we include when reading</param>
        public void Setup(string filePath, int fromLine, int toLine)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back all the content of the file, doesn't care about from/toLine
        /// </summary>
        /// <returns>The content of the whole file as a String</returns>
        public string Read()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the lines from the line in fromLine to the line in toLine.
        /// </summary>
        /// <returns>The content of file between fromLine and toLine as a string</returns>
        public string ReadLines()
        {
            throw new NotImplementedException();
        }
    }
}
