namespace MoneyManager.Services.Assets.Application.Objects.Responses
{
    public class AssetResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
        
        public int CurrencyId { get; set; }
    }
}
