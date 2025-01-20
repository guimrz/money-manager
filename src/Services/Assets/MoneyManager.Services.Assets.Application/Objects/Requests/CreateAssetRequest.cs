namespace MoneyManager.Services.Assets.Application.Objects.Requests
{
    public class CreateAssetRequest
    {
        public string Name { get; set; } = default!;

        public int CurrencyId { get; set; }
    }
}
