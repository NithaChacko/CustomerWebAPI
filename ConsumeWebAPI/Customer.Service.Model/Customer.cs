using System;
using System.Net;
using System.Text.Json.Serialization;

namespace Customer.Service.Model
{
    public class Customer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Phone { get; set; } = String.Empty;

        public string Age { get; set; } = String.Empty;
    }

    
}
