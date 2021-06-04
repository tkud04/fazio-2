using System;
using System.ComponentModel.DataAnnotations;

namespace ass_2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }
        public decimal Price { get; set; }
    }
}