﻿namespace Butler.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public Unit Unit { get; set; }
    }
}