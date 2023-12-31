﻿
using System;
using System.Collections.Generic;

namespace Dma.DatasourceLoader.Models
{
    public class SampleData
    {
        public int IntProperty { get; set; }
        public bool BooleanProperty { get; set; }
        public DateTime DateProperty { get; set; }
        public SampleNestedData NestedData { get; set; } 
        public string StrProperty { get; set; } = "";
        //public List<string> StrCollection { get; set; } = new();
        public List<SampleNestedData> NestedCollection { get; set; } = new List<SampleNestedData>();
        //public List<DateTime> DateCollection { get;  set; } = new();
        //public List<int> NumericCollection { get;  set; } = new();
        public int Id { get; set; }
    }
    public class DeepNestedData
    {
        public int Id { get; set; }
        public string StrProperty { get; set; } = default;
        public int OwnerId { get; set; }
        public SampleNestedData Owner { get; set; } = default;
    }
    public class SampleNestedData
    {
        public int Id { get; set; }
        public int IntProperty { get; set; }
        public DateTime DateProperty { get; set; }
        public string StrProperty { get; set; } = "";
        public DeepNestedData DeepNestedData { get; set; } = default;
        public int OwnerId { get; set; }
        public int ParentId { get; set; }
        public SampleData Owner { get; set; } = default;
        public SampleData Parent { get; set; } = default;
    }
}
