namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotfoundException
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found.")
        {
        }
    }
}
