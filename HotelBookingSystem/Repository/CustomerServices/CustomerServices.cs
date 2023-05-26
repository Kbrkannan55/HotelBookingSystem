﻿using HotelBookingSystem.Models;
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
            var cus=await _context.Customers.FirstOrDefaultAsync(x=>x.CusID==id);
            cus.CustomerPassword = customer.CustomerPassword;
            _context.SaveChanges();
            return cus;
        }

        public async Task<String> DeleteCustomer(int id)
        {
            var Cus = await _context.Customers.FirstOrDefaultAsync(x => x.CusID == id);
            _context.Remove(Cus);
            _context.SaveChanges();
            return "Deleted Successfully";
        }




    }
}
