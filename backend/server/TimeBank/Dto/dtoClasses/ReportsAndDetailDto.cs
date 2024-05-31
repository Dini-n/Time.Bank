using System;
using System.Collections.Generic;
namespace Dto.dtoClasses
{
    public class Receiver
    {
        public string name { get; set; }
        public string phone { get; set; }
        public Receiver(string name, string phone)
        {
            this.name = name;
            this.phone = phone;
        }
    }

    public class ReportAndDetailDto
    {
        public DateTime date { get; set; }
        public Time time { get; set; }
        public string Note { get; set; }
        // כאן להפוך את זה אחר כך למערך
        public List<Receiver> getterMembers { get; set; }
        //public Receiver GetterMember { get; set; }
        public bool? receiverApproved { get; set; } 
    }
}