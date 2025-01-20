namespace MoneyManager.Services.Assets.Application.Objects.Responses
{
    public class CurrencyResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier of the currency.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Gets or sets the code of the currency (e.g., USD, EUR).
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// Gets or sets the symbol of the currency (e.g., $, €).
        /// </summary>
        public string Symbol { get; set; } = default!;
    }
}
