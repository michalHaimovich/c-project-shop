using System;

namespace DO;

[Serializable]
public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException(string? message) : base(message) { }
    public DalDoesNotExistException(string message, Exception innerException) : base(message, innerException) { }
}

[Serializable]
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string? message) : base(message) { }
    public DalAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}