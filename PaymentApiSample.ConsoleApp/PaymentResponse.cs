namespace PaymentApiSample.ConsoleApp
{
    /// <summary>
    /// Payment Response class used for deserializing the Payment API's POST /payments response into.
    /// </summary>
    public class PaymentResponse
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public int Id;

        /// <summary>
        /// The account identifier
        /// </summary>
        public int AccountId;

        /// <summary>
        /// The payment amount
        /// </summary>
        public decimal PaymentAmount;

        /// <summary>
        /// The description
        /// </summary>
        public string Description;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public string ReferenceId;

        /// <summary>
        /// The payment method
        /// </summary>
        public PaymentMethod PaymentMethod;

        /// <summary>
        /// The result
        /// </summary>
        public PaymentResult Result;

        /// <summary>
        /// The created date
        /// </summary>
        public string CreatedDate;

        /// <summary>
        /// The modified date
        /// </summary>
        public string ModifiedDate;
    }

    /// <summary>
    /// Payment Result
    /// </summary>
    public class PaymentResult
    {
        /// <summary>
        /// The status
        /// </summary>
        public string Status;

        /// <summary>
        /// The code
        /// </summary>
        public string Code;

        /// <summary>
        /// The message
        /// </summary>
        public string Message;

        /// <summary>
        /// The provider account identifier/
        /// </summary>
        public string ProviderAccountId;

        /// <summary>
        /// The merchant transaction identifier
        /// </summary>
        public string MerchantTransactionId;

        /// <summary>
        /// The merchant transaction fee
        /// </summary>
        public decimal MerchantTransactionFee;
    }
}
