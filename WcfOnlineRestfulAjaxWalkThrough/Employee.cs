using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WcfOnlineRestfulAjaxWalkThrough
{
    [DataContract]
   public class Employee
    {
        [DataMember]
        public string EmployeeId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string JoiningDate { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}