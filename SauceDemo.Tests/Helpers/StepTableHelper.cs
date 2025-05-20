namespace SauceDemo.Tests.Helpers
{
    using TechTalk.SpecFlow;

    public static class StepTableHelper
    {
        public static List<string> GetProductNamesFromTableOrdered(Table table)
        {
            return table.Rows
                .Select(row => new
                {
                    Name = row["Product"],
                    Order = int.Parse(row["Order"]),
                })
                .OrderBy(p => p.Order)
                .Select(p => p.Name)
                .ToList();
        }

        public static List<string> GetProductNamesFromTable(Table table)
        {
            return table.Rows.Select(row => row["Product"]).ToList();
        }
    }
}