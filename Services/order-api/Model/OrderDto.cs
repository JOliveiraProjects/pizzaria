using System;

namespace Pizzaria.OrderApi.Model
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public int TotalItems { get; set; }
        public DateTime DateCreated { get; set; }
    }
}