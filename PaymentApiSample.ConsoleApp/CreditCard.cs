namespace PaymentApiSample.ConsoleApp
{
    /// <summary>
    /// Credit Card class used for creating a credit card token via the Payment API's POST /creditcard
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// The card number
        /// </summary>
        public string CardNumber;

        /// <summary>
        /// The security code
        /// </summary>
        public string SecurityCode;

        /// <summary>
        /// The expiration month
        /// </summary>
        public int ExpirationMonth;

        /// <summary>
        /// The expiration year
        /// </summary>
        public int ExpirationYear;

        /// <summary>
        /// The card holder name
        /// </summary>
        public string CardHolderName;

        /// <summary>
        /// The billing address
        /// </summary>
        public Address BillingAddress;

        /// <summary>
        /// The email
        /// </summary>
        public string Email;

        /// <summary>
        /// The reference identifier
        /// </summary>
        public string ReferenceId;

        /// <summary>
        /// The redirect URL
        /// </summary>
        public string RedirectUrl;
    }
}
