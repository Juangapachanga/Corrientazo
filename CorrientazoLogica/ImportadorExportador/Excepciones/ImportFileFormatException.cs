using System;
using System.Runtime.Serialization;

namespace RDD.SalesTracker.Logic.AdminApplication.FileImportExport.Exceptions
{
    public class ImportFileFormatException : Exception
    {
        public ImportFileFormatException() 
            : base()
        { }

        public ImportFileFormatException(string message) 
            : base(message)
        { }

        public ImportFileFormatException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public ImportFileFormatException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        { }
    }
}
