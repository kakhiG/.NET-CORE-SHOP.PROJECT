using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Infrastructure;
using Shop.Domain.Models;
using System;


namespace Shop.Application.Cart
{
    public class GetCustomerInformation
    {
        private ISessionManager _sessionManager;

        public GetCustomerInformation(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public class Response
        {
     
            public string FirstName { get; set; }
          
            public string LastName { get; set; }
        
            public string Email { get; set; }
            
            public string PhoneNumber { get; set; }
       
            public string Address1 { get; set; }
        
            public string Address2 { get; set; }
         
            public string City { get; set; }

            public string PostCode { get; set; }
        }

        public Response Do()
        {
            var stringObject =_session.GetString("customer-info");

            if (String.IsNullOrEmpty(stringObject))
                return null;

            var customerInformation = JsonConvert.DeserializeObject<Shop.Domain.Models.CustomerInformation>(stringObject);

            return new Response
            {
                FirstName = customerInformation.FirstName,
                LastName = customerInformation.LastName,
                Email = customerInformation.Email,
                PhoneNumber = customerInformation.PhoneNumber,
                Address1 = customerInformation.Address1,
                Address2 = customerInformation.Address2,
                City = customerInformation.City,
                PostCode = customerInformation.PostCode,
            };
        }
       

    }
}
