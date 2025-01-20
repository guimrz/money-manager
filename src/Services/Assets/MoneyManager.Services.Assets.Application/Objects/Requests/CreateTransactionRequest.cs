namespace MoneyManager.Services.Assets.Application.Objects.Requests
{
    public class CreateTransactionRequest
    {
        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
