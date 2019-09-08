//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER
    {
        public CUSTOMER()
        {
            this.ACCOUNTS = new HashSet<ACCOUNT>();
            this.TRANSACTIONS = new HashSet<TRANSACTION>();
            this.LOANs = new HashSet<LOAN>();
        }
    
        public decimal CUSTOMER_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CUSTOMER_EMAIL { get; set; }
        public string CUSTOMER_PASSWORD { get; set; }
        public string CUSTOMER_PHONE { get; set; }
        public Nullable<System.DateTime> CUSTOMER_JOINDATE { get; set; }
        public decimal BRANCH_ID { get; set; }
        public string CUSTOMER_ADDRESS { get; set; }
        public string CUSTOMER_PICTURE { get; set; }
    
        public virtual ICollection<ACCOUNT> ACCOUNTS { get; set; }
        public virtual BRANCH BRANCH { get; set; }
        public virtual ICollection<TRANSACTION> TRANSACTIONS { get; set; }
        public virtual ICollection<LOAN> LOANs { get; set; }
    }
}
