//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSO.WCFService
{
    using System;
    using System.Collections.Generic;
    
    public partial class CV_FRAGMENT_TYPE
    {
        public CV_FRAGMENT_TYPE()
        {
            this.CV_XML_FRAGMENT = new HashSet<CV_XML_FRAGMENT>();
        }
    
        public int ID { get; set; }
        public string FRAGMENT_TYPE { get; set; }
    
        public virtual ICollection<CV_XML_FRAGMENT> CV_XML_FRAGMENT { get; set; }
    }
}