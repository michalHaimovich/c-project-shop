
namespace DO;

public class ExceptionsIdNotFound: Exception
{
    public override string Message
    {
        get { return "this id doesnt exist"; }
    }
}

public class ExceptionIDAllredyExist : Exception
{
    public override string Message
    {
        get { return "this id exist allready"; }
    }
}
