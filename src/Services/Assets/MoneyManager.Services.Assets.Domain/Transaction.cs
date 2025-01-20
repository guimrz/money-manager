namespace MoneyManager.Services.Assets.Domain
{
    /// <summary>
    /// Represents a financial transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets the unique identifier of the transaction.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Gets the description of the transaction.
        /// </summary>
        public string? Description { get; protected set; }

        /// <summary>
        /// Gets the value of the transaction.
        /// </summary>
        public decimal Value { get; protected set; } // TODO: Rename to amount

        /// <summary>
        /// Gets the date and time of the transaction.
        /// </summary>
        public DateTimeOffset Date { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="value">The monetary value of the transaction.</param>
        /// <param name="description">An optional description of the transaction.</param>
        /// <param name="date">The date and time the transaction occurred.</param>
        public Transaction(decimal value, string? description, DateTimeOffset date)
        {
            Value = value;
            Date = date;
            Description = description;
        }
    }
}
