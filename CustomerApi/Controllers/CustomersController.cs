using CustomerApi.Data;
using CustomerApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> repository;
    }
}
