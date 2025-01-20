namespace MoneyManager.Services.Assets.Domain.Tests
{
    public class AssetTests
    {
        /// <summary>
        /// Verifies that the constructor correctly sets the Name and CurrencyId properties when valid values are provided.
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly_WhenValidNameAndCurrencyId()
        {
            // Act
            var asset = new Asset("Asset1", 1);

            // Assert
            Assert.Equal("Asset1", asset.Name);
            Assert.Equal(1, asset.CurrencyId);
        }

        /// <summary>
        /// Verifies that the Add method correctly adds a transaction to the asset's transaction list.
        /// </summary>
        [Fact]
        public void Add_AddsTransaction_WhenValidTransaction()
        {
            // Arrange
            var asset = new Asset("Asset1", 1);
            var transaction = new Transaction(100, "abc", DateTimeOffset.Now);  // Assuming the transaction has an amount of 100

            // Act
            asset.Add(transaction);

            // Assert
            Assert.Contains(transaction, asset.Transactions);
        }

        /// <summary>
        /// Verifies that the Add method throws an ArgumentNullException when the provided transaction is null.
        /// </summary>
        [Fact]
        public void Add_ThrowsArgumentNullException_WhenTransactionIsNull()
        {
            // Arrange
            var asset = new Asset("Asset1", 1);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => asset.Add(null!));
        }

        /// <summary>
        /// Verifies that the Remove method correctly removes a transaction when it exists in the transaction list.
        /// </summary>
        [Fact]
        public void Remove_RemovesTransaction_WhenTransactionExists()
        {
            // Arrange
            var asset = new Asset("Asset1", 1);
            var transaction = new Transaction(100, "abc", DateTimeOffset.Now);
            asset.Add(transaction);

            // Act
            var result = asset.Remove(transaction);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(transaction, asset.Transactions);
        }

        /// <summary>
        /// Verifies that the Remove method returns false when attempting to remove a transaction that does not exist in the transaction list.
        /// </summary>
        [Fact]
        public void Remove_ReturnsFalse_WhenTransactionDoesNotExist()
        {
            // Arrange
            var asset = new Asset("Asset1", 1);
            var transaction = new Transaction(100, "abc", DateTimeOffset.Now);  // Create a transaction

            // Act
            var result = asset.Remove(transaction);

            // Assert

            Assert.False(result);
        }
    }
}
