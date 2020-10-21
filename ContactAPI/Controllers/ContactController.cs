using ContactAPI.DAL;
using ContactAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactAPI.Controllers
{
    /// <summary>
    /// ContactController class
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ContactController : ApiController
    {
        /// <summary>
        /// Our customer respository
        /// </summary>
        private CustomRepository _ourCustomerRespository = new CustomRepository();
        // GET: api/Contact
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Contacts")]
        public async Task<IEnumerable<PersonContactDetails>> Get()
        {
            return await _ourCustomerRespository.GetPersonContactListAsync();
        }





        /// <summary>
        /// Posts the specified contact details.
        /// </summary>
        /// <param name="contactDetails">The contact details.</param>
        /// <returns></returns>
        [HttpPost]
        // POST: api/Contact
        public async Task<OperationResultDTO> Post([FromBody]PersonContactDetails contactDetails)
        {
            return await _ourCustomerRespository.AddContact(contactDetails).ConfigureAwait(false);
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="contactDetails">The contact details.</param>
        /// <returns></returns>
        [HttpPut]
       // PUT: api/Contact/5
        public async Task<OperationResultDTO> Put(int id, [FromBody]PersonContactDetails contactDetails)
        {
            return await _ourCustomerRespository.SetContact(contactDetails).ConfigureAwait(false);
        }

        // DELETE: api/Contact/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
        }
    }
}
