namespace MoneyManager.Services.Assets.Domain
{
    /// <summary>
    /// Represents an asset.
    /// </summary>
    public class Asset
    {      
        private readonly List<Transaction> _transactions;

        /// <summary>
        /// Gets the unique identifier of the asset.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets the name of the asset.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets a read-only collection of transactions associated with the asset.
        /// </summary>
        public IReadOnlyCollection<Transaction> Transactions { get { return _transactions; } }

        /// <summary>
        /// Gets the identifier of the currency used in the asset.
        /// </summary>
        public int CurrencyId { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Asset"/> class.
        /// </summary>
        /// <param name="name">The name of the asset. Must not be null or whitespace.</param>
        /// <param name="currencyId">The identifier of the currency associated with the asset.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null or whitespace.</exception>
        public Asset(string name, int currencyId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            _transactions = new List<Transaction>();

            Name = name;
            CurrencyId = currencyId;
        }

        /// <summary>
        /// Adds a transaction to the asset.
        /// </summary>
        /// <param name="transaction">The transaction to add. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="transaction"/> is null.</exception>
        public void Add(Transaction transaction)
        {
            ArgumentNullException.ThrowIfNull(transaction);
            _transactions.Add(transaction);
        }

        /// <summary>
        /// Removes a transaction from the asset.
        /// </summary>
        /// <param name="transaction">The transaction to remove.</param>
        /// <returns>
        /// <c>true</c> if the transaction was successfully removed; otherwise, <c>false</c>.
        /// </returns>
        public bool Remove(Transaction transaction)
        {
            return _transactions.Remove(transaction);
        }
    }
}
