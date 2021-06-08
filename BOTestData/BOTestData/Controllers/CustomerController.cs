using BOTestData.Models;
using BOTestData.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOTestData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILoadJSONService<Customer> service;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILoadJSONService<Customer> service, ILogger<CustomerController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<CustomerResponse> Get([FromQuery] QueryParams query)
        {
            var json = await this.service.LoadJson();

            var data = json.Where(x => string.IsNullOrEmpty(query.FirstName) ? true : x.FirstName.ToLower().Contains(query.FirstName.ToLower()))
                                    .Where(x => string.IsNullOrEmpty(query.LastName) ? true : x.LastName.ToLower().Contains(query.LastName.ToLower()))
                                    .Where(x => string.IsNullOrEmpty(query.TaxNumber) ? true : x.TaxNumber.Contains(query.TaxNumber))
                                    .Where(x => string.IsNullOrEmpty(query.Cellphone) ? true : x.Cellphone.Contains(query.Cellphone))
                                    .Where(x => string.IsNullOrEmpty(query.Status) ? true : x.Status.ToLower() == query.Status.ToLower())
                                    .Skip((query.PageNumber - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .ToList();

            var dto = new CustomerResponse
            {
                Customers = new CustomerData
                {
                    Data = data,
                    Page = query.PageNumber,
                    TotalRecords = json.Count()
                }
            };

            return dto;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Customer> Get(string id)
        {
            var json = await this.service.LoadJson();

            var data = json.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }
    }
}
