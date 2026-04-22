using System;

namespace BO;

// 1. חריגה המקבילה ל"מזהה לא קיים" בשכבת הנתונים
[Serializable]
public class BlDoesNotExistException : Exception
{
    public BlDoesNotExistException(string? message) : base(message) { }
    public BlDoesNotExistException(string message, Exception innerException) : base(message, innerException) { }
}

// 2. חריגה המקבילה ל"מזהה כבר קיים" בשכבת הנתונים
[Serializable]
public class BlAlreadyExistsException : Exception
{
    public BlAlreadyExistsException(string? message) : base(message) { }
    public BlAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
}

// 3. חריגה ייעודית עבור תקלות פנימיות של השכבה הלוגית (למשל: קלט לא תקין)
[Serializable]
public class BlInvalidInputException : Exception
{
    public BlInvalidInputException(string? message) : base(message) { }
    public BlInvalidInputException(string message, Exception innerException) : base(message, innerException) { }
}

[Serializable]
public class BlNotInStockException : Exception
{
    public BlNotInStockException(string? message) : base(message) { }
    public BlNotInStockException(string message, Exception innerException) : base(message, innerException) { }
}
