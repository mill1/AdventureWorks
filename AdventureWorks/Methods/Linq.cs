using AdventureWorks.Interfaces;
using AdventureWorks.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

/*
 @@: List of Linq methods

https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=netcore-3.0

Aggregate
All
Any
Append
AsEnumerable
Average
Cast
Concat
Contains
Count
DefaultIfEmpty
Distinct
ElementAt
ElementAtOrDefault
Empty
Except
First
FirstOrDefault
GroupBy
GroupJoin
Intersect
Join
Last
LastOrDefault
LongCount
Max
Min
OfType
OrderBy
OrderByDescending
Prepend
Range(Int32, Int32)
Repeat
Reverse
Select
SelectMany
SequenceEqual
Single
SingleOrDefault
Skip
SkipLast
SkipWhile
Sum
Take
TakeLast
TakeWhile
ThenBy
ThenByDescending
ToArray
ToDictionary
ToHashSet
ToList
ToLookup
Union
Where

 */

namespace AdventureWorks.Methods
{
    public class Linq : IMethodsClass
    {
        private readonly IEnumerable<Models.Cassier.Ticket> tickets;
        private readonly IEnumerable<Models.Personel.Cassier> cassiers;
        private Interfaces.IUI ui;

        public Linq() : this(null)
        {
        }

        public Linq(IUI ui)
        {
            SetUI(ui);

            tickets = new Models.Cassier.DataSet().Data;
            cassiers = new Models.Personel.DataSet().Data;
        }

        public void SetUI(IUI ui)
        {
            this.ui = ui;
        }

        [UIOptionAttribute]
        internal void LINQ_Aggregate()
        {
            const string CHOICE_NAME = "n";
            const string CHOICE_SUM = "s";
            const string CHOICE_AVG= "a";

            string[] choices = new string[] { CHOICE_NAME, CHOICE_SUM, CHOICE_AVG};
            string choice = ui.Input("Choose: " +
                                    $"{CHOICE_NAME} (longest Name), " +
                                    $"{CHOICE_SUM} (Sum) or " + 
                                    $"{CHOICE_AVG} (Average):", choices);

            switch (choice)
            {
                case CHOICE_NAME:
                    
                    string longestName = Aggregate1();

                    ui.Output($"The longest name is {longestName}", "Result");
                    break;

                case CHOICE_SUM:
                    int[] i = { 1, 2, 3, 4 };

                    ui.Output($"Sum: {i.Aggregate(0, (result, nextItem) => result + nextItem)}", "Result");
                    break;

                case CHOICE_AVG:
                    IEnumerable<int> numbers = new List<int> { 6, 2, -1, 8, 3 }.Where(n => n > 0);

                    decimal d  = numbers.Aggregate(0, (result, nextItem) => result + nextItem, result => (decimal) result / numbers.Count());

                    var numbersAsText = numbers.Select(n => n.ToString()).Aggregate("", (result, nextItem) => result + ", " + nextItem);

                    ui.Output(String.Format("Average of [{0}] is {1}", numbersAsText , d), "Result");
                    break;

                default:
                    ui.Output("Invalid option", Helper.Constant.APP_NAME);
                    break;
            }
        }

        public string Aggregate1()
        {
            Func<string, string, string> GetLongerName = (longest, next) => next.Length > longest.Length ? next : longest;
            return cassiers.Select(c => c.Name).ToList().Aggregate("", GetLongerName);
        }

        [UIOptionAttribute]
        internal void LINQ_All()
        {
            if (!Int32.TryParse(ui.Input("Number of characters name:", new string[] { "8", "9", "10", "11" }), out int i))
                ui.Output("Invalid input", Helper.Constant.APP_NAME);
            else
                ui.Output(All(i), "Result");
        }

        public string All(int i)
        {
            return String.Format("{0} cassier names are at least {1} chars long",
                                cassiers.All(c => c.Name.Length >= i) ? "All" : "Not all",
                                i);
        }

        [UIOptionAttribute]
        internal void LINQ_Any()
        {
            string input = ui.Input("Minimum price (decimal separator = .)", new string[] { "0.20", "0.25", "0.26", "0.30" }); 

            if (!Decimal.TryParse(input, out decimal minimumPrice))
                ui.Output($"Invalid input. '{input}' could not be parsed.", Helper.Constant.APP_NAME);
            else
            {
                ui.Output(Any(input), "Result");
            }
        }

        public string Any(string input)
        {
            var prices = tickets.SelectMany(t => t.Articles.Select(x => x.Price)).ToList();
            bool sold = prices.Any(p => p < decimal.Parse(input, CultureInfo.InvariantCulture));
            return String.Format("Articles cheaper than {0} {1} been sold.", input, sold ? "have" : "have not");
        }

        [UIOptionAttribute]
        internal void LINQ_Concat()
        {
            var list = Concat();
            Common.Print(ui, list);
        }

        public IEnumerable<string> Concat()
        {
            return cassiers.Select(c => c.Name).Concat(cassiers.Select(c => "Id: " + c.Id));
        }

        [UIOptionAttribute]
        internal void LINQ_ForEach()
        {
            cassiers.ToList().ForEach(c => ui.Output($"{c.Name} ({c.Id})", "Result"));
        }

        [UIOptionAttribute]
        internal void LINQ_GroupJoin()
        {
            var results = cassiers.GroupJoin(tickets,
                            c => c.Id,
                            t => t.ClientCardId,
                            (c, t) => new { cassier = c, tickets = t }
                            );

            Common.Print(ui, results.Select(r => r.cassier.Name + ": # tickets: " + r.tickets.Count()));
        }

        [UIOptionAttribute]
        internal void LINQ_Join()
        {
            var results = tickets.Join(cassiers,
                                        t => t.ClientCardId,
                                        c => c.Id,
                                        (t, c) => new { ticket = t, cassier = c }
                                        );

            Common.Print(ui, results.Select(r => r.cassier.Name + ": Total price: " + r.ticket.TotalPrice));
        }

        [UIOptionAttribute]
        internal void LINQ_Select()
        {
            Dictionary<string, Models.Personel.Cassier> dict = cassiers.ToDictionary(c => c.Id);
            var anonType = dict.Select(c => new { CassierName = c.Value.Name, EmailID = c.Value.Name + "@hyves.nl" });
            Common.Print(ui, anonType.Select(c => c.CassierName));
        }

        [UIOptionAttribute]
        internal void LINQ_SelectMany()
        {
            IEnumerable<string> AllSoldArticleNames = tickets.SelectMany(t => t.Articles.Select(x => x.Name));
            Common.Print(ui, AllSoldArticleNames);
        }
    }
}
