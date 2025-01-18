namespace MoneyManager.Services.Assets.Domain
{
    /// <summary>
    /// Represents a currency with its associated properties.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets or sets the unique identifier of the currency.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the currency (e.g., USD, EUR).
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the symbol of the currency (e.g., $, €).
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the currency.</param>
        /// <param name="name">The name of the currency.</param>
        /// <param name="code">The code of the currency (e.g., USD, EUR).</param>
        /// <param name="symbol">The symbol of the currency (e.g., $, €).</param>
        public Currency(int id, string name, string code, string symbol)
        {
            Id = id;
            Name = name;
            Code = code;
            Symbol = symbol;
        }
    }
}
