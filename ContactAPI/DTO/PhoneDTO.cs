namespace ContactAPI.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class PhoneDTO
    {
        /// <summary>
        /// Gets or sets the phone identifier.
        /// </summary>
        /// <value>
        /// The phone identifier.
        /// </value>
        public int PhoneId { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        public int ContactId { get; set; }
    }
}