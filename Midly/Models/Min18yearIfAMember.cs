using Midly.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Models
{
    public class Min18yearIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // ObjectInstance gives us access to our class
            //(Customer)validationContext.ObjectInstance Casting it into customer object
            var customer = (CustomerDto)validationContext.ObjectInstance;

            //MembershipType.PayAsYouGo is defined to replace magic numbers i.e 0,1
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo || customer.MembershipTypeId == MembershipType.Unknown)            
                return ValidationResult.Success;
            
            if(customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.Birthdate.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Age should be greater than 18");
        }
    }
}