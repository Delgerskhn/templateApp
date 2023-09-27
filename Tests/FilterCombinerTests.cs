using Dma.DatasourceLoader.Creator;
using Dma.DatasourceLoader.Filters;
using Dma.DatasourceLoader.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using templateApp.Models;

namespace Tests
{
    [TestClass]
    public class FilterCombinerTests
    {
        [TestMethod]
        public void ShouldAddAndOption()
        {

            var combiner = new FilterCombiner<ProjectDatum>(new EqualFilter<ProjectDatum>("id", 1003));
            combiner.AddAnd(new EqualFilter<ProjectDatum>("id", 1003));

            Assert.IsInstanceOfType(combiner.Filter, typeof(AndFilter<ProjectDatum>));
        }

        [TestMethod]
        public void ShouldAddOrOption()
        {

            var combiner = new FilterCombiner<ProjectDatum>(new EqualFilter<ProjectDatum>("id", 1003));
            combiner.AddOr(new EqualFilter<ProjectDatum>("id", 1003));

            Assert.IsInstanceOfType(combiner.Filter, typeof(OrFilter<ProjectDatum>));
        }

        [TestMethod]
        public void ShouldThrowException_ifOptionsAreLessThan2()
        {

        }
    }
}
