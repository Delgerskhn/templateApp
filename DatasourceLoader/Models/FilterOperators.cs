using System;
using System.Collections.Generic;

namespace Dma.DatasourceLoader.Models
{
    public class FilterOperators : IEquatable<FilterOperators>
    {
        private string _value;
        public string Value => _value;
        
        public static readonly FilterOperators Eq = new FilterOperators("Equal");
        public static readonly FilterOperators Between = new FilterOperators("Between");
        public static readonly FilterOperators NotEq = new FilterOperators("Not equal");
        public static readonly FilterOperators Contains = new FilterOperators("Contains");
        public static readonly FilterOperators NotContains = new FilterOperators("Not contains");
        public static readonly FilterOperators StartsWith = new FilterOperators("Starts with");
        public static readonly FilterOperators EndsWith = new FilterOperators("Ends with");
        public static readonly FilterOperators In = new FilterOperators("In");
        public static readonly FilterOperators NotIn = new FilterOperators("Not in");
        public static readonly FilterOperators Gt = new FilterOperators(">");
        public static readonly FilterOperators Gte = new FilterOperators(">=");
        public static readonly FilterOperators Lt = new FilterOperators("<");
        public static readonly FilterOperators Lte = new FilterOperators("<=");
        public static readonly FilterOperators Null = new FilterOperators("Null");
        public static readonly FilterOperators NotNull = new FilterOperators("Not null");

        public static readonly FilterOperators[] ComplexFilters = new FilterOperators[]
        {
            In, NotIn
        };

        public static List<FilterOperators> GetNumericFilters()
        {
            return new List<FilterOperators>
            {
                Eq,
                NotEq,
                Gt,
                Gte,
                Lt,
                Lte
            };
        }

        public static List<FilterOperators> GetStringFilters()
        {
            return new List<FilterOperators>
            {
                Contains, StartsWith, EndsWith
            };
        }

        public static List<FilterOperators> GetDateFilters()
        {
            return new List<FilterOperators>
        {
                Between
        };
        }

        private FilterOperators(string value) {
            _value = value;
        }

        public static implicit operator string(FilterOperators op) => op.Value;
        //public static implicit operator FilterOperators(string op) => new(op);

        public bool Equals(FilterOperators other)
        {
            return other?.Value == _value;
        }
    }
}
