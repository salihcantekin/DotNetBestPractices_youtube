using BP.Api.Models;
using BP.Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ContactController> logger;

        public ContactController(IConfiguration Configuration, IContactService ContactService, ILogger<ContactController> logger)
        {
            configuration = Configuration;
            contactService = ContactService;
            this.logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            logger.LogTrace("LogTrace -> Get Method is called");
            logger.LogDebug("LogDebug -> Get Method is called");
            logger.LogInformation("LogInformation -> Get Method is called");
            logger.LogWarning("LogWarning -> Get Method is called");
            logger.LogError("LogError -> Get Method is called");

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
