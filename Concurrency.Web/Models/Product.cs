﻿namespace Concurrency.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //[Timestamp] 1.yol ama best practice degildir
        public byte[] RowVersion { get; set; }
    }
}
