﻿namespace Customers.Application.Contacts.DTOs
{
    public class UpdateContactDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string PreferredContactMethod { get; set; }
    }
}