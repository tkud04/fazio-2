using System;
using System.ComponentModel.DataAnnotations;

namespace ass_2.Models
{
    public class Bag
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
    }
}