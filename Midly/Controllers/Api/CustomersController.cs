using AutoMapper;
using Midly.Dtos;
using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Midly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _applicationDbContext;

        public CustomersController()
        {
            //Initilizing the object
            _applicationDbContext = new ApplicationDbContext();
        }

        // api/customers
        public IHttpActionResult GetCustomers()
        {
            //Need to map CustomerDto to Customer
            //.Select() is a link extension method
            //.Select() inside we are passing a Deligate
            //here we are mapping data from customer to customerdto
            //EX: Data comming Customer model & then into CustomerDto Model
            var customers = _applicationDbContext.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customers);
        }

        // api/customer/{id}
        public CustomerDto GetCustomer(int id)
        {
            var customer = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                //Will throw as response as NOT FOUND/404
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //here we are mapping data from customer to customerdto
            //EX: Data comming Customer model & then into CustomerDto Model
            return Mapper.Map<Customer,CustomerDto>(customer);
        }
     
        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customer">This will be a part of REQUEST BODY</param>
        /// <returns></returns>
        /// Post api/customers
        [HttpPost]  //This attribute  can be used or rename method to PostCustomer
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //Here we are add data from customerDto to customer
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);

            //Adding customerdto in form of customer 
            _applicationDbContext.Customers.Add(customer);
            _applicationDbContext.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }

        /// <summary>
        /// Update an existing customer
        /// Datatype is void as we dont want to return anything from this action
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <param name="customer">Customer Model</param>
        /// PUT api/customers/{id}
        /// 
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerdto)
        {
            //Checking id modelState is valid
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //getting customer from DB based on Id
            var customerInDb = _applicationDbContext.Customers.SingleOrDefault(c => c.Id ==id);

            //Checking if customer is null
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Mapping from customerdto to customer as our data is frist in dto model and it again needs to be saved in customer model
            Mapper.Map<CustomerDto, Customer>(customerdto,customerInDb);

            ////updating customer values
            //customerInDb.Name = customerdto.Name;
            //customerInDb.MembershipTypeId = customerdto.MembershipTypeId;
            //customerInDb.IsSubscribedToNewsLetter = customerdto.IsSubscribedToNewsLetter;
            //customerInDb.Birthdate = customerdto.Birthdate;

            _applicationDbContext.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _applicationDbContext.Customers.Remove(customerInDb);
            _applicationDbContext.SaveChanges();
        }
    }
}
