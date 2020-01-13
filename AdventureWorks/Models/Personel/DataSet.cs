using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureWorks.Models.Personel
{
    public class DataSet
    {
        public IEnumerable<Cassier> Data { get; set; } = new Cassier[]
        {
            new Cassier()
            {
                Id= "98765415-154785",
                Name = "Pooja Bradford"
            },
            new Cassier()
            {
                Id= "51466151-145224",
                Name = "Abul Travis"
            },
            new Cassier()
            {
                Id= "62147521-341597",
                Name = "Ned Mckenzie"
            },
            new Cassier()
            {
                Id= "35412541-354765",
                Name = "Star Park"
            },
            new Cassier()
            {
                Id= "12346798-715561",
                Name = "Kerys Couch"
            },
            new Cassier()
            {
                Id= "48942146-124654",
                Name = "Lynden Britton III"
            },
            new Cassier()
            {
                Id= "85413214-258465",
                Name = "Kier Alston"
            },
            new Cassier()
            {
                Id= "435413214-258464",
                Name = "Sonnie Miranda"
            },
            new Cassier()
            {
                Id= "24413214-2584555",
                Name = "Roma Frederick"
            }
        };
    }
}
