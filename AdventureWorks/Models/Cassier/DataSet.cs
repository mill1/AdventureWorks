using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Models.Cassier
{
    public class DataSet
    {
        public IEnumerable<Ticket> Data { get; set; } = new Ticket[]
        {
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-20 8:30"),
                CassierId = "AAGTV12",
                ClientCardId = "98765415-154785",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Drinkontbijt",
                        Count = 1,
                        Price = 3.95M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-20 9:03"),
                CassierId = "BHGTV65",
                ClientCardId = "51466151-145224",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Volkorenbrood",
                        Count = 5,
                        Price = 2.00M
                    },
                    new Article()
                    {
                        Name = "Halfvolle Melk",
                        Count = 3,
                        Price = 0.60M
                    },
                    new Article()
                    {
                        Name = "Pindakaas",
                        Count = 1,
                        Price = 1.60M
                    },
                    new Article()
                    {
                        Name = "Suiker 1kg",
                        Count = 1,
                        Price = 0.75M
                    },
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-20 9:38"),
                CassierId = "AAGTV12",
                ClientCardId = "62147521-341597",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Schultenbrau 0.5l",
                        Count = 6,
                        Price = 0.35M
                    },
                    new Article()
                    {
                        Name = "Biscuits",
                        Count = 2,
                        Price = 0.25M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-20 12:03"),
                CassierId = "BHGTV65",
                ClientCardId = "35412541-354765",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Paprika chips",
                        Count = 1,
                        Price = 0.95M
                    },
                    new Article()
                    {
                        Name = "Cola 1.5l",
                        Count = 1,
                        Price = 1.35M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-20 18:30"),
                CassierId = "AAGTV12",
                ClientCardId = "98765415-154785",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Pizza Salami",
                        Count = 1,
                        Price = 4.25M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-21 8:27"),
                CassierId = "BHGTV65",
                ClientCardId = "98765415-154785",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Drink ontbijt",
                        Count = 1,
                        Price = 3.95M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-21 9:17"),
                CassierId = "BHGTV65",
                ClientCardId = "12346798-715561",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Cornflakes Family pack",
                        Count = 1,
                        Price = 3.41M
                    },
                    new Article()
                    {
                        Name = "Volle Melk",
                        Count = 5,
                        Price = 0.75M
                    },
                    new Article()
                    {
                        Name = "Eieren 12st",
                        Count = 1,
                        Price = 3.26M
                    },
                    new Article()
                    {
                        Name = "Bloem",
                        Count = 1,
                        Price = 0.75M
                    },
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-21 9:41"),
                CassierId = "AAGTV12",
                ClientCardId = "62147521-341597",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Schultenbrau 0.5l",
                        Count = 6,
                        Price = 0.35M
                    },
                    new Article()
                    {
                        Name = "Half wit brood",
                        Count = 1,
                        Price = 0.95M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-21 12:11"),
                CassierId = "BHGTV65",
                ClientCardId = "48942146-124654",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Frikadelbroodje",
                        Count = 1,
                        Price = 0.85M
                    },
                    new Article()
                    {
                        Name = "Sinas 1.5l",
                        Count = 1,
                        Price = 1.35M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-22 8:34"),
                CassierId = "AAGTV12",
                ClientCardId = "98765415-154785",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Drink ontbijt",
                        Count = 1,
                        Price = 3.95M
                    }
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-22 9:56"),
                CassierId = "AAGTV12",
                ClientCardId = "62147521-341597",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Schultenbrau 0.5l",
                        Count = 8,
                        Price = 0.35M
                    },
                }
            },
            new Ticket()
            {
                CheckoutTime = DateTime.Parse("2018-03-20 9:07"),
                CassierId = "BHGTV65",
                ClientCardId = "85413214-258465",
                Articles = new Article[]
                {
                    new Article()
                    {
                        Name = "Volkoren brood",
                        Count = 3,
                        Price = 2.00M
                    },
                    new Article()
                    {
                        Name = "Halfvolle Melk",
                        Count = 3,
                        Price = 0.60M
                    },
                    new Article()
                    {
                        Name = "Hagelslag",
                        Count = 1,
                        Price = 0.79M
                    },
                    new Article()
                    {
                        Name = "Cornflakes Family pack",
                        Count = 1,
                        Price = 3.41M
                    }
                }
            },
        };
    }
}
