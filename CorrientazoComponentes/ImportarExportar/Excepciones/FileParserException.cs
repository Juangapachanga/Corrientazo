using System;

namespace RDD.SalesTracker.Component.FileImportExport.Exceptions
{  
    /// <summary>
    /// Represents an exception that occurs when parsing a file.
    /// </summary>
    public class FileParserException : Exception
    {
        public FileParserException() : base()
        {
        }

        public FileParserException(string message) : base(message)
        {
        }
    }
}
