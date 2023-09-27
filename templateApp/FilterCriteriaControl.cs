using Dma.DatasourceLoader.Creator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using templateApp.Helpers;
using templateApp.Shared;
using templateApp.ViewModels;

namespace templateApp
{
    public partial class FilterCriteriaControl : UserControl
    {
        public event EventHandler RemoveButtonClick;
        private FilterCriteria _criteria;
        public FilterCriteria Criteria => _criteria;

        public FilterCriteriaControl(bool isFirst = false, FilterCriteria criteria = null)
        {
            _criteria = criteria ?? new FilterCriteria(ProjectDatumHelpers.ColumnConfigs);
            
            InitializeComponent();
            _criteria.ColumnSelected += setFilters;
            _criteria.ColumnSelected += setInputType;
            
            InitColumnItems();
            if (criteria == null)
            {
                comboBox1.SelectedIndex = 0;
                _criteria.SelectColumn(0);
                comboBox3.SelectedIndex = 0;
            }

            label1.Visible = isFirst;
            comboBox3.Visible = !isFirst;
            button1.Visible = !isFirst;


            BindState();
        }

        private void BindState()
        {
            if (_criteria != null)
            {
                numericUpDown1.Value = _criteria.NumValue;
                textBox1.Text = _criteria.TextValue;
                dateTimePicker1.Value = _criteria.DateValue.Item1;
                dateTimePicker2.Value = _criteria.DateValue.Item2;
                comboBox1.SelectedIndex = _criteria.SelectedIndex;
                comboBox2.SelectedIndex = _criteria.OperatorIndex;
                comboBox3.SelectedIndex = (int)_criteria.CombinationType;
            }
        }

        private void setFilters(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(_criteria.Filters.Select(f => f.Value).ToArray());
            comboBox2.SelectedIndex = 0;
        }

        private void setInputType(object sender, EventArgs e)
        {
            if(_criteria.SelectedConf.DataType.IsNumeric())
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                textBox1.Visible = false;
                numericUpDown1.Visible = true;
            }
            if(_criteria.SelectedConf.DataType.IsDate())
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                textBox1.Visible = false;
                numericUpDown1.Visible = false;
            }
            if(_criteria.SelectedConf.DataType == typeof(string))
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                textBox1.Visible = true;
                numericUpDown1.Visible = false;
            }
        }

        private void InitColumnItems()
        {
            string[] items = ProjectDatumHelpers.ColumnConfigs.Select(c =>
                            c.Caption
                        ).ToArray();
            comboBox1.Items.AddRange(items);
        }

        private void ColumnSelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected (SelectedIndex is not -1)
            if (comboBox1.SelectedIndex != -1)
            {
                // Get the selected item
                _criteria.SelectColumn(comboBox1.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _criteria.DateValue = (dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            _criteria.DateValue = (dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _criteria.SelectOperator(comboBox2.SelectedIndex);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _criteria.NumValue = numericUpDown1.Value;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _criteria.TextValue = textBox1.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            _criteria.CombinationType = comboBox3.SelectedItem.ToString() == "AND" ? FilterCombinationTypes.AND : FilterCombinationTypes.OR;
        }
    }
}
