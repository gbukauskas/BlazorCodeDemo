﻿namespace BlazorApp_1.CustomErrors
{
    [Serializable]
    public class DatabaseException : Exception
    {
        public DatabaseException()
        { }

        public DatabaseException(string message)
            : base(message)
        { }

        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException() 
        { }

        public NotFoundException(string message): base(message)
        { }
    }

    public class DataBaseUpdateException: Exception
    {
        public DataBaseUpdateException()
        { }

        public DataBaseUpdateException(string message)
            : base(message)
        { }

        public DataBaseUpdateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
