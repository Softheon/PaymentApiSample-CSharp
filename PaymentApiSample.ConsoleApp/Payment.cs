namespace PaymentApiSample.ConsoleApp
{
    /// <summary>
    /// Payment class used for making a payment via the Payment API's POST /payments
    /// </summary>
    public class Payment
    {
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
        /// The callback URL
        /// </summary>
        public string CallbackUrl;
    }

    /// <summary>
    /// Payment Method
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// The payment token
        /// </summary>
        public string PaymentToken;

        /// <summary>
        /// The type (Unknown, Credit Card, or ACH)
        /// </summary>
        public string Type;
    }
}
