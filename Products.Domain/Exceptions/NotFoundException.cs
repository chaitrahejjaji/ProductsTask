namespace Products.Domain.Exceptions
{
    public class NotFoundException(string type, string id) : Exception($"The {type} of Id:{id} does not exist")
    {

    }
}
