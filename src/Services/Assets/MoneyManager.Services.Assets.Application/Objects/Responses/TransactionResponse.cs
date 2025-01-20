namespace MoneyManager.Services.Assets.Application.Objects.Responses
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
