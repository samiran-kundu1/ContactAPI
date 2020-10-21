using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ContactAPI.DTO
{
    [DataContract]
    public class OperationResultDTO
    {
        /// <summary>
        /// Gets or sets the return code.
        /// </summary>
        /// <value>
        /// The return code.
        /// </value>
        [DataMember]
        public int ReturnCode { get; set; }

        /// <summary>
        /// Gets or sets the return message.
        /// </summary>
        /// <value>
        /// The return message.
        /// </value>
        [DataMember]
        public string ReturnMessage { get; set; }
    }
}