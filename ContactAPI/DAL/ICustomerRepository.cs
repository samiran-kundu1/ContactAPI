using ContactAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.DAL
{
    /// <summary>
    /// ICustomerRepository
    /// </summary>
    interface ICustomerRepository
    {
        /// <summary>
        /// Gets the person contact list asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<List<PersonContactDetails>> GetPersonContactListAsync();
        /// <summary>
        /// Sets the contact.
        /// </summary>
        /// <param name="contactDetails">The contact details.</param>
        /// <returns></returns>
        Task<OperationResultDTO> SetContact(PersonContactDetails contactDetails);
        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="contactDetails">The contact details.</param>
        /// <returns></returns>
        Task<OperationResultDTO> AddContact(PersonContactDetails contactDetails);

    }
}
