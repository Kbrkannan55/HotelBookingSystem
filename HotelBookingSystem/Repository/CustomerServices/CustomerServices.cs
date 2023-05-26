using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Repository.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private HotelBookingDBContext _context;
        public CustomerServices(HotelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomers(int id)
        {
            if (id < 0)
            {
                throw new ArithmeticException("Enter Valid Number");
            }

            var cus = await _context.Customers.FirstOrDefaultAsync(x => x.CusID == id);
          
            return cus;
        }

        public async Task<Customer> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }


        public async Task<Customer?> PutCustomer(int id, Customer customer)
        {
            if (id < 0)
            {
                throw new Exception("Not Valid");
            }
            var cus=await _context.Customers.FirstOrDefaultAsync(x=>x.CusID==id);
            cus.CustomerPassword = customer.CustomerPassword;
            _context.SaveChanges();
            return cus;
        }

        [Authorize]
        public async Task<String> DeleteCustomer(int id)
        {
            if (id < 0)
            {
                throw new Exception("Not Valid");
            }
            var Cus = await _context.Customers.FirstOrDefaultAsync(x => x.CusID == id);
            _context.Remove(Cus);
            _context.SaveChanges();
            return "Deleted Successfully";
        }




    }
}
