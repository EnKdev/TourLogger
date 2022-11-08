using System;

namespace TourLogger.Mvvm.Exceptions;

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