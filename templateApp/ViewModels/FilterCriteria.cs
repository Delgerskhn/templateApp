using Dma.DatasourceLoader.Creator;
using Dma.DatasourceLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using templateApp.Helpers;
using templateApp.Shared;

namespace templateApp.ViewModels
{
    public delegate void ColumnSelectedEventHandler(object sender, EventArgs e);

    public class FilterCriteria
    {
        private List<ColumnMappingConfig> _configs;
        private ColumnMappingConfig _selectedConf;
        private List<FilterOperators> _filters;
        private FilterOperators _operator;
        public FilterOperators Operator => _operator;
        public int OperatorIndex => _filters.IndexOf(_operator);
        public FilterCombinationTypes CombinationType { get; set; }
        public decimal NumValue { get; set; } = 0;
        public (DateTime, DateTime) DateValue { get; set; } = (DateTime.Now, DateTime.Now);
        public string TextValue { get; set; } = "";

        public event ColumnSelectedEventHandler ColumnSelected;
        public ColumnMappingConfig SelectedConf => _selectedConf;
        public int SelectedIndex => _configs.IndexOf(_selectedConf);

        public FilterCriteria(List<ColumnMappingConfig> configs)
        {
            _configs = configs;
        }

        public List<FilterOperators> Filters { get => _filters; }

        public void SelectOperator(int ind)
        {
            if (ind < 0) return;
            _operator = _filters[ind];
        }

        public void SelectColumn(int index)
        {
            var config = _configs[index];
            SelectColumn(config);

        }
        public void SelectColumn(ColumnMappingConfig config)
        {
            _selectedConf = config;
            if(config.DataType == typeof(string))
            {
                _filters = FilterOperators.GetStringFilters();
            }
            if(config.DataType.IsNumeric())
            {
                _filters = FilterOperators.GetNumericFilters();
            }
            if(config.DataType == typeof(DateTime))
            {
                _filters = FilterOperators.GetDateFilters();
            }
            OnColumnSelected(EventArgs.Empty);

        }
        // Helper method to raise the ColumnSelected event
        protected virtual void OnColumnSelected(EventArgs e)
        {
            ColumnSelected?.Invoke(this, e);
        }

        private object GetValue()
        {
            if (_selectedConf.DataType == typeof(string))
                return TextValue;
            if (_selectedConf.DataType == typeof(DateTime))
                return DateValue;
            return _selectedConf.DataType.CastNumber(NumValue);
        }

        public (FilterCombinationTypes, FilterOption) AsFilterOption()
        {
            return (CombinationType, new FilterOption(SelectedConf.FieldName, Operator, GetValue()));
        }
    }
}
