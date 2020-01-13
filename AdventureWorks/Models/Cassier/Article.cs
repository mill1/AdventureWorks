using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Models.Cassier
{
    public class Article
    {
        public Article() {
        }

        public Article(string name) {
            Name = name;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal PriceTotal => Price * Count;
    }
}
