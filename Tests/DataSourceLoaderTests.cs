using Dma.DatasourceLoader;
using Dma.DatasourceLoader.Creator;
using Dma.DatasourceLoader.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using templateApp.Shared;

namespace Tests
{
    [TestClass]
    public class DataSourceLoaderTests
    {
        [TestMethod]
        public void ShouldLoadFilters()
        {
            var data = TestDataGenerator.CreateSampleProjectData();

            var options = new DataSourceLoadOptions()
            {
                Filters = new List<FilterOption>() { new FilterOption("id", FilterOperators.Gte, 1003) }
            };

            var result = DataSourceLoader.Load(data.AsQueryable(), options);

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void ShouldLoadCombinedFilters()
        {
            var data = TestDataGenerator.CreateSampleProjectData();

            var options = new List<(FilterCombinationTypes, FilterOption)>() {
                (FilterCombinationTypes.AND, new FilterOption("id", FilterOperators.Eq, 1003)),
                (FilterCombinationTypes.OR, new FilterOption("id", FilterOperators.Eq, 1004))
            };

            var result = DataSourceLoader.ApplyCombinedFilters(data.AsQueryable(), options);

            Assert.AreEqual(2, result.Count());

        }
    }
}
