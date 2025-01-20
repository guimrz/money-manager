namespace MoneyManager.Services.Assets.Application.Exceptions
{
    public class AssetsApplicationException : Exception
    {
        public AssetsApplicationException(string message) : base(message) { }

        public AssetsApplicationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
