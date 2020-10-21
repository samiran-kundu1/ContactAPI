using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAPI.DTO
{
    /// <summary>
    /// EmailDTO
    /// </summary>
    public class EmailDTO
    {
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>
        /// The email identifier.
        /// </value>
        public int EmailId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        /// <value>
        /// The contact identifier.
        /// </value>
        public int ContactId { get; set; }
    }
}