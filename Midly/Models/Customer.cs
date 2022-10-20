using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //Error message overwrites the ModelState error message.
        [Required(ErrorMessage = "PLEASE ENTER CUSTOMERS NAME")]
        [StringLength(25)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        //As datatype of Membershiptypeid is byte is implicitly [Required],but if we make it nullable i.e byte? then its not required
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }


        //In view, Date of birth will be picked instead of Birthdate because of 
        //Display(name = "") attribute
        //[Min18yearIfAMember]  //Commented to work 
        [Display(Name = "Date of Birth")]
        public DateTime Birthdate { get; set; }
    }
}