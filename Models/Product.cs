using System;
using System.ComponentModel.DataAnnotations;

namespace ass_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Category { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}