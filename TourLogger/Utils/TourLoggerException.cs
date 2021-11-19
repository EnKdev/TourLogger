using System;

namespace TourLogger.Utils
{
    public class TourLoggerException : Exception
    {
        public TourLoggerException() : base()
        {
        }

        public TourLoggerException(string message) : base(message)
        {
        }

        public TourLoggerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}