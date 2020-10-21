using ContactAPI.DAL;
using ContactAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContactAPI.Controllers
{
    /// <summary>
    /// PhoneController
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class PhoneController : ApiController
    {
        /// <summary>
        /// Our customer respository
        /// </summary>
        private CustomRepository _ourCustomerRespository = new CustomRepository();
       
        // GET: api/Phone
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets the specified contact identifier.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Phones/{contactId}")]
        // GET: api/Phone/5
        public async Task<IEnumerable<PhoneDTO>> Get(int contactId)
        {
            return await _ourCustomerRespository.GetPhoneNumbers(contactId);
        }

        // POST: api/Phone
        /// <summary>
        /// Posts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> Post([FromBody]PhoneDTO value)
        {
            return await _ourCustomerRespository.AddPhone(value).ConfigureAwait(false);
        }

        // PUT: api/Phone/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> Put(int id, [FromBody]PhoneDTO value)
        {
            return await _ourCustomerRespository.UpdatePhone(value).ConfigureAwait(false);
        }

        // DELETE: api/Phone/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(int id)
        {
        }
    }
}
