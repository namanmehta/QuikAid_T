using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuikAid_T.Models
{
    public class MyClass
    {
        [DisplayName("ID number")]
        public string FirstName { get; set; }
        [DisplayName("Count of Ids for this client")]
        public int CountOfClients { get; set; }
    }
}