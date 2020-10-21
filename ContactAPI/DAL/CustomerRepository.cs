using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ContactAPI.DTO;
using Dapper;

namespace ContactAPI.DAL
{
    /// <summary>
    /// CustomRepository
    /// </summary>
    /// <seealso cref="ContactAPI.DAL.ICustomerRepository" />
    public class CustomRepository : ICustomerRepository
    {
        /// <summary>
        /// The database
        /// </summary>
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        /// <summary>
        /// Gets the person contact list asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task<List<PersonContactDetails>> GetPersonContactListAsync()
        {
            var result = await _db.QueryAsync<PersonContactDetails>("[dbo].[GetContactList]", commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            if (result.Any())
            {
                return result.ToList();
            }
            return null;
        }

        /// <summary>
        /// Gets the emails.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns></returns>
        public async Task<List<EmailDTO>> GetEmails(int contactId)
        {

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContactId", contactId, DbType.Int32, ParameterDirection.Input);
            var result = await _db.QueryAsync<EmailDTO>("[dbo].[EmailList]",dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            if (result.Any())
            {
                return result.ToList();
            }
            return null;
        }

        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns></returns>
        public async Task<List<PhoneDTO>> GetPhoneNumbers(int contactId)
        {

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ContactId", contactId, DbType.Int32, ParameterDirection.Input);
            var result = await _db.QueryAsync<PhoneDTO>("[dbo].[PhoneNumbersList]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            if (result.Any())
            {
                return result.ToList();
            }
            return null;
        }

        /// <summary>
        /// Adds the contact.
        /// </summary>
        /// <param name="personContactDetails">The person contact details.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> AddContact(PersonContactDetails personContactDetails)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@FirstName", personContactDetails.FirstName, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@LastName", personContactDetails.LastName, DbType.String, ParameterDirection.Input);
            var results = (await _db.QueryAsync<OperationResultDTO>(
                                    "[dbo].[AddContact]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();

            return results;
        }

        /// <summary>
        /// Sets the contact.
        /// </summary>
        /// <param name="personContactDetails">The person contact details.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> SetContact(PersonContactDetails  personContactDetails)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@FirstName", personContactDetails.FirstName, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@LastName", personContactDetails.LastName, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@ContactId", personContactDetails.ContactId, DbType.Int32, ParameterDirection.Input);
            var results = (await _db.QueryAsync<OperationResultDTO>(
                                    "[dbo].[UpdateContact]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();

            return results;
        }



        /// <summary>
        /// Adds the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> AddEmail(EmailDTO email)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Email", email.Email, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@ContactId", email.ContactId, DbType.Int32, ParameterDirection.Input);
            var results = (await _db.QueryAsync<OperationResultDTO>(
                                    "[dbo].[AddEmail]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();

            return results;
        }

        /// <summary>
        /// Updates the email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> UpdateEmail(EmailDTO  email)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@Email", email.Email, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@EmailId", email.EmailId, DbType.Int32, ParameterDirection.Input);
            var results = (await _db.QueryAsync<OperationResultDTO>(
                                    "[dbo].[UpdateEmail]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();

            return results;
        }

        /// <summary>
        /// Adds the phone.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> AddPhone(PhoneDTO phone)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@PhoneNumber", phone.PhoneNumber, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@ContactId", phone.ContactId, DbType.Int32, ParameterDirection.Input);
            var results = (await _db.QueryAsync<OperationResultDTO>(
                                    "[dbo].[AddPhoneNumber]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();

            return results;
        }

        /// <summary>
        /// Updates the phone.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
        public async Task<OperationResultDTO> UpdatePhone(PhoneDTO phone)
        {
            var dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@PhoneNumber", phone.PhoneNumber, DbType.String, ParameterDirection.Input);
            dynamicParameters.Add("@PhoneId", phone.PhoneId, DbType.Int32, ParameterDirection.Input);
            var results = (await _db.QueryAsync<OperationResultDTO>(
                                    "[dbo].[UpdatePhoneNumber]", dynamicParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).FirstOrDefault();

            return results;
        }

       
    }
}