using BP.Api.Models;
using BP.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IContactService contactService;

        public ContactController(IConfiguration Configuration, IContactService ContactService)
        {
            configuration = Configuration;
            contactService = ContactService;
        }

        [HttpGet]
        public String Get()
        {
            return configuration["ReadMe"].ToString();
        }

        [ResponseCache(Duration = 10)]
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return contactService.GetContactById(id);
        }

        [HttpPost]
        public ContactDVO CreateContact(ContactDVO Contact)
        {
            // Create Contact on DB
            return Contact;

            //return contactService.GetContactById(id);
        }
    }
}
