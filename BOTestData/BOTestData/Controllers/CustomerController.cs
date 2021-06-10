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
        private readonly ILoadJSONService<Customer> _service;
        private readonly ILoadJSONService<CustomerLookup> _lookupService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILoadJSONService<Customer> service, ILoadJSONService<CustomerLookup> lookupService, ILogger<CustomerController> logger)
        {
            _service = service;
            _lookupService = lookupService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<CustomerResponse> Get([FromQuery] CustomerQueryParams query)
        {
            var json = await this._service.LoadJson();

            var data = json.Where(x => string.IsNullOrEmpty(query.CustomerId) ? true : x.Id.Contains(query.CustomerId))
                                    .Where(x => string.IsNullOrEmpty(query.LastName) ? true : x.LastName.ToLower().Contains(query.LastName.ToLower()))
                                    .Where(x => string.IsNullOrEmpty(query.FirstName) ? true : x.FirstName.ToLower().Contains(query.FirstName.ToLower()))
                                    .Where(x => string.IsNullOrEmpty(query.MobileNumber) ? true : x.MobileNumber.Contains(query.MobileNumber))
                                    .Where(x => string.IsNullOrEmpty(query.Email) ? true : x.Email.ToLower().Contains(query.Email.ToLower()))
                                    .Where(x => string.IsNullOrEmpty(query.PostalCode) ? true : x.PostalCode.Replace(" ", string.Empty).Contains(query.PostalCode.Replace(" ", string.Empty)))
                                    .Where(x => string.IsNullOrEmpty(query.LandlineNumber) ? true : x.LandlineNumber.Contains(query.LandlineNumber))
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
            var json = await this._service.LoadJson();

            var data = json.Where(x => x.Id == id).FirstOrDefault();

            return data;
        }

        [HttpGet]
        [Route("lookup")]
        public async Task<CustomerLookup> Lookup()
        {
            var json = await this._lookupService.LoadLookupJson();

            return json;
        }
    }
}
