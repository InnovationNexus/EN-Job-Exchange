//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENJobExchange.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Industry
    {
        public Industry()
        {
            this.tblLINK_Partner_to_Industry = new HashSet<LINK_Partner_to_Industry>();
        }
    
        public long IndustryID { get; set; }
        public string Industry_Title { get; set; }
        public string NAIC_Industry_Code { get; set; }
        public string NAIC_Industry_Specific_Code { get; set; }
    
        public virtual Industry_Category tblLIST_Industry_Category { get; set; }
        public virtual ICollection<LINK_Partner_to_Industry> tblLINK_Partner_to_Industry { get; set; }
    }
}
