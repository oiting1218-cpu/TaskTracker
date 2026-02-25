namespace TaskTracker.Api.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string email) : base($"Email '{email}' is already registered.")
        {
            //Note: calls base Exception constructor, and set exception's Message property
        }
    }
}
