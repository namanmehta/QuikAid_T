//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuikAid_T.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class clientTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientTable()
        {
            this.phoneTables = new HashSet<phoneTable>();
        }
    
        public int clientID { get; set; }
        [DisplayName("First Name")]
        public string fname { get; set; }
        [DisplayName("Last Name")]
        public string lName { get; set; }
        [StringLength(10, MinimumLength = 10)]
        [DisplayName("Social Security")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter 10 digits for Social Security")]
        public string SSN { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Date Joined")]
        public Nullable<System.DateTime> DOB { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        public int userId { get; set; }
    
        public virtual UserTable UserTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phoneTable> phoneTables { get; set; }
    }
}