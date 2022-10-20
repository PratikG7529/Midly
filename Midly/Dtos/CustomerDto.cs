using Midly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Dtos
{
    //Dtos are used to define how to send and receive data between two applications(api and server)
    //It doesnot contain any logic within
    //It is also used to transfer/receive data with security
    public class CustomerDto
    {

        public int Id { get; set; }

        //Error message overwrites the ModelState error message.
        [Required(ErrorMessage = "PLEASE ENTER CUSTOMERS NAME")]
        [StringLength(25)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //As datatype of Membershiptypeid is byte is implicitly [Required],but if we make it nullable i.e byte? then its not required
        public byte MembershipTypeId { get; set; }

        //Cannot specify MembershipType model because we dont want it to directly depend or coupled to 
        // that class
        public MembershipTypeDto MembershipType { get; set; }


        //In view, Date of birth will be picked instead of Birthdate because of 
        //Display(name = "") attribute
        [Min18yearIfAMember]
        public DateTime Birthdate { get; set; }
    }
}