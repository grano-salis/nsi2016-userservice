using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SSO.WCFService.DataContracts
{
    [DataContract]
    public class ChangePasswordRequest
    {
        // UID for the User whose password should be changed.
        [DataMember(IsRequired = true)]
        //[Required(ErrorMessage = "ID is required.")]
        public Int32 ID { get; set; }

        [DataMember(IsRequired = true)]
        //[Required(ErrorMessage = "Password is required.")]
        //[StringLength(16, MinimumLength = 8, ErrorMessage = "Password length should be between 10 and 100.")]
        public string OldPassword { get; set; }

        [DataMember(IsRequired = true)]
        //[Required(ErrorMessage = "Password is required.")]
        //[StringLength(16, MinimumLength = 8, ErrorMessage = "Password length should be between 10 and 100.")]
        public string NewPassword { get; set; }
    }
}