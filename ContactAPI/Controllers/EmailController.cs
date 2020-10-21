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
    public class EmailController : ApiController
    {
        private CustomRepository _ourCustomerRespository = new CustomRepository();
        // GET: api/Email
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/Emails/{contactId}")]
        // GET: api/Email/5
        public async Task<IEnumerable<EmailDTO>> Get(int contactId)
        {
            return await _ourCustomerRespository.GetEmails(contactId);
        }

        // POST: api/Email
        public async Task<OperationResultDTO> Post([FromBody]EmailDTO email)
        {
            return await _ourCustomerRespository.AddEmail(email).ConfigureAwait(false);
        }

        // PUT: api/Email/5
        public async Task<OperationResultDTO> Put(int id, [FromBody]EmailDTO value)
        {
            return await _ourCustomerRespository.UpdateEmail(value).ConfigureAwait(false);

        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }
    }
}
