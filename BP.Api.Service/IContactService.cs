using BP.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Api.Service
{
    public interface IContactService
    {
        public ContactDVO GetContactById(int Id);
    }
}
