using HotelBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Repository.CustomerServices
{
    public interface ICustomerServices
    {
        Task<Customer> GetCustomers(int id);
        Task<Customer> PostCustomer(Customer customer);

        Task<Customer?> PutCustomer(int id, Customer customer);
        Task<String> DeleteCustomer(int id);

    }
}
