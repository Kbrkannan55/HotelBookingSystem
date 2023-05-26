using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;
using HotelBookingSystem.Repository.CustomerServices;

namespace HotelBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _context;

        public CustomersController(ICustomerServices context)
        {
            _context = context;
        }

        [HttpGet,Route("Get Your Details")]
        public async Task<ActionResult<Customer>> GetCustomers(int id)
        {
            return await _context.GetCustomers(id);
         }
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return await _context.PostCustomer(customer);
        }

        [HttpPut,Route("Update Your Password By using ID")] 
        public async Task<ActionResult<Customer?>> PutCustomer(int id, Customer customer)
        {
            return await _context.PutCustomer(id,customer);
        }

        [HttpDelete("Delete By Id")]
        public async Task<String> DeleteCustomer(int id)
        {
            return await _context.DeleteCustomer(id);
        }
    }
}
