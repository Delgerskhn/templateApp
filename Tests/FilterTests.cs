using Dma.DatasourceLoader.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using templateApp.Models;
using templateApp.Shared;

namespace Tests
{
    [TestClass]

    public class FilterTests
    {
        [TestMethod]
        public void ShouldApplyBetweenFilterOnDate()
        {
            var data = TestDataGenerator.CreateSampleProjectData();
            var min = new DateTime(2023, 1, 10);
            var max = new DateTime(2023, 2, 5);

            var filter = new BetweenFilter<ProjectDatum>("order_date", (min,max));

            var filterExpression = filter.GetFilterExpression();

            var filteredData = data.AsQueryable().Where((Expression<Func<ProjectDatum, bool>>)filterExpression);

            Assert.AreEqual(2, filteredData.Count());
        }

        [TestMethod]
        public void ShouldApplyAndFilter()
        {
            var data = TestDataGenerator.CreateSampleProjectData();
            var filter = new GreaterThanOrEqualFilter<ProjectDatum>("id", 1003);
            var filter1 = new ContainsFilter<ProjectDatum>("user_name", "Suzuki");

            var andExpr = new AndFilter<ProjectDatum>(filter, filter1).GetFilterExpression();

            var result = data.AsQueryable().Where((Expression<Func<ProjectDatum, bool>>)andExpr);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void ShouldApplyOrFilter() {
            var data = TestDataGenerator.CreateSampleProjectData();
            var filter = new EqualFilter<ProjectDatum>("id", 1003);
            var filter1 = new EqualFilter<ProjectDatum>("id", 1004);
            var filter2 = new EqualFilter<ProjectDatum>("id", 1005);
            var orExpr = new OrFilter<ProjectDatum>(filter, filter1);
            var or1Expr = new OrFilter<ProjectDatum>(orExpr, filter2).GetFilterExpression();
            var result = data.AsQueryable().Where((Expression<Func<ProjectDatum, bool>>)or1Expr);

            Assert.AreEqual(3, result.Count());

        }
    }
}
